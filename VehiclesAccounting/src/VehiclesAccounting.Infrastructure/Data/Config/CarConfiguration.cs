using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehiclesAccounting.Core.ProjectAggregate;

namespace VehiclesAccounting.Infrastructure.Data.Config
{
    /// <summary>
    /// Configurations for class Car and table Cars
    /// </summary>
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");
            builder.Property(c => c.Color).IsRequired().HasMaxLength(30);
            builder.Property(c => c.Description).IsRequired();
            builder.Property(c => c.Photo).IsRequired();
        }
    }
}
