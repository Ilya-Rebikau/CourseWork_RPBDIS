using VehiclesAccounting.Core.ProjectAggregate;
using VehiclesAccounting.Core.Services;

namespace VehiclesAccounting.Core.Interfaces
{
    public interface ICarService : IServiceAsync<Car>
    {
        Task<Car> GetCarByIdAsync(int id);
        Task<IEnumerable<Car>> ReadAllCarsAsync();
        Task<IEnumerable<Car>> SortFilter(SortState sortOrder, string carBrandName);
    }
}
