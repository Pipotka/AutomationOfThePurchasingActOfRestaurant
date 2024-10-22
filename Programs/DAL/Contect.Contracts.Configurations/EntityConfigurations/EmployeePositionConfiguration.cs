using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Configurations.EntityConfigurations;

public class EmployeePositionConfiguration : IEntityTypeConfiguration<EmployeePosition>
{
    public void Configure(EntityTypeBuilder<EmployeePosition> builder)
    {
        builder.HasKey(ep => ep.Id);

        builder.HasMany(ep => ep.Approvers)
            .WithOne(a => a.Position)
            .HasForeignKey(a => a.PositionId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(ep => ep.Employees)
            .WithOne(e => e.Position)
            .HasForeignKey(e => e.PositionId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
