using AutoMapper;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.WriteRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Exceptions;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.ModelServices;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.ModelServices;

/// <summary>
/// Сервис по работе с ценами товаров
/// </summary>
public class MerchandisePriceService : IMerchandisePriceService
{
    private readonly IMerchandisePriceReadRepository merchandisePriceReadRepository;
    private readonly IMerchandisePriceWriteRepository merchandisePriceWriteRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    /// <summary>
    /// Конструктор <see cref="MerchandisePriceService"/>
    /// </summary>
    public MerchandisePriceService(IMerchandisePriceReadRepository merchandisePriceReadRepository
        , IMerchandisePriceWriteRepository merchandisePriceWriteRepository
        , IUnitOfWork unitOfWork
        , IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.merchandisePriceWriteRepository = merchandisePriceWriteRepository;
        this.merchandisePriceReadRepository = merchandisePriceReadRepository;
        this.mapper = mapper;
    }

    /// <summary>
    /// Добавляет цену товара
    /// </summary>
    public async Task<MerchandisePriceModel> AddAsync(MerchandisePriceBaseModel source, CancellationToken token)
    {
        var IsExist = merchandisePriceReadRepository.IsExist(mapper.Map<MerchandisePrice>(source));
        if (IsExist)
        {
            throw new InvalidOperationPurchasingEntityServiceException($"Цена {source.CostPerUnit} уже существует");
        }

        var result = mapper.Map<MerchandisePrice>(source);
        result.Id = Guid.NewGuid();
        merchandisePriceWriteRepository.Add(result);
        await unitOfWork.SaveChangesAsync(token);

        return mapper.Map<MerchandisePriceModel>(result);
    }

    /// <summary>
    /// Удаляет цену товара по Id
    /// </summary>
    public async Task DeleteByIdAsync(Guid id, CancellationToken token)
    {
        var result = await merchandisePriceReadRepository.GetAsync(id, token);
        if (result != null)
        {
            merchandisePriceWriteRepository.Delete(result);
            await unitOfWork.SaveChangesAsync(token);
            return;
        }
        throw new PurchasingEntityNotFoundByIdServiceExeption<MerchandisePrice>(id);
    }

    /// <summary>
    /// Возвращает все цены товара
    /// </summary>
    public async Task<List<MerchandisePriceModel>> GetAllAsync(CancellationToken token)
    {
        var result = await merchandisePriceReadRepository.GetAllAsync(token);
        return mapper.Map<List<MerchandisePriceModel>>(result);
    }

    /// <summary>
    /// Возвращает цену товара по Id
    /// </summary>
    public async Task<MerchandisePriceModel> GetAsync(Guid id, CancellationToken token)
    {
        var result = await merchandisePriceReadRepository.GetAsync(id, token);
        if (result == null)
        {
            throw new PurchasingEntityNotFoundByIdServiceExeption<MerchandisePrice>(id);
        }
        return mapper.Map<MerchandisePriceModel>(result);
    }

    /// <summary>
    /// Возвращает цену товара по Id товара
    /// </summary>
    public async Task<List<MerchandisePriceModel>> GetByMerchandiseIdAsync(Guid MerchendiseId, CancellationToken token)
    {
        var result = await merchandisePriceReadRepository.GetByMerchandiseIdAsync(MerchendiseId, token);
        if (result == null)
        {
            throw new PurchasingEntityNotFoundByRelatedEntityServiceExeption<MerchandisePriceModel, Merchandise>(MerchendiseId);
        }
        return mapper.Map<List<MerchandisePriceModel>>(result);
    }

    /// <summary>
    /// Изменяет цену товара
    /// </summary>
    public async Task<MerchandisePriceModel> UpdateAsync(MerchandisePriceModel source, CancellationToken token)
    {
        var result = await merchandisePriceReadRepository.GetAsync(source.Id, token);
        if (result != null)
        {
            mapper.Map(source, result);
            merchandisePriceWriteRepository.Update(result);
            await unitOfWork.SaveChangesAsync(token);
            return source;
        }
        throw new PurchasingEntityNotFoundByIdServiceExeption<MerchandisePrice>(source.Id);
    }
}
