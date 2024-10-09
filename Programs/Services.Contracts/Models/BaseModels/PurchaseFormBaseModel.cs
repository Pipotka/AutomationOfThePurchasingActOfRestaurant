
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

/// <summary>
/// Базовая модель закупочного акта
/// </summary>
public class PurchaseFormBaseModel : IBaseEntityModel
{
    /// <summary>
    /// <see cref="FormKeyModel"/> Id
    /// </summary>
    public Guid FormKeyId { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseForm.FormKey" path="/summary"/>
    /// </summary>
    public FormKeyBaseModel FormKey { get; set; }
    /// <summary>
    /// <see cref="SponsorOrganization"/> Id
    /// </summary>
    public Guid SponsorOrganizationId { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseForm.SponsorOrganization" path="/summary"/>
    /// </summary>
    public OrganizationBaseModel SponsorOrganization { get; set; }
    /// <summary>
    /// <see cref="ApprovingOfficer"/> Id
    /// </summary>
    public Guid ApprovingOfficerId { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseForm.ApprovingOfficer" path="/summary"/>
    /// </summary>
    public ApproverBaseModel ApprovingOfficer { get; set; }
    /// <summary>
    /// <see cref="OfficerSignature"/> Id
    /// </summary>
    public Guid OfficerSignatureId { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseForm.OfficerSignature" path="/summary"/>
    /// </summary>
    public SignatureBaseModel OfficerSignature { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseForm.DocumentNumber" path="/summary"/>
    /// </summary>
    public int DocumentNumber { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseForm.DocumentDate" path="/summary"/>
    /// </summary>
    public DateTime DocumentDate { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseForm.AddressOfPurchase" path="/summary"/>
    /// </summary>
    public string AddressOfPurchase { get; set; }
    /// <summary>
    /// <see cref="ProcurementSpecialist"/> Id
    /// </summary>
    public Guid ProcurementSpecialistId { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseForm.ProcurementSpecialist" path="/summary"/>
    /// </summary>
    public EmployeeBaseModel ProcurementSpecialist { get; set; }
    /// <summary>
    /// <see cref="Salesman"/> Id
    /// </summary>
    public Guid SalesmanId { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseForm.Salesman" path="/summary"/>
    /// </summary>
    public SupplierBaseModel Salesman { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseForm.PurchasedMerchandises" path="/summary"/>
    /// </summary>
    public ICollection<MerchandiseBaseModel> PurchasedMerchandises { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseForm.Prices" path="/summary"/>
    /// </summary>
    public ICollection<MerchandisePriceBaseModel> Prices { get; set; }
}
