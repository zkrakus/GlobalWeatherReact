using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Persistence
{
    public static class ServiceInjectionModule
    {
        /// <summary>
        /// Dependency inject services
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection InjectServices(this IServiceCollection services)
        {
            services.AddTransient<ICityService, CityService>();
            return services;
        }
    }
}
