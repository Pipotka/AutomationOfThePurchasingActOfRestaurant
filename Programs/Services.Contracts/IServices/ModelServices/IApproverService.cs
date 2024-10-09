using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.ModelServices;

/// <summary>
/// Интерфейс сервиса утверждающего
/// </summary>
public interface IApproverService : IBaseEntityService<ApproverModel, ApproverBaseModel>, IGetEntityModelPage<ApproverModel, ApproverSortBy>
{
    /// <summary>
    /// Получает утверждающего по фамилии
    /// </summary>
    Task<ApproverModel?> GetByLastNameAsync(string lastName, CancellationToken token);
}