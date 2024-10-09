using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;
using Microsoft.EntityFrameworkCore;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.ReadRepositories;

/// <summary>
/// Читает <see cref="PurchaseForm"/> из репозитория
/// </summary>
public class PurchaseFormReadRepository : IPurchaseFormReadRepository
{
    private readonly IDbReader reader;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="PurchaseFormReadRepository"/>
    /// </summary>
    public PurchaseFormReadRepository(IDbReader reader)
    {
        this.reader = reader;
    }

    /// <summary>
    /// Получает все закупочные акты
    /// </summary>
    public Task<List<PurchaseForm>> GetAllAsync(CancellationToken token)
        => reader.Read<PurchaseForm>()
        .NotDeleted()
                 .OrderBy(pf => pf.Id)
                 .ToListAsync(token);

    /// <summary>
    /// Получает закупочный акт по идентификатору
    /// </summary>
    public Task<PurchaseForm?> GetAsync(Guid id, CancellationToken token)
        => reader.Read<PurchaseForm>()
            .NotDeleted()
            .Where(pf => pf.Id == id)
            .FirstOrDefaultAsync(token);

    /// <summary>
    /// Получает закупочный акт со всеми связями
    /// </summary>
    public Task<PurchaseForm?> GetWithAllLinksAsync(Guid id, CancellationToken token)
        => reader.Read<PurchaseForm>()
            .NotDeleted()
            .Where(pf => pf.Id == id)
            .Include(pf => pf.FormKey)
            .Include(pf => pf.SponsorOrganization)
            .Include(pf => pf.ApprovingOfficer)
            .Include(pf => pf.OfficerSignature)
            .Include(pf => pf.ProcurementSpecialist)
            .Include(pf => pf.Salesman)
            .Include(pf => pf.PurchasedMerchandises)
                .ThenInclude(m => m.MeasurementUnit)
            .Include(pf => pf.Prices)
            .FirstOrDefaultAsync(token);

    /// <summary>
    /// Получает закупочный акт по коду формы
    /// </summary>
    public Task<PurchaseForm?> GetByFormKeyAsync(Guid formKeyId, CancellationToken token)
        => reader.Read<PurchaseForm>()
            .NotDeleted()
            .Where(pf => pf.FormKeyId == formKeyId)
            .FirstOrDefaultAsync(token);

    /// <summary>
    /// Проверяет, существует ли закупочный акт по свойству FormKeyId
    /// </summary>
    public bool IsExist(PurchaseForm purchaseForm)
        => reader.Read<PurchaseForm>()
        .NotDeleted()
                 .Any(pf => pf.FormKeyId == purchaseForm.FormKeyId);

    /// <summary>
    /// Получает страницу из закупочных актов
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
    public async Task<List<PurchaseForm>> GetPageAsync(PurchaseFormSortBy sortBy, int pageNumber, int pageSize, CancellationToken token)
    {
        var result = reader.Read<PurchaseForm>().NotDeleted();

        switch (sortBy)
        {
            case PurchaseFormSortBy.Id:
                result = result.OrderBy(x => x.Id);
                break;
            case PurchaseFormSortBy.DocumentNumber:
                result = result.OrderBy(x => x.DocumentNumber);
                break;
            case PurchaseFormSortBy.DocumentNumberDesc:
                result = result.OrderByDescending(x => x.DocumentNumber);
                break;
            case PurchaseFormSortBy.DocumentDate:
                result = result.OrderBy(x => x.DocumentDate);
                break;
            case PurchaseFormSortBy.DocumentDateDesc:
                result = result.OrderByDescending(x => x.DocumentDate);
                break;
            case PurchaseFormSortBy.AddressOfPurchase:
                result = result.OrderBy(x => x.AddressOfPurchase);
                break;
            case PurchaseFormSortBy.AddressOfPurchaseDesc:
                result = result.OrderByDescending(x => x.AddressOfPurchase);
                break;
            case PurchaseFormSortBy.DateOfCreation:
                result = result.OrderBy(x => x.DateOfCreation);
                break;
            case PurchaseFormSortBy.DateOfCreationDesc:
                result = result.OrderByDescending(x => x.DateOfCreation);
                break;
            case PurchaseFormSortBy.DateOfLastChange:
                result = result.OrderBy(x => x.DateOfLastChange);
                break;
            case PurchaseFormSortBy.DateOfLastChangeDesc:
                result = result.OrderByDescending(x => x.DateOfLastChange);
                break;
            case PurchaseFormSortBy.ApprovingOfficerName:
                result = result.OrderBy(x => x.ApprovingOfficer.FirstName).ThenBy(x => x.ApprovingOfficer.LastName);
                break;
            case PurchaseFormSortBy.ApprovingOfficerNameDesc:
                result = result.OrderByDescending(x => x.ApprovingOfficer.FirstName).ThenByDescending(x => x.ApprovingOfficer.LastName);
                break;
            case PurchaseFormSortBy.SponsorOrganizationName:
                result = result.OrderBy(x => x.SponsorOrganization.Name);
                break;
            case PurchaseFormSortBy.SponsorOrganizationNameDesc:
                result = result.OrderByDescending(x => x.SponsorOrganization.Name);
                break;
        }

        result = result
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

        return await result.ToListAsync(token);
    }
}