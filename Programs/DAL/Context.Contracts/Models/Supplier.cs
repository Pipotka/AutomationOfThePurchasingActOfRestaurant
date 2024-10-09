using System.ComponentModel.DataAnnotations;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;

/// <summary>
/// Поставщик
/// </summary>
public class Supplier : IBaseEntity, ISoftDelited
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
    /// Имя
    /// </summary>
    public string FirstName { get; set; }
    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; set; }
    /// <summary>
    /// Отчество
    /// </summary>
    public string Patronymic { get; set; } = string.Empty;
    /// <summary>
    /// <inheritdoc cref="ISoftDelited.DateOfDeletion" path="/summary"/>
    /// </summary>
    public DateTime DateOfDeletion { get; set; }
    /// <summary>
    /// <inheritdoc cref="ISoftDelited.IsDelited" path="/summary"/>
    /// </summary>
    public bool IsDelited { get; set; } = false;

    /// <summary>
    /// Пустой конструктор <see cref="Supplier"/>
    /// </summary>
    public Supplier() { }
}
