using VehiclesAccounting.Core.Services;

namespace VehiclesAccounting.Web.ViewModels.CarBrands
{
    public class SortViewModel
    {
        public SortState NameSort { get; private set; }
        public SortState ProducerSort { get; private set; }
        public SortState CountrySort { get; private set; }
        public SortState DateStartSort { get; private set; }
        public SortState CategorySort { get; private set; }
        public SortState Current { get; private set; }

        public SortViewModel(SortState sortOrder)
        {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            ProducerSort = sortOrder == SortState.ProducerAsc ? SortState.ProducerDesc : SortState.ProducerAsc;
            CountrySort = sortOrder == SortState.CountryAsc ? SortState.CountryDesc : SortState.CountryAsc;
            DateStartSort = sortOrder == SortState.DateStartAsc ? SortState.DateStartDesc : SortState.DateStartAsc;
            CategorySort = sortOrder == SortState.CategoryAsc ? SortState.CategoryDesc : SortState.CategoryAsc;
            Current = sortOrder;
        }
    }
}
