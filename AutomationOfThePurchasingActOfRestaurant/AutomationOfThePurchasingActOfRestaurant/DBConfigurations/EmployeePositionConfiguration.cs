using AutomationOfThePurchasingActOfRestaurant.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomationOfThePurchasingActOfRestaurant.DBConfigurations
{
    public class EmployeePositionConfiguration : IEntityTypeConfiguration<EmployeePosition>
    {
        public void Configure(EntityTypeBuilder<EmployeePosition> builder)
        {
            builder.HasKey(ep => ep.EmployeePositionId);

            builder.HasMany(ep => ep.Approvers)
                .WithOne(a => a.Position)
                .HasForeignKey(a => a.PositionId);
            builder.HasMany(ep => ep.Employees)
                .WithOne(e => e.Position)
                .HasForeignKey(e => e.PositionId);
        }
    }
}
