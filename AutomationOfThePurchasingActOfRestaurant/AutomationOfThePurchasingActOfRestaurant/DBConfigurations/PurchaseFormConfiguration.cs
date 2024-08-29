using AutomationOfThePurchasingActOfRestaurant.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomationOfThePurchasingActOfRestaurant.DBConfigurations
{
    public class PurchaseFormConfiguration : IEntityTypeConfiguration<PurchaseForm>
    {
        public void Configure(EntityTypeBuilder<PurchaseForm> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.FormKey)
                .WithOne(f => f.PurchaseForm)
                .HasForeignKey<PurchaseForm>(p => p.FormKeyId);
            builder.HasOne(p => p.SponsorOrganization)
                .WithMany(o => o.PurchaseForms)
                .HasForeignKey(p => p.SponsorOrganizationId);
            builder.HasOne(p => p.ApprovingOfficer)
                .WithMany(a => a.PurchaseForms)
                .HasForeignKey(p => p.ApprovingOfficerId);
            builder.HasOne(p => p.ProcurementSpecialist)
                .WithMany(pr => pr.PurchaseForms)
                .HasForeignKey(p => p.ProcurementSpecialistId);
            builder.HasOne(p => p.Salesman)
                .WithMany(s => s.PurchaseForms)
                .HasForeignKey(p => p.SalesmanId);
            builder.HasMany(p => p.PurchasedMerchandises)
                .WithMany(m => m.PurchaseForms);
            builder.HasMany(p => p.Prices)
                .WithMany(mp => mp.PurchaseForms);
        }
    }
}
