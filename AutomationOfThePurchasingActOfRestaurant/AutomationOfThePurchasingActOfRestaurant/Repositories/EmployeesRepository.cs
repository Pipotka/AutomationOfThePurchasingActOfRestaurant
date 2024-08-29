using AutomationOfThePurchasingActOfRestaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomationOfThePurchasingActOfRestaurant.Repositories
{
    /// <summary>
    /// Репозиторий Сотрудников
    /// </summary>
    public class EmployeesRepository
    {
        private readonly PurchasingDbContext dbContext;

        public EmployeesRepository(PurchasingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Получает сотрудника по индентификатору
        /// </summary>
        public async Task<Employee> GetAsync(Guid id, CancellationToken token)
        {
            var employee = await dbContext.Employees
                .AsNoTracking()
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync(token);

            return employee;
        }

        /// <summary>
        /// Получает всех сотрудников
        /// </summary>
        public async Task<List<Employee>> GetAllAsync(CancellationToken token)
        {
            var employees = await dbContext.Employees
                .AsNoTracking()
                .ToListAsync(token);

            return employees;
        }

        /// <summary>
        /// Добавляет сотрудника в БД
        /// </summary>
        public async Task CreateAsync(Employee employee, CancellationToken token)
        {
            dbContext.Employees.Add(employee);
            await dbContext
                .SaveChangesAsync(token);
        }

        /// <summary>
        /// Проверяет существует ли сотрудник в БД
        /// </summary>
        /// <returns>
        /// Если сотрудник существует,
        /// то возвращает <c>True</c>, иначе <c>False</c>
        /// </returns>
        public bool IsExist(Employee employee)
        {
            var isExist = dbContext.Employees
                .Where(e => e.Equals(employee)) == null
                ? false : true;

            return isExist;
        }

        /// <summary>
        /// Проверяет существует ли сотрудник c <paramref name="id"/> в БД
        /// </summary>
        /// <param name="id">
        /// Id сотрудника, который нуждается в проверке
        /// </param>
        /// <returns>
        /// Если сотрудник существует,
        /// то возвращает <c>True</c>, иначе <c>False</c>
        /// </returns>
        public async Task<bool> IsExistByIdAsync(Guid id, CancellationToken token)
        {
            var result = await GetAsync(id, token);
            var isExist = result == null ? false : true;

            return isExist;
        }

        /// <summary>
        /// Изменяет сотрудника
        /// </summary>
        /// <param name="updatedEmployee">
        /// Изменённый сотрудник
        /// </param>
        public async Task EditAsync(Employee updatedEmployee, CancellationToken token)
        {
            var oldEmployee = await dbContext.Employees
                .FirstOrDefaultAsync(e =>
                e.Id == updatedEmployee.Id, token);

            oldEmployee.FirstName = updatedEmployee.FirstName;
            oldEmployee.LastName = updatedEmployee.LastName;
            oldEmployee.Patronymic = updatedEmployee.Patronymic;
            oldEmployee.PositionId = updatedEmployee.PositionId;
            oldEmployee.PurchaseForms = updatedEmployee.PurchaseForms;

            dbContext.Employees.Update(oldEmployee);

            await dbContext.SaveChangesAsync(token);
        }

        /// <summary>
        /// Удаляет сотрудника по индентификатору
        /// </summary>
        public async Task DeleteAsync(Guid id, CancellationToken token)
        {
            var removableEmployee = await dbContext.Employees
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync(token);

            dbContext.Employees.Remove(removableEmployee);

            await dbContext.SaveChangesAsync(token);
        }
    }
}
