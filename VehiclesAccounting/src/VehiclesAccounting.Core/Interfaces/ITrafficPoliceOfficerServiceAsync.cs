using VehiclesAccounting.Core.ProjectAggregate;
using VehiclesAccounting.Core.Services;

namespace VehiclesAccounting.Core.Interfaces
{
    public interface ITrafficPoliceOfficerServiceAsync : IServiceAsync<TrafficPoliceOfficer>
    {
        public Task<IEnumerable<TrafficPoliceOfficer>> Sort(SortState sortOrder);
    }
}
