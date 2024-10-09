using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Configurations.EntityConfigurations;

public class PurchaseFormConfiguration : IEntityTypeConfiguration<PurchaseForm>
{
    public void Configure(EntityTypeBuilder<PurchaseForm> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.FormKey)
            .WithOne(f => f.PurchaseForm)
            .HasForeignKey<PurchaseForm>(p => p.FormKeyId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.SponsorOrganization)
            .WithMany(o => o.PurchaseForms)
            .HasForeignKey(p => p.SponsorOrganizationId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.ApprovingOfficer)
            .WithMany(a => a.PurchaseForms)
            .HasForeignKey(p => p.ApprovingOfficerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(pf => pf.OfficerSignature)
            .WithMany(s => s.purchaseForms)
            .HasForeignKey(p => p.OfficerSignatureId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.ProcurementSpecialist)
            .WithMany(pr => pr.PurchaseForms)
            .HasForeignKey(p => p.ProcurementSpecialistId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.Salesman)
            .WithMany(s => s.PurchaseForms)
            .HasForeignKey(p => p.SalesmanId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(p => p.PurchasedMerchandises)
            .WithMany(m => m.PurchaseForms);

        builder.HasMany(p => p.Prices)
            .WithMany(mp => mp.PurchaseForms);

        builder.HasOne(pf => pf.OfficerSignature)
            .WithMany(s => s.purchaseForms);
    }
}
