using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;

/// <summary>
/// Читает <see cref="PurchaseForm"/> из репозитория
/// </summary>
public interface IPurchaseFormReadRepository : IReadRepository<PurchaseForm>, IGetEntityPage<PurchaseForm, PurchaseFormSortBy>
{
    /// <summary>
    /// Получает закупочный акт по коду фрмы
    /// </summary>
    Task<PurchaseForm?> GetByFormKeyAsync(Guid formKeyId, CancellationToken token);

    /// <summary>
    /// Получает закупочный акт со всеми связями
    /// </summary>
    Task<PurchaseForm?> GetWithAllLinksAsync(Guid id, CancellationToken token);

    /// <summary>
    /// Получает все закупочные акты с их связями
    /// </summary>
    Task<List<PurchaseForm>> GetAllWithAllLinksAsync(CancellationToken token);
}
