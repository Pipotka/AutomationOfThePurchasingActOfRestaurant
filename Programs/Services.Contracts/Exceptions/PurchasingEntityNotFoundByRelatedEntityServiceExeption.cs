
namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Exceptions;

public class PurchasingEntityNotFoundByRelatedEntityServiceExeption<TEntity, TRelatedEntity> : EntityNotFoundServiceExeption
{
    public PurchasingEntityNotFoundByRelatedEntityServiceExeption(Guid relatedEntityId) 
        : base($"Cущность {typeof(TEntity)} не найдена по связанной сущности {typeof(TRelatedEntity)}, id которой равна {relatedEntityId}")
    {
    }
}
