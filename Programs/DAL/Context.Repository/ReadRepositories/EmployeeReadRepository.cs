using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;
using Microsoft.EntityFrameworkCore;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.ReadRepositories;

/// <summary>
/// Читает <see cref="Employee"/> из репозитория
/// </summary>
public class EmployeeReadRepository : IEmployeeReadRepository
{
    private readonly IDbReader reader;

    /// <summary>
    /// Инициализирует новый эекземпляр <see cref="EmployeeReadRepository"/>
    /// </summary>
    public EmployeeReadRepository(IDbReader reader)
    {
        this.reader = reader;
    }

    /// <summary>
    /// Получает список всех сотрудников
    /// </summary>
    public Task<List<Employee>> GetAllAsync(CancellationToken token)
        => reader.Read<Employee>()
        .NotDeleted()
        .OrderBy(e => e.LastName)
        .ToListAsync(token);

    /// <summary>
    /// Получает список всех сотрудников с их связями
    /// </summary>
    public Task<List<Employee>> GetAllWithLinksAsync(CancellationToken token)
        => reader.Read<Employee>()
        .NotDeleted()
        .OrderBy(e => e.LastName)
        .Include(e => e.Position)
        .ToListAsync(token);

    /// <summary>
    /// Получает сотрудника по идентификатору
    /// </summary>
    public Task<Employee?> GetAsync(Guid id, CancellationToken token)
        => reader.Read<Employee>()
        .NotDeleted()
        .Where(e => e.Id == id)
        .FirstOrDefaultAsync(token);

    /// <summary>
    /// Получает сотрудника по названию
    /// </summary>
    public Task<Employee?> GetByLastNameAsync(string lastName, CancellationToken token)
        => reader.Read<Employee>()
        .NotDeleted()
        .Where(e => e.LastName == lastName)
        .FirstOrDefaultAsync(token);

    /// <summary>
    /// Проверяет, существует ли сотрудник
    /// </summary>
    public bool IsExist(Employee employee)
        => reader.Read<Employee>()
        .NotDeleted()
        .Any(e => e.FirstName == employee.FirstName
        && e.LastName == employee.LastName);

    /// <summary>
    /// Получает страницу из сотрудников
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
    public async Task<List<Employee>> GetPageAsync(EmployeeSortBy sortBy, int pageNumber, int pageSize, CancellationToken token)
    {
        var result = reader.Read<Employee>().NotDeleted();

        switch (sortBy)
        {
            case EmployeeSortBy.Id:
                result = result.OrderBy(x => x.Id);
                break;
            case EmployeeSortBy.Patronymic:
                result = result.OrderBy(x => x.Patronymic);
                break;
            case EmployeeSortBy.PatronymicDesc:
                result = result.OrderByDescending(x => x.Patronymic);
                break;
            case EmployeeSortBy.DateOfCreation:
                result = result.OrderBy(x => x.DateOfCreation);
                break;
            case EmployeeSortBy.DateOfCreationDesc:
                result = result.OrderByDescending(x => x.DateOfCreation);
                break;
            case EmployeeSortBy.DateOfLastChange:
                result = result.OrderBy(x => x.DateOfLastChange);
                break;
            case EmployeeSortBy.DateOfLastChangeDesc:
                result = result.OrderByDescending(x => x.DateOfLastChange);
                break;
            case EmployeeSortBy.FirstName:
                result = result.OrderBy(x => x.FirstName);
                break;
            case EmployeeSortBy.FirstNameDesc:
                result = result.OrderByDescending(x => x.FirstName);
                break;
            case EmployeeSortBy.LastName:
                result = result.OrderBy(x => x.LastName);
                break;
            case EmployeeSortBy.LastNameDesc:
                result = result.OrderByDescending(x => x.LastName);
                break;
        }

        result = result
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

        return await result.ToListAsync(token);
    }
}
