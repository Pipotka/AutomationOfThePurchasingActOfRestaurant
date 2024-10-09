using Company.AutomationOfThePurchasingActOfRestaurant.Models.CreateModelRequest;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Models;

/// <summary>
/// Модель ответа по закупочному акту для API
/// </summary>
public class PurchaseFormResponseModel
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// <see cref="FormKeyResponseModel"/> Id
    /// </summary>
    public Guid FormKeyId { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseFormRequest.FormKey" path="/summary"/>
    /// </summary>
    public FormKeyResponseModel FormKey { get; set; }
    /// <summary>
    /// <see cref="SponsorOrganization"/> Id
    /// </summary>
    public Guid SponsorOrganizationId { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseFormRequest.SponsorOrganization" path="/summary"/>
    /// </summary>
    public OrganizationResponseModel SponsorOrganization { get; set; }
    /// <summary>
    /// <see cref="ApprovingOfficer"/> Id
    /// </summary>
    public Guid ApprovingOfficerId { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseFormRequest.ApprovingOfficer" path="/summary"/>
    /// </summary>
    public ApproverResponseModel ApprovingOfficer { get; set; }
    /// <summary>
    /// <see cref="OfficerSignature"/> Id
    /// </summary>
    public Guid OfficerSignatureId { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseFormRequest.OfficerSignature" path="/summary"/>
    /// </summary>
    public SignatureResponseModel OfficerSignature { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseFormRequest.DocumentNumber" path="/summary"/>
    /// </summary>
    public int DocumentNumber { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseFormRequest.DocumentDate" path="/summary"/>
    /// </summary>
    public DateTime DocumentDate { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseFormRequest.AddressOfPurchase" path="/summary"/>
    /// </summary>
    public string AddressOfPurchase { get; set; }
    /// <summary>
    /// <see cref="ProcurementSpecialist"/> Id
    /// </summary>
    public Guid ProcurementSpecialistId { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseFormRequest.ProcurementSpecialist" path="/summary"/>
    /// </summary>
    public EmployeeResponseModel ProcurementSpecialist { get; set; }
    /// <summary>
    /// <see cref="Salesman"/> Id
    /// </summary>
    public Guid SalesmanId { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseFormRequest.Salesman" path="/summary"/>
    /// </summary>
    public SupplierResponseModel Salesman { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseFormRequest.PurchasedMerchandises" path="/summary"/>
    /// </summary>
    public ICollection<MerchandiseResponseModel> PurchasedMerchandises { get; set; }
    /// <summary>
    /// <inheritdoc cref="PurchaseFormRequest.Prices" path="/summary"/>
    /// </summary>
    public ICollection<MerchandisePriceResponseModel> Prices { get; set; }
    /// <summary>
    /// Полная стоимость товаров
    /// </summary>
    public double TotalCost { get; set; }
}
