
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

/// <summary>
/// Базовая модель товара
/// </summary>
public class MerchandiseBaseModel : IBaseEntityModel
{
    /// <summary>
    /// <inheritdoc cref="Merchandise.PurchaseForms" path="/summary"/>
    /// </summary>
    public ICollection<PurchaseFormBaseModel> PurchaseForms { get; set; } = new List<PurchaseFormBaseModel>();
    /// <summary>
    /// <inheritdoc cref="Merchandise.Name" path="/summary"/>
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// <inheritdoc cref="Merchandise.MerchandiseKey" path="/summary"/>
    /// </summary>
    public int MerchandiseKey { get; set; }
    /// <summary>
    /// <see cref="MeasurementUnitModel"/> Id
    /// </summary>
    public Guid MeasurementUnitId { get; set; }
    /// <summary>
    /// <inheritdoc cref="Merchandise.MeasurementUnit" path="/summary"/>
    /// </summary>
    public MeasurementUnitBaseModel MeasurementUnit { get; set; }
    /// <summary>
    /// <inheritdoc cref="Merchandise.Count" path="/summary"/>
    /// </summary>
    public int Count { get; set; }
    /// <summary>
    /// <inheritdoc cref="Merchandise.Prices" path="/summary"/>
    /// </summary>
    public ICollection<MerchandisePriceBaseModel> Prices { get; set; }
}
