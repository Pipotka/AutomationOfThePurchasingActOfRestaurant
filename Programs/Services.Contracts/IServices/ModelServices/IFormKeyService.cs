using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.ModelServices;

/// <summary>
/// Интерфейс сервиса кода формы
/// </summary>
public interface IFormKeyService : IBaseEntityService<FormKeyModel, FormKeyBaseModel>, IGetEntityModelPage<FormKeyModel, FormKeySortBy>
{

}
