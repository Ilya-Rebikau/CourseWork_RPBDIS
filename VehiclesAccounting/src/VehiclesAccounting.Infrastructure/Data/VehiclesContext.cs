using Microsoft.EntityFrameworkCore;
using VehiclesAccounting.Core.ProjectAggregate;
using VehiclesAccounting.Infrastructure.Data.Config;

namespace VehiclesAccounting.Infrastructure.Data
{
    /// <summary>
    /// Class of vehicles context
    /// </summary>
    public class VehiclesContext : DbContext
    {
        /// <summary>
        /// Constructor of class VehiclesContext
        /// </summary>
        public VehiclesContext()
        { }
        /// <summary>
        /// Counstructor of class VehiclesContext
        /// Creating database if it not exists
        /// </summary>
        /// <param name="options">Options for context</param>
        public VehiclesContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
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
}
