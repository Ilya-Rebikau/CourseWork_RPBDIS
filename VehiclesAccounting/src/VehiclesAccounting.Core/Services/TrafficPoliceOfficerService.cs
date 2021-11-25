using VehiclesAccounting.Core.Interfaces;
using VehiclesAccounting.Core.ProjectAggregate;

namespace VehiclesAccounting.Core.Services
{
    public class TrafficPoliceOfficerService : BaseService<TrafficPoliceOfficer>, ITrafficPoliceOfficerServiceAsync
    {
        public TrafficPoliceOfficerService(IRepository<TrafficPoliceOfficer> repository) : base(repository)
        {
            _repository = repository;
        }
        private async Task<IEnumerable<TrafficPoliceOfficer>> SortByNameAscAsync()
        {
            IQueryable<TrafficPoliceOfficer> trafficPoliceOfficers = await _repository.GetAllAsync();
            return await Task.Run(() => trafficPoliceOfficers.OrderBy(x => x.Name).AsEnumerable());
        }
        private async Task<IEnumerable<TrafficPoliceOfficer>> SortByNameDescAsync()
        {
            IQueryable<TrafficPoliceOfficer> trafficPoliceOfficers = await _repository.GetAllAsync();
            return await Task.Run(() => trafficPoliceOfficers.OrderByDescending(x => x.Name).AsEnumerable());
        }
        private async Task<IEnumerable<TrafficPoliceOfficer>> SortBySurnameAscAsync()
        {
            IQueryable<TrafficPoliceOfficer> trafficPoliceOfficers = await _repository.GetAllAsync();
            return await Task.Run(() => trafficPoliceOfficers.OrderBy(x => x.Surname).AsEnumerable());
        }
        private async Task<IEnumerable<TrafficPoliceOfficer>> SortBySurnameDescAsync()
        {
            IQueryable<TrafficPoliceOfficer> trafficPoliceOfficers = await _repository.GetAllAsync();
            return await Task.Run(() => trafficPoliceOfficers.OrderByDescending(x => x.Surname).AsEnumerable());
        }
        private async Task<IEnumerable<TrafficPoliceOfficer>> SortByPatronymicAscAsync()
        {
            IQueryable<TrafficPoliceOfficer> trafficPoliceOfficers = await _repository.GetAllAsync();
            return await Task.Run(() => trafficPoliceOfficers.OrderBy(x => x.Patronymic).AsEnumerable());
        }
        private async Task<IEnumerable<TrafficPoliceOfficer>> SortByPatronymicDescAsync()
        {
            IQueryable<TrafficPoliceOfficer> trafficPoliceOfficers = await _repository.GetAllAsync();
            return await Task.Run(() => trafficPoliceOfficers.OrderByDescending(x => x.Patronymic).AsEnumerable());
        }
        private async Task<IEnumerable<TrafficPoliceOfficer>> SortByBirthdayAscAsync()
        {
            IQueryable<TrafficPoliceOfficer> trafficPoliceOfficers = await _repository.GetAllAsync();
            return await Task.Run(() => trafficPoliceOfficers.OrderBy(x => x.Birthday).AsEnumerable());
        }
        private async Task<IEnumerable<TrafficPoliceOfficer>> SortByBirthdayDescAsync()
        {
            IQueryable<TrafficPoliceOfficer> trafficPoliceOfficers = await _repository.GetAllAsync();
            return await Task.Run(() => trafficPoliceOfficers.OrderByDescending(x => x.Birthday).AsEnumerable());
        }
        private async Task<IEnumerable<TrafficPoliceOfficer>> SortByPostAscAsync()
        {
            IQueryable<TrafficPoliceOfficer> trafficPoliceOfficers = await _repository.GetAllAsync();
            return await Task.Run(() => trafficPoliceOfficers.OrderBy(x => x.Post).AsEnumerable());
        }
        private async Task<IEnumerable<TrafficPoliceOfficer>> SortByPostDescAsync()
        {
            IQueryable<TrafficPoliceOfficer> trafficPoliceOfficers = await _repository.GetAllAsync();
            return await Task.Run(() => trafficPoliceOfficers.OrderByDescending(x => x.Post).AsEnumerable());
        }
        public async Task<IEnumerable<TrafficPoliceOfficer>> Sort(SortState sortOrder)
        {
            IEnumerable<TrafficPoliceOfficer> trafficPoliceOfficers = await ReadAllAsync();
            switch (sortOrder)
            {
                case SortState.NameAsc:
                    trafficPoliceOfficers = await SortByNameAscAsync();
                    break;
                case SortState.NameDesc:
                    trafficPoliceOfficers = await SortByNameDescAsync();
                    break;
                case SortState.SurnameAsc:
                    trafficPoliceOfficers = await SortBySurnameAscAsync();
                    break;
                case SortState.SurnameDesc:
                    trafficPoliceOfficers = await SortBySurnameDescAsync();
                    break;
                case SortState.PatronymicAsc:
                    trafficPoliceOfficers = await SortByPatronymicAscAsync();
                    break;
                case SortState.PatronymicDesc:
                    trafficPoliceOfficers = await SortByPatronymicDescAsync();
                    break;
                case SortState.AgeAsc:
                    trafficPoliceOfficers = await SortByBirthdayAscAsync();
                    break;
                case SortState.AgeDesc:
                    trafficPoliceOfficers = await SortByBirthdayDescAsync();
                    break;
                case SortState.PostAsc:
                    trafficPoliceOfficers = await SortByPostAscAsync();
                    break;
                case SortState.PostDesc:
                    trafficPoliceOfficers = await SortByPostDescAsync();
                    break;
            }
            return trafficPoliceOfficers;
        }
    }
}
