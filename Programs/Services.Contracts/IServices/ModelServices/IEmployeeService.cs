using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.ModelServices;

/// <summary>
/// Интерфейс сервиса сотрудника
/// </summary>
public interface IEmployeeService : IBaseEntityService<EmployeeModel, EmployeeBaseModel>, IGetEntityModelPage<EmployeeModel, EmployeeSortBy>
{
    /// <summary>
    /// Получает сотрудника по фамилии
    /// </summary>
    Task<EmployeeModel?> GetByLastNameAsync(string lastName, CancellationToken token);
}
