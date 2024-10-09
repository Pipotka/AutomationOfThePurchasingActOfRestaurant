using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Models.CreateModelRequest;

/// <summary>
/// Модель запроса поставщика
/// </summary>
public class SupplierRequest
{
    /// <summary>
    /// <inheritdoc cref="SupplierBaseModel.PurchaseForms" path="/summary"/>
    /// </summary>
    public ICollection<PurchaseFormResponseModel> PurchaseForms { get; set; } = new List<PurchaseFormResponseModel>();
    /// <summary>
    /// <inheritdoc cref="SupplierBaseModel.FirstName" path="/summary"/>
    /// </summary>
    public string FirstName { get; set; }
    /// <summary>
    /// <inheritdoc cref="SupplierBaseModel.LastName" path="/summary"/>
    /// </summary>
    public string LastName { get; set; }
    /// <summary>
    /// <inheritdoc cref="SupplierBaseModel.Patronymic" path="/summary"/>
    /// </summary>
    public string Patronymic { get; set; } = string.Empty;
}
