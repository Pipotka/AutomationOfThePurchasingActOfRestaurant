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
/// Сервис по работе с поставщиками
/// </summary>
public class SupplierService : ISupplierService
{
    private readonly ISupplierReadRepository supplierReadRepository;
    private readonly ISupplierWriteRepository supplierWriteRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    /// <summary>
    /// Конструктор <see cref="SupplierService"/>
    /// </summary>
    public SupplierService(ISupplierReadRepository supplierReadRepository
        , ISupplierWriteRepository supplierWriteRepository
        , IUnitOfWork unitOfWork
        , IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.supplierWriteRepository = supplierWriteRepository;
        this.supplierReadRepository = supplierReadRepository;
        this.mapper = mapper;
    }

    /// <summary>
    /// Получает <paramref name="pageNumber"/> страницу,
    /// из <paramref name="pageSize"/> моделей утверждающих
    /// </summary>
    /// <param name="sortBy">
    /// Перечисление сортировок для <see cref="Supplier"/>
    /// </param>
    /// <param name="pageNumber">
    /// Номер страницы
    /// </param>
    /// <param name="pageSize">
    /// размер страницы
    /// </param>
    public async Task<List<SupplierModel>> GetPageAsync(SupplierSortBy sortBy, int pageNumber, int pageSize, CancellationToken token)
    {
        var result = await supplierReadRepository.GetPageAsync(sortBy, pageNumber, pageSize, token);
        return mapper.Map<List<SupplierModel>>(result);
    }

    /// <summary>
    /// Добавляет поставщика
    /// </summary>
    public async Task<SupplierModel> AddAsync(SupplierBaseModel source, CancellationToken token)
    {
        var result = await supplierReadRepository.GetByLastNameAsync(source.LastName, token);
        if (result != null)
        {
            throw new InvalidOperationPurchasingEntityServiceException($"Поставщик {source.LastName} уже существует");
        }

        result = mapper.Map<Supplier>(source);
        result.Id = Guid.NewGuid();
        supplierWriteRepository.Add(result);
        await unitOfWork.SaveChangesAsync(token);

        return mapper.Map<SupplierModel>(result);
    }

    /// <summary>
    /// Удаляет поставщика по Id
    /// </summary>
    public async Task DeleteByIdAsync(Guid id, CancellationToken token)
    {
        var result = await supplierReadRepository.GetAsync(id, token);
        if (result != null)
        {
            supplierWriteRepository.Delete(result);
            await unitOfWork.SaveChangesAsync(token);
            return;
        }
        throw new PurchasingEntityNotFoundByIdServiceExeption<Supplier>(id);
    }

    /// <summary>
    /// Возвращает всех поставщиков
    /// </summary>
    public async Task<List<SupplierModel>> GetAllAsync(CancellationToken token)
    {
        var result = await supplierReadRepository.GetAllAsync(token);
        return mapper.Map<List<SupplierModel>>(result);
    }

    /// <summary>
    /// Возвращает поставщика по Id
    /// </summary>
    public async Task<SupplierModel> GetAsync(Guid id, CancellationToken token)
    {
        var result = await supplierReadRepository.GetAsync(id, token);
        if (result == null)
        {
            throw new PurchasingEntityNotFoundByIdServiceExeption<Supplier>(id);
        }
        return mapper.Map<SupplierModel>(result);
    }

    /// <summary>
    /// Возвращает поставщика по фамилии
    /// </summary>
    public async Task<SupplierModel?> GetByLastNameAsync(string lastName, CancellationToken token)
    {
        var result = await supplierReadRepository.GetByLastNameAsync(lastName, token);
        if (result == null)
        {
            throw new PurchasingEntityNotFoundByFieldServiceExeption<Supplier>(nameof(lastName), lastName);
        }

        return mapper.Map<SupplierModel>(result);
    }

    /// <summary>
    /// Изменяет поставщика
    /// </summary>
    public async Task<SupplierModel> UpdateAsync(SupplierModel source, CancellationToken token)
    {
        var result = await supplierReadRepository.GetAsync(source.Id, token);
        if (result != null)
        {
            mapper.Map(source, result);
            supplierWriteRepository.Update(result);
            await unitOfWork.SaveChangesAsync(token);
            return source;
        }
        throw new PurchasingEntityNotFoundByIdServiceExeption<Supplier>(source.Id);
    }
}