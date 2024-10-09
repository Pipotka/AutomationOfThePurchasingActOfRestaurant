using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Models.CreateModelRequest;

/// <summary>
/// Модель запроса организации
/// </summary>
public class OrganizationRequest
{
    /// <summary>
    /// <inheritdoc cref="OrganizationBaseModel.PurchaseForms" path="/summary"/>
    /// </summary>
    public ICollection<PurchaseFormResponseModel> PurchaseForms { get; set; } = new List<PurchaseFormResponseModel>();
    /// <summary>
    /// <inheritdoc cref="OrganizationBaseModel.Name" path="/summary"/>
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// <inheritdoc cref="OrganizationBaseModel.Address" path="/summary"/>
    /// </summary>
    public string Address { get; set; }
    /// <summary>
    /// <inheritdoc cref="OrganizationBaseModel.StructuralUnit" path="/summary"/>
    /// </summary>
    public string StructuralUnit { get; set; }
}
