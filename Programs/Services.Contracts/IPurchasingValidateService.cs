
namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts;

/// <summary>
/// Интрефейс валидации закупочных моделей
/// </summary>
public interface IPurchasingValidateService
{
    /// <summary>
    /// Валидация модели
    /// </summary>
    Task ValidateAsync<TModel>(TModel model, CancellationToken token) where TModel : class;
}
