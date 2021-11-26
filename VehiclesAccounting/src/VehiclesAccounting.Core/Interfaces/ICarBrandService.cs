using VehiclesAccounting.Core.ProjectAggregate;
using VehiclesAccounting.Core.Services;

namespace VehiclesAccounting.Core.Interfaces;

/// <summary>
/// Services for car brands
/// </summary>
public interface ICarBrandService : IServiceAsync<CarBrand>
{
    /// <summary>
    /// Sort car brand by their properties
    /// </summary>
    /// <param name="sortOrder">State how to sort</param>
    /// <returns>Sorted car brands</returns>
    Task<IEnumerable<CarBrand>> Sort(SortState sortOrder);
}
