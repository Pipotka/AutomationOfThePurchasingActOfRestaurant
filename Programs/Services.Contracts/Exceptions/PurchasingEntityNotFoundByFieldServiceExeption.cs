namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Exceptions;
/// <summary>
/// Ошибка сервиса. Закупочная сущность не найдена по значению поля
/// </summary>
public class PurchasingEntityNotFoundByFieldServiceExeption<TEntity> : EntityNotFoundServiceExeption
{
    public PurchasingEntityNotFoundByFieldServiceExeption(string fieldName, string fieldValue) 
        : base($"Сущность {typeof(TEntity)} с полем {fieldName}, равным {fieldValue} не найдена")
    {

    }
}
