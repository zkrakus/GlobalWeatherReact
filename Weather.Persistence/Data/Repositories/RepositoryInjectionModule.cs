using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Weather.Persistence
{
    public static class RepositoryInjectionModule
    {
        public static IServiceCollection InjectPersistence(this IServiceCollection services)
        {
            services.AddScoped<IDbContextFactory, DbContextFactory>();
            services.AddTransient<ICityRepository, CityRepository>();

            return services;
        }
    }
}
