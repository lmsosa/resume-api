using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace resume_api.Model
{
    public class ResumeContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ResumeContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<Experience> Experiences { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var constring = _configuration.GetConnectionString("Resume");
                optionsBuilder.UseSqlServer(constring, o => o.MigrationsAssembly("resume-api"));
            }

        }
    }
}
