
using Company.AutomationOfThePurchasingActOfRestaurant.Models.CreateModelRequest;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Models;

/// <summary>
/// Модель ответа по сотруднику для API
/// </summary>
public class EmployeeResponseModel
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// <inheritdoc cref="EmployeeRequest.FirstName" path="/summary"/>
    /// </summary>
    public string FirstName { get; set; }
    /// <summary>
    /// <inheritdoc cref="EmployeeRequest.LastName" path="/summary"/>
    /// </summary>
    public string LastName { get; set; }
    /// <summary>
    /// <inheritdoc cref="EmployeeRequest.Patronymic" path="/summary"/>
    /// </summary>
    public string Patronymic { get; set; } = string.Empty;
    /// <summary>
    /// <see cref="EmployeePositionResponseModel"/> Id
    /// </summary>
    public Guid PositionId { get; set; }
    /// <summary>
    /// <inheritdoc cref="EmployeeRequest.Position" path="/summary"/>
    /// </summary>
    public EmployeePositionResponseModel Position { get; set; }
}
