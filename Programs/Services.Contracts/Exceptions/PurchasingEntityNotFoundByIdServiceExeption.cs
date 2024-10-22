namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Exceptions;

/// <summary>
/// Ошибка сервиса. Закупочная сущность не найдена по id
/// </summary>
public class PurchasingEntityNotFoundByIdServiceExeption<TEntity> : EntityNotFoundServiceExeption
{
    public PurchasingEntityNotFoundByIdServiceExeption(Guid id) 
        : base($"Сущность {typeof(TEntity)} с индентификатором {id} не найдена")
    {
    }
}
