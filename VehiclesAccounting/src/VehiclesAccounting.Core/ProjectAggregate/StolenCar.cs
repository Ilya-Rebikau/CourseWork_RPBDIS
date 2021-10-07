using System;
using VehiclesAccounting.Core.Interfaces;

namespace VehiclesAccounting.Core.ProjectAggregate
{
    /// <summary>
    /// Class of stolen cars
    /// </summary>
    public class StolenCar : Car, IEntity
    {
        /// <summary>
        /// Constructor of class StolenCar
        /// </summary>
        /// <param name="registrationNumber">Registration number of car</param>
        /// <param name="photo">Photo of car</param>
        /// <param name="bodyNumber">Number of car's body</param>
        /// <param name="engineNumber">Engine's number</param>
        /// <param name="techPassportNumber">Technical passport's number</param>
        /// <param name="dateCreating">Car's creating date</param>
        /// <param name="dateRegistration">Car's registration date</param>
        /// <param name="dateInspection">Last car's technical inspection date</param>
        /// <param name="color">Color</param>
        /// <param name="description">Description about car</param>
        /// <param name="theftDate">Date when car was stolen</param>
        /// <param name="statementDate">Date when statement was written</param>
        /// <param name="insuranceType">Type of insurance</param>
        /// <param name="circumstances">Circumstances of theft</param>
        /// <param name="markAboutFinding">Mark about was car found or not</param>
        /// <param name="inspectorId">ID of inspector</param>
        /// <param name="carId">ID of car</param>
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
        /// <summary>
        /// Constructor of class StolenCar
        /// </summary>
        public StolenCar()
        { }
        /// <summary>
        /// Gets or sets date when statement was written
        /// </summary>
        public DateTime StatementDate { get; set; }
        /// <summary>
        /// Gets or sets type of insurance
        /// </summary>
        public string InsuranceType { get; set; }
        /// <summary>
        /// Gets or sets Circumstances of theft
        /// </summary>
        public string Circumstances { get; set; }
        /// <summary>
        /// Gets or sets mark about was car found or not
        /// </summary>
        public bool MarkAboutFinding { get; set; }
        /// <summary>
        /// Gets or sets date when car was stolen
        /// </summary>
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
