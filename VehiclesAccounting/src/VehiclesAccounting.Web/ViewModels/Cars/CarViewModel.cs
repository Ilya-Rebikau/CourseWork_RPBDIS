using System.Collections.Generic;
using VehiclesAccounting.Core.ProjectAggregate;

namespace VehiclesAccounting.Web.ViewModels.Cars
{
    public class CarViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
    }
}
