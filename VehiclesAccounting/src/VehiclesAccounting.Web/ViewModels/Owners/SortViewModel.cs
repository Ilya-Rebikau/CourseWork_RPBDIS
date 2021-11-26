using VehiclesAccounting.Core.Services;

namespace VehiclesAccounting.Web.ViewModels.Owners
{
    public class SortViewModel
    {
        public SortState NameSort { get; private set; }
        public SortState SurnameSort { get; private set; }
        public SortState PatronymicSort { get; private set; }
        public SortState AgeSort { get; private set; }
        public SortState Current { get; private set; }

        public SortViewModel(SortState sortOrder)
        {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            SurnameSort = sortOrder == SortState.SurnameAsc ? SortState.SurnameDesc : SortState.SurnameAsc;
            PatronymicSort = sortOrder == SortState.PatronymicAsc ? SortState.PatronymicDesc : SortState.PatronymicAsc;
            AgeSort = sortOrder == SortState.AgeAsc ? SortState.AgeDesc : SortState.AgeAsc;
            Current = sortOrder;
        }
    }
}
