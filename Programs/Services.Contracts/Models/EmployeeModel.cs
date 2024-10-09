using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;

/// <summary>
/// Модель сотрудника
/// </summary>
public class EmployeeModel : IEntityModel
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// <inheritdoc cref="EmployeeBaseModel.PurchaseForms" path="/summary"/>
    /// </summary>
    public ICollection<PurchaseFormModel> PurchaseForms { get; set; } = new List<PurchaseFormModel>();
    /// <summary>
    /// <inheritdoc cref="EmployeeBaseModel.FirstName" path="/summary"/>
    /// </summary>
    public string FirstName { get; set; }
    /// <summary>
    /// <inheritdoc cref="EmployeeBaseModel.LastName" path="/summary"/>
    /// </summary>
    public string LastName { get; set; }
    /// <summary>
    /// <inheritdoc cref="EmployeeBaseModel.Patronymic" path="/summary"/>
    /// </summary>
    public string Patronymic { get; set; } = string.Empty;
    /// <summary>
    /// <see cref="EmployeePositionModel"/> Id
    /// </summary>
    public Guid PositionId { get; set; }
    /// <summary>
    /// <inheritdoc cref="EmployeeBaseModel.Position" path="/summary"/>
    /// </summary>
    public EmployeePositionModel Position { get; set; }
}
