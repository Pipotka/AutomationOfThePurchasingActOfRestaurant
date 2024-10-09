namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;

/// <summary>
/// Операции добавления, обновления, удаления над сущностями
/// </summary>
public interface IDbWriter
{
    /// <summary>
    /// Добавить новую сущность
    /// </summary>
    void Add<TEntity>(TEntity entity) where TEntity : IBaseEntity;

    /// <summary>
    /// Изменить сущность
    /// </summary>
    void Update<TEntity>(TEntity entity) where TEntity : IBaseEntity;

    /// <summary>
    /// Удалить сущность
    /// </summary>
    void Delete<TEntity>(TEntity entity) where TEntity : IBaseEntity;
}
