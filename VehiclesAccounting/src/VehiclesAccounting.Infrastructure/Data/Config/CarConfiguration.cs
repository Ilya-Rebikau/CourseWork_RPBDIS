using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehiclesAccounting.Core.ProjectAggregate;

namespace VehiclesAccounting.Infrastructure.Data.Config;

/// <summary>
/// Configurations for class Car and table Cars
/// </summary>
internal class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.Property(c => c.Color).IsRequired().HasMaxLength(30);
        builder.Property(c => c.Description).IsRequired();
        builder.Property(c => c.BodyNumber).IsRequired().HasMaxLength(20);
        builder.Property(c => c.RegistrationNumber).IsRequired().HasMaxLength(15);
        builder.Property(c => c.TechPassportNumber).IsRequired().HasMaxLength(15);
        builder.Property(c => c.EngineNumber).IsRequired().HasMaxLength(20);
    }
}
