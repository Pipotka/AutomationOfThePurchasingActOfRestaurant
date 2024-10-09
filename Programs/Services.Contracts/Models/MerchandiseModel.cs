using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;
using System.ComponentModel.DataAnnotations;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;

/// <summary>
/// Модель товара
/// </summary>
public class MerchandiseModel : IEntityModel
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// <inheritdoc cref="MerchandiseBaseModel.PurchaseForms" path="/summary"/>
    /// </summary>
    public ICollection<PurchaseFormModel> PurchaseForms { get; set; } = new List<PurchaseFormModel>();
    /// <summary>
    /// <inheritdoc cref="MerchandiseBaseModel.Name" path="/summary"/>
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// <inheritdoc cref="MerchandiseBaseModel.MerchandiseKey" path="/summary"/>
    /// </summary>
    public int MerchandiseKey { get; set; }
    /// <summary>
    /// <see cref="MeasurementUnitModel"/> Id
    /// </summary>
    public Guid MeasurementUnitId { get; set; }
    /// <summary>
    /// <inheritdoc cref="MerchandiseBaseModel.MeasurementUnit" path="/summary"/>
    /// </summary>
    public MeasurementUnitModel MeasurementUnit { get; set; }
    /// <summary>
    /// <inheritdoc cref="MerchandiseBaseModel.Count" path="/summary"/>
    /// </summary>
    public int Count { get; set; }
    /// <summary>
    /// <inheritdoc cref="MerchandiseBaseModel.Prices" path="/summary"/>
    /// </summary>
    public ICollection<MerchandisePriceModel> Prices { get; set; }
}
