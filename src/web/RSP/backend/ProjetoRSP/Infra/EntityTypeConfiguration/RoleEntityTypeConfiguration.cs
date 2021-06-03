using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectRSP.Models;
using ProjetoRSP.Infra.EntityTypeConfiguration;

namespace ProjectRSP.Infra.EntityTypeConfiguration
{
    public class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.AddDefaultPrimaryKey();
            builder.ToTable("Roles");

            builder.HasData(new {
                Id = 1,
                Name = "admin"
            },
            new {
                Id = 2,
                Name = "user"
            });
        }
    }
}