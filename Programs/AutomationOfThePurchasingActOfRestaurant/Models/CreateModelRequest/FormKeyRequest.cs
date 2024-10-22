using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;
using Newtonsoft.Json;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Models.CreateModelRequest;

/// <summary>
/// Модель запроса кода формы
/// </summary>
public class FormKeyRequest
{
    /// <summary>
    /// <see cref="PurchaseFormRequest"/> Id
    /// </summary>
    public Guid? PurchaseFormId { get; set; }
    /// <summary>
    /// <inheritdoc cref="FormKeyBaseModel.PurchaseForm" path="/summary"/>
    /// </summary>
    [JsonProperty(Required = Required.AllowNull)]
    public PurchaseFormResponseModel? PurchaseForm { get; set; }
    /// <summary>
    /// <inheritdoc cref="FormKeyBaseModel.OKUD" path="/summary"/>
    /// </summary>
    public string OKUD { get; set; }
    /// <summary>
    /// <inheritdoc cref="FormKeyBaseModel.OKPO" path="/summary"/>
    /// </summary>
    public string OKPO { get; set; }
    /// <summary>
    /// <inheritdoc cref="FormKeyBaseModel.TIN" path="/summary"/>
    /// </summary>
    public string TIN { get; set; }
    /// <summary>
    /// <inheritdoc cref="FormKeyBaseModel.OKDP" path="/summary"/>
    /// </summary>
    public string OKDP { get; set; }
}
