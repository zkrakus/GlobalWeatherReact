﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Persistence.Models;

namespace Weather.Persistence
{
    public interface ICityRepository : IRepository<City>
    {
        Task<City> GetLastAccessedCityAsync();
        Task InsertOrUpdateCityAsync(City city);
    }
}
