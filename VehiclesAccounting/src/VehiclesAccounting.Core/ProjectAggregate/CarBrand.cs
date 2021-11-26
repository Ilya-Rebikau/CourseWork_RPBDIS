using VehiclesAccounting.Core.Interfaces;

namespace VehiclesAccounting.Core.ProjectAggregate;

/// <summary>
///Car brand
/// </summary>
public class CarBrand : IEntity
{
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets name of car brand
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Gets or sets company-producer of car brand
    /// </summary>
    public string Producer { get; set; }
    /// <summary>
    /// Gets or sets country of car brand
    /// </summary>
    public string Country { get; set; }
    /// <summary>
    /// Gets or sets date of starting car brand producing
    /// </summary>
    public DateTime DateStart { get; set; }
    /// <summary>
    /// Gets or sets date of finishing car brand producing
    /// </summary>
    public DateTime DateFinish { get; set; }
    /// <summary>
    /// Gets or sets car brand characteristics
    /// </summary>
    public string Characteristics { get; set; }
    /// <summary>
    /// Gets or sets car brand category
    /// </summary>
    public string Category { get; set; }
    /// <summary>
    /// Gets or sets description of car brand
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Navigation property for DB Cars
    /// </summary>
    public List<Car>? Cars { get; set; }
}
