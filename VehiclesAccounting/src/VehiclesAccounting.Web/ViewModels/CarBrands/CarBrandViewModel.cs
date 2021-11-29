using System.Collections.Generic;
using VehiclesAccounting.Core.ProjectAggregate;

namespace VehiclesAccounting.Web.ViewModels.CarBrands
{
    public class CarBrandViewModel
    {
        public IEnumerable<CarBrand> CarBrands { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}
