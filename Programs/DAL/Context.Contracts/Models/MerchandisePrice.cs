using System.ComponentModel.DataAnnotations;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;

/// <summary>
/// Цена товара
/// </summary>
public class MerchandisePrice : IBaseEntity, ISoftDelited
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
    /// <see cref="PurchaseForm"/> в которых используется данная цена
    /// </summary>
    public ICollection<PurchaseForm> PurchaseForms { get; set; } = new List<PurchaseForm>();
    /// <summary>
    /// <see cref="Models.Merchandise"/> Id
    /// </summary>
    public Guid? MerchandiseId { get; set; }
    /// <summary>
    /// Товар
    /// </summary>
    public Merchandise? Merchandise { get; set; }
    /// <summary>
    /// Цена за единицу товара
    /// </summary>
    public double CostPerUnit { get; set; }
    /// <summary>
    /// <inheritdoc cref="ISoftDelited.DateOfDeletion" path="/summary"/>
    /// </summary>
    public DateTime DateOfDeletion { get; set; }
    /// <summary>
    /// <inheritdoc cref="ISoftDelited.IsDelited" path="/summary"/>
    /// </summary>
    public bool IsDelited { get; set; } = false;

    /// <summary>
    /// Пустой конструктор <see cref="MerchandisePrice"/>
    /// </summary>
    public MerchandisePrice() { }
}
