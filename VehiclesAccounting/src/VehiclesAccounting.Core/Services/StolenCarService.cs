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
        public async Task<IEnumerable<StolenCar>> SortFilter(SortState sortOrder)
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
            return stolenCars.AsEnumerable();
        }
    }
}
