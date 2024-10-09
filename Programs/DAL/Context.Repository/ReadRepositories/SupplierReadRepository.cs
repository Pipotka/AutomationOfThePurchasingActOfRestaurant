using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;
using Microsoft.EntityFrameworkCore;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.ReadRepositories;

/// <summary>
/// Читает <see cref="Supplier"/> из репозитория
/// </summary>
public class SupplierReadRepository : ISupplierReadRepository
{
    private readonly IDbReader reader;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="SupplierReadRepository"/>
    /// </summary>
    public SupplierReadRepository(IDbReader reader)
    {
        this.reader = reader;
    }

    /// <summary>
    /// Получает все поставщики
    /// </summary>
    public Task<List<Supplier>> GetAllAsync(CancellationToken token)
        => reader.Read<Supplier>()
        .NotDeleted()
                 .OrderBy(s => s.LastName)
                 .ToListAsync(token);

    /// <summary>
    /// Получает поставщика по идентификатору
    /// </summary>
    public Task<Supplier?> GetAsync(Guid id, CancellationToken token)
        => reader.Read<Supplier>()
            .NotDeleted()
            .Where(s => s.Id == id)
            .FirstOrDefaultAsync(token);

    /// <summary>
    /// Получает поставщика по фамилии
    /// </summary>
    public Task<Supplier?> GetByLastNameAsync(string lastName, CancellationToken token)
        => reader.Read<Supplier>()
            .NotDeleted()
            .Where(s => s.LastName == lastName)
            .FirstOrDefaultAsync(token);

    /// <summary>
    /// Проверяет, существует ли поставщик по свойствам FirstName и LastName
    /// </summary>
    public bool IsExist(Supplier supplier)
        => reader.Read<Supplier>()
        .NotDeleted()
                 .Any(s => s.FirstName == supplier.FirstName &&
                           s.LastName == supplier.LastName);

    /// <summary>
    /// Получает страницу из поставщиков
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
    public async Task<List<Supplier>> GetPageAsync(SupplierSortBy sortBy, int pageNumber, int pageSize, CancellationToken token)
    {
        var result = reader.Read<Supplier>().NotDeleted();

        switch (sortBy)
        {
            case SupplierSortBy.Id:
                result = result.OrderBy(x => x.Id);
                break;
            case SupplierSortBy.FirstName:
                result = result.OrderBy(x => x.FirstName);
                break;
            case SupplierSortBy.FirstNameDesc:
                result = result.OrderByDescending(x => x.FirstName);
                break;
            case SupplierSortBy.LastName:
                result = result.OrderBy(x => x.LastName);
                break;
            case SupplierSortBy.LastNameDesc:
                result = result.OrderByDescending(x => x.LastName);
                break;
            case SupplierSortBy.Patronymic:
                result = result.OrderBy(x => x.Patronymic);
                break;
            case SupplierSortBy.PatronymicDesc:
                result = result.OrderByDescending(x => x.Patronymic);
                break;
            case SupplierSortBy.DateOfCreation:
                result = result.OrderBy(x => x.DateOfCreation);
                break;
            case SupplierSortBy.DateOfCreationDesc:
                result = result.OrderByDescending(x => x.DateOfCreation);
                break;
            case SupplierSortBy.DateOfLastChange:
                result = result.OrderBy(x => x.DateOfLastChange);
                break;
            case SupplierSortBy.DateOfLastChangeDesc:
                result = result.OrderByDescending(x => x.DateOfLastChange);
                break;
        }

        result = result
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

        return await result.ToListAsync(token);
    }
}