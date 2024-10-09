using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Microsoft.EntityFrameworkCore;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.ReadRepositories;

/// <summary>
/// Читает <see cref="MerchandisePrice"/> из репозитория
/// </summary>
public class MerchandisePriceReadRepository : IMerchandisePriceReadRepository
{
    private readonly IDbReader reader;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="MerchandisePriceReadRepository"/>
    /// </summary>
    public MerchandisePriceReadRepository(IDbReader reader)
    {
        this.reader = reader;
    }

    /// <summary>
    /// Получает все цены товаров
    /// </summary>
    public Task<List<MerchandisePrice>> GetAllAsync(CancellationToken token)
        => reader.Read<MerchandisePrice>()
        .NotDeleted()
                 .OrderBy(mp => mp.Id)
                 .ToListAsync(token);

    /// <summary>
    /// Получает цену товара по идентификатору
    /// </summary>
    public Task<MerchandisePrice?> GetAsync(Guid id, CancellationToken token)
        => reader.Read<MerchandisePrice>()
            .NotDeleted()
            .Where(mp => mp.Id == id)
            .FirstOrDefaultAsync(token);

    /// <summary>
    /// Получает цену товара по Id товара
    /// </summary>
    public Task<List<MerchandisePrice>> GetByMerchandiseIdAsync(Guid merchandiseId, CancellationToken token)
        => reader.Read<MerchandisePrice>()
            .NotDeleted()
            .Where(mp => mp.MerchandiseId == merchandiseId)
            .ToListAsync(token);

    /// <summary>
    /// Проверяет, существует ли цена товара по свойству CostPerUnit
    /// </summary>
    public bool IsExist(MerchandisePrice merchandisePrice)
        => reader.Read<MerchandisePrice>()
        .NotDeleted()
                 .Any(mp => mp.CostPerUnit == merchandisePrice.CostPerUnit);
}