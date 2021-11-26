using VehiclesAccounting.Core.Interfaces;
using VehiclesAccounting.Core.ProjectAggregate;

namespace VehiclesAccounting.Core.Services
{
    public class TrafficPoliceOfficerService : BaseService<TrafficPoliceOfficer>, ITrafficPoliceOfficerService
    {
        public TrafficPoliceOfficerService(IRepository<TrafficPoliceOfficer> repository) : base(repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<TrafficPoliceOfficer>> Sort(SortState sortOrder)
        {
            IQueryable<TrafficPoliceOfficer>? trafficPoliceOfficers = await _repository.GetAllAsync();
            switch (sortOrder)
            {
                case SortState.NameAsc:
                    trafficPoliceOfficers = trafficPoliceOfficers.OrderBy(x => x.Name);
                    break;
                case SortState.NameDesc:
                    trafficPoliceOfficers = trafficPoliceOfficers.OrderByDescending(x => x.Name);
                    break;
                case SortState.SurnameAsc:
                    trafficPoliceOfficers = trafficPoliceOfficers.OrderBy(x => x.Surname);
                    break;
                case SortState.SurnameDesc:
                    trafficPoliceOfficers = trafficPoliceOfficers.OrderByDescending(x => x.Surname);
                    break;
                case SortState.PatronymicAsc:
                    trafficPoliceOfficers = trafficPoliceOfficers.OrderBy(x => x.Patronymic);
                    break;
                case SortState.PatronymicDesc:
                    trafficPoliceOfficers = trafficPoliceOfficers.OrderByDescending(x => x.Patronymic);
                    break;
                case SortState.AgeAsc:
                    trafficPoliceOfficers = trafficPoliceOfficers.OrderBy(x => x.Birthday);
                    break;
                case SortState.AgeDesc:
                    trafficPoliceOfficers = trafficPoliceOfficers.OrderByDescending(x => x.Birthday);
                    break;
                case SortState.PostAsc:
                    trafficPoliceOfficers = trafficPoliceOfficers.OrderBy(x => x.Post);
                    break;
                case SortState.PostDesc:
                    trafficPoliceOfficers = trafficPoliceOfficers.OrderByDescending(x => x.Post);
                    break;
            }
            return trafficPoliceOfficers.AsEnumerable();
        }
    }
}
