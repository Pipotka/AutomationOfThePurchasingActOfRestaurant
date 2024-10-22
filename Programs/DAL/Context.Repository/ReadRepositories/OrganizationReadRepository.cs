using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;
using Microsoft.EntityFrameworkCore;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.ReadRepositories;

/// <summary>
/// Читает <see cref="Organization"/> из репозитория
/// </summary>
public class OrganizationReadRepository : IOrganizationReadRepository
{
    private readonly IDbReader reader;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="OrganizationReadRepository"/>
    /// </summary>
    public OrganizationReadRepository(IDbReader reader)
    {
        this.reader = reader;
    }

    /// <summary>
    /// Получает все организации
    /// </summary>
    public Task<List<Organization>> GetAllAsync(CancellationToken token)
        => reader.Read<Organization>()
        .NotDeleted()
                 .OrderBy(org => org.Id)
                 .ToListAsync(token);

    /// <summary>
    /// Получает организацию по идентификатору
    /// </summary>
    public Task<Organization?> GetAsync(Guid id, CancellationToken token)
        => reader.Read<Organization>()
            .NotDeleted()
            .Where(org => org.Id == id)
            .FirstOrDefaultAsync(token);

    /// <summary>
    /// Получает организацию по названию
    /// </summary>
    public Task<Organization?> GetByNameAsync(string name, CancellationToken token)
        => reader.Read<Organization>()
            .NotDeleted()
            .Where(org => org.Name == name)
            .FirstOrDefaultAsync(token);

    /// <summary>
    /// Проверяет, существует ли организация по свойствам Name, Address и StructuralUnit
    /// </summary>
    public bool IsExist(Organization organization)
        => reader.Read<Organization>()
        .NotDeleted()
                 .Any(org => org.Name == organization.Name &&
                             org.Address == organization.Address &&
                             org.StructuralUnit == organization.StructuralUnit);

    /// <summary>
    /// Получает страницу из организаций
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
    public async Task<List<Organization>> GetPageAsync(OrganizationSortBy sortBy, int pageNumber, int pageSize, CancellationToken token)
    {
        var result = reader.Read<Organization>().NotDeleted();

        switch (sortBy)
        {
            case OrganizationSortBy.Id:
                result = result.OrderBy(x => x.Id);
                break;
            case OrganizationSortBy.Name:
                result = result.OrderBy(x => x.Name);
                break;
            case OrganizationSortBy.NameDesc:
                result = result.OrderByDescending(x => x.Name);
                break;
            case OrganizationSortBy.Address:
                result = result.OrderBy(x => x.Address);
                break;
            case OrganizationSortBy.AddressDesc:
                result = result.OrderByDescending(x => x.Address);
                break;
            case OrganizationSortBy.StructuralUnit:
                result = result.OrderBy(x => x.StructuralUnit);
                break;
            case OrganizationSortBy.StructuralUnitDesc:
                result = result.OrderByDescending(x => x.StructuralUnit);
                break;
            case OrganizationSortBy.DateOfCreation:
                result = result.OrderBy(x => x.DateOfCreation);
                break;
            case OrganizationSortBy.DateOfCreationDesc:
                result = result.OrderByDescending(x => x.DateOfCreation);
                break;
            case OrganizationSortBy.DateOfLastChange:
                result = result.OrderBy(x => x.DateOfLastChange);
                break;
            case OrganizationSortBy.DateOfLastChangeDesc:
                result = result.OrderByDescending(x => x.DateOfLastChange);
                break;
        }

        result = result
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

        return await result.ToListAsync(token);
    }
}