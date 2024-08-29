using AutomationOfThePurchasingActOfRestaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomationOfThePurchasingActOfRestaurant.Repositories
{
    /// <summary>
    /// Репозиторий Кодов формы
    /// </summary>
    public class FormKeysRepository
    {
        private readonly PurchasingDbContext dbContext;

        public FormKeysRepository(PurchasingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Получает код формы по индентификатору
        /// </summary>
        public async Task<FormKey> GetAsync(Guid id, CancellationToken token)
        {
            var formKey = await dbContext.FormKeys
                .AsNoTracking()
                .Where(f => f.Id == id)
                .FirstOrDefaultAsync(token);

            return formKey;
        }

        /// <summary>
        /// Получает все коды формы
        /// </summary>
        public async Task<List<FormKey>> GetAllAsync(CancellationToken token)
        {
            var formKeys = await dbContext.FormKeys
                .AsNoTracking()
                .ToListAsync(token);

            return formKeys;
        }

        /// <summary>
        /// Добавляет код формы в БД
        /// </summary>
        public async Task CreateAsync(FormKey formKey, CancellationToken token)
        {
            dbContext.FormKeys.Add(formKey);
            await dbContext
                .SaveChangesAsync(token);
        }

        /// <summary>
        /// Проверяет существует ли код формы в БД
        /// </summary>
        /// <returns>
        /// Если код формы существует,
        /// то возвращает <c>True</c>, иначе <c>False</c>
        /// </returns>
        public bool IsExist(FormKey formKey)
        {
            var isExist = dbContext.FormKeys
                .Where(f => f.Equals(formKey)) == null
                ? false : true;

            return isExist;
        }

        /// <summary>
        /// Проверяет существует ли код формы c <paramref name="id"/> в БД
        /// </summary>
        /// <param name="id">
        /// Id кода формы, который нуждается в проверке
        /// </param>
        /// <returns>
        /// Если код формы существует,
        /// то возвращает <c>True</c>, иначе <c>False</c>
        /// </returns>
        public async Task<bool> IsExistByIdAsync(Guid id, CancellationToken token)
        {
            var result = await GetAsync(id, token);
            var isExist = result == null ? false : true;

            return isExist;
        }

        /// <summary>
        /// Изменяет код формы
        /// </summary>
        /// <param name="updatedFormKey">
        /// Изменённый код формы
        /// </param>
        public async Task EditAsync(FormKey updatedFormKey, CancellationToken token)
        {
            var oldFormKey = await dbContext.FormKeys
                .FirstOrDefaultAsync(f =>
                f.Id == updatedFormKey.Id, token);

            oldFormKey.PurchaseFormId = updatedFormKey.PurchaseFormId;
            oldFormKey.OKDP = updatedFormKey.OKDP;
            oldFormKey.TIN = updatedFormKey.TIN;
            oldFormKey.OKUD = updatedFormKey.OKUD;
            oldFormKey.OKPO = updatedFormKey.OKPO;

            dbContext.FormKeys.Update(oldFormKey);

            await dbContext.SaveChangesAsync(token);
        }

        /// <summary>
        /// Удаляет код формы по индентификатору
        /// </summary>
        public async Task DeleteAsync(Guid id, CancellationToken token)
        {
            var removableFurchaseForm = await dbContext.FormKeys
                .Where(f => f.Id == id)
                .FirstOrDefaultAsync(token);

            dbContext.FormKeys.Remove(removableFurchaseForm);

            await dbContext.SaveChangesAsync(token);
        }
    }
}
