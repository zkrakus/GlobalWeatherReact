using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Persistence
{
    public class DbContextFactory : IDbContextFactory, IDisposable
    {
        public WeatherDbContext DbContext { get; private set; }

        /// <summary>
        /// Create Db context with connection string
        /// </summary>
        /// <param name="settings"></param>
        public DbContextFactory(IOptions<DbContextSettings> settings)
        {
            var options = new DbContextOptionsBuilder<WeatherDbContext>()
                .UseSqlServer(settings.Value.DbConnectionString).Options;
            DbContext = new WeatherDbContext(options);
        }

        /// <summary>
        /// Call Dispose to release DbContext
        /// </summary>
        ~DbContextFactory()
        {
            Dispose();
        }

        /// <summary>
        /// Release DB context
        /// </summary>
        public void Dispose()
        {
            DbContext?.Dispose();
        }
    }
}
