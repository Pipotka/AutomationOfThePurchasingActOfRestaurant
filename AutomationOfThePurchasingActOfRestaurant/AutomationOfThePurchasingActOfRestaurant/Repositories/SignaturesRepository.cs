using AutomationOfThePurchasingActOfRestaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomationOfThePurchasingActOfRestaurant.Repositories
{
    /// <summary>
    /// Репозиторий Подписей
    /// </summary>
    public class SignaturesRepository
    {
        private readonly PurchasingDbContext dbContext;

        public SignaturesRepository(PurchasingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Получает подпись по идентификатору
        /// </summary>
        public async Task<Signature> GetAsync(Guid id, CancellationToken token)
        {
            var signature = await dbContext.Signatures
                .AsNoTracking()
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync(token);

            return signature;
        }

        /// <summary>
        /// Получает все подписи
        /// </summary>
        public async Task<List<Signature>> GetAllAsync(CancellationToken token)
        {
            var signatures = await dbContext.Signatures
                .AsNoTracking()
                .ToListAsync(token);

            return signatures;
        }

        /// <summary>
        /// Добавляет подпись в БД
        /// </summary>
        public async Task CreateAsync(Signature signature, CancellationToken token)
        {
            dbContext.Signatures.Add(signature);
            await dbContext
                .SaveChangesAsync(token);
        }

        /// <summary>
        /// Проверяет существует ли подпись в БД
        /// </summary>
        /// <returns>
        /// Если подпись существует,
        /// то возвращает <c>True</c>, иначе <c>False</c>
        /// </returns>
        public bool IsExist(Signature signature)
        {
            var isExist = dbContext.Signatures
                .Where(s => s.Equals(signature)) == null
                ? false : true;

            return isExist;
        }

        /// <summary>
        /// Проверяет существует ли подпись с <paramref name="id"/> в БД
        /// </summary>
        /// <param name="id">
        /// Id подписи, которая нуждается в проверке
        /// </param>
        /// <returns>
        /// Если подпись существует,
        /// то возвращает <c>True</c>, иначе <c>False</c>
        /// </returns>
        public async Task<bool> IsExistByIdAsync(Guid id, CancellationToken token)
        {
            var result = await GetAsync(id, token);
            var isExist = result == null ? false : true;

            return isExist;
        }

        /// <summary>
        /// Изменяет подпись
        /// </summary>
        /// <param name="updatedSignature">
        /// Изменённая подпись
        /// </param>
        public async Task EditAsync(Signature updatedSignature, CancellationToken token)
        {
            var oldSignature = await dbContext.Signatures
                .FirstOrDefaultAsync(s =>
                s.Id == updatedSignature.Id, token);

            oldSignature.SignatureDecryption = updatedSignature.SignatureDecryption;
            oldSignature.ApproverId = updatedSignature.ApproverId;
            oldSignature.IsObsolete = updatedSignature.IsObsolete;
            oldSignature.Points = updatedSignature.Points;

            dbContext.Signatures.Update(oldSignature);

            await dbContext.SaveChangesAsync(token);
        }

        /// <summary>
        /// Удаляет подпись по идентификатору
        /// </summary>
        public async Task DeleteAsync(Guid id, CancellationToken token)
        {
            var removableSignature = await dbContext.Signatures
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync(token);

            dbContext.Signatures.Remove(removableSignature);

            await dbContext.SaveChangesAsync(token);
        }
    }
}
