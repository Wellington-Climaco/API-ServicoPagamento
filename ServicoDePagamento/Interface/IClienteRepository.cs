using ServicoDePagamento.Models;

namespace ServicoDePagamento.Interface
{
    public interface IClienteRepository : IUnitOfWork
    {
        Task<IEnumerable<Cliente>> BuscarTodos();

        Task<Cliente> BuscarPorId(int id);

        Task<Cliente> Adicionar(Cliente cliente);

        Task<Cliente> Atualizar(Cliente cliente);

        Task<string> Remover(int Id);

        Task<double> ConsultarSaldoDisponivel(int Id);

        Task<double> ConsultarSaldoAReceber(int Id);





    }
}
