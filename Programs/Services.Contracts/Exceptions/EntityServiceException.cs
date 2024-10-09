namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Exceptions;

/// <summary>
/// Ошибка сервиса. Ошибка, связанная с сущностью
/// </summary>
public abstract class EntityServiceException : Exception
{
    protected EntityServiceException(string message)
        : base(message)
    {

    }
}
