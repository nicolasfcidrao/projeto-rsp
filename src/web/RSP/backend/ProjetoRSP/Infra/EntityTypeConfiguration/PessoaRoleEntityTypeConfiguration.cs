using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectRSP.Models;

namespace ProjectRSP.Infra.EntityTypeConfiguration
{
    public class PessoaRoleEntityTypeConfiguration : IEntityTypeConfiguration<PessoaRole>
    {
        public void Configure(EntityTypeBuilder<PessoaRole> builder)
        {
            builder.HasKey(pr => new
            {
                pr.PessoaId,
                pr.RoleId
            });
            builder.HasOne(pr => pr.Pessoa).WithMany(p => p.PessoaRoles).HasForeignKey(x => x.PessoaId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(pr => pr.Role).WithMany().HasForeignKey(r => r.RoleId);
            builder.ToTable("PessoaRoles");
        }
    }
}