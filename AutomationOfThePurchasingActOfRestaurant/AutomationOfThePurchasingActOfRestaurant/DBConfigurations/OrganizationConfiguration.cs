using AutomationOfThePurchasingActOfRestaurant.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomationOfThePurchasingActOfRestaurant.DBConfigurations
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.PurchaseForms)
                .WithOne(p => p.SponsorOrganization)
                .HasForeignKey(p => p.SponsorOrganizationId);
        }
    }
}
