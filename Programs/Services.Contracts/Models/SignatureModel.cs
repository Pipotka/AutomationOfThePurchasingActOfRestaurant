using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;

/// <summary>
/// Модель подписи
/// </summary>
public class SignatureModel : IEntityModel
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// <inheritdoc cref="SignatureBaseModel.purchaseForms" path="/summary"/>
    /// </summary>
    public ICollection<PurchaseFormModel> purchaseForms { get; set; } = new List<PurchaseFormModel>();
    /// <summary>
    /// <see cref="ApproverModel"/> Id
    /// </summary>
    public Guid? ApproverId { get; set; }
    /// <summary>
    /// <inheritdoc cref="SignatureBaseModel.Approver" path="/summary"/>
    /// </summary>
    public ApproverModel? Approver { get; set; }
    /// <summary>
    /// <inheritdoc cref="SignatureBaseModel.Points" path="/summary"/>
    /// </summary>
    public Point[] Points { get; set; }
    /// <summary>
    /// <inheritdoc cref="SignatureBaseModel.SignatureDecryption" path="/summary"/>
    /// </summary>
    public string SignatureDecryption { get; set; }
}
