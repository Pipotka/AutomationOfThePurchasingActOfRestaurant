using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;

/// <summary>
/// Читает <see cref="MeasurementUnit"/> из репозитория
/// </summary>
public interface IMeasurementUnitReadRepository : IReadRepository<MeasurementUnit>
{
    /// <summary>
    /// Получает единицу измерения по названию
    /// </summary>
    Task<MeasurementUnit?> GetByNameAsync(string name, CancellationToken token);
    /// <summary>
    /// Получает единицу измерения по ОКЕИ 
    /// </summary>
    Task<MeasurementUnit?> GetByOKEIKeyAsync(string OKEIKey, CancellationToken token);
}
