using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;

/// <summary>
/// Читает <see cref="Merchandise"/> из репозитория
/// </summary>
public interface IMerchandiseReadRepository : IReadRepository<Merchandise>, IGetEntityPage<Merchandise, MerchandiseSortBy>
{
    /// <summary>
    /// Получает продукта по названию
    /// </summary>
    Task<Merchandise?> GetByNameAsync(string name, CancellationToken token);

    /// <summary>
    /// Получает все товары c сылками
    /// </summary>
    public Task<List<Merchandise>> GetAllWithLinksAsync(CancellationToken token);
}
