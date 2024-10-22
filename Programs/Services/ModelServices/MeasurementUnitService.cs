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
/// Сервис по работе с единицами измерения
/// </summary>
public class MeasurementUnitService : IMeasurementUnitService
{
    private readonly IMeasurementUnitReadRepository measurementUnitReadRepository;
    private readonly IMeasurementUnitWriteRepository measurementUnitWriteRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    /// <summary>
    /// Конструктор <see cref="MeasurementUnitService"/>
    /// </summary>
    public MeasurementUnitService(IMeasurementUnitReadRepository measurementUnitReadRepository
        , IMeasurementUnitWriteRepository measurementUnitWriteRepository
        , IUnitOfWork unitOfWork
        , IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.measurementUnitWriteRepository = measurementUnitWriteRepository;
        this.measurementUnitReadRepository = measurementUnitReadRepository;
        this.mapper = mapper;
    }

    /// <summary>
    /// Добавляет единицу измерения
    /// </summary>
    public async Task<MeasurementUnitModel> AddAsync(MeasurementUnitBaseModel source, CancellationToken token)
    {
        var IsExist = measurementUnitReadRepository.IsExist(mapper.Map<MeasurementUnit>(source));
        if (IsExist)
        {
            throw new InvalidOperationPurchasingEntityServiceException($"Единица измерения {source.Name} уже существует");
        }

        var result = mapper.Map<MeasurementUnit>(source);
        result.Id = Guid.NewGuid();
        measurementUnitWriteRepository.Add(result);
        await unitOfWork.SaveChangesAsync(token);

        return mapper.Map<MeasurementUnitModel>(result);
    }

    /// <summary>
    /// Удаляет единицу измерения по Id
    /// </summary>
    public async Task DeleteByIdAsync(Guid id, CancellationToken token)
    {
        var result = await measurementUnitReadRepository.GetAsync(id, token);
        if (result != null)
        {
            measurementUnitWriteRepository.Delete(result);
            await unitOfWork.SaveChangesAsync(token);
            return;
        }
        throw new PurchasingEntityNotFoundByIdServiceExeption<MeasurementUnit>(id);
    }

    /// <summary>
    /// Возвращает все единици измерения
    /// </summary>
    public async Task<List<MeasurementUnitModel>> GetAllAsync(CancellationToken token)
    {
        var result = await measurementUnitReadRepository.GetAllAsync(token);
        return mapper.Map<List<MeasurementUnitModel>>(result);
    }

    /// <summary>
    /// Возвращает единицу измерения по Id
    /// </summary>
    public async Task<MeasurementUnitModel> GetAsync(Guid id, CancellationToken token)
    {
        var result = await measurementUnitReadRepository.GetAsync(id, token);
        if (result == null)
        {
            throw new PurchasingEntityNotFoundByIdServiceExeption<MeasurementUnit>(id);
        }
        return mapper.Map<MeasurementUnitModel>(result);
    }

    /// <summary>
    /// Возвращает единицу измерения по названию
    /// </summary>
    public async Task<MeasurementUnitModel?> GetByNameAsync(string name, CancellationToken token)
    {
        var result = await measurementUnitReadRepository.GetByNameAsync(name, token);
        if (result == null)
        {
            throw new PurchasingEntityNotFoundByFieldServiceExeption<MeasurementUnit>(nameof(name), name);
        }
        return mapper.Map<MeasurementUnitModel>(result);
    }

    /// <summary>
    /// Возвращает единицу измерения по ОКУД
    /// </summary>
    public async Task<MeasurementUnitModel?> GetByOKEIKeyAsync(string OKEIKey, CancellationToken token)
    {
        var result = await measurementUnitReadRepository.GetByOKEIKeyAsync(OKEIKey, token);
        if (result == null)
        {
            throw new PurchasingEntityNotFoundByFieldServiceExeption<MeasurementUnit>(nameof(OKEIKey), OKEIKey.ToString());
        }
        return mapper.Map<MeasurementUnitModel>(result);
    }

    /// <summary>
    /// Изменяет единицу измерения
    /// </summary>
    public async Task<MeasurementUnitModel> UpdateAsync(MeasurementUnitModel source, CancellationToken token)
    {
        var result = await measurementUnitReadRepository.GetAsync(source.Id, token);
        if (result != null)
        {
            mapper.Map(source, result);
            measurementUnitWriteRepository.Update(result);
            await unitOfWork.SaveChangesAsync(token);
            return source;
        }
        throw new PurchasingEntityNotFoundByIdServiceExeption<MeasurementUnit>(source.Id);
    }
}
