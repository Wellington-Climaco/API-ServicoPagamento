using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServicoDePagamento.Models;

namespace ServicoDePagamento.Data.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x => x.Nome).IsRequired().HasColumnName("Nome").HasColumnType("VARCHAR").HasMaxLength(100);

            builder.Property(x => x.Documento).IsRequired().HasColumnName("Documento").HasColumnType("VARCHAR").HasMaxLength(100);

            builder.Property(x => x.Saldo).IsRequired().HasColumnName("Saldo").HasColumnType("FLOAT");

            builder.Property(x => x.Cep).HasColumnName("CEP").HasColumnType("VARCHAR").HasMaxLength(100);

            builder.HasIndex(x => x.Documento,"IX_Cliente_Documento").IsUnique();

            
        }
    }
}
