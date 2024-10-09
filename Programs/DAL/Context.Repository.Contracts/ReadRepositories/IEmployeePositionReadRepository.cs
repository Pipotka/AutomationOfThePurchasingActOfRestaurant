using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;

/// <summary>
/// Читает <see cref="EmployeePosition"/> из репозитория
/// </summary>
public interface IEmployeePositionReadRepository : IReadRepository<EmployeePosition>, IGetEntityPage<EmployeePosition, EmployeePositionSortBy>
{
    /// <summary>
    /// Получает должность сотрудника по названию
    /// </summary>
    Task<EmployeePosition?> GetByNameAsync(string name, CancellationToken token);
}