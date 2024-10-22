using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.ModelServices;

/// <summary>
/// Интерфейс сервиса единицы измерения
/// </summary>
public interface IMeasurementUnitService : IBaseEntityService<MeasurementUnitModel, MeasurementUnitBaseModel>
{
    /// <summary>
    /// Получает единицу измерения по названию
    /// </summary>
    Task<MeasurementUnitModel?> GetByNameAsync(string name, CancellationToken token);
    /// <summary>
    /// Получает единицу измерения по ОКЕИ 
    /// </summary>
    Task<MeasurementUnitModel?> GetByOKEIKeyAsync(string OKEIKey, CancellationToken token);
}
