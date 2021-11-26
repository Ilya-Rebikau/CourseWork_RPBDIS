using VehiclesAccounting.Core.ProjectAggregate;

namespace VehiclesAccounting.Core.Interfaces
{
    public interface ICarRepository : IRepository<Car>
    {
        Task<IQueryable<Car>> GetAllCarsAsync();
        Task<Car> GetCarByIdAsync(int id);
    }
}
