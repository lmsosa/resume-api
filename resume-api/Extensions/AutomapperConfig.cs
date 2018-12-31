using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.WebApi.Extensions
{
    /// <summary>
    /// Extensions for AutoMapper configuration
    /// </summary>
    public static class AutoMapperConfig
    {
        /// <summary>
        /// Loads existing AutoMapper profiles from an assembly
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblyType"></param>
        /// <returns></returns>
        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services, Type assemblyType)
        {
            var profiles = assemblyType
                .Assembly.GetTypes()
                .Where(t => typeof(Profile).IsAssignableFrom(t))
                .Select(t => (Profile)Activator.CreateInstance(t));
            var config = new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }
            });
            var mapper = config.CreateMapper();
            return services.AddSingleton(mapper);
        }
    }
}
