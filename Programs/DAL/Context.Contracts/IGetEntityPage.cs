
namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;

/// <summary>
/// Интерфейс получения страницы из сущностей
/// </summary>
public interface IGetEntityPage<TEntity, TEntitySortBy>
    where TEntity : class, IBaseEntity
    where TEntitySortBy : Enum
{
    /// <summary>
    /// Получает <paramref name="pageNumber"/> страницу,
    /// из <paramref name="pageSize"/> элементов
    /// </summary>
    /// <param name="sortBy">
    /// Перечисление сортировок для <see cref="TEntity"/>
    /// </param>
    /// <param name="pageNumber">
    /// Номер страницы
    /// </param>
    /// <param name="pageSize">
    /// размер страницы
    /// </param>
    Task<List<TEntity>> GetPageAsync(TEntitySortBy sortBy, int pageNumber, int pageSize, CancellationToken token);
}
