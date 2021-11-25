using VehiclesAccounting.Core.Interfaces;
using VehiclesAccounting.Core.ProjectAggregate;

namespace VehiclesAccounting.Core.Services
{
    public class StolenCarService : BaseService<StolenCar>, IStolenCarService
    {
        public StolenCarService(IRepository<StolenCar> repository) : base(repository)
        {
            _repository = repository;
        }
        private async Task<IEnumerable<StolenCar>> SortByRegistrationNumberAscAsync()
        {
            IQueryable<StolenCar> stolenCars = await _repository.GetAllAsync();
            return await Task.Run(() => stolenCars.OrderBy(x => x.Car.RegistrationNumber).AsEnumerable());
        }
        private async Task<IEnumerable<StolenCar>> SortByRegistrationNumberDescAsync()
        {
            IQueryable<StolenCar> stolenCars = await _repository.GetAllAsync();
            return await Task.Run(() => stolenCars.OrderBy(x => x.Car.RegistrationNumber).AsEnumerable());
        }
        private async Task<IEnumerable<StolenCar>> SortByBodyNumberAscAsync()
        {
            IQueryable<StolenCar> stolenCars = await _repository.GetAllAsync();
            return await Task.Run(() => stolenCars.OrderBy(x => x.Car.BodyNumber).AsEnumerable());
        }
        private async Task<IEnumerable<StolenCar>> SortByBodyNumberDescAsync()
        {
            IQueryable<StolenCar> stolenCars = await _repository.GetAllAsync();
            return await Task.Run(() => stolenCars.OrderBy(x => x.Car.BodyNumber).AsEnumerable());
        }
        private async Task<IEnumerable<StolenCar>> SortByTheftDateAscAsync()
        {
            IQueryable<StolenCar> stolenCars = await _repository.GetAllAsync();
            return await Task.Run(() => stolenCars.OrderBy(x => x.TheftDate).AsEnumerable());
        }
        private async Task<IEnumerable<StolenCar>> SortByTheftDateDescAsync()
        {
            IQueryable<StolenCar> stolenCars = await _repository.GetAllAsync();
            return await Task.Run(() => stolenCars.OrderBy(x => x.TheftDate).AsEnumerable());
        }
        private async Task<IEnumerable<StolenCar>> SortByMarkAscAsync()
        {
            IQueryable<StolenCar> stolenCars = await _repository.GetAllAsync();
            return await Task.Run(() => stolenCars.OrderBy(x => x.MarkAboutFinding).AsEnumerable());
        }
        private async Task<IEnumerable<StolenCar>> SortByMarkDescAsync()
        {
            IQueryable<StolenCar> stolenCars = await _repository.GetAllAsync();
            return await Task.Run(() => stolenCars.OrderBy(x => x.MarkAboutFinding).AsEnumerable());
        }
        public async Task<IEnumerable<StolenCar>> Sort(SortState sortOrder)
        {
            IEnumerable<StolenCar> stolenCars = await ReadAllAsync();
            switch (sortOrder)
            {
                case SortState.RegistrationNumberAsc:
                    stolenCars = await SortByRegistrationNumberAscAsync();
                    break;
                case SortState.RegistrationNumberDesc:
                    stolenCars = await SortByRegistrationNumberDescAsync();
                    break;
                case SortState.BodyNumberAsc:
                    stolenCars = await SortByBodyNumberAscAsync();
                    break;
                case SortState.BodyNumberDesc:
                    stolenCars = await SortByBodyNumberDescAsync();
                    break;
                case SortState.MarkAboutFindingAsc:
                    stolenCars = await SortByMarkAscAsync();
                    break;
                case SortState.MarkAboutFindingDesc:
                    stolenCars = await SortByMarkDescAsync();
                    break;
                case SortState.TheftDateAsc:
                    stolenCars = await SortByTheftDateAscAsync();
                    break;
                case SortState.TheftDateDesc:
                    stolenCars = await SortByTheftDateDescAsync();
                    break;
            }
            return stolenCars;
        }
    }
}
