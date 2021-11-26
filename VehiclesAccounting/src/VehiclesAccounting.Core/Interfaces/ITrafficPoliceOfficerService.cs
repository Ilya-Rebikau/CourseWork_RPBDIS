using VehiclesAccounting.Core.ProjectAggregate;
using VehiclesAccounting.Core.Services;

namespace VehiclesAccounting.Core.Interfaces;

/// <summary>
/// Services for traffic police officers
/// </summary>
public interface ITrafficPoliceOfficerService : IServiceAsync<TrafficPoliceOfficer>
{
    /// <summary>
    /// Sort traffic police officers by their properties
    /// </summary>
    /// <param name="sortOrder">State how to sort</param>
    /// <returns>Sorted traffic police officers</returns>
    Task<IEnumerable<TrafficPoliceOfficer>> Sort(SortState sortOrder);
}
