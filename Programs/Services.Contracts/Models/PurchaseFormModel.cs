using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;

/// <summary>
/// Модель закупочной формы
/// </summary>
public class PurchaseFormModel : IEntityModel
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// <see cref="FormKeyModel"/> Id
    /// </summary>
    public Guid FormKeyId { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseFormBaseModel.FormKey" path="/summary"/>
    /// </summary>
    public FormKeyModel FormKey { get; set; }
    /// <summary>
    /// <see cref="SponsorOrganization"/> Id
    /// </summary>
    public Guid SponsorOrganizationId { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseFormBaseModel.SponsorOrganization" path="/summary"/>
    /// </summary>
    public OrganizationModel SponsorOrganization { get; set; }
    /// <summary>
    /// <see cref="ApprovingOfficer"/> Id
    /// </summary>
    public Guid ApprovingOfficerId { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseFormBaseModel.ApprovingOfficer" path="/summary"/>
    /// </summary>
    public ApproverModel ApprovingOfficer { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseFormBaseModel.DocumentNumber" path="/summary"/>
    /// </summary>
    public int DocumentNumber { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseFormBaseModel.DocumentDate" path="/summary"/>
    /// </summary>
    public DateTime DocumentDate { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseFormBaseModel.AddressOfPurchase" path="/summary"/>
    /// </summary>
    public string AddressOfPurchase { get; set; }
    /// <summary>
    /// <see cref="ProcurementSpecialist"/> Id
    /// </summary>
    public Guid ProcurementSpecialistId { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseFormBaseModel.ProcurementSpecialist" path="/summary"/>
    /// </summary>
    public EmployeeModel ProcurementSpecialist { get; set; }
    /// <summary>
    /// <see cref="Salesman"/> Id
    /// </summary>
    public Guid SalesmanId { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseFormBaseModel.Salesman" path="/summary"/>
    /// </summary>
    public SupplierModel Salesman { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseFormBaseModel.PurchasedMerchandises" path="/summary"/>
    /// </summary>
    public ICollection<MerchandiseModel> PurchasedMerchandises { get; set; }
}
