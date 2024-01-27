using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServicoDePagamento.Models;

namespace ServicoDePagamento.Data.Mapping
{
    public class RecebiveisMap : IEntityTypeConfiguration<Recebiveis>
    {
        public void Configure(EntityTypeBuilder<Recebiveis> builder)
        {
            builder.ToTable("Recebiveis");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x=>x.status).IsRequired().HasColumnName("Status").HasColumnType("VARCHAR").HasMaxLength(100);

            builder.Property(x => x.DataPagamento).IsRequired().HasColumnName("DataPagamento").HasColumnType("SMALLDATETIME").HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.Taxa).IsRequired().HasColumnName("Taxa").HasColumnType("FLOAT").HasMaxLength(100);

            builder.HasOne(x => x.Cliente).WithMany(x => x.Recebiveis).HasConstraintName("FK_Recebiveis_Cliente").OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Transacao).WithOne(x=>x.Recebivel).HasForeignKey<Recebiveis>(x => x.TransacaoId).HasConstraintName("FK_Recebiveis_Transacao").OnDelete(DeleteBehavior.Cascade);
        }
    }
}
