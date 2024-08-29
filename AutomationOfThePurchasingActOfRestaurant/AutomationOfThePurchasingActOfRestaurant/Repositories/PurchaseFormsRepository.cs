using AutomationOfThePurchasingActOfRestaurant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutomationOfThePurchasingActOfRestaurant.Repositories
{
    /// <summary>
    /// Репозиторий закупочных актов
    /// </summary>
    public class PurchaseFormsRepository
    {
        private readonly PurchasingDbContext dbContext;

        public PurchaseFormsRepository(PurchasingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Получает закупочный акт по индентификатору
        /// </summary>
        public async Task<PurchaseForm> GetAsync(Guid id, CancellationToken token)
        {
            var purchaseForm = await dbContext.purchaseForms
                .AsNoTracking()
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync(token);

            return purchaseForm;
        }

        /// <summary>
        /// Получает все закупочные акты
        /// </summary>
        public async Task<List<PurchaseForm>> GetAllAsync(CancellationToken token)
        {
            var purchaseForms = await dbContext.purchaseForms
                .AsNoTracking()
                .ToListAsync(token);

            return purchaseForms;
        }

        /// <summary>
        /// Добавляет закупочный акт в БД
        /// </summary>
        public async Task CreateAsync(PurchaseForm purchaseForm, CancellationToken token)
        {
            dbContext.purchaseForms.Add(purchaseForm);
            await dbContext
                .SaveChangesAsync(token);
        }

        /// <summary>
        /// Проверяет существует ли закупочный акт в БД
        /// </summary>
        /// <returns>
        /// Если закупочный акт существует,
        /// то возвращает <c>True</c>, иначе <c>False</c>
        /// </returns>
        public bool IsExist(PurchaseForm purchaseForm)
        {
            var isExist = dbContext.purchaseForms
                .Where
                (p => p.FormKey.Equals(purchaseForm.FormKey)) == null 
                ? false : true;

            return isExist;
        }

        /// <summary>
        /// Проверяет существует ли закупочный акт c <paramref name="id"/> в БД
        /// </summary>
        /// <param name="id">
        /// Id закупочного акта, который нуждается в проверке
        /// </param>
        /// <returns>
        /// Если закупочный акт существует,
        /// то возвращает <c>True</c>, иначе <c>False</c>
        /// </returns>
        public async Task<bool> IsExistByIdAsync(Guid id, CancellationToken token)
        {
            var result = await GetAsync(id, token);
            var isExist = result == null ? false : true;

            return isExist;
        }

        /// <summary>
        /// Изменяет закупочный акт
        /// </summary>
        /// <param name="updatedPurchaseForm">
        /// Изменённый закупочный акт
        /// </param>
        public async Task EditAsync(PurchaseForm updatedPurchaseForm, CancellationToken token)
        {
            var oldPurchaseForm = await dbContext.purchaseForms
                .FirstOrDefaultAsync(p => 
                p.Id == updatedPurchaseForm.Id, token);

            oldPurchaseForm.FormKeyId = updatedPurchaseForm.FormKeyId;
            oldPurchaseForm.SponsorOrganizationId = updatedPurchaseForm.SponsorOrganizationId;
            oldPurchaseForm.ApprovingOfficerId = updatedPurchaseForm.ApprovingOfficerId;
            oldPurchaseForm.DocumentNumber = updatedPurchaseForm.DocumentNumber;
            oldPurchaseForm.DocumentDate = updatedPurchaseForm.DocumentDate;
            oldPurchaseForm.AddressOfPurchase = updatedPurchaseForm.AddressOfPurchase;
            oldPurchaseForm.ProcurementSpecialistId = updatedPurchaseForm.ProcurementSpecialistId;
            oldPurchaseForm.SalesmanId = updatedPurchaseForm.SalesmanId;
            oldPurchaseForm.PurchasedMerchandises = updatedPurchaseForm.PurchasedMerchandises;
            oldPurchaseForm.Prices = updatedPurchaseForm.Prices;

            dbContext.purchaseForms.Update(oldPurchaseForm);

            await dbContext.SaveChangesAsync(token);
        }

        /// <summary>
        /// Удаляет закупочный акт по индентификатору
        /// </summary>
        public async Task DeleteAsync(Guid id, CancellationToken token)
        {
            var removableFurchaseForm = await dbContext.purchaseForms
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync(token);

            dbContext.purchaseForms.Remove(removableFurchaseForm);

            await dbContext.SaveChangesAsync(token);
        }
    }
}
