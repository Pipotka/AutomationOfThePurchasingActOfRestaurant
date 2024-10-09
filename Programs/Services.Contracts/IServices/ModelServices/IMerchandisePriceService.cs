using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.ModelServices;

/// <summary>
/// Интерфейс сервиса цены товара
/// </summary>
public interface IMerchandisePriceService : IBaseEntityService<MerchandisePriceModel, MerchandisePriceBaseModel>
{
    /// <summary>
    /// Получает цены товара по Id товара
    /// </summary>
    Task<List<MerchandisePriceModel>> GetByMerchandiseIdAsync(Guid MerchendiseId, CancellationToken token);
}
