using AutomationOfThePurchasingActOfRestaurant.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomationOfThePurchasingActOfRestaurant.DBConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(e => e.PurchaseForms)
                .WithOne(p => p.ProcurementSpecialist)
                .HasForeignKey(p => p.ProcurementSpecialistId);
            builder.HasOne(e => e.Position)
                .WithMany(ep => ep.Employees)
                .HasForeignKey(e => e.PositionId);
        }
    }
}
