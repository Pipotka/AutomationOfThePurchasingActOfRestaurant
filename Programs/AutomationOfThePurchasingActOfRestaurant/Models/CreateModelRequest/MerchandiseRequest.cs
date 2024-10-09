using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Models.CreateModelRequest;

/// <summary>
/// Модель запроса товара
/// </summary>
public class MerchandiseRequest
{
    /// <summary>
    /// <inheritdoc cref="MerchandiseBaseModel.PurchaseForms" path="/summary"/>
    /// </summary>
    public ICollection<PurchaseFormResponseModel> PurchaseForms { get; set; } = new List<PurchaseFormResponseModel>();
    /// <summary>
    /// <inheritdoc cref="MerchandiseBaseModel.Name" path="/summary"/>
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// <inheritdoc cref="MerchandiseBaseModel.MerchandiseKey" path="/summary"/>
    /// </summary>
    public int MerchandiseKey { get; set; }
    /// <summary>
    /// <see cref="MeasurementUnitRequest"/> Id
    /// </summary>
    public Guid MeasurementUnitId { get; set; }
    /// <summary>
    /// <inheritdoc cref="MerchandiseBaseModel.MeasurementUnit" path="/summary"/>
    /// </summary>
    public MeasurementUnitResponseModel MeasurementUnit { get; set; }
    /// <summary>
    /// <inheritdoc cref="MerchandiseBaseModel.Count" path="/summary"/>
    /// </summary>
    public int Count { get; set; }
    /// <summary>
    /// <inheritdoc cref="MerchandiseBaseModel.Prices" path="/summary"/>
    /// </summary>
    public ICollection<MerchandisePriceResponseModel> Prices { get; set; }
}
