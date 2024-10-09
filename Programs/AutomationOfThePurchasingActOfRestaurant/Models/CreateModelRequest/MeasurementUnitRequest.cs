using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Models.CreateModelRequest;

/// <summary>
/// Модель запроса единицы измерения
/// </summary>
public class MeasurementUnitRequest
{
    /// <summary>
    /// <inheritdoc cref="MeasurementUnitBaseModel.Merchandises" path="/summary"/>
    /// </summary>
    public ICollection<MerchandiseResponseModel> Merchandises { get; set; } = new List<MerchandiseResponseModel>();
    /// <summary>
    /// <inheritdoc cref="MeasurementUnitBaseModel.Name" path="/summary"/>
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// <inheritdoc cref="MeasurementUnitBaseModel.OKEIKey" path="/summary"/>
    /// </summary>
    public short OKEIKey { get; set; }
}
