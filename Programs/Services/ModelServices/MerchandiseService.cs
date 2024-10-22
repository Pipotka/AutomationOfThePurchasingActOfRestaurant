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
/// Сервис по работе с товарами
/// </summary>
public class MerchandiseService : IMerchandiseService
{
    private readonly IMerchandiseReadRepository merchandiseReadRepository;
    private readonly IMerchandiseWriteRepository merchandiseWriteRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    /// <summary>
    /// Конструктор <see cref="MerchandiseService"/>
    /// </summary>
    public MerchandiseService(IMerchandiseReadRepository merchandiseReadRepository
        , IMerchandiseWriteRepository merchandiseWriteRepository
        , IUnitOfWork unitOfWork
        , IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.merchandiseWriteRepository = merchandiseWriteRepository;
        this.merchandiseReadRepository = merchandiseReadRepository;
        this.mapper = mapper;
    }

    /// <summary>
    /// Получает <paramref name="pageNumber"/> страницу,
    /// из <paramref name="pageSize"/> моделей утверждающих
    /// </summary>
    /// <param name="sortBy">
    /// Перечисление сортировок для <see cref="Merchandise"/>
    /// </param>
    /// <param name="pageNumber">
    /// Номер страницы
    /// </param>
    /// <param name="pageSize">
    /// размер страницы
    /// </param>
    public async Task<List<MerchandiseModel>> GetPageAsync(MerchandiseSortBy sortBy, int pageNumber, int pageSize, CancellationToken token)
    {
        var result = await merchandiseReadRepository.GetPageAsync(sortBy, pageNumber, pageSize, token);
        return mapper.Map<List<MerchandiseModel>>(result);
    }

    /// <summary>
    /// Добавляет товар
    /// </summary>
    public async Task<MerchandiseModel> AddAsync(MerchandiseBaseModel source, CancellationToken token)
    {
        var IsExist = merchandiseReadRepository.IsExist(mapper.Map<Merchandise>(source));
        if (IsExist)
        {
            throw new InvalidOperationPurchasingEntityServiceException($"Товар {source.Name} уже существует");
        }

        var result = mapper.Map<Merchandise>(source);
        result.Id = Guid.NewGuid();
        merchandiseWriteRepository.Add(result);
        await unitOfWork.SaveChangesAsync(token);

        return mapper.Map<MerchandiseModel>(result);
    }

    /// <summary>
    /// Удаляет товар по Id
    /// </summary>
    public async Task DeleteByIdAsync(Guid id, CancellationToken token)
    {
        var result = await merchandiseReadRepository.GetAsync(id, token);
        if (result != null)
        {
            merchandiseWriteRepository.Delete(result);
            await unitOfWork.SaveChangesAsync(token);
            return;
        }
        throw new PurchasingEntityNotFoundByIdServiceExeption<Merchandise>(id);
    }

    /// <summary>
    /// Возвращает все товары
    /// </summary>
    public async Task<List<MerchandiseModel>> GetAllAsync(CancellationToken token)
    {
        var result = await merchandiseReadRepository.GetAllAsync(token);
        return mapper.Map<List<MerchandiseModel>>(result);
    }

    /// <summary>
    /// Возвращает все товары с их связями
    /// </summary>
    public async Task<List<MerchandiseModel>> GetAllWithLinksAsync(CancellationToken token)
    {
        var result = await merchandiseReadRepository.GetAllWithLinksAsync(token);
        return mapper.Map<List<MerchandiseModel>>(result);
    }

    /// <summary>
    /// Возвращает товар по Id
    /// </summary>
    public async Task<MerchandiseModel> GetAsync(Guid id, CancellationToken token)
    {
        var result = await merchandiseReadRepository.GetAsync(id, token);
        if (result == null)
        {
            throw new PurchasingEntityNotFoundByIdServiceExeption<Merchandise>(id);
        }
        return mapper.Map<MerchandiseModel>(result);
    }

    /// <summary>
    /// Изменяет товар
    /// </summary>
    public async Task<MerchandiseModel> UpdateAsync(MerchandiseModel source, CancellationToken token)
    {
        var result = await merchandiseReadRepository.GetAsync(source.Id, token);
        if (result != null)
        {
            mapper.Map(source, result);
            merchandiseWriteRepository.Update(result);
            await unitOfWork.SaveChangesAsync(token);
            return source;
        }
        throw new PurchasingEntityNotFoundByIdServiceExeption<Merchandise>(source.Id);
    }

    /// <summary>
    /// Возвращает товар по названию
    /// </summary>
    /// <param name="name">название</param>
    public async Task<MerchandiseModel?> GetByNameAsync(string name, CancellationToken token)
    {
        var result = await merchandiseReadRepository.GetByNameAsync(name, token);
        if (result == null)
        {
            throw new PurchasingEntityNotFoundByFieldServiceExeption<Merchandise>(nameof(name), name);
        }
        return mapper.Map<MerchandiseModel>(result);
    }
}
