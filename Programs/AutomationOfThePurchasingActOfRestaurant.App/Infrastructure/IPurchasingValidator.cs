namespace Company.AutomationOfThePurchasingActOfRestaurant.App.Infrastructure;

/// <summary>
/// Интрефейс валидации закупочных моделей
/// </summary>
public interface IPurchasingValidator
{
    /// <summary>
    /// Валидация модели
    /// </summary>
    Task ValidateAsync<TModel>(TModel model, CancellationToken token) where TModel : class;
}
