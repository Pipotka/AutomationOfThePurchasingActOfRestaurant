using AutomationOfThePurchasingActOfRestaurant.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomationOfThePurchasingActOfRestaurant.DBConfigurations
{
    public class MerchandiseConfiguration : IEntityTypeConfiguration<Merchandise>
    {
        public void Configure(EntityTypeBuilder<Merchandise> builder)
        {
            builder.HasKey(m => m.MerchandiseId);

            builder.HasMany(m => m.PurchaseForms)
                .WithMany(p => p.PurchasedMerchandises);
            builder.HasOne(m => m.MeasurementUnit)
                .WithMany(mu => mu.Merchandises)
                .HasForeignKey(m => m.MeasurementUnitId);
            builder.HasMany(m => m.Prices)
                .WithOne(pr => pr.Merchandise)
                .HasForeignKey(mp => mp.MerchandiseId);
        }
    }
}
