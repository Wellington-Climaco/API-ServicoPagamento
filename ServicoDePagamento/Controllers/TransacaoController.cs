using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicoDePagamento.Data;
using ServicoDePagamento.Interface;
using ServicoDePagamento.Models;
using ServicoDePagamento.ViewModel.TransacaoVM;

namespace ServicoDePagamento.Controllers
{
    [ApiController]
    [Route("v1/transacao/")]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IRecebivelRepository _recebivelRepository;
        public TransacaoController(ITransacaoRepository transacaoRepository,IRecebivelRepository recebivelRepository)
        {
            _transacaoRepository = transacaoRepository;
            _recebivelRepository = recebivelRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> CriarTransacao([FromBody] CriarTransacaoViewModel transacaoViewModel)
        {
            try
            {
                var identificacao = await _transacaoRepository.ValidarCliente(transacaoViewModel.ClienteId);
                if (identificacao == null) return NotFound("Cliente não encontrado");
                
                var transacao = new Transacao
                {
                    Descricao = transacaoViewModel.Descricao,
                    Valor = transacaoViewModel.Valor,
                    NomeDonoCartao = transacaoViewModel.NomeDonoCartao,
                    MetodoPagamento = transacaoViewModel.MetodoPagamento,
                    NumeroCartao = transacaoViewModel.NumeroCartao,
                    ValidadeCartao = transacaoViewModel.ValidadeCartao,
                    CVV = transacaoViewModel.CVV,
                    Cliente = identificacao
                };

                await _transacaoRepository.NovaTransacao(transacao);
                await _transacaoRepository.Commit();

                var Status = "Pago";
                var taxa = 0.03;
                var dataPagamento = DateTime.Now;
                if (transacao.MetodoPagamento == Enum.Enumerador.EMetodoPagamento.CartaoCredito)
                {
                    taxa = 0.05;
                    dataPagamento = dataPagamento.AddDays(30);
                    Status = "Aguardando Pagamento";
                }

                var Recebivel = new Recebiveis { Cliente = identificacao,status = Status,DataPagamento=dataPagamento.Date,Taxa=taxa,Transacao=transacao,TransacaoId=transacao.Id};
                await _recebivelRepository.Criar(Recebivel);

                var desconto = transacao.Valor - (transacao.Valor * taxa);
                identificacao.Saldo += desconto;

                await _transacaoRepository.Commit();

                return Ok(transacao);
            }
            catch (DbUpdateException ex) 
            { 
                return StatusCode(500, "Não foi possivel criar transacao");            
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Erro interno");
            }
        }

        [HttpGet("listarTudo")]
        public async Task<IActionResult> ListarTodasTransacoes()
        {
            try
            {
                var transacoes = await _transacaoRepository.ListarTudo();
                if (transacoes == null) return NotFound("Nao existem transacoes!!");
                return Ok(transacoes);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, "Erro interno no servidor");
            }
        }

        [HttpGet("listar/{Id:int}")]
        public async Task<IActionResult> ListarPorId([FromRoute] int Id)
        {
            try
            {
                var transacao = await _transacaoRepository.ListarPorId(Id);
                if (transacao == null) return NotFound("Transação não encontrada!!");
                return Ok(transacao);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno no servidor");
            }
        }

        [HttpDelete("Remover/{Id:int}")]
        public async Task<IActionResult> RemoverTransacao([FromRoute] int Id)
        {
            try
            {
                var transacao = await _transacaoRepository.RemoverTransacao(Id);
                if (transacao == false) return NotFound("Transação não encontrada");
                await _transacaoRepository.Commit();
                return Ok("Transacao removida com sucesso");
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Não foi possivel remover transacao");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno");
            }
        }

    }
}
