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
    /// <see cref="PurchaseForm"/> Id
    /// </summary>
    public Guid? PurchaseFormId { get; set; }
    /// <summary>
    /// <inheritdoc cref="MerchandiseBaseModel.PurchaseForm" path="/summary"/>
    /// </summary>
    public PurchaseFormModel? PurchaseForm { get; set; }
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
    public double Price { get; set; } = 0;
}
