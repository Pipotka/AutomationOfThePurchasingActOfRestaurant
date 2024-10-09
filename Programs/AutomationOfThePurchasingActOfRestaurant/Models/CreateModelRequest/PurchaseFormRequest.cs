using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Models.CreateModelRequest;

/// <summary>
/// Модель запроса закупочной формы
/// </summary>
public class PurchaseFormRequest
{
    /// <summary>
    /// <see cref="FormKeyRequest"/> Id
    /// </summary>
    public Guid FormKeyId { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseFormBaseModel.FormKey" path="/summary"/>
    /// </summary>
    public FormKeyResponseModel FormKey { get; set; }
    /// <summary>
    /// <see cref="SponsorOrganization"/> Id
    /// </summary>
    public Guid SponsorOrganizationId { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseFormBaseModel.SponsorOrganization" path="/summary"/>
    /// </summary>
    public OrganizationResponseModel SponsorOrganization { get; set; }
    /// <summary>
    /// <see cref="ApprovingOfficer"/> Id
    /// </summary>
    public Guid ApprovingOfficerId { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseFormBaseModel.ApprovingOfficer" path="/summary"/>
    /// </summary>
    public ApproverResponseModel ApprovingOfficer { get; set; }
    /// <summary>
    /// <see cref="OfficerSignature"/> Id
    /// </summary>
    public Guid OfficerSignatureId { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseFormBaseModel.OfficerSignature" path="/summary"/>
    /// </summary>
    public SignatureResponseModel OfficerSignature { get; set; }
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
    public EmployeeResponseModel ProcurementSpecialist { get; set; }
    /// <summary>
    /// <see cref="Salesman"/> Id
    /// </summary>
    public Guid SalesmanId { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseFormBaseModel.Salesman" path="/summary"/>
    /// </summary>
    public SupplierResponseModel Salesman { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseFormBaseModel.PurchasedMerchandises" path="/summary"/>
    /// </summary>
    public ICollection<MerchandiseResponseModel> PurchasedMerchandises { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseFormBaseModel.Prices" path="/summary"/>
    /// </summary>
    public ICollection<MerchandisePriceResponseModel> Prices { get; set; }
}
