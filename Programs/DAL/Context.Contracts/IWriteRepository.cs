namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;

/// <summary>
/// Репозиторий для операций удаления, изменения и добавления сущностей
/// </summary>
public interface IWriteRepository<in TEntity> where TEntity : IBaseEntity
{
    /// <summary>
    /// Добавить новую сущность
    /// </summary>
    void Add(TEntity entity);

    /// <summary>
    /// Изменить сущность
    /// </summary>
    void Update(TEntity entity);

    /// <summary>
    /// Удалить сущность
    /// </summary>
    void Delete(TEntity entity);
}