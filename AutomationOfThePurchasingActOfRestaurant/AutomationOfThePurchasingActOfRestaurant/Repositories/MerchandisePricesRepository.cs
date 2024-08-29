using AutomationOfThePurchasingActOfRestaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomationOfThePurchasingActOfRestaurant.Repositories
{
    /// <summary>
    /// Репозиторий Цен на товары
    /// </summary>
    public class MerchandisePricesRepository
    {
        private readonly PurchasingDbContext dbContext;

        public MerchandisePricesRepository(PurchasingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Получает цену товара по индентификатору
        /// </summary>
        public async Task<MerchandisePrice> GetAsync(Guid id, CancellationToken token)
        {
            var merchandisePrice = await dbContext.MerchandisePrices
                .AsNoTracking()
                .Where(mp => mp.Id == id)
                .FirstOrDefaultAsync(token);

            return merchandisePrice;
        }

        /// <summary>
        /// Получает все цены на товары
        /// </summary>
        public async Task<List<MerchandisePrice>> GetAllAsync(CancellationToken token)
        {
            var merchandisePrices = await dbContext.MerchandisePrices
                .AsNoTracking()
                .ToListAsync(token);

            return merchandisePrices;
        }

        /// <summary>
        /// Добавляет цену товара в БД
        /// </summary>
        public async Task CreateAsync(MerchandisePrice merchandisePrice, CancellationToken token)
        {
            dbContext.MerchandisePrices.Add(merchandisePrice);
            await dbContext
                .SaveChangesAsync(token);
        }

        /// <summary>
        /// Проверяет существует ли цена товара в БД
        /// </summary>
        /// <returns>
        /// Если цена товара существует,
        /// то возвращает <c>True</c>, иначе <c>False</c>
        /// </returns>
        public bool IsExist(MerchandisePrice merchandisePrice)
        {
            var isExist = dbContext.MerchandisePrices
                .Where(mp => mp.Equals(merchandisePrice)) == null
                ? false : true;

            return isExist;
        }

        /// <summary>
        /// Проверяет существует ли цена товара c <paramref name="id"/> в БД
        /// </summary>
        /// <param name="id">
        /// Id цены товара, которая нуждается в проверке
        /// </param>
        /// <returns>
        /// Если цена товара существует,
        /// то возвращает <c>True</c>, иначе <c>False</c>
        /// </returns>
        public async Task<bool> IsExistByIdAsync(Guid id, CancellationToken token)
        {
            var result = await GetAsync(id, token);
            var isExist = result == null ? false : true;

            return isExist;
        }

        /// <summary>
        /// Изменяет цену товара
        /// </summary>
        /// <param name="updatedMerchandisePrice">
        /// Изменённая цена товара
        /// </param>
        public async Task EditAsync(MerchandisePrice updatedMerchandisePrice, CancellationToken token)
        {
            var oldMerchandisePrice = await dbContext.MerchandisePrices
                .FirstOrDefaultAsync(mp =>
                mp.Id == updatedMerchandisePrice.Id, token);

            oldMerchandisePrice.PurchaseForms = updatedMerchandisePrice.PurchaseForms;
            oldMerchandisePrice.MerchandiseId = updatedMerchandisePrice.MerchandiseId;
            oldMerchandisePrice.CostPerUnit = updatedMerchandisePrice.CostPerUnit;

            dbContext.MerchandisePrices.Update(oldMerchandisePrice);

            await dbContext.SaveChangesAsync(token);
        }

        /// <summary>
        /// Удаляет цену товара по индентификатору
        /// </summary>
        public async Task DeleteAsync(Guid id, CancellationToken token)
        {
            var removableMerchandisePrice = await dbContext.MerchandisePrices
                .Where(mp => mp.Id == id)
                .FirstOrDefaultAsync(token);

            dbContext.MerchandisePrices.Remove(removableMerchandisePrice);

            await dbContext.SaveChangesAsync(token);
        }
    }
}
