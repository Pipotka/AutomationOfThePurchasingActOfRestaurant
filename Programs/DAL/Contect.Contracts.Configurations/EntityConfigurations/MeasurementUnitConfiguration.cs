using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Configurations.EntityConfigurations;

public class MeasurementUnitConfiguration : IEntityTypeConfiguration<MeasurementUnit>
{
    public void Configure(EntityTypeBuilder<MeasurementUnit> builder)
    {
        builder.HasKey(mu => mu.Id);

        builder.HasMany(mu => mu.Merchandises)
            .WithOne(m => m.MeasurementUnit)
            .HasForeignKey(m => m.MeasurementUnitId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
