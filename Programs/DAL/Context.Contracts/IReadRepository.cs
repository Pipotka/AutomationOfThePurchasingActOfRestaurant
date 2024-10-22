namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;

/// <summary>
/// Интерфейс обобщенного репозитория на чтение
/// </summary>
public interface IReadRepository<TEntity> where TEntity : class, IBaseEntity
{
    /// <summary>
    /// Получает список всех сущностей
    /// </summary>
    Task<List<TEntity>> GetAllAsync(CancellationToken token);

    /// <summary>
    /// Получает сущночть по индентификатору
    /// </summary>
    Task<TEntity?> GetAsync(Guid id, CancellationToken token);

    /// <summary>
    /// Проверяет существует ли сущность
    /// </summary>
    /// <returns>
    /// Если сущность существует,
    /// то возвращает <c>True</c>, иначе <c>False</c>
    /// </returns>
    bool IsExist(TEntity entity);
}