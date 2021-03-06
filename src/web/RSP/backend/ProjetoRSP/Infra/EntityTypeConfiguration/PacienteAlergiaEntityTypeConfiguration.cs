using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoRSP.Models;

namespace ProjetoRSP.Infra.EntityTypeConfiguration
{
    public class PacienteAlergiaEntityTypeConfiguration : IEntityTypeConfiguration<PacienteAlergia>
    {
        public void Configure(EntityTypeBuilder<PacienteAlergia> builder)
        {
            builder.HasKey(pa => new
            {
                pa.AlergiaId,
                pa.PacienteId
            });
            builder.HasOne(pa => pa.Paciente).WithMany(p => p.PacienteAlergias).HasForeignKey(pa => pa.PacienteId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(pa => pa.Alergia).WithMany().HasForeignKey(p => p.AlergiaId);
            builder.ToTable("PacienteAlergias");
        }
    }
}
