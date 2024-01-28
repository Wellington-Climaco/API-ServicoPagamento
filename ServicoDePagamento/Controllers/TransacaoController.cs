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
        public TransacaoController(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
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
                    MetodoPagamento = transacaoViewModel.MetodoPagamento,
                    NumeroCartao = transacaoViewModel.NumeroCartao,
                    ValidadeCartao = transacaoViewModel.ValidadeCartao,
                    CVV = transacaoViewModel.CVV,
                    Cliente = identificacao
                };
                await _transacaoRepository.NovaTransacao(transacao);
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
            var transacao = await _transacaoRepository.ListarPorId(Id);
            if (transacao == null) return NotFound("Transação não encontrada!!");
            return Ok(transacao);
        }

        [HttpDelete("Remover/{Id:int}")]
        public async Task<IActionResult> RemoverTransacao([FromRoute] int Id)
        {
            var transacao = await _transacaoRepository.RemoverTransacao(Id);
            if (transacao == false) return NotFound("Transação não encontrada");
            return Ok("Transacao removida com sucesso");
        }

    }
}
