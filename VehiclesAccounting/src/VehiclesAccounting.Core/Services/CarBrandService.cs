using VehiclesAccounting.Core.Interfaces;
using VehiclesAccounting.Core.ProjectAggregate;

namespace VehiclesAccounting.Core.Services
{
    public class CarBrandService : BaseService<CarBrand>, ICarBrandService
    {
        public CarBrandService(IRepository<CarBrand> repository) : base(repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<CarBrand>> Sort(SortState sortOrder)
        {
            IQueryable<CarBrand> carBrands = await _repository.GetAllAsync();
            switch (sortOrder)
            {
                case SortState.NameAsc:
                    carBrands = carBrands.OrderBy(x => x.Name);
                    break;
                case SortState.NameDesc:
                    carBrands = carBrands.OrderByDescending(x => x.Name);
                    break;
                case SortState.ProducerAsc:
                    carBrands = carBrands.OrderBy(x => x.Producer);
                    break;
                case SortState.ProducerDesc:
                    carBrands = carBrands.OrderByDescending(x => x.Producer);
                    break;
                case SortState.CountryAsc:
                    carBrands = carBrands.OrderBy(x => x.Country);
                    break;
                case SortState.CountryDesc:
                    carBrands = carBrands.OrderByDescending(x => x.Country);
                    break;
                case SortState.DateStartAsc:
                    carBrands = carBrands.OrderBy(x => x.DateStart);
                    break;
                case SortState.DateStartDesc:
                    carBrands = carBrands.OrderByDescending(x => x.DateStart);
                    break;
                case SortState.CategoryAsc:
                    carBrands = carBrands.OrderBy(x => x.Category);
                    break;
                case SortState.CategoryDesc:
                    carBrands = carBrands.OrderByDescending(x => x.Category);
                    break;
            }
            return carBrands.AsEnumerable();
        }
    }
}
