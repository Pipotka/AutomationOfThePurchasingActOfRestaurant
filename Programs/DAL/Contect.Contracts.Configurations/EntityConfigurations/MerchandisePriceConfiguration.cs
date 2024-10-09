using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Configurations.EntityConfigurations;

public class MerchandisePriceConfiguration : IEntityTypeConfiguration<MerchandisePrice>
{
    public void Configure(EntityTypeBuilder<MerchandisePrice> builder)
    {
        builder.HasKey(mp => mp.Id);

        builder.HasMany(mp => mp.PurchaseForms)
            .WithMany(p => p.Prices);
        builder.HasOne(pm => pm.Merchandise)
            .WithMany(m => m.Prices)
            .HasForeignKey(pm => pm.MerchandiseId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
