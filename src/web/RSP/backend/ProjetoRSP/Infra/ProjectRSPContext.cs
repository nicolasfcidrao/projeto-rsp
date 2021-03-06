using Microsoft.EntityFrameworkCore;
using ProjetoRSP.Models;
using ProjetoRSP.Shared.Extensions;
using System.Linq;

namespace ProjetoRSP.Infra
{
    public class ProjectRSPContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Alergia> Alergias { get; set; }
        public DbSet<PacienteAlergia> PacienteAlergias { get; set; }

        public ProjectRSPContext(DbContextOptions<ProjectRSPContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ProjectRSPContext).Assembly);
            
            var baseEntityType = typeof(Entidade);
            var baseStringType = typeof(string);
            builder.Model
                .GetEntityTypes()
                .Where(x => baseEntityType.IsAssignableFrom(x.ClrType))
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == baseStringType)
                .Select(p => builder.Entity(p.DeclaringEntityType.ClrType).Property(p.Name))
                .ForEach(propBuilder => propBuilder.IsRequired().IsUnicode(false).HasMaxLength(100));

            base.OnModelCreating(builder);
        }
    }
}
