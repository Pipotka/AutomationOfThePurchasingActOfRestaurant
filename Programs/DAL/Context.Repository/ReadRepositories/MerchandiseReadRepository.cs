using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;
using Microsoft.EntityFrameworkCore;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.ReadRepositories;

/// <summary>
/// Читает <see cref="Merchandise"/> из репозитория
/// </summary>
public class MerchandiseReadRepository : IMerchandiseReadRepository
{
    private readonly IDbReader reader;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="MerchandiseReadRepository"/>
    /// </summary>
    public MerchandiseReadRepository(IDbReader reader)
    {
        this.reader = reader;
    }

    /// <summary>
    /// Получает все товары
    /// </summary>
    public Task<List<Merchandise>> GetAllAsync(CancellationToken token)
        => reader.Read<Merchandise>()
        .NotDeleted()
                 .OrderBy(m => m.Id)
                 .ToListAsync(token);

    /// <summary>
    /// Получает все товары c сылками
    /// </summary>
    public Task<List<Merchandise>> GetAllWithLinksAsync(CancellationToken token)
        => reader.Read<Merchandise>()
        .NotDeleted()
                 .OrderBy(m => m.Id)
                 .Include(m => m.MeasurementUnit)
                 .ToListAsync(token);

    /// <summary>
    /// Получает товар по идентификатору
    /// </summary>
    public Task<Merchandise?> GetAsync(Guid id, CancellationToken token)
        => reader.Read<Merchandise>()
            .NotDeleted()
            .Where(m => m.Id == id)
            .FirstOrDefaultAsync(token);

    /// <summary>
    /// Получает товар по названию
    /// </summary>
    public Task<Merchandise?> GetByNameAsync(string name, CancellationToken token)
        => reader.Read<Merchandise>()
            .NotDeleted()
            .Where(m => m.Name == name)
            .FirstOrDefaultAsync(token);

    /// <summary>
    /// Проверяет, существует ли товар по свойствам Name и MerchandiseKey
    /// </summary>
    public bool IsExist(Merchandise merchandise)
        => reader.Read<Merchandise>()
        .NotDeleted()
                 .Any(m => m.Name == merchandise.Name && m.MerchandiseKey == merchandise.MerchandiseKey);

    /// <summary>
    /// Получает страницу из товаров
    /// </summary>
    /// <param name="sortBy">
    /// Метод сортировки списка
    /// </param>
    /// <param name="pageNumber">
    /// Номер страницы
    /// </param>
    /// <param name="pageSize">
    /// Размер страницы
    /// </param>
    public async Task<List<Merchandise>> GetPageAsync(MerchandiseSortBy sortBy, int pageNumber, int pageSize, CancellationToken token)
    {
        var result = reader.Read<Merchandise>().NotDeleted();

        switch (sortBy)
        {
            case MerchandiseSortBy.Id:
                result = result.OrderBy(x => x.Id);
                break;
            case MerchandiseSortBy.Name:
                result = result.OrderBy(x => x.Name);
                break;
            case MerchandiseSortBy.NameDesc:
                result = result.OrderByDescending(x => x.Name);
                break;
            case MerchandiseSortBy.MerchandiseKey:
                result = result.OrderBy(x => x.MerchandiseKey);
                break;
            case MerchandiseSortBy.MerchandiseKeyDesc:
                result = result.OrderByDescending(x => x.MerchandiseKey);
                break;
            case MerchandiseSortBy.DateOfCreation:
                result = result.OrderBy(x => x.DateOfCreation);
                break;
            case MerchandiseSortBy.DateOfCreationDesc:
                result = result.OrderByDescending(x => x.DateOfCreation);
                break;
            case MerchandiseSortBy.DateOfLastChange:
                result = result.OrderBy(x => x.DateOfLastChange);
                break;
            case MerchandiseSortBy.DateOfLastChangeDesc:
                result = result.OrderByDescending(x => x.DateOfLastChange);
                break;
            case MerchandiseSortBy.Count:
                result = result.OrderBy(x => x.Count);
                break;
            case MerchandiseSortBy.CountDesc:
                result = result.OrderByDescending(x => x.Count);
                break;
        }

        result = result
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

        return await result.ToListAsync(token);
    }
}