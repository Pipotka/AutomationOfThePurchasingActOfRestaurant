using AutomationOfThePurchasingActOfRestaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomationOfThePurchasingActOfRestaurant.Repositories
{
    /// <summary>
    /// Репозиторий Организаций
    /// </summary>
    public class OrganizationsRepository
    {
        private readonly PurchasingDbContext dbContext;

        public OrganizationsRepository(PurchasingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Получает организацию по индентификатору
        /// </summary>
        public async Task<Organization> GetAsync(Guid id, CancellationToken token)
        {
            var organization = await dbContext.Organizations
                .AsNoTracking()
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync(token);

            return organization;
        }

        /// <summary>
        /// Получает все организации
        /// </summary>
        public async Task<List<Organization>> GetAllAsync(CancellationToken token)
        {
            var organizations = await dbContext.Organizations
                .AsNoTracking()
                .ToListAsync(token);

            return organizations;
        }

        /// <summary>
        /// Добавляет организацию в БД
        /// </summary>
        public async Task CreateAsync(Organization organization, CancellationToken token)
        {
            dbContext.Organizations.Add(organization);
            await dbContext
                .SaveChangesAsync(token);
        }

        /// <summary>
        /// Проверяет существует ли организация в БД
        /// </summary>
        /// <returns>
        /// Если организация существует,
        /// то возвращает <c>True</c>, иначе <c>False</c>
        /// </returns>
        public bool IsExist(Organization organization)
        {
            var isExist = dbContext.Organizations
                .Where
                (o => o.Equals(organization)) == null
                ? false : true;

            return isExist;
        }

        /// <summary>
        /// Проверяет существует ли организация c <paramref name="id"/> в БД
        /// </summary>
        /// <param name="id">
        /// Id организации, которая нуждается в проверке
        /// </param>
        /// <returns>
        /// Если организация существует,
        /// то возвращает <c>True</c>, иначе <c>False</c>
        /// </returns>
        public async Task<bool> IsExistByIdAsync(Guid id, CancellationToken token)
        {
            var result = await GetAsync(id, token);
            var isExist = result == null ? false : true;

            return isExist;
        }

        /// <summary>
        /// Изменяет организацию
        /// </summary>
        /// <param name="updatedOrganization">
        /// Изменённый организация
        /// </param>
        public async Task EditAsync(Organization updatedOrganization, CancellationToken token)
        {
            var oldOrganization = await dbContext.Organizations
                .FirstOrDefaultAsync(o =>
                o.Id == updatedOrganization.Id, token);

            oldOrganization.StructuralUnit = updatedOrganization.StructuralUnit;
            oldOrganization.Name = updatedOrganization.Name;
            oldOrganization.PurchaseForms = updatedOrganization.PurchaseForms;
            oldOrganization.Address = updatedOrganization.Address;

            dbContext.Organizations.Update(oldOrganization);

            await dbContext.SaveChangesAsync(token);
        }

        /// <summary>
        /// Удаляет организацию по индентификатору
        /// </summary>
        public async Task DeleteAsync(Guid id, CancellationToken token)
        {
            var removableOrganization = await dbContext.Organizations
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync(token);

            dbContext.Organizations.Remove(removableOrganization);

            await dbContext.SaveChangesAsync(token);
        }
    }
}
