namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;

/// <summary>
/// Базовый репозиторий для записи
/// </summary>
public abstract class BaseWriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : IBaseEntity
{
    private readonly IDbWriter writer;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="BaseWriteRepository"/>
    /// </summary>
    protected BaseWriteRepository(IDbWriter writer)
    {
        this.writer = writer;
    }

    /// <summary>
    /// Добавить новую сущность
    /// </summary>
    public virtual void Add(TEntity entity)
    {
        entity.DateOfCreation = DateTime.UtcNow;
        entity.DateOfLastChange = DateTime.UtcNow;
        writer.Add(entity);
    }

    /// <summary>
    /// Изменить сущность
    /// </summary>
    public virtual void Update(TEntity entity)
    {
        if (entity is ISoftDelited softDelitedEntity)
        {
            if (!softDelitedEntity.IsDelited)
            {
                entity.DateOfLastChange = DateTime.UtcNow;
            }
        }
        else
        {
            entity.DateOfLastChange = DateTime.UtcNow;
        }
        writer.Update(entity);
    }

    /// <summary>
    /// Удалить сущность
    /// </summary>
    public virtual void Delete(TEntity entity)
    {
        if (entity is ISoftDelited softDelitedEntity)
        {
            softDelitedEntity.IsDelited = true;
            softDelitedEntity.DateOfDeletion = DateTime.UtcNow;
            Update(entity);
        }
        else
        {
            writer.Delete(entity);
        }
    }
}