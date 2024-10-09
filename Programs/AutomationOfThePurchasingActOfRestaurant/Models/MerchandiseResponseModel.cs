using Company.AutomationOfThePurchasingActOfRestaurant.Models.CreateModelRequest;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Models;

/// <summary>
/// Модель ответа по товару для API
/// </summary>
public class MerchandiseResponseModel
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// <inheritdoc cref="MerchandiseRequest.PurchaseForms" path="/summary"/>
    /// </summary>
    public ICollection<PurchaseFormResponseModel> PurchaseForms { get; set; } = new List<PurchaseFormResponseModel>();
    /// <summary>
    /// <inheritdoc cref="MerchandiseRequest.Name" path="/summary"/>
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// <inheritdoc cref="MerchandiseRequest.MerchandiseKey" path="/summary"/>
    /// </summary>
    public int MerchandiseKey { get; set; }
    /// <summary>
    /// <see cref="MeasurementUnitResponseModel"/> Id
    /// </summary>
    public Guid MeasurementUnitId { get; set; }
    /// <summary>
    /// <inheritdoc cref="MerchandiseRequest.MeasurementUnit" path="/summary"/>
    /// </summary>
    public MeasurementUnitResponseModel MeasurementUnit { get; set; }
    /// <summary>
    /// <inheritdoc cref="MerchandiseRequest.Count" path="/summary"/>
    /// </summary>
    public int Count { get; set; }
    /// <summary>
    /// <inheritdoc cref="MerchandiseRequest.Prices" path="/summary"/>
    /// </summary>
    public ICollection<MerchandisePriceResponseModel> Prices { get; set; }
}
