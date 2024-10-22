
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

/// <summary>
/// Базовая модель организации
/// </summary>
public class OrganizationBaseModel : IBaseEntityModel
{
    /// <summary>
    /// <inheritdoc cref="Organization.PurchaseForms" path="/summary"/>
    /// </summary>
    public ICollection<PurchaseFormBaseModel> PurchaseForms { get; set; } = new List<PurchaseFormBaseModel>();
    /// <summary>
    /// <inheritdoc cref="Organization.Name" path="/summary"/>
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// <inheritdoc cref="Organization.Address" path="/summary"/>
    /// </summary>
    public string Address { get; set; }
    /// <summary>
    /// <inheritdoc cref="Organization.StructuralUnit" path="/summary"/>
    /// </summary>
    public string StructuralUnit { get; set; }
}
