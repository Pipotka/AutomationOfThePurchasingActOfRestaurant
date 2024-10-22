using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Configurations.EntityConfigurations;

public class ApproverConfiguration : IEntityTypeConfiguration<Approver>
{
    public void Configure(EntityTypeBuilder<Approver> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasMany(a => a.PurchaseForms)
            .WithOne(p => p.ApprovingOfficer)
            .HasForeignKey(p => p.ApprovingOfficerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.Position)
            .WithMany(p => p.Approvers)
            .HasForeignKey(a => a.PositionId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
