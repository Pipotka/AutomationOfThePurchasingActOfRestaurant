using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;

/// <summary>
/// Код формы
/// </summary>
public class FormKey : IBaseEntity, ISoftDelited
{
    /// <summary>
    /// Регулярное выражение для <see cref="OKUD"/>
    /// </summary>
    public static Regex RegularExpressionForOKUD = new Regex(@"^\d+$");
    /// <summary>
    /// Регулярное выражение для <see cref="OKPO"/>
    /// </summary>
    public static Regex RegularExpressionForOKPO = new Regex(@"^\d+$");
    /// <summary>
    /// Регулярное выражение для <see cref="TIN"/>
    /// </summary>
    public static Regex RegularExpressionForTIN = new Regex(@"^\d+$");
    /// <summary>
    /// Регулярное выражение для <see cref="OKDP"/>
    /// </summary>
    public static Regex RegularExpressionForOKDP = new Regex(@"^\d+(\.\d+)*$");
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
    /// Закупочные акты
    /// </summary>
    public PurchaseForm? PurchaseForm { get; set; }
    /// <summary>
    /// Длина <see cref="OKUD"/>
    /// </summary>
    public const int lengthOfTheOKUD = 8;
    /// <summary>
    /// ОКУД(Общероссийский классификатор управленческой документации)
    /// </summary>
    public string OKUD { get; set; }
    /// <summary>
    /// Длина <see cref="OKPO"/>
    /// </summary>
    public const int lengthOfTheOKPO = 8;
    /// <summary>
    /// ОКПО юридического лица(Общероссийский классификатор предприятий и организаций)
    /// </summary>
    public string OKPO { get; set; }
    /// <summary>
    /// Длина <see cref="TIN"/>
    /// </summary>
    public const int lengthOfTheTIN = 10;
    /// <summary>
    /// ИНН(Идентификационный номер налогоплательщика)
    /// </summary>
    public string TIN { get; set; }
    /// <summary>
    /// ОКДП (Общероссийский классификатор видов экономической деятельности, продукции и услуг)
    /// </summary>
    public string OKDP { get; set; }
    /// <summary>
    /// <inheritdoc cref="ISoftDelited.DateOfDeletion" path="/summary"/>
    /// </summary>
    public DateTime DateOfDeletion { get; set; }
    /// <summary>
    /// <inheritdoc cref="ISoftDelited.IsDelited" path="/summary"/>
    /// </summary>
    public bool IsDelited { get; set; } = false;

    /// <summary>
    /// Пустой конструктор <see cref="FormKey"/>
    /// </summary>
    public FormKey() { }
}
