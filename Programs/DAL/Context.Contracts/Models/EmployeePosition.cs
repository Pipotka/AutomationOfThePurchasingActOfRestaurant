using System.ComponentModel.DataAnnotations;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;

/// <summary>
/// Должность сотрудника
/// </summary>
public class EmployeePosition : IBaseEntity, ISoftDelited
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime DateOfCreation { get; set; }
    /// <summary>
    /// Дата последнего изменения
    /// </summary>
    public DateTime DateOfLastChange { get; set; }
    /// <summary>
    /// Утверждающие
    /// </summary>
    public ICollection<Approver> Approvers { get; set; } = new List<Approver>();
    /// <summary>
    /// Сотрудники
    /// </summary>
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    /// <summary>
    /// Название должности
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// <inheritdoc cref="ISoftDelited.DateOfDeletion" path="/summary"/>
    /// </summary>
    public DateTime DateOfDeletion { get; set; }
    /// <summary>
    /// <inheritdoc cref="ISoftDelited.IsDelited" path="/summary"/>
    /// </summary>
    public bool IsDelited { get; set; } = false;

    /// <summary>
    /// Пустой конструктор <see cref="EmployeePosition"/>
    /// </summary>
    public EmployeePosition() { }
}
