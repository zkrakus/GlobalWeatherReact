﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Persistence.Models;

namespace Weather.Persistence
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(IDbContextFactory dbContextFactory, ILogger logger) : base(dbContextFactory, logger)
        {
        }
        
        /// <summary>
        /// GetLastAccessedCityAsync
        /// </summary>
        /// <returns>City</returns>
        public async Task<City> GetLastAccessedCityAsync()
        {
            var city = await DbContext.Cities.OrderByDescending(x => x.AccessedDate).FirstOrDefaultAsync();

            return city;
        }

        /// <summary>
        /// InsertOrUpdateCityAsync
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public async Task InsertOrUpdateCityAsync(City city)
        {
            var entity = await GetEntity(city.Id);
            if (entity != null)
            {
                entity.Name = city.Name;
                entity.CountryId = city.CountryId;
                entity.AccessedDate = city.AccessedDate;
                await UpdateEntity(entity);
            }
            else
            {
                await AddEntity(city);
            }
        }
    }
}
