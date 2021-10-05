using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehiclesAccounting.Core.ProjectAggregate
{
    [Table("StolenCars")]
    public class StolenCar : Car
    {
        public StolenCar(long registrationNumber, byte[] photo, long bodyNumber, long engineNumber,
                   long techPassportNumber, DateTime dateCreating, DateTime dateRegistration, DateTime dateInspection,
                   string color, string description, DateTime theftDate, DateTime statementDate, string insuranceType, 
                   string circumstances, bool markAboutFinding, int? inspectorId, int? carId) 
            : base(registrationNumber, photo, bodyNumber, engineNumber, techPassportNumber, dateCreating, dateRegistration, 
                  dateInspection, color, description)
        {
            TheftDate = theftDate;
            StatementDate = statementDate;
            InsuranceType = insuranceType;
            Circumstances = circumstances;
            MarkAboutFinding = markAboutFinding;
            InspectorId = inspectorId;
            CarId = carId;
        }
        //public new int Id { get; set; }
        public DateTime StatementDate { get; set; }
        public string InsuranceType { get; set; }
        public string Circumstances { get; set; }
        public bool MarkAboutFinding { get; set; }
        public DateTime TheftDate { get; set; }
        /// <summary>
        /// Gets or sets foreign key with inspector ID for DB TrafficPoliceOfficers
        /// </summary>
        public int? InspectorId { get; set; }
        /// <summary>
        /// Navigation property for DB TrafficPoliceOfficers
        /// </summary>
        public TrafficPoliceOfficer Inspector { get; set; }
        /// <summary>
        /// Gets or sets foreign key with car ID for DB Cars
        /// </summary>
        public int? CarId { get; set; }
        /// <summary>
        /// Navigation property for DB Cars
        /// </summary>
        public Car Car { get; set; }
    }
}
