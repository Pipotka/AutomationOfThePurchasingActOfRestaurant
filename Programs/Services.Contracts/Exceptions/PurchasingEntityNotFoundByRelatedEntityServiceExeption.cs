
namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Exceptions;

/// <summary>
/// Ошибка сервиса. Закупочная сущность не найдена по id связанной сущности
/// </summary>
public class PurchasingEntityNotFoundByRelatedEntityServiceExeption<TEntity, TRelatedEntity> : EntityNotFoundServiceExeption
{
    public PurchasingEntityNotFoundByRelatedEntityServiceExeption(Guid relatedEntityId) 
        : base($"Cущность {typeof(TEntity)} не найдена по связанной сущности {typeof(TRelatedEntity)}, id которой равна {relatedEntityId}")
    {
    }
}
