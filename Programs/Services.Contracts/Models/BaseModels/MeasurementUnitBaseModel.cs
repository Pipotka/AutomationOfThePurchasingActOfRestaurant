
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

/// <summary>
/// Базовая модель единицы измерения
/// </summary>
public class MeasurementUnitBaseModel : IBaseEntityModel
{
    /// <summary>
    /// <inheritdoc cref="MeasurementUnit.Merchandises" path="/summary"/>
    /// </summary>
    public ICollection<MerchandiseBaseModel> Merchandises { get; set; } = new List<MerchandiseBaseModel>();
    /// <summary>
    /// <inheritdoc cref="MeasurementUnit.Name" path="/summary"/>
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// <inheritdoc cref="MeasurementUnit.OKEIKey" path="/summary"/>
    /// </summary>
    public short OKEIKey { get; set; }
}
