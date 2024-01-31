using ServicoDePagamento.Data;
using ServicoDePagamento.Models;
using ServicoDePagamento.ViewModel.TransacaoVM;

namespace ServicoDePagamento.Interface
{
    public interface ITransacaoRepository : IUnitOfWork
    {
        Task<List<ListarTransacao>> ListarTudo();

        Task<Transacao> ListarPorId(int Id);

        Task<Transacao> NovaTransacao(Transacao transacao);

        Task<bool> RemoverTransacao(int Id);

        Task<Cliente> ValidarCliente(int Id);

    }
}
