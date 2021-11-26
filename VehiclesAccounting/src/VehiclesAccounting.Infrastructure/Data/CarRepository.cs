using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesAccounting.Core.Interfaces;
using VehiclesAccounting.Core.ProjectAggregate;

namespace VehiclesAccounting.Infrastructure.Data
{
    public class CarRepository : EfRepository<Car>, ICarRepository
    {
        public CarRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IQueryable<Car>> GetAllCarsAsync()
        {
            return await Task.Run(() => _dbContext.Set<Car>().Include("TrafficPoliceOfficer").Include("CarBrand").Include("Owner"));
        }
        public async Task<Car> GetCarByIdAsync(int id)
        {
            return await _dbContext.Set<Car>().Include("TrafficPoliceOfficer").Include("CarBrand").Include("Owner").SingleOrDefaultAsync(e => e.Id == id);
        }
    }
}
