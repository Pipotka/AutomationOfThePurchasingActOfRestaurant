using AutomationOfThePurchasingActOfRestaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomationOfThePurchasingActOfRestaurant.Repositories
{
    /// <summary>
    /// Репозиторий Товаров
    /// </summary>
    public class MerchandiseRepository
    {
        private readonly PurchasingDbContext dbContext;

        public MerchandiseRepository(PurchasingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Получает товар по индентификатору
        /// </summary>
        public async Task<Merchandise> GetAsync(Guid id, CancellationToken token)
        {
            var merchandise = await dbContext.Merchandises
                .AsNoTracking()
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync(token);

            return merchandise;
        }

        /// <summary>
        /// Получает все товары
        /// </summary>
        public async Task<List<Merchandise>> GetAllAsync(CancellationToken token)
        {
            var merchandiseList = await dbContext.Merchandises
                .AsNoTracking()
                .ToListAsync(token);

            return merchandiseList;
        }

        /// <summary>
        /// Добавляет товар в БД
        /// </summary>
        public async Task CreateAsync(Merchandise merchandise, CancellationToken token)
        {
            dbContext.Merchandises.Add(merchandise);
            await dbContext
                .SaveChangesAsync(token);
        }

        /// <summary>
        /// Проверяет существует ли товар в БД
        /// </summary>
        /// <returns>
        /// Если товар существует,
        /// то возвращает <c>True</c>, иначе <c>False</c>
        /// </returns>
        public bool IsExist(Merchandise merchandise)
        {
            var isExist = dbContext.Merchandises
                .Where(m => m.Equals(merchandise)) == null
                ? false : true;

            return isExist;
        }

        /// <summary>
        /// Проверяет существует ли товар c <paramref name="id"/> в БД
        /// </summary>
        /// <param name="id">
        /// Id товара, который нуждается в проверке
        /// </param>
        /// <returns>
        /// Если товар существует,
        /// то возвращает <c>True</c>, иначе <c>False</c>
        /// </returns>
        public async Task<bool> IsExistByIdAsync(Guid id, CancellationToken token)
        {
            var result = await GetAsync(id, token);
            var isExist = result == null ? false : true;

            return isExist;
        }

        /// <summary>
        /// Изменяет товар
        /// </summary>
        /// <param name="updatedMerchandise">
        /// Изменённый товар
        /// </param>
        public async Task EditAsync(Merchandise updatedMerchandise, CancellationToken token)
        {
            var oldMerchandise = await dbContext.Merchandises
                .FirstOrDefaultAsync(m =>
                m.Id == updatedMerchandise.Id, token);

            oldMerchandise.PurchaseForms = updatedMerchandise.PurchaseForms;
            oldMerchandise.MerchandiseKey = updatedMerchandise.MerchandiseKey;
            oldMerchandise.Prices = updatedMerchandise.Prices;
            oldMerchandise.Count = updatedMerchandise.Count;
            oldMerchandise.MeasurementUnitId = updatedMerchandise.MeasurementUnitId;
            oldMerchandise.Name = updatedMerchandise.Name;

            dbContext.Merchandises.Update(oldMerchandise);

            await dbContext.SaveChangesAsync(token);
        }

        /// <summary>
        /// Удаляет товар по индентификатору
        /// </summary>
        public async Task DeleteAsync(Guid id, CancellationToken token)
        {
            var removableMerchandise = await dbContext.Merchandises
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync(token);

            dbContext.Merchandises.Remove(removableMerchandise);

            await dbContext.SaveChangesAsync(token);
        }
    }
}
