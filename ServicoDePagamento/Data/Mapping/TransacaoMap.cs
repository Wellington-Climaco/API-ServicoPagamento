using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServicoDePagamento.Models;

namespace ServicoDePagamento.Data.Mapping
{
    public class TransacaoMap : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.ToTable("Transacao");

            builder.HasKey(x=>x.Id);

            builder.Property(x=>x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x => x.Valor).IsRequired().HasColumnName("Valor").HasColumnType("MONEY");

            builder.Property(x => x.Descricao).IsRequired().HasColumnName("Descricao").HasColumnType("VARCHAR").HasMaxLength(100);

            builder.Property(x => x.MetodoPagamento).IsRequired().HasColumnName("MetodoPagamento").HasColumnType("VARCHAR").HasMaxLength(50);

            builder.Property(x => x.NumeroCartao).IsRequired().HasColumnName("NumeroCartao").HasColumnType("VARCHAR").HasMaxLength(50);

            builder.Property(x => x.ValidadeCartao).IsRequired().HasColumnName("ValidadeCartao").HasColumnType("VARCHAR").HasMaxLength(50);

            builder.Property(x => x.CVV).IsRequired().HasColumnName("CCV").HasColumnType("VARCHAR").HasMaxLength(50);

            builder.HasOne(x=>x.Cliente).WithMany(x=>x.Transacoes).HasConstraintName("FK_Transacao_Cliente").OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Recebivel).WithOne(x=>x.Transacao).HasForeignKey<Recebiveis>(x => x.TransacaoId).HasConstraintName("FK_Transacao_Recebivel").OnDelete(DeleteBehavior.Cascade);

        }
    }
}
