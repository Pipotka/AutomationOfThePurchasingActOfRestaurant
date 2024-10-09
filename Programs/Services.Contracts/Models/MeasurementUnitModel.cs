using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;
using System.ComponentModel.DataAnnotations;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;

/// <summary>
/// Модель единицы измерения
/// </summary>
public class MeasurementUnitModel : IEntityModel
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// <inheritdoc cref="MeasurementUnitBaseModel.Merchandises" path="/summary"/>
    /// </summary>
    public ICollection<MerchandiseModel> Merchandises { get; set; } = new List<MerchandiseModel>();
    /// <summary>
    /// <inheritdoc cref="MeasurementUnitBaseModel.Name" path="/summary"/>
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// <inheritdoc cref="MeasurementUnitBaseModel.OKEIKey" path="/summary"/>
    /// </summary>
    public short OKEIKey { get; set; }
}
