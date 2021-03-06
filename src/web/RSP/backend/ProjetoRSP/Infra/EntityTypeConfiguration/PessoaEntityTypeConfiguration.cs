using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoRSP.Models;

namespace ProjetoRSP.Infra.EntityTypeConfiguration
{
    public class PessoaEntityTypeConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.AddDefaultPrimaryKey();
            builder.Property(x => x.Cpf).HasMaxLength(11);
            builder.HasIndex(x => x.Cpf).IsUnique();
            builder.Property(x => x.Rg).HasMaxLength(20);
            builder.HasIndex(x => x.Rg).IsUnique();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.ToTable("Pessoas");
        }
    }
}
