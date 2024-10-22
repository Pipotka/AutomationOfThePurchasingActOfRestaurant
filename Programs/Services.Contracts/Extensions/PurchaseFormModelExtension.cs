using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Extentoins;

/// <summary>
/// Расширение для <see cref="PurchaseFormModel"/>
/// </summary>
public static class PurchaseFormModelExtension
{
    /// <summary>
    /// Рассчитывает полную стоимость <see cref="PurchasedMerchandises"/>
    /// </summary>
    /// <returns>Полная стоимасть <see cref="PurchasedMerchandises"/></returns>
    public static double GetTotalCost(this PurchaseFormModel purchaseFormModel)
    {
        var totalCost = 0.0;
        foreach (var merchandise in purchaseFormModel.PurchasedMerchandises)
        {
            totalCost += merchandise.Price * merchandise.Count;
        }
        return totalCost;
    }
}
