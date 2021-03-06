using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoRSP.Models;

namespace ProjetoRSP.Infra.EntityTypeConfiguration
{
    public class AlergiaEntityTypeConfiguration : IEntityTypeConfiguration<Alergia>
    {
        public void Configure(EntityTypeBuilder<Alergia> builder)
        {
            builder.AddDefaultPrimaryKey();
            builder.ToTable("Alergias");
        }
    }
}
