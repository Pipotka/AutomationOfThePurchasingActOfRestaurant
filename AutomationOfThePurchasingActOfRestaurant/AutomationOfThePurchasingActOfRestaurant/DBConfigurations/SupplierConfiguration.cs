using AutomationOfThePurchasingActOfRestaurant.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomationOfThePurchasingActOfRestaurant.DBConfigurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasMany(s => s.PurchaseForms)
                .WithOne(p => p.Salesman)
                .HasForeignKey(p => p.SalesmanId);
        }
    }
}
