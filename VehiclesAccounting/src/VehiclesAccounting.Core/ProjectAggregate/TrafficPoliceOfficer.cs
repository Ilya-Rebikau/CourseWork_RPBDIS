using VehiclesAccounting.Core.Interfaces;

namespace VehiclesAccounting.Core.ProjectAggregate;

/// <summary>
/// Traffic police officer
/// </summary>
public class TrafficPoliceOfficer : IEntity
{
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets name
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Gets or sets surname
    /// </summary>
    public string Surname { get; set; }
    /// <summary>
    /// Gets or sets patronymic
    /// </summary>
    public string Patronymic { get; set; }
    /// <summary>
    /// Gets or sets birthday
    /// </summary>
    public DateTime Birthday { get; set; }
    /// <summary>
    /// Gets or sets post
    /// </summary>
    public string Post { get; set; }
    /// <summary>
    /// Navigation property for DB Cars
    /// </summary>
    public List<Car>? Cars { get; set; }
    /// <summary>
    /// Navigation property for DB StolenCars
    /// </summary>
    public List<StolenCar>? StolenCars { get; set; }
}
