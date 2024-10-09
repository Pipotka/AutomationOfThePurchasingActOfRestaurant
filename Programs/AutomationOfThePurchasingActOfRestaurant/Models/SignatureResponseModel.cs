using Company.AutomationOfThePurchasingActOfRestaurant.Models.CreateModelRequest;
using Newtonsoft.Json;
using System.Drawing;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Models;

/// <summary>
/// Модель ответа по утверждающему для API
/// </summary>
public class SignatureResponseModel
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// <inheritdoc cref="SignatureRequest.purchaseForms" path="/summary"/>
    /// </summary>
    public ICollection<PurchaseFormResponseModel> purchaseForms { get; set; } = new List<PurchaseFormResponseModel>();
    /// <summary>
    /// <see cref="ApproverResponseModel"/> Id
    /// </summary>
    public Guid? ApproverId { get; set; }
    /// <summary>
    /// <inheritdoc cref="SignatureRequest.Approver" path="/summary"/>
    /// </summary>
    [JsonProperty(Required = Required.AllowNull)]
    public ApproverResponseModel? Approver { get; set; }
    /// <summary>
    /// <inheritdoc cref="SignatureRequest.Points" path="/summary"/>
    /// </summary>
    public Point[] Points { get; set; }
    /// <summary>
    /// <inheritdoc cref="SignatureRequest.SignatureDecryption" path="/summary"/>
    /// </summary>
    public string SignatureDecryption { get; set; }
}
