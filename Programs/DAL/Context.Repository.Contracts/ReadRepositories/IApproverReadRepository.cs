using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;

/// <summary>
/// Читает <see cref="Approver"/> из репозитория
/// </summary>
public interface IApproverReadRepository : IReadRepository<Approver>, IGetEntityPage<Approver, ApproverSortBy>
{
    /// <summary>
    /// Получает утверждающего по фамилии
    /// </summary>
    Task<Approver?> GetByLastNameAsync(string lastName, CancellationToken token);
    /// <summary>
    /// Получает список всех утверждающих с их связями
    /// </summary>
    Task<List<Approver>> GetAllWithAllLinksAsync(CancellationToken token);
}
