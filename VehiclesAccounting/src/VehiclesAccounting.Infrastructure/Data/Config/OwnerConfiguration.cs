using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehiclesAccounting.Core.ProjectAggregate;

namespace VehiclesAccounting.Infrastructure.Data.Config
{
    /// <summary>
    /// Configurations for class Owner and table Owners
    /// </summary>
    internal class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.Property(o => o.Name).IsRequired().HasMaxLength(50);
            builder.Property(o => o.Surname).IsRequired().HasMaxLength(50);
            builder.Property(o => o.Patronymic).IsRequired().HasMaxLength(50);
            builder.Property(o => o.PassportInfo).IsRequired().HasMaxLength(500);
            builder.Property(o => o.Categories).IsRequired().HasMaxLength(20);
            builder.Property(o => o.ExtraInformation).IsRequired();
        }
    }
}
