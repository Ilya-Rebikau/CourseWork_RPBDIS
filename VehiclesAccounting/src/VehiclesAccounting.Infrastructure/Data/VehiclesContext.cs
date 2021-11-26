using Microsoft.EntityFrameworkCore;
using VehiclesAccounting.Core.ProjectAggregate;
using VehiclesAccounting.Infrastructure.Data.Config;

namespace VehiclesAccounting.Infrastructure.Data;

/// <summary>
/// Vehicles context
/// </summary>
public class VehiclesContext : DbContext
{
    /// <summary>
    /// Counstructor of class
    /// </summary>
    /// <param name="options">DbContextOptions object</param>
    public VehiclesContext(DbContextOptions<VehiclesContext> options) : base(options)
    {
    }
    /// <summary>
    /// Constructor of class
    /// </summary>
    public VehiclesContext()
    { }
    /// <summary>
    /// Gets or sets DbSet of car owners
    /// </summary>
    public DbSet<Owner> Owners { get; set; }
    /// <summary>
    /// Gets or sets DbSet of traffic police officers
    /// </summary>
    public DbSet<TrafficPoliceOfficer> TrafficPoliceOfficers { get; set; }
    /// <summary>
    /// Gets or sets DbSet of car brands
    /// </summary>
    public DbSet<CarBrand> CarBrands { get; set; }
    /// <summary>
    /// Gets or sets DbSet of cars
    /// </summary>
    public DbSet<Car> Cars { get; set; }
    /// <summary>
    /// Gets or sets DbSet of stolen cars
    /// </summary>
    public DbSet<StolenCar> StolenCars { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CarConfiguration());
        modelBuilder.ApplyConfiguration(new CarBrandConfiguration());
        modelBuilder.ApplyConfiguration(new OwnerConfiguration());
        modelBuilder.ApplyConfiguration(new StolenCarConfiguration());
        modelBuilder.ApplyConfiguration(new OfficerConfiguration());
    }
}
