namespace Company.AutomationOfThePurchasingActOfRestaurant.Infrastructure;

/// <summary>
/// Информация об ошибке работы с API
/// </summary>
public class ApiExeptionDetails
{
    /// <summary>
    /// Сообщение об ошибке
    /// </summary>
    public string Message { get; set; } = string.Empty;
}
