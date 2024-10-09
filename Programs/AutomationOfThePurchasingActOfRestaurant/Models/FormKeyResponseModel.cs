
using Company.AutomationOfThePurchasingActOfRestaurant.Models.CreateModelRequest;
using Newtonsoft.Json;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Models;

/// <summary>
/// Модель ответа по коду формы для API
/// </summary>
public class FormKeyResponseModel
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// <see cref="PurchaseFormResponseModel"/> Id
    /// </summary>
    public Guid? PurchaseFormId { get; set; }
    /// <summary>
    /// <inheritdoc cref="FormKeyRequest.PurchaseForm" path="/summary"/>
    /// </summary>
    [JsonProperty(Required = Required.AllowNull)]
    public PurchaseFormResponseModel? PurchaseForm { get; set; }
    /// <summary>
    /// <inheritdoc cref="FormKeyFormKeyRequestBaseModel.OKUD" path="/summary"/>
    /// </summary>
    public string OKUD { get; set; }
    /// <summary>
    /// <inheritdoc cref="FormKeyRequest.OKPO" path="/summary"/>
    /// </summary>
    public string OKPO { get; set; }
    /// <summary>
    /// <inheritdoc cref="FormKeyRequest.TIN" path="/summary"/>
    /// </summary>
    public string TIN { get; set; }
    /// <summary>
    /// <inheritdoc cref="FormKeyRequest.OKDP" path="/summary"/>
    /// </summary>
    public string OKDP { get; set; }
}
