using System;

namespace VehiclesAccounting.Web.ViewModels.StolenCars
{
    public class FilterViewModel
    {
        public FilterViewModel(string carBrandName, string engineNumber, DateTime? theftStart, DateTime? theftEnd, string mark)
        {
            SelectedCarBrand = carBrandName;
            SelectedEngineNumber = engineNumber;
            SelectedTheftStart = theftStart;
            SelectedTheftEnd = theftEnd;
            SelectedMark = mark;
        }
        public string SelectedCarBrand { get; private set; }
        public string SelectedEngineNumber { get; private set; }
        public DateTime? SelectedTheftStart { get; private set; }
        public DateTime? SelectedTheftEnd { get; private set; }
        public string SelectedMark { get; private set; }
    }
}
