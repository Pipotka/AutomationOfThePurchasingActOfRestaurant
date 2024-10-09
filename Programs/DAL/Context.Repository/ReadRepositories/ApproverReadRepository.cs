using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;
using Microsoft.EntityFrameworkCore;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.ReadRepositories;

/// <summary>
/// Читает <see cref="Approver"/> из репозитория
/// </summary>
public class ApproverReadRepository : IApproverReadRepository
{
    private readonly IDbReader reader;

    /// <summary>
    /// Инициализирует новый эекземпляр <see cref="ApproverReadRepository"/>
    /// </summary>
    public ApproverReadRepository(IDbReader reader)
    {
        this.reader = reader;
    }

    /// <summary>
    /// Получает утверждающего по фамилии
    /// </summary>
    public Task<Approver?> GetByLastNameAsync(string lastName, CancellationToken token)
        => reader.Read<Approver>()
            .NotDeleted()
            .Where(a => a.LastName == lastName)
            .FirstOrDefaultAsync(token);

    /// <summary>
    /// Получает утверждающего по идентификатору
    /// </summary>
    public async Task<Approver?> GetAsync(Guid id, CancellationToken token)
       => await reader.Read<Approver>()
            .NotDeleted()
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync(token);

    /// <summary>
    /// Получает список всех утверждающих
    /// </summary>
    public Task<List<Approver>> GetAllAsync(CancellationToken token)
        => reader.Read<Approver>()
        .NotDeleted()
        .OrderBy(a => a.LastName)
        .ToListAsync(token);

    /// <summary>
    /// Проверяет, существует ли утверждающий
    /// </summary>
    public bool IsExist(Approver approver)
        => reader.Read<Approver>()
        .NotDeleted()
        .Any(a => a.FirstName == approver.FirstName 
        && a.LastName == approver.LastName);

    /// <summary>
    /// Получает страницу из утверждающих
    /// </summary>
    /// <param name="sortBy">
    /// Метод сортировки списка
    /// </param>
    /// <param name="pageNumber">
    /// Номер страницы
    /// </param>
    /// <param name="pageSize">
    /// размер страницы
    /// </param>
    public async Task<List<Approver>> GetPageAsync(ApproverSortBy sortBy, int pageNumber, int pageSize, CancellationToken token)
    {
        var result = reader.Read<Approver>().NotDeleted();

        switch (sortBy)
        {
            case ApproverSortBy.Id:
                result = result.OrderBy(x => x.Id);
                break;
            case ApproverSortBy.Patronymic:
                result = result.OrderBy(x => x.Patronymic);
                break;
            case ApproverSortBy.PatronymicDesc:
                result = result.OrderByDescending(x => x.Patronymic);
                break;
            case ApproverSortBy.DateOfCreation:
                result = result.OrderBy(x => x.DateOfCreation);
                break;
            case ApproverSortBy.DateOfCreationDesc:
                result = result.OrderByDescending(x => x.DateOfCreation);
                break;
            case ApproverSortBy.DateOfLastChange:
                result = result.OrderBy(x => x.DateOfLastChange);
                break;
            case ApproverSortBy.DateOfLastChangeDesc:
                result = result.OrderByDescending(x => x.DateOfLastChange);
                break;
            case ApproverSortBy.FirstName:
                result = result.OrderBy(x => x.FirstName);
                break;
            case ApproverSortBy.FirstNameDesc:
                result = result.OrderByDescending(x => x.FirstName);
                break;
            case ApproverSortBy.LastName:
                result = result.OrderBy(x => x.LastName);
                break;
            case ApproverSortBy.LastNameDesc:
                result = result.OrderByDescending(x => x.LastName);
                break;
        }

        result = result
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize);

        return await result.ToListAsync(token);
    }
}