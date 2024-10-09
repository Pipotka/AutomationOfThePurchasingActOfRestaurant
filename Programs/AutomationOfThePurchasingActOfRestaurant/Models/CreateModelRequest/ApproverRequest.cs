using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Models.CreateModelRequest;

/// <summary>
/// Модель запроса утверждающего
/// </summary>
public class ApproverRequest
{
    /// <summary>
    /// <inheritdoc cref="ApproverBaseModel.PurchaseForms" path="/summary"/>
    /// </summary>
    public ICollection<PurchaseFormResponseModel> PurchaseForms { get; set; } = new List<PurchaseFormResponseModel>();
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
    /// <see cref="EmployeePositionRequest"/> Id
    /// </summary>
    public Guid PositionId { get; set; }
    /// <summary>
    /// <inheritdoc cref="ApproverBaseModel.Position" path="/summary"/>
    /// </summary>
    public EmployeePositionResponseModel Position { get; set; }
    /// <summary>
    /// <see cref="SignatureRequest"/> Id
    /// </summary>
    public Guid SignatureId { get; set; }
    /// <summary>
    /// <inheritdoc cref="ApproverBaseModel.Signature" path="/summary"/>
    /// </summary>
    public SignatureResponseModel Signature { get; set; }
}