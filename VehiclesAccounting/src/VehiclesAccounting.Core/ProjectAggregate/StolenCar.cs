using VehiclesAccounting.Core.Interfaces;

namespace VehiclesAccounting.Core.ProjectAggregate
{
    /// <summary>
    /// Class of stolen cars
    /// </summary>
    public class StolenCar : IEntity
    {
        /// <summary>
        /// Constructor of class StolenCar
        /// </summary
        /// <param name="theftDate">Date when car was stolen</param>
        /// <param name="statementDate">Date when statement was written</param>
        /// <param name="insuranceType">Type of insurance</param>
        /// <param name="circumstances">Circumstances of theft</param>
        /// <param name="markAboutFinding">Mark about was car found or not</param>
        /// <param name="inspectorId">ID of inspector</param>
        /// <param name="carId">ID of car</param>
        public StolenCar(DateTime theftDate, DateTime statementDate, string insuranceType,
                   string circumstances, bool markAboutFinding, int? inspectorId, int? carId)
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
        public int Id { get; set; }
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
        public TrafficPoliceOfficer? Inspector { get; set; }
        /// <summary>
        /// Gets or sets foreign key with car ID for DB Cars
        /// </summary>
        public int? CarId { get; set; }
        /// <summary>
        /// Navigation property for DB Cars
        /// </summary>
        public Car? Car { get; set; }
    }
}
