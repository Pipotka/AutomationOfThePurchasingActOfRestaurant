using AutomationOfThePurchasingActOfRestaurant.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomationOfThePurchasingActOfRestaurant.DBConfigurations
{
    public class MeasurementUnitConfiguration : IEntityTypeConfiguration<MeasurementUnit>
    {
        public void Configure(EntityTypeBuilder<MeasurementUnit> builder)
        {
            builder.HasKey(mu => mu.Id);

            builder.HasMany(mu => mu.Merchandises)
                .WithOne(m => m.MeasurementUnit)
                .HasForeignKey(m => m.MeasurementUnitId);
        }
    }
}
