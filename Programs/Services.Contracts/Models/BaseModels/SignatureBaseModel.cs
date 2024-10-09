
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using System.Drawing;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

/// <summary>
/// Базовая модель подписи
/// </summary>
public class SignatureBaseModel : IBaseEntityModel
{
    /// <summary>
    /// <inheritdoc cref="Signature.purchaseForms" path="/summary"/>
    /// </summary>
    public ICollection<PurchaseFormBaseModel> purchaseForms { get; set; } = new List<PurchaseFormBaseModel>();
    /// <summary>
    /// <see cref="ApproverModel"/> Id
    /// </summary>
    public Guid? ApproverId { get; set; }
    /// <summary>
    /// <inheritdoc cref="Signature.Approver" path="/summary"/>
    /// </summary>
    public ApproverBaseModel? Approver { get; set; }
    /// <summary>
    /// <inheritdoc cref="Signature.Points" path="/summary"/>
    /// </summary>
    public Point[] Points { get; set; }
    /// <summary>
    /// <inheritdoc cref="Signature.SignatureDecryption" path="/summary"/>
    /// </summary>
    public string SignatureDecryption { get; set; }
}
