using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Microsoft.EntityFrameworkCore;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.ReadRepositories;

/// <summary>
/// Читает <see cref="MeasurementUnit"/> из репозитория
/// </summary>
public class MeasurementUnitReadRepository : IMeasurementUnitReadRepository
{
    private readonly IDbReader reader;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="MeasurementUnitReadRepository"/>
    /// </summary>
    public MeasurementUnitReadRepository(IDbReader reader)
    {
        this.reader = reader;
    }

    /// <summary>
    /// Получает список всех единиц измерения
    /// </summary>
    public Task<List<MeasurementUnit>> GetAllAsync(CancellationToken token)
            => reader.Read<MeasurementUnit>()
        .NotDeleted()
            .OrderBy(mu => mu.Id)
            .ToListAsync(token);

    /// <summary>
    /// Получает единицу измерения по идентификатору
    /// </summary>
    public Task<MeasurementUnit?> GetAsync(Guid id, CancellationToken token)
        => reader.Read<MeasurementUnit>()
        .NotDeleted()
        .Where(mu => mu.Id == id)
        .FirstOrDefaultAsync(token);

    /// <summary>
    /// Получает единицу измерения по названию
    /// </summary>
    public Task<MeasurementUnit?> GetByNameAsync(string name, CancellationToken token)
        => reader.Read<MeasurementUnit>()
        .NotDeleted()
        .Where(mu => mu.Name == name)
        .FirstOrDefaultAsync(token);

    /// <summary>
    /// Получает единицу измерения по коду ОКЕИ
    /// </summary>
    public Task<MeasurementUnit?> GetByOKEIKeyAsync(string OKEIKey, CancellationToken token)
        => reader.Read<MeasurementUnit>()
        .NotDeleted()
        .Where(mu => mu.OKEIKey == OKEIKey)
        .FirstOrDefaultAsync(token);

    /// <summary>
    /// Проверяет существует ли единица измерения по Name и OKEIKey
    /// </summary>
    public bool IsExist(MeasurementUnit measurementUnit)
        => reader.Read<MeasurementUnit>()
        .NotDeleted()
        .Any(mu => mu.Name == measurementUnit.Name && mu.OKEIKey == measurementUnit.OKEIKey);
}