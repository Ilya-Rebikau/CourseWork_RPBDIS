using VehiclesAccounting.Core.ProjectAggregate;
using VehiclesAccounting.Core.Services;

namespace VehiclesAccounting.Core.Interfaces
{
    public interface IOwnerService : IServiceAsync<Owner>
    {
        Task<IEnumerable<Owner>> SortFilter(SortState sortOrder, string categories, string didLicenseFinish);
    }
}
