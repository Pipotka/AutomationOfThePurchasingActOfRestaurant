
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Extensions;

public static class MeasurementUnitModelExtension
{
    /// <summary>
    /// Превращает <see cref="MeasurementUnitModel.OKEIKey"/> в строку
    /// </summary>
    /// <returns>Возвращает <see cref="MeasurementUnitModel.OKEIKey"/> в виде строки</returns>
    public static string OKEIKeyToString(this MeasurementUnitModel measurementUnitModel)
    {
        if (measurementUnitModel.OKEIKey < 100)
        {
            if (measurementUnitModel.OKEIKey < 10)
            {
                return $"00{measurementUnitModel.OKEIKey}";
            }
            return $"0{measurementUnitModel.OKEIKey}";
        }
        return measurementUnitModel.OKEIKey.ToString();
    }
}
