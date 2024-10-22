
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

/// <summary>
/// Базовая модель кода формы
/// </summary>
public class FormKeyBaseModel : IBaseEntityModel
{
    /// <summary>
    /// <see cref="PurchaseFormModel"/> Id
    /// </summary>
    public Guid? PurchaseFormId { get; set; }
    /// <summary>
    /// <inheritdoc cref="FormKey.PurchaseForm" path="/summary"/>
    /// </summary>
    public PurchaseFormBaseModel? PurchaseForm { get; set; }
    /// <summary>
    /// <inheritdoc cref="FormKey.OKUD" path="/summary"/>
    /// </summary>
    public string OKUD { get; set; }
    /// <summary>
    /// <inheritdoc cref="FormKey.OKPO" path="/summary"/>
    /// </summary>
    public string OKPO { get; set; }
    /// <summary>
    /// <inheritdoc cref="FormKey.TIN" path="/summary"/>
    /// </summary>
    public string TIN { get; set; }
    /// <summary>
    /// <inheritdoc cref="FormKey.OKDP" path="/summary"/>
    /// </summary>
    public string OKDP { get; set; }
}
