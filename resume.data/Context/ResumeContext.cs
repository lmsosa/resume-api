using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Resume.Data.ModelBuilders;
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
            modelBuilder.BuildEducacion();
            base.OnModelCreating(modelBuilder);
        }
    }
}
