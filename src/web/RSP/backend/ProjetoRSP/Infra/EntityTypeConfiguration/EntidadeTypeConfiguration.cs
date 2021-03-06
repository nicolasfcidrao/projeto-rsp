using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoRSP.Models;

namespace ProjetoRSP.Infra.EntityTypeConfiguration
{
    public static class EntidadeTypeConfiguration
    {
        public static void AddDefaultPrimaryKey<TEntity>(this EntityTypeBuilder<TEntity> builder)
           where TEntity : Entidade => builder.HasKey(e => e.Id);
    }
}
