using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Configurations.EntityConfigurations;

public class MerchandiseConfiguration : IEntityTypeConfiguration<Merchandise>
{
    public void Configure(EntityTypeBuilder<Merchandise> builder)
    {
        builder.HasKey(m => m.Id);

        builder.HasMany(m => m.PurchaseForms)
            .WithMany(p => p.PurchasedMerchandises);
        builder.HasOne(m => m.MeasurementUnit)
            .WithMany(mu => mu.Merchandises)
            .HasForeignKey(m => m.MeasurementUnitId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(m => m.Prices)
            .WithOne(pr => pr.Merchandise)
            .HasForeignKey(mp => mp.MerchandiseId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
