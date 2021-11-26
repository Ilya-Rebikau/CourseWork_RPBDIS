using VehiclesAccounting.Core.Interfaces;
using VehiclesAccounting.Core.ProjectAggregate;

namespace VehiclesAccounting.Core.Services;
/// <summary>
/// Owner services
/// </summary>
public class OwnerService : BaseService<Owner>, IOwnerService
{
    /// <summary>
    /// Constructor of class
    /// </summary>
    /// <param name="repository">IRepository object</param>
    public OwnerService(IRepository<Owner> repository) : base(repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<Owner>> SortFilter(SortState sortOrder, string categories, string didLicenseFinish)
    {
        IEnumerable<Owner> owners = await _repository.GetAllAsync();
        switch (sortOrder)
        {
            case SortState.NameAsc:
                owners = owners.OrderBy(x => x.Name);
                break;
            case SortState.NameDesc:
                owners = owners.OrderByDescending(x => x.Name);
                break;
            case SortState.SurnameAsc:
                owners = owners.OrderBy(x => x.Surname);
                break;
            case SortState.SurnameDesc:
                owners = owners.OrderByDescending(x => x.Surname);
                break;
            case SortState.PatronymicAsc:
                owners = owners.OrderBy(x => x.Patronymic);
                break;
            case SortState.PatronymicDesc:
                owners = owners.OrderByDescending(x => x.Patronymic);
                break;
            case SortState.AgeAsc:
                owners = owners.OrderBy(x => x.Birthday);
                break;
            case SortState.AgeDesc:
                owners = owners.OrderByDescending(x => x.Birthday);
                break;
        }
        if (!string.IsNullOrEmpty(didLicenseFinish))
        {
            owners = owners.Where(p => p.LicenseEnd <= DateTime.Now);
        }
        if (!string.IsNullOrEmpty(categories))
        {
            owners = owners.Where(p => p.Categories.Contains(categories));
        }
        return owners.AsEnumerable();
    }
}
