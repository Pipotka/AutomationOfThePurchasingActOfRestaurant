using AutomationOfThePurchasingActOfRestaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomationOfThePurchasingActOfRestaurant.Repositories
{
    /// <summary>
    /// Репозиторий Утверждающих
    /// </summary>
    public class ApproversRepository
    {
        private readonly PurchasingDbContext dbContext;

        public ApproversRepository(PurchasingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Получает утверждающего по индентификатору
        /// </summary>
        public async Task<Approver> GetAsync(Guid id, CancellationToken token)
        {
            var approver = await dbContext.Approvers
                .AsNoTracking()
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync(token);

            return approver;
        }

        /// <summary>
        /// Получает всех утверждающих
        /// </summary>
        public async Task<List<Approver>> GetAllAsync(CancellationToken token)
        {
            var approvers = await dbContext.Approvers
                .AsNoTracking()
                .ToListAsync(token);

            return approvers;
        }

        /// <summary>
        /// Добавляет утверждающего в БД
        /// </summary>
        public async Task CreateAsync(Approver approver, CancellationToken token)
        {
            dbContext.Approvers.Add(approver);
            await dbContext
                .SaveChangesAsync(token);
        }

        /// <summary>
        /// Проверяет существует ли утверждающий в БД
        /// </summary>
        /// <returns>
        /// Если утверждающий существует,
        /// то возвращает <c>True</c>, иначе <c>False</c>
        /// </returns>
        public bool IsExist(Approver approver)
        {
            var isExist = dbContext.Approvers
                .Where(a => a.Equals(approver)) == null
                ? false : true;

            return isExist;
        }

        /// <summary>
        /// Проверяет существует ли утверждающий c <paramref name="id"/> в БД
        /// </summary>
        /// <param name="id">
        /// Id утверждающего, который нуждается в проверке
        /// </param>
        /// <returns>
        /// Если утверждающий существует,
        /// то возвращает <c>True</c>, иначе <c>False</c>
        /// </returns>
        public async Task<bool> IsExistByIdAsync(Guid id, CancellationToken token)
        {
            var result = await GetAsync(id, token);
            var isExist = result == null ? false : true;

            return isExist;
        }

        /// <summary>
        /// Изменяет утверждающего
        /// </summary>
        /// <param name="updatedApprover">
        /// Изменённый утверждающий
        /// </param>
        public async Task EditAsync(Approver updatedApprover, CancellationToken token)
        {
            var oldApprover = await dbContext.Approvers
                .FirstOrDefaultAsync(a =>
                a.Id == updatedApprover.Id, token);

            oldApprover.Signatures = updatedApprover.Signatures;
            oldApprover.PurchaseForms = updatedApprover.PurchaseForms;
            oldApprover.FirstName = updatedApprover.FirstName;
            oldApprover.LastName = updatedApprover.LastName;
            oldApprover.Patronymic = updatedApprover.Patronymic;
            oldApprover.PositionId = updatedApprover.PositionId;

            dbContext.Approvers.Update(oldApprover);

            await dbContext.SaveChangesAsync(token);
        }

        /// <summary>
        /// Удаляет утверждающего по индентификатору
        /// </summary>
        public async Task DeleteAsync(Guid id, CancellationToken token)
        {
            var removableApprover = await dbContext.Approvers
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync(token);

            dbContext.Approvers.Remove(removableApprover);

            await dbContext.SaveChangesAsync(token);
        }
    }
}
