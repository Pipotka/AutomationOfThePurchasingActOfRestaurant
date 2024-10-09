using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;
using System.ComponentModel.DataAnnotations;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;

/// <summary>
/// Модель цены товара
/// </summary>
public class MerchandisePriceModel : IEntityModel
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// <inheritdoc cref="MerchandisePriceBaseModel.PurchaseForms" path="/summary"/>
    /// </summary>
    public ICollection<PurchaseFormModel> PurchaseForms { get; set; } = new List<PurchaseFormModel>();
    /// <summary>
    /// <see cref="MerchandiseModel"/> Id
    /// </summary>
    public Guid? MerchandiseId { get; set; }
    /// <summary>
    /// <inheritdoc cref="MerchandisePriceBaseModel.Merchandise" path="/summary"/>
    /// </summary>
    public MerchandiseModel? Merchandise { get; set; }
    /// <summary>
    /// <inheritdoc cref="MerchandisePriceBaseModel.CostPerUnit" path="/summary"/>
    /// </summary>
    public double CostPerUnit { get; set; }
}
