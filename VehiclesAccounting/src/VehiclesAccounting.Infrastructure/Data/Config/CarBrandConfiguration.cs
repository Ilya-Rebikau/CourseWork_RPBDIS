using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehiclesAccounting.Core.ProjectAggregate;

namespace VehiclesAccounting.Infrastructure.Data.Config
{
    /// <summary>
    /// Configurations for class CarBrand and table CarBrands
    /// </summary>
    internal class CarBrandConfiguration : IEntityTypeConfiguration<CarBrand>
    {
        public void Configure(EntityTypeBuilder<CarBrand> builder)
        {
            builder.Property(b => b.Name).IsRequired().HasMaxLength(50);
            builder.Property(b => b.Producer).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Country).IsRequired().HasMaxLength(50);
            builder.Property(b => b.Characteristics).IsRequired();
            builder.Property(b => b.Category).IsRequired().HasMaxLength(20);
            builder.Property(b => b.Description).IsRequired();
        }
    }
}
