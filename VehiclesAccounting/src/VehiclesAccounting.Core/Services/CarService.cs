using Microsoft.EntityFrameworkCore;
using VehiclesAccounting.Core.Interfaces;
using VehiclesAccounting.Core.ProjectAggregate;

namespace VehiclesAccounting.Core.Services;
/// <summary>
/// Car services
/// </summary>
public class CarService : BaseService<Car>, ICarService
{
    /// <summary>
    /// Constructor of class
    /// </summary>
    /// <param name="repository">IRepository object</param>
    public CarService(IRepository<Car> repository) : base(repository)
    {
        _repository = repository;
    }
    public new async Task<IEnumerable<Car>> ReadAllAsync()
    {
        IQueryable<Car> cars = await _repository.GetAllAsync();
        cars = cars.Include("TrafficPoliceOfficer").Include("CarBrand").Include("Owner");
        return await Task.Run(() => cars.AsEnumerable());
    }
    public new async Task<Car> GetByIdAsync(int id)
    {
        IQueryable<Car>? cars = await _repository.GetAllAsync();
        return await Task.Run(() => cars.Include("TrafficPoliceOfficer").Include("CarBrand").Include("Owner").SingleOrDefaultAsync(e => e.Id == id));
    }
    public async Task<IEnumerable<Car>> SortFilter(SortState sortOrder, string carBrandName, string bodyNumber, int? ownerId, DateTime dateStart, DateTime dateEnd)
    {
        IQueryable<Car> cars = await _repository.GetAllAsync();
        switch (sortOrder)
        {
            case SortState.RegistrationNumberAsc:
                cars = cars.OrderBy(x => x.RegistrationNumber);
                break;
            case SortState.RegistrationNumberDesc:
                cars = cars.OrderByDescending(x => x.RegistrationNumber);
                break;
            case SortState.TechPassportNumberAsc:
                cars = cars.OrderBy(x => x.TechPassportNumber);
                break;
            case SortState.TechPassportNumberDesc:
                cars = cars.OrderByDescending(x => x.TechPassportNumber);
                break;
            case SortState.DateInspectionAsc:
                cars = cars.OrderBy(x => x.DateInspection);
                break;
            case SortState.DateInspectionDesc:
                cars = cars.OrderByDescending(x => x.DateInspection);
                break;
        }
        if (!string.IsNullOrEmpty(carBrandName))
        {
            cars = cars.Include("TrafficPoliceOfficer").Include("CarBrand").Include("Owner").Where(c => c.CarBrand.Name.Contains(carBrandName));
        }
        return cars.AsEnumerable();
    }
}
