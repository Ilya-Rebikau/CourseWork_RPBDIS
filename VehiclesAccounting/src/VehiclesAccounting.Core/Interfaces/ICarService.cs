using VehiclesAccounting.Core.ProjectAggregate;
using VehiclesAccounting.Core.Services;

namespace VehiclesAccounting.Core.Interfaces
{
    public interface ICarService : IServiceAsync<Car>
    {
        Task<IEnumerable<Car>> Sort(SortState sortOrder);
    }
}
