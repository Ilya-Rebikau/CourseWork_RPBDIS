namespace VehiclesAccounting.Web.ViewModels.Owners
{
    public class FilterViewModel
    {
        public FilterViewModel(string categories, string didLicenseFinish)
        {
            SelectedCategories = categories;
            SelectedLicense = didLicenseFinish;
        }
        public string SelectedCategories { get; private set; }
        public string SelectedLicense { get; private set; }
    }
}
