using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.ModelServices;

/// <summary>
/// Интерфейс сервиса организации
/// </summary>
public interface IOrganizationService : IBaseEntityService<OrganizationModel, OrganizationBaseModel>, IGetEntityModelPage<OrganizationModel, OrganizationSortBy>
{
    /// <summary>
    /// Получает организацию по названию
    /// </summary>
    Task<OrganizationModel?> GetByNameAsync(string name, CancellationToken token);
}
