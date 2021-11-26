namespace VehiclesAccounting.Web.ViewModels.Cars
{
    public class FilterViewModel
    {
        public FilterViewModel(string carBrandName)
        {
            SelectedCarBrand = carBrandName;
        }
        public string SelectedCarBrand { get; private set; }
    }
}
