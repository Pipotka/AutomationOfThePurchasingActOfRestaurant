using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.ModelServices;

/// <summary>
/// Интерфейс сервиса должности сотрудника
/// </summary>
public interface IEmployeePositionService : IBaseEntityService<EmployeePositionModel, EmployeePositionBaseModel>, IGetEntityModelPage<EmployeePositionModel, EmployeePositionSortBy>
{
    /// <summary>
    /// Получает должность сотрудника по названию
    /// </summary>
    Task<EmployeePositionModel?> GetByNameAsync(string name, CancellationToken token);
}
