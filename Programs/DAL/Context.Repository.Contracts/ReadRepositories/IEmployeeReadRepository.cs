using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;

/// <summary>
/// Читает <see cref="Employee"/> из репозитория
/// </summary>
public interface IEmployeeReadRepository : IReadRepository<Employee>, IGetEntityPage<Employee, EmployeeSortBy>
{
    /// <summary>
    /// Получает сотрудника по фамилии
    /// </summary>
    Task<Employee?> GetByLastNameAsync(string lastName, CancellationToken token);
    /// <summary>
    /// Получает список всех сотрудников с их связями
    /// </summary>
    Task<List<Employee>> GetAllWithLinksAsync(CancellationToken token);
}