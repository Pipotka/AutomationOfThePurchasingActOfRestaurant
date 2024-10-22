using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;


/// <summary>
/// Модель утверждающего
/// </summary>
public class ApproverModel : IEntityModel
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// <inheritdoc cref="ApproverBaseModel.PurchaseForms" path="/summary"/>
    /// </summary>
    public ICollection<PurchaseFormModel> PurchaseForms { get; set; } = new List<PurchaseFormModel>();
    /// <summary>
    /// <inheritdoc cref="ApproverBaseModel.FirstName" path="/summary"/>
    /// </summary>
    public string FirstName { get; set; }
    /// <summary>
    /// <inheritdoc cref="ApproverBaseModel.LastName" path="/summary"/>
    /// </summary>
    public string LastName { get; set; }
    /// <summary>
    /// <inheritdoc cref="ApproverBaseModel.Patronymic" path="/summary"/>
    /// </summary>
    public string Patronymic { get; set; } = string.Empty;
    /// <summary>
    /// <see cref="EmployeePositionModel"/> Id
    /// </summary>
    public Guid PositionId { get; set; }
    /// <summary>
    /// <inheritdoc cref="ApproverBaseModel.Position" path="/summary"/>
    /// </summary>
    public EmployeePositionModel Position { get; set; }
    /// <summary>
    /// <inheritdoc cref="ApproverBaseModel.SignatureDecryption" path="/summary"/>
    /// </summary>
    public string SignatureDecryption { get; set; }
}
