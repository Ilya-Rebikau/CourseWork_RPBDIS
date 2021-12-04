using System.Collections.Generic;
using VehiclesAccounting.Core.ProjectAggregate;

namespace VehiclesAccounting.Web.ViewModels.TrafficPoliceOfficers
{
    public class TrafficPoliceOfficerViewModel
    {
        public IEnumerable<TrafficPoliceOfficer> TrafficPoliceOfficers { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}
