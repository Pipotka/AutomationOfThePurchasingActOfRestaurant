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
/// Сервис по работе с кодами форм
/// </summary>
public class FormKeyService : IFormKeyService
{
    private readonly IFormKeyReadRepository formKeyReadRepository;
    private readonly IFormKeyWriteRepository formKeyWriteRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    /// <summary>
    /// Конструктор <see cref="FormKeyService"/>
    /// </summary>
    public FormKeyService(IFormKeyReadRepository formKeyReadRepository
        , IFormKeyWriteRepository formKeyWriteRepository
        , IUnitOfWork unitOfWork
        , IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.formKeyWriteRepository = formKeyWriteRepository;
        this.formKeyReadRepository = formKeyReadRepository;
        this.mapper = mapper;
    }

    /// <summary>
    /// Получает <paramref name="pageNumber"/> страницу,
    /// из <paramref name="pageSize"/> моделей утверждающих
    /// </summary>
    /// <param name="sortBy">
    /// Перечисление сортировок для <see cref="FormKey"/>
    /// </param>
    /// <param name="pageNumber">
    /// Номер страницы
    /// </param>
    /// <param name="pageSize">
    /// размер страницы
    /// </param>
    public async Task<List<FormKeyModel>> GetPageAsync(FormKeySortBy sortBy, int pageNumber, int pageSize, CancellationToken token)
    {
        var result = await formKeyReadRepository.GetPageAsync(sortBy, pageNumber, pageSize, token);
        return mapper.Map<List<FormKeyModel>>(result);
    }

    /// <summary>
    /// Добавляет код формы
    /// </summary>
    public async Task<FormKeyModel> AddAsync(FormKeyBaseModel source, CancellationToken token)
    {
        var IsExist = formKeyReadRepository.IsExist(mapper.Map<FormKey>(source));
        if (IsExist)
        {
            throw new InvalidOperationPurchasingEntityServiceException($"Код с OKDP = {source.OKDP}, OKUD = {source.OKUD}, OKPO = {source.OKPO} и TIN = {source.TIN} уже существует");
        }

        var result = mapper.Map<FormKey>(source);
        result.Id = Guid.NewGuid();
        formKeyWriteRepository.Add(result);
        await unitOfWork.SaveChangesAsync(token);

        return mapper.Map<FormKeyModel>(result);
    }

    /// <summary>
    /// Удаляет код формы по Id
    /// </summary>
    public async Task DeleteByIdAsync(Guid id, CancellationToken token)
    {
        var result = await formKeyReadRepository.GetAsync(id, token);
        if (result != null)
        {
            formKeyWriteRepository.Delete(result);
            await unitOfWork.SaveChangesAsync(token);
            return;
        }
        throw new PurchasingEntityNotFoundByIdServiceExeption<FormKey>(id);
    }

    /// <summary>
    /// Возвращает все кода форм
    /// </summary>
    public async Task<List<FormKeyModel>> GetAllAsync(CancellationToken token)
    {
        var result = await formKeyReadRepository.GetAllAsync(token);
        return mapper.Map<List<FormKeyModel>>(result);
    }

    /// <summary>
    /// Возвращает код формы по Id
    /// </summary>
    public async Task<FormKeyModel> GetAsync(Guid id, CancellationToken token)
    {
        var result = await formKeyReadRepository.GetAsync(id, token);
        if (result == null)
        {
            throw new PurchasingEntityNotFoundByIdServiceExeption<FormKey>(id);
        }
        return mapper.Map<FormKeyModel>(result);
    }

    /// <summary>
    /// Изменяет код формы
    /// </summary>
    public async Task<FormKeyModel> UpdateAsync(FormKeyModel source, CancellationToken token)
    {
        var result = await formKeyReadRepository.GetAsync(source.Id, token);
        if (result != null)
        {
            mapper.Map(source, result);
            formKeyWriteRepository.Update(result);
            await unitOfWork.SaveChangesAsync(token);
            return source;
        }
        throw new PurchasingEntityNotFoundByIdServiceExeption<FormKey>(source.Id);
    }
}
