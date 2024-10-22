using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;
using Microsoft.EntityFrameworkCore;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.ReadRepositories;

/// <summary>
/// Читает <see cref="FormKey"/> из репозитория
/// </summary>
public class FormKeyReadRepository : IFormKeyReadRepository
{
    private readonly IDbReader reader;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="FormKeyReadRepository"/>
    /// </summary>
    public FormKeyReadRepository(IDbReader reader)
    {
        this.reader = reader;
    }

    /// <summary>
    /// Получает код формы по идентификатору
    /// </summary>
    public Task<FormKey?> GetAsync(Guid id, CancellationToken token)
        => reader.Read<FormKey>()
        .NotDeleted()
            .Where(fk => fk.Id == id)
            .FirstOrDefaultAsync(token);

    /// <summary>
    /// Получает список всех кодов форм
    /// </summary>
    public Task<List<FormKey>> GetAllAsync(CancellationToken token)
        => reader.Read<FormKey>()
        .NotDeleted()
            .OrderBy(fk => fk.Id)
            .ToListAsync(token);

    /// <summary>
    /// Проверяет, существует ли код формы с указанными параметрами
    /// </summary>
    public bool IsExist(FormKey formKey)
        => reader.Read<FormKey>()
        .NotDeleted()
            .Any(fk => fk.OKUD == formKey.OKUD &&
                       fk.OKPO == formKey.OKPO &&
                       fk.TIN == formKey.TIN &&
                       fk.OKDP == formKey.OKDP);

    /// <summary>
    /// Получает страницу из кодов формы
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
    public async Task<List<FormKey>> GetPageAsync(FormKeySortBy sortBy, int pageNumber, int pageSize, CancellationToken token)
    {
        var result = reader.Read<FormKey>().NotDeleted();

        switch (sortBy)
        {
            case FormKeySortBy.Id:
                result = result.OrderBy(x => x.Id);
                break;
            case FormKeySortBy.OKUD:
                result = result.OrderBy(x => x.OKUD);
                break;
            case FormKeySortBy.OKUDDesc:
                result = result.OrderByDescending(x => x.OKUD);
                break;
            case FormKeySortBy.OKPO:
                result = result.OrderBy(x => x.OKPO);
                break;
            case FormKeySortBy.OKPODesc:
                result = result.OrderByDescending(x => x.OKPO);
                break;
            case FormKeySortBy.TIN:
                result = result.OrderBy(x => x.TIN);
                break;
            case FormKeySortBy.TINDesc:
                result = result.OrderByDescending(x => x.TIN);
                break;
            case FormKeySortBy.OKDP:
                result = result.OrderBy(x => x.OKDP);
                break;
            case FormKeySortBy.OKDPDesc:
                result = result.OrderByDescending(x => x.OKDP);
                break;
            case FormKeySortBy.DateOfCreation:
                result = result.OrderBy(x => x.DateOfCreation);
                break;
            case FormKeySortBy.DateOfCreationDesc:
                result = result.OrderByDescending(x => x.DateOfCreation);
                break;
            case FormKeySortBy.DateOfLastChange:
                result = result.OrderBy(x => x.DateOfLastChange);
                break;
            case FormKeySortBy.DateOfLastChangeDesc:
                result = result.OrderByDescending(x => x.DateOfLastChange);
                break;
        }

        result = result
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

        return await result.ToListAsync(token);
    }
}