using Company.AutomationOfThePurchasingActOfRestaurant.Models.CreateModelRequest;
using Newtonsoft.Json;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Models;

/// <summary>
/// Модель ответа по цене товара для API
/// </summary>
public class MerchandisePriceResponseModel
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// <inheritdoc cref="MerchandisePriceRequest.PurchaseForms" path="/summary"/>
    /// </summary>
    public ICollection<PurchaseFormResponseModel> PurchaseForms { get; set; } = new List<PurchaseFormResponseModel>();
    /// <summary>
    /// <see cref="Merchandise"/> Id
    /// </summary>
    public Guid? MerchandiseId { get; set; }
    /// <summary>
    /// <inheritdoc cref="MerchandisePriceRequest.Merchandise" path="/summary"/>
    /// </summary>
    [JsonProperty(Required = Required.AllowNull)]
    public MerchandiseResponseModel? Merchandise { get; set; }
    /// <summary>
    /// <inheritdoc cref="MerchandisePriceRequest.CostPerUnit" path="/summary"/>
    /// </summary>
    public double CostPerUnit { get; set; }
}
