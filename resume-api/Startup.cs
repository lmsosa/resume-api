﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Resume.Api.Extensions;
using Resume.Data.Context;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Resume.Api
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration object
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configure services
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddEntityFrameworkSqlServer()
                    .AddDbContext<ResumeContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("Resume")));
            services.AddAutoMapperConfig(typeof(Startup));

            services.AddSwaggerDocumentation();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                // Sets Swagger UI route on root, "GET {baseUrl}/".
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint(
                    "/swagger/v1/swagger.json",
                    "swagger name");

                c.DocExpansion(DocExpansion.None);
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
