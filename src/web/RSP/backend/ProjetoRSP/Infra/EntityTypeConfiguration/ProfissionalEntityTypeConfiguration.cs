using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoRSP.Models;

namespace ProjetoRSP.Infra.EntityTypeConfiguration
{
    public class ProfissionalEntityTypeConfiguration : IEntityTypeConfiguration<Profissional>
    {
        public void Configure(EntityTypeBuilder<Profissional> builder)
        {
            builder.AddDefaultPrimaryKey();
            builder.HasIndex(x => x.Cnpj).IsUnique();
            builder.HasOne(x => x.Pessoa).WithOne().HasForeignKey<Profissional>(x => x.PessoaId);
            builder.ToTable("Profissionais");
        }
    }
}
