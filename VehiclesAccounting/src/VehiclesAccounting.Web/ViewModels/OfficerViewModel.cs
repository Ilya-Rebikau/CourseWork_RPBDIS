namespace VehiclesAccounting.Web.ViewModels
{
    public class OfficerViewModel
    {
        public OfficerViewModel(int id, string nspb)
        {
            Id = id;
            NSPB = nspb;
        }
        public int Id { get; set; }
        public string NSPB { get; set; }
    }
}
