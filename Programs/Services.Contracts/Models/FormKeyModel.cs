using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;
using System.ComponentModel.DataAnnotations;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;

/// <summary>
/// Модель кода формы
/// </summary>
public class FormKeyModel : IEntityModel
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// <see cref="PurchaseFormModel"/> Id
    /// </summary>
    public Guid? PurchaseFormId { get; set; }
    /// <summary>
    /// <inheritdoc cref="FormKeyBaseModel.PurchaseForm" path="/summary"/>
    /// </summary>
    public PurchaseFormModel? PurchaseForm { get; set; }
    /// <summary>
    /// <inheritdoc cref="FormKeyBaseModel.OKUD" path="/summary"/>
    /// </summary>
    public string OKUD { get; set; }
    /// <summary>
    /// <inheritdoc cref="FormKeyBaseModel.OKPO" path="/summary"/>
    /// </summary>
    public string OKPO { get; set; }
    /// <summary>
    /// <inheritdoc cref="FormKeyBaseModel.TIN" path="/summary"/>
    /// </summary>
    public string TIN { get; set; }
    /// <summary>
    /// <inheritdoc cref="FormKeyBaseModel.OKDP" path="/summary"/>
    /// </summary>
    public string OKDP { get; set; }
}
