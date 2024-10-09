
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

/// <summary>
/// Базовая модель цены товара
/// </summary>
public class MerchandisePriceBaseModel : IBaseEntityModel
{
    /// <summary>
    /// <inheritdoc cref="MerchandisePrice.PurchaseForms" path="/summary"/>
    /// </summary>
    public ICollection<PurchaseFormBaseModel> PurchaseForms { get; set; } = new List<PurchaseFormBaseModel>();
    /// <summary>
    /// <see cref="MerchandiseModel"/> Id
    /// </summary>
    public Guid? MerchandiseId { get; set; }
    /// <summary>
    /// <inheritdoc cref="MerchandisePrice.Merchandise" path="/summary"/>
    /// </summary>
    public MerchandiseBaseModel? Merchandise { get; set; }
    /// <summary>
    /// <inheritdoc cref="MerchandisePrice.CostPerUnit" path="/summary"/>
    /// </summary>
    public double CostPerUnit { get; set; }
}
