using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;

/// <summary>
/// Модель организации
/// </summary>
public class OrganizationModel : IEntityModel
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// <inheritdoc cref="OrganizationBaseModel.PurchaseForms" path="/summary"/>
    /// </summary>
    public ICollection<PurchaseFormModel> PurchaseForms { get; set; } = new List<PurchaseFormModel>();
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
