
namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts;

/// <summary>
/// Интерфейс получения страницы из моделей сущности
/// </summary>
public interface IGetEntityModelPage<TEntityModel, TEntitySortBy>
    where TEntityModel : class, IEntityModel
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
    public Task<List<TEntityModel>> GetPageAsync(TEntitySortBy sortBy, int pageNumber, int pageSize, CancellationToken token);
}