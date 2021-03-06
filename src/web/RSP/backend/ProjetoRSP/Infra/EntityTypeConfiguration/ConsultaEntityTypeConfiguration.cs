using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoRSP.Models;

namespace ProjetoRSP.Infra.EntityTypeConfiguration
{
    public class ConsultaEntityTypeConfiguration : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.AddDefaultPrimaryKey();
            builder.HasOne(x => x.Paciente).WithOne().HasForeignKey<Consulta>(x => x.PacienteId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Profissional).WithOne().HasForeignKey<Consulta>(x => x.ProfissionalId).OnDelete(DeleteBehavior.Restrict);
            builder.ToTable("Consultas");
        }
    }
}
