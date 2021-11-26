using Microsoft.EntityFrameworkCore;
using VehiclesAccounting.Core.Interfaces;
using VehiclesAccounting.Core.ProjectAggregate;

namespace VehiclesAccounting.Core.Services;
/// <summary>
/// Stolen car services
/// </summary>
public class StolenCarService : BaseService<StolenCar>, IStolenCarService
{
    /// <summary>
    /// Constructor of class
    /// </summary>
    /// <param name="repository">IRepository object</param>
    public StolenCarService(IRepository<StolenCar> repository) : base(repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<StolenCar>> SortFilter(SortState sortOrder, string carBrandName, string engineNumber, DateTime? theftStart, DateTime? theftEnd, string mark)
    {
        IQueryable<StolenCar> stolenCars = await _repository.GetAllAsync();
        switch (sortOrder)
        {
            case SortState.RegistrationNumberAsc:
                stolenCars = stolenCars.OrderBy(x => x.Car.RegistrationNumber);
                break;
            case SortState.RegistrationNumberDesc:
                stolenCars = stolenCars.OrderBy(x => x.Car.RegistrationNumber);
                break;
            case SortState.BodyNumberAsc:
                stolenCars = stolenCars.OrderBy(x => x.Car.BodyNumber);
                break;
            case SortState.BodyNumberDesc:
                stolenCars = stolenCars.OrderBy(x => x.Car.BodyNumber);
                break;
            case SortState.MarkAboutFindingAsc:
                stolenCars = stolenCars.OrderBy(x => x.TheftDate);
                break;
            case SortState.MarkAboutFindingDesc:
                stolenCars = stolenCars.OrderBy(x => x.TheftDate);
                break;
            case SortState.TheftDateAsc:
                stolenCars = stolenCars.OrderBy(x => x.MarkAboutFinding);
                break;
            case SortState.TheftDateDesc:
                stolenCars = stolenCars.OrderBy(x => x.MarkAboutFinding);
                break;
        }
        if (!string.IsNullOrEmpty(mark))
        {
            stolenCars = stolenCars.Include("TrafficPoliceOfficer").Include("Car").Where(c => c.MarkAboutFinding == false);
        }
        if (!string.IsNullOrEmpty(carBrandName))
        {
            stolenCars = stolenCars.Include("TrafficPoliceOfficer").Include("Car").Where(c => c.Car.CarBrand.Name.Contains(carBrandName));
        }
        if (!string.IsNullOrEmpty(engineNumber))
        {
            stolenCars = stolenCars.Include("TrafficPoliceOfficer").Include("Car").Where(c => c.Car.EngineNumber.Contains(engineNumber));
        }
        if (theftStart is not null && theftEnd is not null)
        {
            stolenCars = stolenCars.Include("TrafficPoliceOfficer").Include("Car").Where(c => c.TheftDate <= theftEnd && c.TheftDate >= theftStart);
        }
        return stolenCars.AsEnumerable();
    }
}
