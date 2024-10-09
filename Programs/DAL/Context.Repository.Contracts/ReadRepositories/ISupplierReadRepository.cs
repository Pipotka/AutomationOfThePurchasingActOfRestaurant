using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;

/// <summary>
/// Читает <see cref="Supplier"/> из репозитория
/// </summary>
public interface ISupplierReadRepository : IReadRepository<Supplier>, IGetEntityPage<Supplier, SupplierSortBy>
{
    /// <summary>
    /// Получает постовщика по фамилии
    /// </summary>
    Task<Supplier?> GetByLastNameAsync(string lastName, CancellationToken token);
}
