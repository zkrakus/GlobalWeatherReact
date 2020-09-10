using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Persistence
{
    public interface IDbContextFactory
    {
        WeatherDbContext DbContext { get; }
    }
}
