using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;

/// <summary>
/// Читает <see cref="Signature"/> из репозитория
/// </summary>
public interface ISignatureReadRepository : IReadRepository<Signature>
{
    /// <summary>
    /// Получает подпись по Id утверждающего
    /// </summary>
    Task<Signature?> GetByApproverIdAsync(Guid approverId, CancellationToken token);
}
