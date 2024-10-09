using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;

/// <summary>
/// Читает <see cref="MerchandisePrice"/> из репозитория
/// </summary>
public interface IMerchandisePriceReadRepository : IReadRepository<MerchandisePrice>
{
    /// <summary>
    /// Получает цены товара по Id товара
    /// </summary>
    Task<List<MerchandisePrice>> GetByMerchandiseIdAsync(Guid MerchendiseId, CancellationToken token);
}