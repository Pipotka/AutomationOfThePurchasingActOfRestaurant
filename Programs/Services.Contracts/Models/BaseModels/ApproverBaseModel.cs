using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using System.ComponentModel.DataAnnotations;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

/// <summary>
/// Базовая модель утверждающего
/// </summary>
public class ApproverBaseModel : IBaseEntityModel
{
    /// <summary>
    /// <inheritdoc cref="Approver.PurchaseForms" path="/summary"/>
    /// </summary>
    public ICollection<PurchaseFormBaseModel> PurchaseForms { get; set; } = new List<PurchaseFormBaseModel>();
    /// <summary>
    /// <inheritdoc cref="Approver.FirstName" path="/summary"/>
    /// </summary>
    public string FirstName { get; set; }
    /// <summary>
    /// <inheritdoc cref="Approver.LastName" path="/summary"/>
    /// </summary>
    public string LastName { get; set; }
    /// <summary>
    /// <inheritdoc cref="Approver.Patronymic" path="/summary"/>
    /// </summary>
    public string Patronymic { get; set; } = string.Empty;
    /// <summary>
    /// <see cref="EmployeePositionModel"/> Id
    /// </summary>
    public Guid PositionId { get; set; }
    /// <summary>
    /// <inheritdoc cref="Approver.Position" path="/summary"/>
    /// </summary>
    public EmployeePositionBaseModel Position { get; set; }
    /// <summary>
    /// <inheritdoc cref="Approver.SignatureId" path="/summary"/>
    /// </summary>
    public Guid SignatureId { get; set; }
    /// <summary>
    /// <inheritdoc cref="Approver.Signature" path="/summary"/>
    /// </summary>
    public SignatureBaseModel Signature { get; set; }
}
