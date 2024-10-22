
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

/// <summary>
/// Базовая модель товара
/// </summary>
public class MerchandiseBaseModel : IBaseEntityModel
{
    /// <summary>
    /// <see cref="PurchaseForm"/> Id
    /// </summary>
    public Guid? PurchaseFormId { get; set; }
    /// <summary>
    /// <inheritdoc cref="Merchandise.PurchaseForm" path="/summary"/>
    /// </summary>
    public PurchaseFormModel? PurchaseForm { get; set; }
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
    public MeasurementUnitModel MeasurementUnit { get; set; }
    /// <summary>
    /// <inheritdoc cref="Merchandise.Count" path="/summary"/>
    /// </summary>
    public int Count { get; set; }
    /// <summary>
    /// <inheritdoc cref="Merchandise.Price" path="/summary"/>
    /// </summary>
    public double Price { get; set; } = 0;
}
