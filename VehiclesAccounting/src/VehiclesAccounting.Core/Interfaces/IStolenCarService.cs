using VehiclesAccounting.Core.ProjectAggregate;
using VehiclesAccounting.Core.Services;

namespace VehiclesAccounting.Core.Interfaces
{
    public interface IStolenCarService : IServiceAsync<StolenCar>
    {
        Task<IEnumerable<StolenCar>> SortFilter(SortState sortOrder);
    }
}
