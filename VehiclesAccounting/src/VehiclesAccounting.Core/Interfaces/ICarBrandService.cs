using VehiclesAccounting.Core.ProjectAggregate;
using VehiclesAccounting.Core.Services;

namespace VehiclesAccounting.Core.Interfaces
{
    public interface ICarBrandService : IServiceAsync<CarBrand>
    {
        Task<IEnumerable<CarBrand>> Sort(SortState sortOrder);
    }
}
