using System.Collections.Generic;
using VehiclesAccounting.Core.ProjectAggregate;

namespace VehiclesAccounting.Web.ViewModels.StolenCars
{
    public class StolenCarViewModel
    {
        public IEnumerable<StolenCar> StolenCars { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
    }
}
