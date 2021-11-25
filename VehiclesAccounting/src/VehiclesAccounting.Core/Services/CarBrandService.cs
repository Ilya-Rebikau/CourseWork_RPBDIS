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
        private async Task<IEnumerable<CarBrand>> SortByNameAscAsync()
        {
            IQueryable<CarBrand> carBrands = await _repository.GetAllAsync();
            return await Task.Run(() => carBrands.OrderBy(x => x.Name).AsEnumerable());
        }
        private async Task<IEnumerable<CarBrand>> SortByNameDescAsync()
        {
            IQueryable<CarBrand> carBrands = await _repository.GetAllAsync();
            return await Task.Run(() => carBrands.OrderByDescending(x => x.Name).AsEnumerable());
        }
        private async Task<IEnumerable<CarBrand>> SortByProducerAscAsync()
        {
            IQueryable<CarBrand> carBrands = await _repository.GetAllAsync();
            return await Task.Run(() => carBrands.OrderBy(x => x.Producer).AsEnumerable());
        }
        private async Task<IEnumerable<CarBrand>> SortByProducerDescAsync()
        {
            IQueryable<CarBrand> carBrands = await _repository.GetAllAsync();
            return await Task.Run(() => carBrands.OrderByDescending(x => x.Producer).AsEnumerable());
        }
        private async Task<IEnumerable<CarBrand>> SortByCountryAscAsync()
        {
            IQueryable<CarBrand> carBrands = await _repository.GetAllAsync();
            return await Task.Run(() => carBrands.OrderBy(x => x.Country).AsEnumerable());
        }
        private async Task<IEnumerable<CarBrand>> SortByCountryDescAsync()
        {
            IQueryable<CarBrand> carBrands = await _repository.GetAllAsync();
            return await Task.Run(() => carBrands.OrderByDescending(x => x.Country).AsEnumerable());
        }
        private async Task<IEnumerable<CarBrand>> SortByDateStartAscAsync()
        {
            IQueryable<CarBrand> carBrands = await _repository.GetAllAsync();
            return await Task.Run(() => carBrands.OrderBy(x => x.DateStart).AsEnumerable());
        }
        private async Task<IEnumerable<CarBrand>> SortByDateStartDescAsync()
        {
            IQueryable<CarBrand> carBrands = await _repository.GetAllAsync();
            return await Task.Run(() => carBrands.OrderByDescending(x => x.DateStart).AsEnumerable());
        }
        private async Task<IEnumerable<CarBrand>> SortByCategoryAscAsync()
        {
            IQueryable<CarBrand> carBrands = await _repository.GetAllAsync();
            return await Task.Run(() => carBrands.OrderBy(x => x.Category).AsEnumerable());
        }
        private async Task<IEnumerable<CarBrand>> SortByCategoryDescAsync()
        {
            IQueryable<CarBrand> carBrands = await _repository.GetAllAsync();
            return await Task.Run(() => carBrands.OrderByDescending(x => x.Category).AsEnumerable());
        }
        public async Task<IEnumerable<CarBrand>> Sort(SortState sortOrder)
        {
            IEnumerable<CarBrand> carBrands = await ReadAllAsync();
            switch (sortOrder)
            {
                case SortState.NameAsc:
                    carBrands = await SortByNameAscAsync();
                    break;
                case SortState.NameDesc:
                    carBrands = await SortByNameDescAsync();
                    break;
                case SortState.ProducerAsc:
                    carBrands = await SortByProducerAscAsync();
                    break;
                case SortState.ProducerDesc:
                    carBrands = await SortByProducerDescAsync();
                    break;
                case SortState.CountryAsc:
                    carBrands = await SortByCountryAscAsync();
                    break;
                case SortState.CountryDesc:
                    carBrands = await SortByCountryDescAsync();
                    break;
                case SortState.DateStartAsc:
                    carBrands = await SortByDateStartAscAsync();
                    break;
                case SortState.DateStartDesc:
                    carBrands = await SortByDateStartDescAsync();
                    break;
                case SortState.CategoryAsc:
                    carBrands = await SortByCategoryAscAsync();
                    break;
                case SortState.CategoryDesc:
                    carBrands = await SortByCategoryDescAsync();
                    break;
            }
            return carBrands;
        }
    }
}
