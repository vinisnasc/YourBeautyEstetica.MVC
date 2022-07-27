using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YB.Domain.Models;

namespace YB.Data.Maps
{
    internal class ServicoMap : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NomeServico).IsRequired().HasColumnType("varchar(200)");
            builder.Property(x => x.TempoNecessario).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.NomeServico).IsRequired();

            builder.HasOne(x => x.Funcionario).WithMany(s => s.Servicos).HasForeignKey(f => f.FuncionarioId);

            builder.ToTable("Servicos");
        }
    }
}