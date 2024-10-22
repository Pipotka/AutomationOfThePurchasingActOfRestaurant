using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Models.CreateModelRequest;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Models;

/// <summary>
/// Модель ответа по утверждающему для API
/// </summary>
public class ApproverResponseModel
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// <inheritdoc cref="ApproverRequest.FirstName" path="/summary"/>
    /// </summary>
    public string FirstName { get; set; }
    /// <summary>
    /// <inheritdoc cref="ApproverRequest.LastName" path="/summary"/>
    /// </summary>
    public string LastName { get; set; }
    /// <summary>
    /// <inheritdoc cref="ApproverRequest.Patronymic" path="/summary"/>
    /// </summary>
    public string Patronymic { get; set; } = string.Empty;
    /// <summary>
    /// <see cref="EmployeePositionRequest"/> Id
    /// </summary>
    public Guid PositionId { get; set; }
    /// <summary>
    /// <inheritdoc cref="ApproverRequest.Position" path="/summary"/>
    /// </summary>
    public EmployeePositionResponseModel Position { get; set; }
    /// <summary>
    /// <inheritdoc cref="ApproverRequest.SignatureDecryption" path="/summary"/>
    /// </summary>
    public string SignatureDecryption { get; set; }
}