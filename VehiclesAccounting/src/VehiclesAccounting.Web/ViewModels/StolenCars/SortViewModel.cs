using VehiclesAccounting.Core.Services;

namespace VehiclesAccounting.Web.ViewModels.StolenCars
{
    public class SortViewModel
    {
        public SortState RegistrationNumberSort { get; private set; }
        public SortState BodyNumberSort { get; private set; }
        public SortState MarkAboutFindingSort { get; private set; }
        public SortState TheftDateSort { get; private set; }
        public SortState Current { get; private set; }

        public SortViewModel(SortState sortOrder)
        {
            RegistrationNumberSort = sortOrder == SortState.RegistrationNumberAsc ? SortState.RegistrationNumberDesc : SortState.RegistrationNumberAsc;
            BodyNumberSort = sortOrder == SortState.BodyNumberAsc ? SortState.BodyNumberDesc : SortState.BodyNumberAsc;
            MarkAboutFindingSort = sortOrder == SortState.MarkAboutFindingAsc ? SortState.MarkAboutFindingDesc : SortState.MarkAboutFindingAsc;
            TheftDateSort = sortOrder == SortState.TheftDateAsc ? SortState.TheftDateDesc : SortState.TheftDateAsc;
            Current = sortOrder;
        }
    }
}
