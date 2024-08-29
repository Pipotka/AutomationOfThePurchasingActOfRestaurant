using AutomationOfThePurchasingActOfRestaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomationOfThePurchasingActOfRestaurant.Repositories
{
    /// <summary>
    /// Репозиторий Должностей сотрудников
    /// </summary>
    public class EmployeePositionsRepository
    {
        private readonly PurchasingDbContext dbContext;

        public EmployeePositionsRepository(PurchasingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Получает должность сотрудника по индентификатору
        /// </summary>
        public async Task<EmployeePosition> GetAsync(Guid id, CancellationToken token)
        {
            var employeePosition = await dbContext.EmployeePositions
                .AsNoTracking()
                .Where(ep => ep.Id == id)
                .FirstOrDefaultAsync(token);

            return employeePosition;
        }

        /// <summary>
        /// Получает все должности сотрудников
        /// </summary>
        public async Task<List<EmployeePosition>> GetAllAsync(CancellationToken token)
        {
            var employeePositions = await dbContext.EmployeePositions
                .AsNoTracking()
                .ToListAsync(token);

            return employeePositions;
        }

        /// <summary>
        /// Добавляет должность сотрудника в БД
        /// </summary>
        public async Task CreateAsync(EmployeePosition employeePosition, CancellationToken token)
        {
            dbContext.EmployeePositions.Add(employeePosition);
            await dbContext
                .SaveChangesAsync(token);
        }

        /// <summary>
        /// Проверяет существует ли должность сотрудника в БД
        /// </summary>
        /// <returns>
        /// Если должность сотрудника существует,
        /// то возвращает <c>True</c>, иначе <c>False</c>
        /// </returns>
        public bool IsExist(EmployeePosition employeePosition)
        {
            var isExist = dbContext.EmployeePositions
                .Where(ep => ep.Equals(employeePosition)) == null
                ? false : true;

            return isExist;
        }

        /// <summary>
        /// Проверяет существует ли должность сотрудника c <paramref name="id"/> в БД
        /// </summary>
        /// <param name="id">
        /// Id должности сотрудника, которая нуждается в проверке
        /// </param>
        /// <returns>
        /// Если должность сотрудника существует,
        /// то возвращает <c>True</c>, иначе <c>False</c>
        /// </returns>
        public async Task<bool> IsExistByIdAsync(Guid id, CancellationToken token)
        {
            var result = await GetAsync(id, token);
            var isExist = result == null ? false : true;

            return isExist;
        }

        /// <summary>
        /// Изменяет должность сотрудника
        /// </summary>
        /// <param name="updatedEmployeePosition">
        /// Изменённая должность сотрудника
        /// </param>
        public async Task EditAsync(EmployeePosition updatedEmployeePosition, CancellationToken token)
        {
            var oldEmployeePosition = await dbContext.EmployeePositions
                .FirstOrDefaultAsync(ep =>
                ep.Id == updatedEmployeePosition.Id, token);

            oldEmployeePosition.Approvers = updatedEmployeePosition.Approvers;
            oldEmployeePosition.Name = updatedEmployeePosition.Name;
            oldEmployeePosition.Employees = updatedEmployeePosition.Employees;

            dbContext.EmployeePositions.Update(oldEmployeePosition);

            await dbContext.SaveChangesAsync(token);
        }

        /// <summary>
        /// Удаляет должность сотрудника по индентификатору
        /// </summary>
        public async Task DeleteAsync(Guid id, CancellationToken token)
        {
            var removableEmployeePosition = await dbContext.EmployeePositions
                .Where(ep => ep.Id == id)
                .FirstOrDefaultAsync(token);

            dbContext.EmployeePositions.Remove(removableEmployeePosition);

            await dbContext.SaveChangesAsync(token);
        }
    }
}