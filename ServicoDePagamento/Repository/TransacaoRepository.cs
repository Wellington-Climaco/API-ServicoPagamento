using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ServicoDePagamento.Data;
using ServicoDePagamento.Interface;
using ServicoDePagamento.Models;
using ServicoDePagamento.ViewModel.TransacaoVM;

namespace ServicoDePagamento.Repository
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly ServicoDbContexto _contexto;
        public TransacaoRepository(ServicoDbContexto dbContexto)
        {
            _contexto = dbContexto;
        }

        public async Task<Transacao> NovaTransacao(Transacao transacao)
        {
            await _contexto.Transacoes.AddAsync(transacao);
            return transacao;
        }

        public async Task<Transacao> ListarPorId(int Id)
        {
            var transacao = await _contexto.Transacoes.AsNoTracking().FirstOrDefaultAsync(x=> x.Id == Id);
            return transacao;
        }

        public Task<List<ListarTransacao>> ListarTudo()
        {
            return _contexto.Transacoes.AsNoTracking().Include(x => x.Cliente).Select(x=>new ListarTransacao { Id=x.Id,Valor=x.Valor,Descricao=x.Descricao,
            MetodoPagamento=x.MetodoPagamento,NumeroCartao=x.NumeroCartao,ValidadeCartao=x.ValidadeCartao,CVV=x.CVV,Cliente=x.Cliente.Nome,NomeDonoCartao=x.NomeDonoCartao}).ToListAsync();            
        }

        public async Task<bool> RemoverTransacao(int Id)
        {
            var transacao = await _contexto.Transacoes.FirstOrDefaultAsync(x=> x.Id == Id);
            _contexto.Remove(transacao);
            return true;
        }

        public async Task<Cliente> ValidarCliente(int Id)
        {
            var identificacao = await _contexto.Clientes.FirstOrDefaultAsync(x=> x.Id == Id);            
            return identificacao;
        }

        public async Task<bool> Commit()
        {
            return await _contexto.SaveChangesAsync() > 0;
            
        }

        public Task RollBack()
        {
            return Task.CompletedTask;
        }
    }
}
