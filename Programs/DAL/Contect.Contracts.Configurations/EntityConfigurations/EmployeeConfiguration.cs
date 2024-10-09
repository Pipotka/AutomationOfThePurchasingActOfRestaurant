using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Configurations.EntityConfigurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasMany(e => e.PurchaseForms)
            .WithOne(p => p.ProcurementSpecialist)
            .HasForeignKey(p => p.ProcurementSpecialistId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.Position)
            .WithMany(ep => ep.Employees)
            .HasForeignKey(e => e.PositionId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
