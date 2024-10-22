namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts;

/// <summary>
/// Базовый интерфейс сервиса сущностей
/// </summary>
public interface IBaseEntityService<TEntityModel, TBaseEntityModel> 
    where TEntityModel : class, IEntityModel 
    where TBaseEntityModel : class, IBaseEntityModel
{
    /// <summary>
    /// Возвращает список всех сущностей
    /// </summary>
    Task<List<TEntityModel>> GetAllAsync(CancellationToken token);

    /// <summary>
    /// Возвращает сущность по id
    /// </summary>
    Task<TEntityModel> GetAsync(Guid id, CancellationToken token);
    /// <summary>
    /// Добавляет новую сущность
    /// </summary>
    Task<TEntityModel> AddAsync(TBaseEntityModel source, CancellationToken token);

    /// <summary>
    /// Изменяет сущность
    /// </summary>
    Task<TEntityModel> UpdateAsync(TEntityModel source, CancellationToken token);

    /// <summary>
    /// Удаляет сущность
    /// </summary>
    Task DeleteByIdAsync(Guid id, CancellationToken token);
}
