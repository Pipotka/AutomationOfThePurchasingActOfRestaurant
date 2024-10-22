using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Configurations.EntityConfigurations;

public class MerchandiseConfiguration : IEntityTypeConfiguration<Merchandise>
{
    public void Configure(EntityTypeBuilder<Merchandise> builder)
    {
        builder.HasKey(m => m.Id);

        builder.HasOne(m => m.PurchaseForm)
            .WithMany(p => p.PurchasedMerchandises)
            .HasForeignKey(m => m.PurchaseFormId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(m => m.MeasurementUnit)
            .WithMany(mu => mu.Merchandises)
            .HasForeignKey(m => m.MeasurementUnitId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
