using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YB.Domain.Models;

namespace YB.Data.Maps
{
    internal class AgendamentoMap : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Data).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.Horario).IsRequired().HasColumnType("datetime");

            builder.HasOne(x => x.Servico).WithMany(s => s.Agendamentos).HasForeignKey(f => f.ServicoId);
            builder.HasOne(x => x.Cliente).WithMany(s => s.Agendamentos).HasForeignKey(f => f.ClienteId);

            builder.ToTable("Agendamentos");
        }
    }
}