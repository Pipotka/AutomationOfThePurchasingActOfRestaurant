using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.ModelServices;

/// <summary>
/// Интерфейс сервиса товаров
/// </summary>
public interface IMerchandiseService : IBaseEntityService<MerchandiseModel, MerchandiseBaseModel>, IGetEntityModelPage<MerchandiseModel, MerchandiseSortBy>
{
    /// <summary>
    /// Получает продукта по названию
    /// </summary>
    Task<MerchandiseModel?> GetByNameAsync(string name, CancellationToken token);

    /// <summary>
    /// Возвращает все товары с их связями
    /// </summary>
    Task<List<MerchandiseModel>> GetAllWithLinksAsync(CancellationToken token);
}
