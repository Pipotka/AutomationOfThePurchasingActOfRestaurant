namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Exceptions;

/// <summary>
/// Ошибка сервиса. Сущность не найдена
/// </summary>
public abstract class EntityNotFoundServiceExeption : EntityServiceException
{
    protected EntityNotFoundServiceExeption(string message) : base(message)
    {
    }
}
