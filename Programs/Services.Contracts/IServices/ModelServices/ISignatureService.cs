using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.ModelServices;

/// <summary>
/// Интерфейс сервиса подписи
/// </summary>
public interface ISignatureService : IBaseEntityService<SignatureModel, SignatureBaseModel>
{
    /// <summary>
    /// Получает подпись по Id утверждающего
    /// </summary>
    Task<SignatureModel?> GetByApproverIdAsync(Guid approverId, CancellationToken token);
}
