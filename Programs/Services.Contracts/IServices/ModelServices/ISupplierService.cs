using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.ModelServices;

/// <summary>
/// Интерфейс сервиса поставщика
/// </summary>
public interface ISupplierService : IBaseEntityService<SupplierModel, SupplierBaseModel>, IGetEntityModelPage<SupplierModel, SupplierSortBy>
{
    /// <summary>
    /// Получает постовщика по фамилии
    /// </summary>
    Task<SupplierModel?> GetByLastNameAsync(string lastName, CancellationToken token);
}