using AutomationOfThePurchasingActOfRestaurant.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomationOfThePurchasingActOfRestaurant.DBConfigurations
{
    public class ApproverConfiguration : IEntityTypeConfiguration<Approver>
    {
        public void Configure(EntityTypeBuilder<Approver> builder)
        {
            builder.HasKey(a => a.ApproverId);

            builder.HasMany(a => a.PurchaseForms)
                .WithOne(p => p.ApprovingOfficer)
                .HasForeignKey(p => p.ApprovingOfficerId);
            builder.HasMany(a => a.Signatures)
                .WithOne(s => s.Approver)
                .HasForeignKey(s => s.ApproverId);
            builder.HasOne(a => a.Position)
                .WithMany(p => p.Approvers)
                .HasForeignKey(a => a.PositionId);
        }
    }
}
