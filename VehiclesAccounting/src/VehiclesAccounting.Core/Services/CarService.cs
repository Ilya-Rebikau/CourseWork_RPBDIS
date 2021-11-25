using VehiclesAccounting.Core.Interfaces;
using VehiclesAccounting.Core.ProjectAggregate;

namespace VehiclesAccounting.Core.Services
{
    public class CarService : BaseService<Car>, ICarService
    {
        public CarService(IRepository<Car> repository) : base(repository)
        {
            _repository = repository;
        }
        private async Task<IEnumerable<Car>> SortByRegistrationNumberAscAsync()
        {
            IQueryable<Car> cars = await _repository.GetAllAsync();
            return await Task.Run(() => cars.OrderBy(x => x.RegistrationNumber).AsEnumerable());
        }
        private async Task<IEnumerable<Car>> SortByRegistrationNumberDescAsync()
        {
            IQueryable<Car> cars = await _repository.GetAllAsync();
            return await Task.Run(() => cars.OrderByDescending(x => x.RegistrationNumber).AsEnumerable());
        }
        private async Task<IEnumerable<Car>> SortByTechPassportNumberAscAsync()
        {
            IQueryable<Car> cars = await _repository.GetAllAsync();
            return await Task.Run(() => cars.OrderBy(x => x.TechPassportNumber).AsEnumerable());
        }
        private async Task<IEnumerable<Car>> SortByTechPassportNumberDescAsync()
        {
            IQueryable<Car> cars = await _repository.GetAllAsync();
            return await Task.Run(() => cars.OrderByDescending(x => x.TechPassportNumber).AsEnumerable());
        }
        private async Task<IEnumerable<Car>> SortByDateInspectionAscAsync()
        {
            IQueryable<Car> cars = await _repository.GetAllAsync();
            return await Task.Run(() => cars.OrderBy(x => x.DateInspection).AsEnumerable());
        }
        private async Task<IEnumerable<Car>> SortByDateInspectionDescAsync()
        {
            IQueryable<Car> cars = await _repository.GetAllAsync();
            return await Task.Run(() => cars.OrderByDescending(x => x.DateInspection).AsEnumerable());
        }
        public async Task<IEnumerable<Car>> Sort(SortState sortOrder)
        {
            IEnumerable<Car> cars = await ReadAllAsync();
            switch (sortOrder)
            {
                case SortState.RegistrationNumberAsc:
                    cars = await SortByRegistrationNumberAscAsync();
                    break;
                case SortState.RegistrationNumberDesc:
                    cars = await SortByRegistrationNumberDescAsync();
                    break;
                case SortState.TechPassportNumberAsc:
                    cars = await SortByTechPassportNumberAscAsync();
                    break;
                case SortState.TechPassportNumberDesc:
                    cars = await SortByTechPassportNumberDescAsync();
                    break;
                case SortState.DateInspectionAsc:
                    cars = await SortByDateInspectionAscAsync();
                    break;
                case SortState.DateInspectionDesc:
                    cars = await SortByDateInspectionDescAsync();
                    break;
            }
            return cars;
        }
    }
}
