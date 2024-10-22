using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Models.CreateModelRequest;

/// <summary>
/// Модель запроса должности сотрудника
/// </summary>
public class EmployeePositionRequest
{
    /// <summary>
    /// <inheritdoc cref="EmployeePositionBaseModel.Approvers" path="/summary"/>
    /// </summary>
    public ICollection<ApproverResponseModel> Approvers { get; set; } = new List<ApproverResponseModel>();
    /// <summary>
    /// <inheritdoc cref="EmployeePositionBaseModel.Employees" path="/summary"/>
    /// </summary>
    public ICollection<EmployeeResponseModel> Employees { get; set; } = new List<EmployeeResponseModel>();
    /// <summary>
    /// <inheritdoc cref="EmployeePositionBaseModel.Name" path="/summary"/>
    /// </summary>
    public string Name { get; set; }
}
