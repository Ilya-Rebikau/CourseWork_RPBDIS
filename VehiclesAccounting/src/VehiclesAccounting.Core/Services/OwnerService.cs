using VehiclesAccounting.Core.Interfaces;
using VehiclesAccounting.Core.ProjectAggregate;

namespace VehiclesAccounting.Core.Services
{
    public class OwnerService : BaseService<Owner>, IOwnerService
    {
        public OwnerService(IRepository<Owner> repository) : base(repository)
        {
            _repository = repository;
        }
        private async Task<IEnumerable<Owner>> SortByNameAscAsync()
        {
            IQueryable<Owner> owners = await _repository.GetAllAsync();
            return await Task.Run(() => owners.OrderBy(x => x.Name).AsEnumerable());
        }
        private async Task<IEnumerable<Owner>> SortByNameDescAsync()
        {
            IQueryable<Owner> owners = await _repository.GetAllAsync();
            return await Task.Run(() => owners.OrderByDescending(x => x.Name).AsEnumerable());
        }
        private async Task<IEnumerable<Owner>> SortBySurnameAscAsync()
        {
            IQueryable<Owner> owners = await _repository.GetAllAsync();
            return await Task.Run(() => owners.OrderBy(x => x.Surname).AsEnumerable());
        }
        private async Task<IEnumerable<Owner>> SortBySurnameDescAsync()
        {
            IQueryable<Owner> owners = await _repository.GetAllAsync();
            return await Task.Run(() => owners.OrderByDescending(x => x.Surname).AsEnumerable());
        }
        private async Task<IEnumerable<Owner>> SortByPatronymicAscAsync()
        {
            IQueryable<Owner> owners = await _repository.GetAllAsync();
            return await Task.Run(() => owners.OrderBy(x => x.Patronymic).AsEnumerable());
        }
        private async Task<IEnumerable<Owner>> SortByPatronymicDescAsync()
        {
            IQueryable<Owner> owners = await _repository.GetAllAsync();
            return await Task.Run(() => owners.OrderByDescending(x => x.Patronymic).AsEnumerable());
        }
        private async Task<IEnumerable<Owner>> SortByBirthdayAscAsync()
        {
            IQueryable<Owner> owners = await _repository.GetAllAsync();
            return await Task.Run(() => owners.OrderBy(x => x.Birthday).AsEnumerable());
        }
        private async Task<IEnumerable<Owner>> SortByBirthdayDescAsync()
        {
            IQueryable<Owner> owners = await _repository.GetAllAsync();
            return await Task.Run(() => owners.OrderByDescending(x => x.Birthday).AsEnumerable());
        }
        public async Task<IEnumerable<Owner>> Sort(SortState sortOrder)
        {
            IEnumerable<Owner> owners = await ReadAllAsync();
            switch (sortOrder)
            {
                case SortState.NameAsc:
                    owners = await SortByNameAscAsync();
                    break;
                case SortState.NameDesc:
                    owners = await SortByNameDescAsync();
                    break;
                case SortState.SurnameAsc:
                    owners = await SortBySurnameAscAsync();
                    break;
                case SortState.SurnameDesc:
                    owners = await SortBySurnameDescAsync();
                    break;
                case SortState.PatronymicAsc:
                    owners = await SortByPatronymicAscAsync();
                    break;
                case SortState.PatronymicDesc:
                    owners = await SortByPatronymicDescAsync();
                    break;
                case SortState.AgeAsc:
                    owners = await SortByBirthdayAscAsync();
                    break;
                case SortState.AgeDesc:
                    owners = await SortByBirthdayDescAsync();
                    break;
            }
            return owners;
        }
    }
}
