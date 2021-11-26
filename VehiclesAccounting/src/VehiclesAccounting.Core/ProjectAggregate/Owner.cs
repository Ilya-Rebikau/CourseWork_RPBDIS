using VehiclesAccounting.Core.Interfaces;

namespace VehiclesAccounting.Core.ProjectAggregate;

/// <summary>
/// Owner
/// </summary>
public class Owner : IEntity
{
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets  name
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Gets or sets  surname
    /// </summary>
    public string Surname { get; set; }
    /// <summary>
    /// Gets or sets  patronymic
    /// </summary>
    public string Patronymic { get; set; }
    /// <summary>
    /// Gets or sets birthday
    /// </summary>
    public DateTime Birthday { get; set; }
    /// <summary>
    /// Gets or sets passport series and number
    /// </summary>
    public string PassportInfo { get; set; }
    /// <summary>
    /// Gets or sets number of drive license
    /// </summary>
    public string LicenseNumber { get; set; }
    /// <summary>
    /// Gets or sets date when owner got drive license
    /// </summary>
    public DateTime LicenseStart { get; set; }
    /// <summary>
    /// Gets or sets date when drive license will end
    /// </summary>
    public DateTime LicenseEnd { get; set; }
    /// <summary>
    /// Gets or sets driver's license categories
    /// </summary>
    public string Categories { get; set; }
    /// <summary>
    /// Gets or sets extra information about car owner
    /// </summary>
    public string ExtraInformation { get; set; }
    /// <summary>
    /// Navigation property for DB Cars
    /// </summary>
    public List<Car>? Cars { get; set; }
}
