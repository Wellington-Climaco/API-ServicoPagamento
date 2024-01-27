using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ServicoDePagamento.Data;
using ServicoDePagamento.Interface;
using ServicoDePagamento.Models;

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
            await _contexto.SaveChangesAsync();
            return transacao;
        }

        public async Task<Transacao> ListarPorId(int Id)
        {
            var transacao = await _contexto.Transacoes.AsNoTracking().FirstOrDefaultAsync(x=> x.Id == Id);
            return transacao;
        }

        public Task<List<Transacao>> ListarTudo()
        {
            return _contexto.Transacoes.AsNoTracking().ToListAsync();            
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
    }
}
