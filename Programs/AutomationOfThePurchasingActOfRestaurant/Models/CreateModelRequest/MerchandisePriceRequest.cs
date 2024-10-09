using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;
using Newtonsoft.Json;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Models.CreateModelRequest;

/// <summary>
/// Модель запроса цены товара
/// </summary>
public class MerchandisePriceRequest
{
    /// <summary>
    /// <inheritdoc cref="MerchandisePriceBaseModel.PurchaseForms" path="/summary"/>
    /// </summary>
    public ICollection<PurchaseFormResponseModel> PurchaseForms { get; set; } = new List<PurchaseFormResponseModel>();
    /// <summary>
    /// <see cref="MerchandiseRequest"/> Id
    /// </summary>
    public Guid? MerchandiseId { get; set; }
    /// <summary>
    /// <inheritdoc cref="MerchandisePriceBaseModel.Merchandise" path="/summary"/>
    /// </summary>
    [JsonProperty(Required = Required.AllowNull)]
    public MerchandiseResponseModel? Merchandise { get; set; }
    /// <summary>
    /// <inheritdoc cref="MerchandisePriceBaseModel.CostPerUnit" path="/summary"/>
    /// </summary>
    public double CostPerUnit { get; set; }
}
