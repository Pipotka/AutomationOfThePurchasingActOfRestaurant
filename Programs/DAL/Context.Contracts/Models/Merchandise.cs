using System.ComponentModel.DataAnnotations;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;

/// <summary>
/// Товар
/// </summary>
public class Merchandise : IBaseEntity, ISoftDelited
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
    /// <see cref="PurchaseForm"/> Id
    /// </summary>
    public Guid? PurchaseFormId { get; set; }
    /// <summary>
    /// Закупочный акт
    /// </summary>
    public PurchaseForm? PurchaseForm { get; set; }
    /// <summary>
    /// Наименование, характеристика товара
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Код товара
    /// </summary>
    public int MerchandiseKey { get; set; }
    /// <summary>
    /// <see cref="MeasurementUnit"/> Id
    /// </summary>
    public Guid MeasurementUnitId { get; set; }
    /// <summary>
    /// <inheritdoc cref="Models.MeasurementUnit" path="/summary"/>
    /// </summary>
    public MeasurementUnit MeasurementUnit { get; set; }
    /// <summary>
    /// Количество товара
    /// </summary>
    public int Count { get; set; }
    /// <summary>
    /// Цена
    /// </summary>
    public double Price { get; set; } = 0;
    /// <summary>
    /// <inheritdoc cref="ISoftDelited.DateOfDeletion" path="/summary"/>
    /// </summary>
    public DateTime DateOfDeletion { get; set; }
    /// <summary>
    /// <inheritdoc cref="ISoftDelited.IsDelited" path="/summary"/>
    /// </summary>
    public bool IsDelited { get; set; } = false;

    /// <summary>
    /// Пустой конструктор <see cref="Merchandise"/>
    /// </summary>
    public Merchandise() { }
}
