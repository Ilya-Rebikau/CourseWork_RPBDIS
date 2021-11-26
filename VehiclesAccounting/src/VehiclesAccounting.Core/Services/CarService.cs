using Microsoft.EntityFrameworkCore;
using VehiclesAccounting.Core.Interfaces;
using VehiclesAccounting.Core.ProjectAggregate;

namespace VehiclesAccounting.Core.Services
{
    public class CarService : BaseService<Car>, ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository repository) : base(repository)
        {
            _carRepository = repository;
        }
        public async Task<Car> GetCarByIdAsync(int id)
        {
            return await _carRepository.GetCarByIdAsync(id);
        }
        public async Task<IEnumerable<Car>> ReadAllCarsAsync()
        {
            IQueryable<Car>? results = await _carRepository.GetAllCarsAsync();
            return await Task.Run(() => results.AsEnumerable());
        }
        public async Task<IEnumerable<Car>> SortFilter(SortState sortOrder, string carBrandName)
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
}
