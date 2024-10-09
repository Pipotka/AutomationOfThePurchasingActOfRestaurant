using System.Linq;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;

/// <summary>
/// Общие спецификации чтения
/// </summary>
public static class CommonSpecs
{
    /// <summary>
    /// Активный. Не удалённый.
    /// </summary>
    public static IQueryable<TEntity> NotDeleted<TEntity>(this IQueryable<TEntity> query) where TEntity : ISoftDelited
        => query.Where(e => e.IsDelited == false);
}
