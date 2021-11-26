using VehiclesAccounting.Core.ProjectAggregate;
using VehiclesAccounting.Core.Services;

namespace VehiclesAccounting.Core.Interfaces;

/// <summary>
/// Services for cars
/// </summary>
public interface ICarService : IServiceAsync<Car>
{
    /// <summary>
    /// Sort and filter cars by their properties
    /// </summary>
    /// <param name="sortOrder">State how to sort</param>
    /// <param name="carBrandName">Name of car brand</param>
    /// <param name="bodyNumber">Body number of car</param>
    /// <param name="ownerId">ID of owner</param>
    /// <param name="dateStart">Start of date registration interval</param>
    /// <param name="dateEnd">End of date registration interval</param>
    /// <returns>Sorted and filtered cars</returns>
    Task<IEnumerable<Car>> SortFilter(SortState sortOrder, string carBrandName, string bodyNumber, int? ownerId, DateTime? dateStart, DateTime? dateEnd);
}
