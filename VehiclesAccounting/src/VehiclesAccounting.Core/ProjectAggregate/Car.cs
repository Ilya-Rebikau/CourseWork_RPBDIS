using VehiclesAccounting.Core.Interfaces;

namespace VehiclesAccounting.Core.ProjectAggregate;

/// <summary>
/// Car
/// </summary>
public class Car : IEntity
{
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets registration number of car
    /// </summary>
    public string RegistrationNumber { get; set; }
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
    public int? OwnerId { get; set; }
    /// <summary>
    /// Navigation property for DB Owners
    /// </summary>
    public Owner? Owner { get; set; }
    /// <summary>
    /// Gets or sets foreign key with traffic police officer ID for DB TrafficPoliceOfficers
    /// </summary>
    public int? TrafficPoliceOfficerId { get; set; }
    /// <summary>
    /// Navigation property for DB TrafficPoliceOfficers
    /// </summary>
    public TrafficPoliceOfficer? TrafficPoliceOfficer { get; set; }
    /// <summary>
    /// Gets or sets foreign key with car brand ID for DB CarBrands
    /// </summary>
    public int? CarBrandId { get; set; }
    /// <summary>
    /// Navigation property for DB CarBrands
    /// </summary>
    public CarBrand? CarBrand { get; set; }
    /// <summary>
    /// Navigation property for DB StolenCars
    /// </summary>
    public List<StolenCar>? StolenCars { get; set; }
}
