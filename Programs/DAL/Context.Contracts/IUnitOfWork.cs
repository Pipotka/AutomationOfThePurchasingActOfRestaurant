using System;
using System.Collections.Generic;
using System.Linq;
namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;

/// <summary>
/// UnitOfWork паттерн
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Асинхронное сохранение изменений
    /// </summary>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
