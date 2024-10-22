
using Company.AutomationOfThePurchasingActOfRestaurant.Models.CreateModelRequest;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Models;

/// <summary>
/// Модель ответа по единице измерения для API
/// </summary>
public class MeasurementUnitResponseModel
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// <inheritdoc cref="MeasurementUnitRequest.Name" path="/summary"/>
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// <inheritdoc cref="MeasurementUnitRequest.OKEIKey" path="/summary"/>
    /// </summary>
    public string OKEIKey { get; set; }
}
