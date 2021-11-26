using VehiclesAccounting.Core.Interfaces;

namespace VehiclesAccounting.Core.ProjectAggregate;

/// <summary>
/// Stolen car
/// </summary>
public class StolenCar : IEntity
{
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
