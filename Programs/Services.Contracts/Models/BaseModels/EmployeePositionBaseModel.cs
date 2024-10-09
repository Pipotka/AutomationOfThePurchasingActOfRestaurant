
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

/// <summary>
/// Базовая модель должности сотрудника
/// </summary>
public class EmployeePositionBaseModel : IBaseEntityModel
{
    /// <summary>
    /// <inheritdoc cref="EmployeePosition.Approvers" path="/summary"/>
    /// </summary>
    public ICollection<ApproverBaseModel> Approvers { get; set; } = new List<ApproverBaseModel>();
    /// <summary>
    /// <inheritdoc cref="EmployeePosition.Employees" path="/summary"/>
    /// </summary>
    public ICollection<EmployeeBaseModel> Employees { get; set; } = new List<EmployeeBaseModel>();
    /// <summary>
    /// <inheritdoc cref="EmployeePosition.Name" path="/summary"/>
    /// </summary>
    public string Name { get; set; }
}
