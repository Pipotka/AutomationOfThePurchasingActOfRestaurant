using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;

/// <summary>
/// Читает <see cref="Organization"/> из репозитория
/// </summary>
public interface IOrganizationReadRepository : IReadRepository<Organization>, IGetEntityPage<Organization, OrganizationSortBy>
{
    /// <summary>
    /// Получает организацию по названию
    /// </summary>
    Task<Organization?> GetByNameAsync(string name, CancellationToken token);
}