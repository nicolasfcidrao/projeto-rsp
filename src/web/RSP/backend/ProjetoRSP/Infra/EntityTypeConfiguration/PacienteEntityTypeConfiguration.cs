using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoRSP.Models;

namespace ProjetoRSP.Infra.EntityTypeConfiguration
{
    public class PacienteEntityTypeConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.AddDefaultPrimaryKey();
            builder.Property(x => x.Cep).HasMaxLength(8);
            builder.HasOne(x => x.Pessoa).WithOne().HasForeignKey<Paciente>(x => x.PessoaId);
            builder.ToTable("Pacientes");
        }
    }
}
