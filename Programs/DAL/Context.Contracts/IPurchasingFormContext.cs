using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using System.Collections.Generic;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;

/// <summary>
/// Контекст работы с Закупочными актами
/// </summary>
public interface IPurchasingFormContext
{
    /// <summary>
    /// Таблица закупочных актов
    /// </summary>
    public IQueryable<PurchaseForm> purchaseForms { get; }

    /// <summary>
    /// Таблица утверждающих
    /// </summary>
    public IQueryable<Approver> Approvers { get; }
    /// <summary>
    /// Таблица сотрудников
    /// </summary>
    public IQueryable<Employee> Employees { get; }
    /// <summary>
    /// Таблица должностей сотрудников
    /// </summary>
    public IQueryable<EmployeePosition> EmployeePositions { get; }
    /// <summary>
    /// Таблица кодов форм
    /// </summary>
    public IQueryable<FormKey> FormKeys { get; }
    /// <summary>
    /// Таблица единиц измерения
    /// </summary>
    public IQueryable<MeasurementUnit> MeasurementUnits { get; }
    /// <summary>
    /// Таблица товаров
    /// </summary>
    public IQueryable<Merchandise> Merchandises { get; }
    /// <summary>
    /// Таблица организаций
    /// </summary>
    public IQueryable<Organization> Organizations { get; }
    /// <summary>
    /// Таблица поставщиков
    /// </summary>
    public IQueryable<Supplier> Suppliers { get; }
}
