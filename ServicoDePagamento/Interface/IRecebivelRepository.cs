using ServicoDePagamento.Models;
using ServicoDePagamento.ViewModel.Recebivel;

namespace ServicoDePagamento.Interface
{
    public interface IRecebivelRepository
    {
        Task<IEnumerable<Recebiveis>> BuscarTodos();

        Task<Recebiveis> BuscarPorId(int id);

        Task<Recebiveis> Criar(Recebiveis Recibo);

        Task<Transacao> ValidarTransacao(int Id);

        Task<Cliente> ValidarCliente(int Id);

        Task<string> Remover(int Id);

        Task<bool> Save();


    }
}
