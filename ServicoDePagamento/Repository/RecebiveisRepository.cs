using Microsoft.EntityFrameworkCore;
using ServicoDePagamento.Data;
using ServicoDePagamento.Interface;
using ServicoDePagamento.Models;
using ServicoDePagamento.ViewModel.Recebivel;
using System.Net.NetworkInformation;
using static ServicoDePagamento.Enum.Enumerador;

namespace ServicoDePagamento.Repository
{
    public class RecebiveisRepository : IRecebivelRepository
    {
        private readonly ServicoDbContexto _DBContexto;
        public RecebiveisRepository(ServicoDbContexto contextoDb)
        {
            _DBContexto = contextoDb;
        }

        public Task<Recebiveis> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Recebiveis>> BuscarTodos()
        {
            return await _DBContexto.Recebiveis.ToListAsync();
            
        }

        public async Task<Recebiveis> Criar(Recebiveis Recibo)
        {
            var recebivel = await _DBContexto.Recebiveis.AddAsync(Recibo);
            return Recibo;
        }

        public Task<string> Remover(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente> ValidarCliente(int Id)
        {
            var cliente = await _DBContexto.Clientes.FirstOrDefaultAsync(x=> x.Id == Id);
            return cliente;
        }

        public async Task<Transacao> ValidarTransacao(int Id)
        {
            var transacao = await _DBContexto.Transacoes.FirstOrDefaultAsync(x=> x.Id == Id);
            return transacao;
        }

        public async Task<bool> Save()
        {
            var save = await _DBContexto.SaveChangesAsync();            
            return true;
        }
    }
}
