using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;

/// <summary>
/// Утверждающий
/// </summary>
public class Approver : IBaseEntity, ISoftDelited
{
    /// <summary>
    /// Регулярное выражение для расшифровки подписи
    /// </summary>
    public static Regex RegularExpressionForSignatureDecryption = new Regex(@"^[A-ZА-Я]\.([A-ZА-Я]\.)? [A-ZА-Я][a-zа-я]*$");
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
    /// <see cref="EmployeePosition"/> Id
    /// </summary>
    public Guid PositionId { get; set; }
    /// <summary>
    /// Должность
    /// </summary>
    public EmployeePosition Position { get; set; }
    /// <summary>
    /// Расшифровка подписи
    /// </summary>
    public string SignatureDecryption { get; set; }
    /// <summary>
    /// <inheritdoc cref="ISoftDelited.DateOfDeletion" path="/summary"/>
    /// </summary>
    public DateTime DateOfDeletion { get; set; }
    /// <summary>
    /// <inheritdoc cref="ISoftDelited.IsDelited" path="/summary"/>
    /// </summary>
    public bool IsDelited { get; set; } = false;

    /// <summary>
    /// Пустой конструктор <see cref="Approver"/>
    /// </summary>
    public Approver() { }
}
