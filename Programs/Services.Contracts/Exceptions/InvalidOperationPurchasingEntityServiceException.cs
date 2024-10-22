namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Exceptions;

/// <summary>
/// Ошибка сервиса. Недопустимая операция закупочной сущности
/// </summary>
public class InvalidOperationPurchasingEntityServiceException : EntityServiceException
{
    public InvalidOperationPurchasingEntityServiceException(string message) : base(message)
    {
        
    }
}
