using AutomationOfThePurchasingActOfRestaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomationOfThePurchasingActOfRestaurant.Repositories
{
    /// <summary>
    /// Репозиторий Поставщиков
    /// </summary>
    public class SuppliersRepository
    {
        private readonly PurchasingDbContext dbContext;

        public SuppliersRepository(PurchasingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Получает поставщика по индентификатору
        /// </summary>
        public async Task<Supplier> GetAsync(Guid id, CancellationToken token)
        {
            var supplier = await dbContext.Suppliers
                .AsNoTracking()
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync(token);

            return supplier;
        }

        /// <summary>
        /// Получает всех поставщиков
        /// </summary>
        public async Task<List<Supplier>> GetAllAsync(CancellationToken token)
        {
            var suppliers = await dbContext.Suppliers
                .AsNoTracking()
                .ToListAsync(token);

            return suppliers;
        }

        /// <summary>
        /// Добавляет поставщика в БД
        /// </summary>
        public async Task CreateAsync(Supplier supplier, CancellationToken token)
        {
            dbContext.Suppliers.Add(supplier);
            await dbContext
                .SaveChangesAsync(token);
        }

        /// <summary>
        /// Проверяет существует ли поставщик в БД
        /// </summary>
        /// <returns>
        /// Если поставщик существует,
        /// то возвращает <c>True</c>, иначе <c>False</c>
        /// </returns>
        public bool IsExist(Supplier supplier)
        {
            var isExist = dbContext.Suppliers
                .Where(s => s.Equals(supplier)) == null
                ? false : true;

            return isExist;
        }

        /// <summary>
        /// Проверяет существует ли поставщик c <paramref name="id"/> в БД
        /// </summary>
        /// <param name="id">
        /// Id поставщика, который нуждается в проверке
        /// </param>
        /// <returns>
        /// Если поставщик существует,
        /// то возвращает <c>True</c>, иначе <c>False</c>
        /// </returns>
        public async Task<bool> IsExistByIdAsync(Guid id, CancellationToken token)
        {
            var result = await GetAsync(id, token);
            var isExist = result == null ? false : true;

            return isExist;
        }

        /// <summary>
        /// Изменяет поставщика
        /// </summary>
        /// <param name="updatedSupplier">
        /// Изменённый поставщик
        /// </param>
        public async Task EditAsync(Supplier updatedSupplier, CancellationToken token)
        {
            var oldSupplier = await dbContext.Suppliers
                .FirstOrDefaultAsync(s =>
                s.Id == updatedSupplier.Id, token);

            oldSupplier.PurchaseForms = updatedSupplier.PurchaseForms;
            oldSupplier.FirstName = updatedSupplier.FirstName;
            oldSupplier.LastName = updatedSupplier.LastName;
            oldSupplier.Patronymic = updatedSupplier.Patronymic;

            dbContext.Suppliers.Update(oldSupplier);

            await dbContext.SaveChangesAsync(token);
        }

        /// <summary>
        /// Удаляет поставщика по индентификатору
        /// </summary>
        public async Task DeleteAsync(Guid id, CancellationToken token)
        {
            var removableSupplier = await dbContext.Suppliers
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync(token);

            dbContext.Suppliers.Remove(removableSupplier);

            await dbContext.SaveChangesAsync(token);
        }
    }
}
