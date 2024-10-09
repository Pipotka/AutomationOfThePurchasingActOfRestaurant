
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

/// <summary>
/// Базовая модель поставщика
/// </summary>
public class SupplierBaseModel : IBaseEntityModel
{
    /// <summary>
    /// <inheritdoc cref="Supplier.PurchaseForms" path="/summary"/>
    /// </summary>
    public ICollection<PurchaseFormBaseModel> PurchaseForms { get; set; } = new List<PurchaseFormBaseModel>();
    /// <summary>
    /// <inheritdoc cref="Supplier.FirstName" path="/summary"/>
    /// </summary>
    public string FirstName { get; set; }
    /// <summary>
    /// <inheritdoc cref="Supplier.LastName" path="/summary"/>
    /// </summary>
    public string LastName { get; set; }
    /// <summary>
    /// <inheritdoc cref="Supplier.Patronymic" path="/summary"/>
    /// </summary>
    public string Patronymic { get; set; } = string.Empty;
}
