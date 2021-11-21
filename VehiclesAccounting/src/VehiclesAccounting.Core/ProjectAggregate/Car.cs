using VehiclesAccounting.Core.Interfaces;

namespace VehiclesAccounting.Core.ProjectAggregate
{
    /// <summary>
    /// Class of car
    /// </summary>
    public class Car : IEntity
    {
        /// <summary>
        /// Constructor of class Car
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
        public Car(string registrationNumber, byte[] photo, string bodyNumber, string engineNumber,
                   string techPassportNumber, DateTime dateCreating, DateTime dateRegistration, DateTime dateInspection,
                   string color, string description)
        {
            RegistrationNumber = registrationNumber;
            Photo = photo;
            BodyNumber = bodyNumber;
            EngineNumber = engineNumber;
            TechPassportNumber = techPassportNumber;
            DateCreating = dateCreating;
            DateRegistration = dateRegistration;
            DateInspection = dateInspection;
            Color = color;
            Description = description;
        }
        /// <summary>
        /// Constructor of class car
        /// </summary>
        public Car()
        { }
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets registration number of car
        /// </summary>
        public string RegistrationNumber { get; set; }
        /// <summary>
        /// Gets or sets photo of car
        /// </summary>
        public byte[] Photo { get; set; }
        /// <summary>
        /// Gets or sets number of car's body
        /// </summary>
        public string BodyNumber { get; set; }
        /// <summary>
        /// Gets or sets engine's number
        /// </summary>
        public string EngineNumber { get; set; }
        /// <summary>
        /// Gets or sets technical passport's number
        /// </summary>
        public string TechPassportNumber { get; set; }
        /// <summary>
        /// Gets or sets car's creating date
        /// </summary>
        public DateTime DateCreating { get; set; }
        /// <summary>
        /// Gets or sets car's registration date
        /// </summary>
        public DateTime DateRegistration { get; set; }
        /// <summary>
        /// Gets or sets last car's technical inspection date
        /// </summary>
        public DateTime DateInspection { get; set; }
        /// <summary>
        /// Gets or sets color
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// Gets or sets description about car
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets foreign key with owner ID for DB Owners
        /// </summary>
        public int OwnerId { get; set; }
        /// <summary>
        /// Navigation property for DB Owners
        /// </summary>
        public Owner Owner { get; set; }
        /// <summary>
        /// Gets or sets foreign key with traffic police officer ID for DB TrafficPoliceOfficers
        /// </summary>
        public int TrafficPoliceOfficerId { get; set; }
        /// <summary>
        /// Navigation property for DB TrafficPoliceOfficers
        /// </summary>
        public TrafficPoliceOfficer TrafficPoliceOfficer { get; set; }
        /// <summary>
        /// Gets or sets foreign key with car brand ID for DB CarBrands
        /// </summary>
        public int CarBrandId { get; set; }
        /// <summary>
        /// Navigation property for DB CarBrands
        /// </summary>
        public CarBrand CarBrand { get; set; }
        /// <summary>
        /// Navigation property for DB StolenCars
        /// </summary>
        public List<StolenCar> StolenCars { get; set; }
    }
}
