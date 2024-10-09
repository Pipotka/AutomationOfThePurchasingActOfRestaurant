using System.ComponentModel.DataAnnotations;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;

/// <summary>
/// Единица измерения
/// </summary>
public class MeasurementUnit : IBaseEntity, ISoftDelited
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
    /// Товары
    /// </summary>
    public ICollection<Merchandise> Merchandises { get; set; } = new List<Merchandise>();
    /// <summary>
    /// длина кода по ОКЕИ
    /// </summary>
    public static int leightOKEIKey = 3;
    /// <summary>
    /// Наименование единицы измерения
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Код по ОКЕИ
    /// </summary>
    public string OKEIKey { get; set; }
    /// <summary>
    /// <inheritdoc cref="ISoftDelited.DateOfDeletion" path="/summary"/>
    /// </summary>
    public DateTime DateOfDeletion { get; set; }
    /// <summary>
    /// <inheritdoc cref="ISoftDelited.IsDelited" path="/summary"/>
    /// </summary>
    public bool IsDelited { get; set; } = false;

    /// <summary>
    /// Пустой конструктор <see cref="MeasurementUnit"/>
    /// </summary>
    public MeasurementUnit() { }
}
