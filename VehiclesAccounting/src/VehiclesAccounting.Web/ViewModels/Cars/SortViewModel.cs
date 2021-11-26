using VehiclesAccounting.Core.Services;

namespace VehiclesAccounting.Web.ViewModels.Cars
{
    public class SortViewModel
    {
        public SortState RegistrationNumberSort { get; private set; }
        public SortState TechPassportNumberSort { get; private set; }
        public SortState DateInspectionSort { get; private set; }
        public SortState Current { get; private set; }

        public SortViewModel(SortState sortOrder)
        {
            RegistrationNumberSort = sortOrder == SortState.RegistrationNumberAsc ? SortState.RegistrationNumberDesc : SortState.RegistrationNumberAsc;
            TechPassportNumberSort = sortOrder == SortState.TechPassportNumberAsc ? SortState.TechPassportNumberDesc : SortState.TechPassportNumberAsc;
            DateInspectionSort = sortOrder == SortState.DateInspectionAsc ? SortState.DateInspectionDesc : SortState.DateInspectionAsc;
            Current = sortOrder;
        }
    }
}
