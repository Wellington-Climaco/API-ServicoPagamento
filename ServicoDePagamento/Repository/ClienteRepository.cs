using Microsoft.EntityFrameworkCore;
using ServicoDePagamento.Data;
using ServicoDePagamento.Interface;
using ServicoDePagamento.Models;

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
            await _contexto.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> Atualizar(Cliente cliente)
        {
            _contexto.Clientes.Update(cliente);
            await _contexto.SaveChangesAsync();
            return cliente;
        }
               
        public async Task<string> Remover(int Id)
        {
            var cliente = await _contexto.Clientes.FirstOrDefaultAsync(x => x.Id == Id);
            _contexto.Remove(cliente);
            await _contexto.SaveChangesAsync();
            return "Excluido com sucesso";
        }
    }
}
