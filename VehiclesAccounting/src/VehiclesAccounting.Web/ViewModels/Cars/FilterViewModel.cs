using System;

namespace VehiclesAccounting.Web.ViewModels.Cars
{
    public class FilterViewModel
    {
        public FilterViewModel(string carBrandName, string bodyNumber, string passportInfo, DateTime? dateStart, DateTime? dateEnd)
        {
            SelectedCarBrand = carBrandName;
            SelectedBodyNumber = bodyNumber;
            SelectedPassportInfo = passportInfo;
            SelectedDateStart = dateStart;
            SelectedDateEnd = dateEnd;
        }
        public string SelectedCarBrand { get; private set; }
        public string SelectedBodyNumber { get; private set; }
        public string SelectedPassportInfo { get; private set; }
        public DateTime? SelectedDateStart { get; private set; }
        public DateTime? SelectedDateEnd { get; private set; }
    }
}
