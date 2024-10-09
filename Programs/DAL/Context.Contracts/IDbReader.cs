namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;

/// <summary>
/// Интерфейс получения данных из контекста
/// </summary>
public interface IDbReader
{
    /// <summary>
    /// Выполнение запросов на чтение
    /// </summary>
    IQueryable<TEntity> Read<TEntity>() where TEntity : class, IBaseEntity;
}
