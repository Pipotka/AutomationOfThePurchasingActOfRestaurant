using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context
{
    /// <summary>
    /// Контекст БД
    /// </summary>
    public class PurchasingContext : DbContext, IDbReader, IDbWriter, IUnitOfWork
    {
        /// <summary>
        /// 
        /// </summary>
        public PurchasingContext(DbContextOptions<PurchasingContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PurchasingFormAnchor).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        IQueryable<TEntity> IDbReader.Read<TEntity>()
            => base.Set<TEntity>()
            .AsNoTracking().AsQueryable();

        void IDbWriter.Add<TEntity>(TEntity entity)
            => base.Entry(entity).State = EntityState.Added;

        void IDbWriter.Update<TEntity>(TEntity entity)
            => base.Entry(entity).State = EntityState.Modified;

        void IDbWriter.Delete<TEntity>(TEntity entity)
            => base.Entry(entity).State = EntityState.Deleted;
    }
}
