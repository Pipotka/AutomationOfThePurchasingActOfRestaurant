using AutomationOfThePurchasingActOfRestaurant.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomationOfThePurchasingActOfRestaurant.DBConfigurations
{
    public class FormKeyConfiguration : IEntityTypeConfiguration<FormKey>
    {
        public void Configure(EntityTypeBuilder<FormKey> builder)
        {
            builder.HasKey(f => f.Id);

            builder.HasOne(f => f.PurchaseForm)
                .WithOne(p => p.FormKey)
                .HasForeignKey<FormKey>(f => f.PurchaseFormId);
        }
    }
}
