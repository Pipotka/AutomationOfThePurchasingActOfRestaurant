using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;
using System.ComponentModel.DataAnnotations;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;

/// <summary>
/// Модель должности сотрудника
/// </summary>
public class EmployeePositionModel : IEntityModel
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// <inheritdoc cref="EmployeePositionBaseModel.Approvers" path="/summary"/>
    /// </summary>
    public ICollection<ApproverModel> Approvers { get; set; } = new List<ApproverModel>();
    /// <summary>
    /// <inheritdoc cref="EmployeePositionBaseModel.Employees" path="/summary"/>
    /// </summary>
    public ICollection<EmployeeModel> Employees { get; set; } = new List<EmployeeModel>();
    /// <summary>
    /// <inheritdoc cref="EmployeePositionBaseModel.Name" path="/summary"/>
    /// </summary>
    public string Name { get; set; }
}
