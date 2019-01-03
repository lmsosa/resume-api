using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Resume.Domain.Entities;

namespace Resume.Data.Context
{
    /// <summary>
    /// Contexto de Base de Datos para Curriculums
    /// </summary>
    public class ResumeContext : DbContext
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Crea una nueva instancia de <see cref="ResumeContext"/>
        /// </summary>
        /// <param name="configuration"></param>
        public ResumeContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// DbSet de Experiencias
        /// </summary>
        public DbSet<Experiencia> Experiences { get; set; }

        /// <summary>
        /// DbSet de Curriculums
        /// </summary>
        public DbSet<Curriculum> Curriculum { get; set; }

        /// <summary>
        /// DbSet de Cursos
        /// </summary>
        public DbSet<Curso> Cursos { get; set; }

        /// <summary>
        /// DbSet de Educacion
        /// </summary>
        public DbSet<Educacion> Educaciones { get; set; }

        /// <summary>
        /// Delegado del evento Configuring
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var constring = _configuration.GetConnectionString("Resume");
                optionsBuilder.UseSqlServer(constring, o => o.MigrationsAssembly(this.GetType().Assembly.GetName().Name));
            }
        }

        /// <summary>
        /// Delegado del evento Model Creating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ResumeContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
