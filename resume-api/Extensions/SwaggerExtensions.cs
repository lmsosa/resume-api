using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace resume_api.Extensions
{
    /// <summary>
    /// Extensions for Swagger
    /// </summary>
    public static class SwaggerExtensions
    {
        /// <summary>
        /// Adds Swagger Documentation
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", GetSwaggerMetadata());

                var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                {
                    c.IncludeXmlComments(xmlPath);
                }
            });

            return services;
        }

        private static Info GetSwaggerMetadata()
        {
            return new Info
            {
                Title = "Resume API",
                Version = "v1",
                Description = "Provides endpoint for resumes",
                Contact = new Contact
                {
                    Name = "Luis Sosa",
                    Email = "lmsosa@gmail.com"
                },
                License = new License
                {
                    Name = "PRIVATE"
                }
            };
        }
    }
}
