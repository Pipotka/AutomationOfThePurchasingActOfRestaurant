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
using System.Xml.Linq;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.ModelServices;

/// <summary>
/// Сервис по работе с утверждающими
/// </summary>
public class ApproverService : IApproverService
{
    private readonly IApproverReadRepository approverReadRepository;
    private readonly IApproverWriteRepository approverWriteRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    /// <summary>
    /// Конструктор <see cref="ApproverService"/>
    /// </summary>
    public ApproverService(IApproverReadRepository approverReadRepository
        , IApproverWriteRepository approverWriteRepository
        , IUnitOfWork unitOfWork
        , IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.approverWriteRepository = approverWriteRepository;
        this.approverReadRepository = approverReadRepository;
        this.mapper = mapper;
    }

    /// <summary>
    /// Получает <paramref name="pageNumber"/> страницу,
    /// из <paramref name="pageSize"/> моделей утверждающих
    /// </summary>
    /// <param name="sortBy">
    /// Перечисление сортировок для <see cref="Approver"/>
    /// </param>
    /// <param name="pageNumber">
    /// Номер страницы
    /// </param>
    /// <param name="pageSize">
    /// размер страницы
    /// </param>
    public async Task<List<ApproverModel>> GetPageAsync(ApproverSortBy sortBy, int pageNumber, int pageSize, CancellationToken token)
    {
        var result = await approverReadRepository.GetPageAsync(sortBy, pageNumber, pageSize, token);
        return mapper.Map<List<ApproverModel>>(result);
    }

    /// <summary>
    /// Добавляет утверждающего
    /// </summary>
    public async Task<ApproverModel> AddAsync(ApproverBaseModel source, CancellationToken token)
    {
        var result = await approverReadRepository.GetByLastNameAsync(source.LastName, token);
        if (result != null)
        {
            throw new InvalidOperationPurchasingEntityServiceException($"Утверждающий {source.LastName} уже существует");
        }

        result = mapper.Map<Approver>(source);
        result.Id = Guid.NewGuid();
        approverWriteRepository.Add(result);
        await unitOfWork.SaveChangesAsync(token);

        return mapper.Map<ApproverModel>(result);
    }

    /// <summary>
    /// Удаляет утверждающего по Id
    /// </summary>
    public async Task DeleteByIdAsync(Guid id, CancellationToken token)
    {
        var result = await approverReadRepository.GetAsync(id, token);
        if (result != null)
        {
            approverWriteRepository.Delete(result);
            await unitOfWork.SaveChangesAsync(token);
            return;
        }
        throw new PurchasingEntityNotFoundByIdServiceExeption<Approver>(id);
    }

    /// <summary>
    /// Возвращает всех утверждающих
    /// </summary>
    public async Task<List<ApproverModel>> GetAllAsync(CancellationToken token)
    {
        var result = await approverReadRepository.GetAllAsync(token);
        return mapper.Map<List<ApproverModel>>(result);
    }

    /// <summary>
    /// Возвращает утверждающего по Id
    /// </summary>
    public async Task<ApproverModel> GetAsync(Guid id, CancellationToken token)
    {
        var result = await approverReadRepository.GetAsync(id, token);
        if (result == null)
        {
            throw new PurchasingEntityNotFoundByIdServiceExeption<Approver>(id);
        }
        return mapper.Map<ApproverModel>(result);
    }

    /// <summary>
    /// Возвращает утверждающего по фамилии
    /// </summary>
    public async Task<ApproverModel?> GetByLastNameAsync(string lastName, CancellationToken token)
    {
        var result = await approverReadRepository.GetByLastNameAsync(lastName, token);
        if (result == null)
        {
            throw new PurchasingEntityNotFoundByFieldServiceExeption<Approver>(nameof(lastName), lastName);
        }

        return mapper.Map<ApproverModel>(result);
    }

    /// <summary>
    /// Изменяет утверждающего
    /// </summary>
    public async Task<ApproverModel> UpdateAsync(ApproverModel source, CancellationToken token)
    {
        var result = await approverReadRepository.GetAsync(source.Id, token);
        if (result != null)
        {
            mapper.Map(source, result);
            approverWriteRepository.Update(result);
            await unitOfWork.SaveChangesAsync(token);
            return source;
        }
        throw new PurchasingEntityNotFoundByIdServiceExeption<Approver>(source.Id);
    }
}