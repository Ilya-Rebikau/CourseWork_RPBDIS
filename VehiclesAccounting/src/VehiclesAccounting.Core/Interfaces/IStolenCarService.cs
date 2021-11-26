using VehiclesAccounting.Core.ProjectAggregate;
using VehiclesAccounting.Core.Services;

namespace VehiclesAccounting.Core.Interfaces;

/// <summary>
/// Services for stolen cars
/// </summary>
public interface IStolenCarService : IServiceAsync<StolenCar>
{
    /// <summary>
    /// Sort and filter stolen cars by their properties
    /// </summary>
    /// <param name="sortOrder">State how to sort</param>
    /// <param name="carBrandName">Name of car brand</param>
    /// <param name="engineNumber">Engine number of car</param>
    /// <param name="theftStart">Start of theft date interval</param>
    /// <param name="theftEnd">End of theft date interval</param>
    /// <param name="mark">Mark about was car founded or not</param>
    /// <returns>Sorted and filtered stolen cars</returns>
    Task<IEnumerable<StolenCar>> SortFilter(SortState sortOrder, string carBrandName, string engineNumber, DateTime theftStart, DateTime theftEnd, string mark);
}
