using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Configurations.EntityConfigurations;

public class FormKeyConfiguration : IEntityTypeConfiguration<FormKey>
{
    public void Configure(EntityTypeBuilder<FormKey> builder)
    {
        builder.HasKey(f => f.Id);

        builder.HasOne(f => f.PurchaseForm)
            .WithOne(p => p.FormKey)
            .HasForeignKey<FormKey>(f => f.PurchaseFormId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
