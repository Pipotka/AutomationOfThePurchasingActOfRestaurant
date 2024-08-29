using AutomationOfThePurchasingActOfRestaurant.DBConfigurations;
using AutomationOfThePurchasingActOfRestaurant.Models;
using Microsoft.EntityFrameworkCore;
namespace AutomationOfThePurchasingActOfRestaurant
{
    public class PurchasingDbContext : DbContext
    {
        public DbSet<PurchaseForm> purchaseForms {  get; set; }
        public DbSet<Approver> Approvers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }
        public DbSet<FormKey> FormKeys { get; set; }
        public DbSet<MeasurementUnit> MeasurementUnits { get; set; }
        public DbSet<Merchandise> Merchandises { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Signature> Signatures { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<MerchandisePrice> MerchandisePrices { get; set; }

        public PurchasingDbContext(DbContextOptions<PurchasingDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApproverConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeePositionConfiguration());
            modelBuilder.ApplyConfiguration(new FormKeyConfiguration());
            modelBuilder.ApplyConfiguration(new MeasurementUnitConfiguration());
            modelBuilder.ApplyConfiguration(new MerchandiseConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseFormConfiguration());
            modelBuilder.ApplyConfiguration(new SignatureConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            modelBuilder.ApplyConfiguration(new MerchandisePriceConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
