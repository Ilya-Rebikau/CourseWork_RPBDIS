using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehiclesAccounting.Core.ProjectAggregate;

namespace VehiclesAccounting.Infrastructure.Data.Config
{
    /// <summary>
    /// Configurations for class TrafficPoliceOfficer and table TrafficPoliceOfficers
    /// </summary>
    public class OfficerConfiguration : IEntityTypeConfiguration<TrafficPoliceOfficer>
    {
        public void Configure(EntityTypeBuilder<TrafficPoliceOfficer> builder)
        {
            builder.Property(tpo => tpo.Name).IsRequired().HasMaxLength(50);
            builder.Property(tpo => tpo.Surname).IsRequired().HasMaxLength(50);
            builder.Property(tpo => tpo.Patronymic).IsRequired().HasMaxLength(50);
            builder.Property(tpo => tpo.Post).IsRequired().HasMaxLength(50);
        }
    }
}
