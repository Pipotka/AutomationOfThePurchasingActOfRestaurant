using AutoMapper;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.WriteRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Exceptions;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.ModelServices;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.ModelServices;

/// <summary>
/// Сервис по работе с закупочными актами
/// </summary>
public class PurchaseFormService : IPurchaseFormService
{
    private readonly IPurchaseFormReadRepository purchaseFormReadRepository;
    private readonly IPurchaseFormWriteRepository purchaseFormWriteRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    /// <summary>
    /// Конструктор <see cref="PurchaseFormService"/>
    /// </summary>
    public PurchaseFormService(IPurchaseFormReadRepository purchaseFormReadRepository
        , IPurchaseFormWriteRepository purchaseFormWriteRepository
        , IUnitOfWork unitOfWork
        , IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.purchaseFormWriteRepository = purchaseFormWriteRepository;
        this.purchaseFormReadRepository = purchaseFormReadRepository;
        this.mapper = mapper;
    }

    /// <summary>
    /// Получает <paramref name="pageNumber"/> страницу,
    /// из <paramref name="pageSize"/> моделей утверждающих
    /// </summary>
    /// <param name="sortBy">
    /// Перечисление сортировок для <see cref="PurchaseForm"/>
    /// </param>
    /// <param name="pageNumber">
    /// Номер страницы
    /// </param>
    /// <param name="pageSize">
    /// размер страницы
    /// </param>
    public async Task<List<PurchaseFormModel>> GetPageAsync(PurchaseFormSortBy sortBy, int pageNumber, int pageSize, CancellationToken token)
    {
        var result = await purchaseFormReadRepository.GetPageAsync(sortBy, pageNumber, pageSize, token);
        return mapper.Map<List<PurchaseFormModel>>(result);
    }

    /// <summary>
    /// Добавляет закупочный акт
    /// </summary>
    public async Task<PurchaseFormModel> AddAsync(PurchaseFormBaseModel source, CancellationToken token)
    {
        var IsExist = purchaseFormReadRepository.IsExist(mapper.Map<PurchaseForm>(source));
        if (IsExist)
        {
            throw new InvalidOperationPurchasingEntityServiceException(
                $"Закупочный акт с кодом формы = OKDP = {source.FormKey.OKDP}, OKUD = {source.FormKey.OKUD}, OKPO = {source.FormKey.OKPO} и TIN = {source.FormKey.TIN} уже существует");
        }

        var result = mapper.Map<PurchaseForm>(source);
        result.Id = Guid.NewGuid();
        purchaseFormWriteRepository.Add(result);
        await unitOfWork.SaveChangesAsync(token);

        return mapper.Map<PurchaseFormModel>(result);
    }

    /// <summary>
    /// Удаляет закупочный акт по Id
    /// </summary>
    public async Task DeleteByIdAsync(Guid id, CancellationToken token)
    {
        var result = await purchaseFormReadRepository.GetAsync(id, token);
        if (result != null)
        {
            purchaseFormWriteRepository.Delete(result);
            await unitOfWork.SaveChangesAsync(token);
            return;
        }
        throw new PurchasingEntityNotFoundByIdServiceExeption<PurchaseForm>(id);
    }

    /// <summary>
    /// Возвращает все закупочный акт
    /// </summary>
    public async Task<List<PurchaseFormModel>> GetAllAsync(CancellationToken token)
    {
        var result = await purchaseFormReadRepository.GetAllAsync(token);
        return mapper.Map<List<PurchaseFormModel>>(result);
    }

    /// <summary>
    /// Возвращает все закупочный акт с их связями
    /// </summary>
    public async Task<List<PurchaseFormModel>> GetAllWithAllLinksAsync(CancellationToken token)
    {
        var result = await purchaseFormReadRepository.GetAllWithAllLinksAsync(token);
        return mapper.Map<List<PurchaseFormModel>>(result);
    }

    /// <summary>
    /// Возвращает закупочный акт по Id
    /// </summary>
    public async Task<PurchaseFormModel> GetAsync(Guid id, CancellationToken token)
    {
        var result = await purchaseFormReadRepository.GetAsync(id, token);
        if (result == null)
        {
            throw new PurchasingEntityNotFoundByIdServiceExeption<PurchaseForm>(id);
        }
        return mapper.Map<PurchaseFormModel>(result);
    }

    /// <summary>
    /// Возвращает закупочный акт со всеми связями по Id
    /// </summary>
    public async Task<PurchaseFormModel> GetWithAllLinksAsync(Guid id, CancellationToken token)
    {
        var result = await purchaseFormReadRepository.GetWithAllLinksAsync(id, token);
        if (result == null)
        {
            throw new PurchasingEntityNotFoundByIdServiceExeption<PurchaseForm>(id);
        }
        return mapper.Map<PurchaseFormModel>(result);
    }

    /// <summary>
    /// Изменяет закупочный акт
    /// </summary>
    public async Task<PurchaseFormModel> UpdateAsync(PurchaseFormModel source, CancellationToken token)
    {
        var result = await purchaseFormReadRepository.GetAsync(source.Id, token);
        if (result != null)
        {
            mapper.Map(source, result);
            purchaseFormWriteRepository.Update(result);
            await unitOfWork.SaveChangesAsync(token);
            return source;
        }
        throw new PurchasingEntityNotFoundByIdServiceExeption<PurchaseForm>(source.Id);
    }

    /// <summary>
    /// Возвращает закупочный акт по коду формы
    /// </summary>
    public async Task<PurchaseFormModel?> GetByFormKeyAsync(Guid formKeyId, CancellationToken token)
    {
        var result = await purchaseFormReadRepository.GetByFormKeyAsync(formKeyId, token);
        if (result == null)
        {
            throw new PurchasingEntityNotFoundByRelatedEntityServiceExeption<PurchaseForm, FormKey>(formKeyId);
        }
        return mapper.Map<PurchaseFormModel>(result);
    }
}
