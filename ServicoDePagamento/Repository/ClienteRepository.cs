using Microsoft.EntityFrameworkCore;
using ServicoDePagamento.Data;
using ServicoDePagamento.Interface;
using ServicoDePagamento.Models;
using static ServicoDePagamento.Enum.Enumerador;

namespace ServicoDePagamento.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ServicoDbContexto _contexto;
        public ClienteRepository(ServicoDbContexto contexto)
        {
            _contexto = contexto;
        }


        public async Task<IEnumerable<Cliente>> BuscarTodos()
        {
            return await _contexto.Clientes.ToListAsync();
        }

        public async Task<Cliente> BuscarPorId(int id)
        {
            var cliente = await _contexto.Clientes.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id);
            return cliente;
        }

        public async Task<Cliente> Adicionar(Cliente cliente)
        {
            await _contexto.Clientes.AddAsync(cliente);
            return cliente;
        }

        public async Task<Cliente> Atualizar(Cliente cliente)
        {
            _contexto.Clientes.Update(cliente);
            return cliente;
        }
               
        public async Task<string> Remover(int Id)
        {
            var cliente = await _contexto.Clientes.FirstOrDefaultAsync(x => x.Id == Id);
            _contexto.Remove(cliente);
            return "Excluido com sucesso";
        }

        public async Task<bool> Commit()
        {
            return await _contexto.SaveChangesAsync() > 0;
        }

        public Task RollBack()
        {
            return Task.CompletedTask;
        }

        public async Task<double> ConsultarSaldoDisponivel(int Id)
        {
            var cliente = await _contexto.Clientes.FirstOrDefaultAsync(x=>x.Id==Id);
            return cliente.Saldo;        
        }

        public async Task<double> ConsultarSaldoAReceber(int Id)
        {
            var cliente = await _contexto.Clientes.FirstOrDefaultAsync(x => x.Id == Id);
            var AReceber = await _contexto.Transacoes.Where(x => x.MetodoPagamento == EMetodoPagamento.CartaoCredito).Where(x=>x.Cliente==cliente).Select(x => x.Valor).SumAsync();
            return AReceber;
        }

        public async Task<bool> ValidarCliente(string Documento)
        {
            var cliente = await _contexto.Clientes.FirstOrDefaultAsync(x=>x.Documento ==Documento);
            if (cliente==null)
            {
                return false;
            }
            return true;
        }
    }
}
