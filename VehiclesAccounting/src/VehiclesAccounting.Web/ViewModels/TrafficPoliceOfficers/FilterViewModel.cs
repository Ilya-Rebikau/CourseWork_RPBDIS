using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using VehiclesAccounting.Core.ProjectAggregate;

namespace VehiclesAccounting.Web.ViewModels.TrafficPoliceOfficers
{
    public class FilterViewModel
    {
        public FilterViewModel(List<TrafficPoliceOfficer> trafficPoliceOfficers, int? id, string surname)
        {
            trafficPoliceOfficers.Insert(0, new TrafficPoliceOfficer { Name = "Все", Id = 0 });
            TrafficPoliceOfficers = new SelectList(trafficPoliceOfficers, "Id", "Surname", id);
            SelectedTrafficPoliceOfficer = id;
            SelectedSurname = surname;
        }
        public SelectList TrafficPoliceOfficers { get; private set; }
        public int? SelectedTrafficPoliceOfficer { get; private set; }
        public string SelectedSurname { get; private set; }
    }
}
