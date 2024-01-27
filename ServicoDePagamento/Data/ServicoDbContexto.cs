using Microsoft.EntityFrameworkCore;
using ServicoDePagamento.Data.Mapping;
using ServicoDePagamento.Models;

namespace ServicoDePagamento.Data
{
    public class ServicoDbContexto : DbContext
    {
        public ServicoDbContexto(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Recebiveis> Recebiveis { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new TransacaoMap());
            modelBuilder.ApplyConfiguration(new RecebiveisMap());
        }

    }
}
