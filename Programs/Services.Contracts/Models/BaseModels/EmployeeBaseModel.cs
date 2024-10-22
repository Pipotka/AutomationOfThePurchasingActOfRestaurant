
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

/// <summary>
/// Базовая модель сотрудника
/// </summary>
public class EmployeeBaseModel : IBaseEntityModel
{
    /// <summary>
    /// <inheritdoc cref="Employee.PurchaseForms" path="/summary"/>
    /// </summary>
    public ICollection<PurchaseFormBaseModel> PurchaseForms { get; set; } = new List<PurchaseFormBaseModel>();
    /// <summary>
    /// <inheritdoc cref="Employee.FirstName" path="/summary"/>
    /// </summary>
    public string FirstName { get; set; }
    /// <summary>
    /// <inheritdoc cref="Employee.LastName" path="/summary"/>
    /// </summary>
    public string LastName { get; set; }
    /// <summary>
    /// <inheritdoc cref="Employee.Patronymic" path="/summary"/>
    /// </summary>
    public string Patronymic { get; set; } = string.Empty;
    /// <summary>
    /// <see cref="EmployeePositionModel"/> Id
    /// </summary>
    public Guid PositionId { get; set; }
    /// <summary>
    /// <inheritdoc cref="Employee.Position" path="/summary"/>
    /// </summary>
    public EmployeePositionModel Position { get; set; }
}