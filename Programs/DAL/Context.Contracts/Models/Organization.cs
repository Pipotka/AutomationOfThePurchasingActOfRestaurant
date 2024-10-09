using System.ComponentModel.DataAnnotations;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;

/// <summary>
/// Организация
/// </summary>
public class Organization : IBaseEntity, ISoftDelited
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
    /// Закупочные акты
    /// </summary>
    public ICollection<PurchaseForm> PurchaseForms { get; set; } = new List<PurchaseForm>();
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Адрес организации
    /// </summary>
    public string Address { get; set; }
    /// <summary>
    /// Структурное подразделение
    /// </summary>
    public string StructuralUnit { get; set; }
    /// <summary>
    /// <inheritdoc cref="ISoftDelited.DateOfDeletion" path="/summary"/>
    /// </summary>
    public DateTime DateOfDeletion { get; set; }
    /// <summary>
    /// <inheritdoc cref="ISoftDelited.IsDelited" path="/summary"/>
    /// </summary>
    public bool IsDelited { get; set; } = false;

    /// <summary>
    /// Пустой конструктор <see cref="Organization"/>
    /// </summary>
    public Organization() { }
}
