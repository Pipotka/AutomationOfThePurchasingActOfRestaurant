using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;
using Microsoft.EntityFrameworkCore;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.ReadRepositories;

/// <summary>
/// Читает <see cref="EmployeePosition"/> из репозитория
/// </summary>
public class EmployeePositionReadRepository : IEmployeePositionReadRepository
{
    private readonly IDbReader reader;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="EmployeePositionReadRepository"/>
    /// </summary>
    public EmployeePositionReadRepository(IDbReader reader)
    {
        this.reader = reader;
    }

    /// <summary>
    /// Получает должность по названию
    /// </summary>
    public Task<EmployeePosition?> GetByNameAsync(string name, CancellationToken token)
        => reader.Read<EmployeePosition>()
            .NotDeleted()
            .Where(ep => ep.Name == name)
            .FirstOrDefaultAsync(token);

    /// <summary>
    /// Получает должность по идентификатору
    /// </summary>
    public Task<EmployeePosition?> GetAsync(Guid id, CancellationToken token)
        => reader.Read<EmployeePosition>()
            .NotDeleted()
            .Where(ep => ep.Id == id)
            .FirstOrDefaultAsync(token);

    /// <summary>
    /// Получает список всех должностей
    /// </summary>
    public Task<List<EmployeePosition>> GetAllAsync(CancellationToken token)
        => reader.Read<EmployeePosition>()
            .NotDeleted()
            .OrderBy(ep => ep.Name)
            .ToListAsync(token);

    /// <summary>
    /// Проверяет, существует ли должность
    /// </summary>
    public bool IsExist(EmployeePosition employeePosition)
        => reader.Read<EmployeePosition>()
            .NotDeleted()
            .Any(ep => ep.Name == employeePosition.Name);

    /// <summary>
    /// Получает страницу из должностей сотрудников
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
    public async Task<List<EmployeePosition>> GetPageAsync(EmployeePositionSortBy sortBy, int pageNumber, int pageSize, CancellationToken token)
    {
        var result = reader.Read<EmployeePosition>().NotDeleted();

        switch (sortBy)
        {
            case EmployeePositionSortBy.Id:
                result = result.OrderBy(x => x.Id);
                break;
            case EmployeePositionSortBy.Name:
                result = result.OrderBy(x => x.Name);
                break;
            case EmployeePositionSortBy.NameDesc:
                result = result.OrderByDescending(x => x.Name);
                break;
            case EmployeePositionSortBy.DateOfCreation:
                result = result.OrderBy(x => x.DateOfCreation);
                break;
            case EmployeePositionSortBy.DateOfCreationDesc:
                result = result.OrderByDescending(x => x.DateOfCreation);
                break;
            case EmployeePositionSortBy.DateOfLastChange:
                result = result.OrderBy(x => x.DateOfLastChange);
                break;
            case EmployeePositionSortBy.DateOfLastChangeDesc:
                result = result.OrderByDescending(x => x.DateOfLastChange);
                break;
        }

        result = result
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

        return await result.ToListAsync(token);
    }
}