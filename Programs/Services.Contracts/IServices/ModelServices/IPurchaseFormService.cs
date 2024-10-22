using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.ModelServices;

/// <summary>
/// Интерфейс сервиса закупочного акта
/// </summary>
public interface IPurchaseFormService : IBaseEntityService<PurchaseFormModel, PurchaseFormBaseModel>, IGetEntityModelPage<PurchaseFormModel, PurchaseFormSortBy>
{
    /// <summary>
    /// Получает закупочный акт по коду фрмы
    /// </summary>
    Task<PurchaseFormModel?> GetByFormKeyAsync(Guid formKeyId, CancellationToken token);

    /// <summary>
    /// Возвращает все закупочный акт с их связями
    /// </summary>
    Task<List<PurchaseFormModel>> GetAllWithAllLinksAsync(CancellationToken token);
    /// <summary>
    /// Возвращает закупочный акт со всеми связями по Id
    /// </summary>
    Task<PurchaseFormModel> GetWithAllLinksAsync(Guid id, CancellationToken token);
}
