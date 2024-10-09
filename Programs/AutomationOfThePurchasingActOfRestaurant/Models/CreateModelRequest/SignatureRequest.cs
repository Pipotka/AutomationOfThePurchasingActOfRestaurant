using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;
using Newtonsoft.Json;
using System.Drawing;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Models.CreateModelRequest;

/// <summary>
/// Модель запроса подписи
/// </summary>
public class SignatureRequest
{
    /// <summary>
    /// <inheritdoc cref="SignatureBaseModel.purchaseForms" path="/summary"/>
    /// </summary>
    public ICollection<PurchaseFormResponseModel> purchaseForms { get; set; } = new List<PurchaseFormResponseModel>();
    /// <summary>
    /// <see cref="ApproverRequest"/> Id
    /// </summary>
    public Guid? ApproverId { get; set; }
    /// <summary>
    /// <inheritdoc cref="SignatureBaseModel.Approver" path="/summary"/>
    /// </summary>
    [JsonProperty(Required = Required.AllowNull)]
    public ApproverResponseModel? Approver { get; set; }
    /// <summary>
    /// <inheritdoc cref="SignatureBaseModel.Points" path="/summary"/>
    /// </summary>
    public Point[] Points { get; set; }
    /// <summary>
    /// <inheritdoc cref="SignatureBaseModel.SignatureDecryption" path="/summary"/>
    /// </summary>
    public string SignatureDecryption { get; set; }
}
