using VehiclesAccounting.Core.ProjectAggregate;
using VehiclesAccounting.Core.Services;

namespace VehiclesAccounting.Core.Interfaces
{
    public interface ITrafficPoliceOfficerService : IServiceAsync<TrafficPoliceOfficer>
    {
        Task<IEnumerable<TrafficPoliceOfficer>> Sort(SortState sortOrder);
    }
}
