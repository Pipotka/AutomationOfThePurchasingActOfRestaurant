using System.ComponentModel.DataAnnotations;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;

/// <summary>
/// Закупочный акт
/// </summary>
public class PurchaseForm : IBaseEntity, ISoftDelited
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
    /// <see cref="FormKey"/> Id
    /// </summary>
    public Guid FormKeyId {  get; set; }
    /// <summary>
    /// <inheritdoc cref="Models.FormKey" path="/summary"/>
    /// </summary>
    public FormKey FormKey { get; set; }
    /// <summary>
    /// <see cref="SponsorOrganization"/> Id
    /// </summary>
    public Guid SponsorOrganizationId { get; set; }
    /// <summary>
    /// Организация-закзчик
    /// </summary>
    public Organization SponsorOrganization { get; set; }
    /// <summary>
    /// <see cref="ApprovingOfficer"/> Id
    /// </summary>
    public Guid ApprovingOfficerId { get; set; }
    /// <summary>
    /// Утверждающее должностное лицо
    /// </summary>
    public Approver ApprovingOfficer { get; set; }
    /// <summary>
    /// Номер документа
    /// </summary>
    public int DocumentNumber { get; set; }
    /// <summary>
    /// Дата составления документа
    /// </summary>
    public DateTime DocumentDate { get; set; }
    /// <summary>
    /// Место закупки
    /// </summary>
    public string AddressOfPurchase { get; set; }
    /// <summary>
    /// <see cref="ProcurementSpecialist"/> Id
    /// </summary>
    public Guid ProcurementSpecialistId { get; set; }
    /// <summary>
    /// Специалист по закупкам
    /// </summary>
    public Employee ProcurementSpecialist { get; set; }
    /// <summary>
    /// <see cref="Salesman"/> Id
    /// </summary>
    public Guid SalesmanId { get; set; }
    /// <summary>
    /// Поставщик
    /// </summary>
    public Supplier Salesman { get; set; }
    /// <summary>
    /// Закупленные товары
    /// </summary>
    public ICollection<Merchandise> PurchasedMerchandises {  get; set; }
    /// <summary>
    /// <inheritdoc cref="ISoftDelited.DateOfDeletion" path="/summary"/>
    /// </summary>
    public DateTime DateOfDeletion { get; set; }
    /// <summary>
    /// <inheritdoc cref="ISoftDelited.IsDelited" path="/summary"/>
    /// </summary>
    public bool IsDelited { get; set; } = false;

    /// <summary>
    /// Пустой конструктор <see cref="PurchaseForm"/>
    /// </summary>
    public PurchaseForm() { }
}
