using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YB.Domain.Models;

namespace YB.Data.Maps
{
    internal class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar(200)");
            builder.Property(x => x.Email).IsRequired().HasColumnType("varchar(200)");
            builder.Property(x => x.Telefone).IsRequired().HasColumnType("varchar(20)");

            builder.ToTable("Funcionarios");
        }
    }
}