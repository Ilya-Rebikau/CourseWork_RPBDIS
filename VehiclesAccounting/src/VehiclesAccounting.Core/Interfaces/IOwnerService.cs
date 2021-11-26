using VehiclesAccounting.Core.ProjectAggregate;
using VehiclesAccounting.Core.Services;

namespace VehiclesAccounting.Core.Interfaces;

/// <summary>
/// Services for owners
/// </summary>
public interface IOwnerService : IServiceAsync<Owner>
{
    /// <summary>
    /// Sort and filter owners by their properties
    /// </summary>
    /// <param name="sortOrder">State how to sort</param>
    /// <param name="categories">Categories</param>
    /// <param name="didLicenseFinish">Statement about did driver's license finish or no</param>
    /// <returns>Sorted and filtered owners</returns>
    Task<IEnumerable<Owner>> SortFilter(SortState sortOrder, string categories, string didLicenseFinish);
}
