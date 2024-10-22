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
/// Сервис по работе с организациями
/// </summary>
public class OrganizationService : IOrganizationService
{
    private readonly IOrganizationReadRepository organizationReadRepository;
    private readonly IOrganizationWriteRepository organizationWriteRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    /// <summary>
    /// Конструктор <see cref="OrganizationService"/>
    /// </summary>
    public OrganizationService(IOrganizationReadRepository organizationReadRepository
        , IOrganizationWriteRepository organizationWriteRepository
        , IUnitOfWork unitOfWork
        , IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.organizationWriteRepository = organizationWriteRepository;
        this.organizationReadRepository = organizationReadRepository;
        this.mapper = mapper;
    }

    /// <summary>
    /// Получает <paramref name="pageNumber"/> страницу,
    /// из <paramref name="pageSize"/> моделей утверждающих
    /// </summary>
    /// <param name="sortBy">
    /// Перечисление сортировок для <see cref="Organization"/>
    /// </param>
    /// <param name="pageNumber">
    /// Номер страницы
    /// </param>
    /// <param name="pageSize">
    /// размер страницы
    /// </param>
    public async Task<List<OrganizationModel>> GetPageAsync(OrganizationSortBy sortBy, int pageNumber, int pageSize, CancellationToken token)
    {
        var result = await organizationReadRepository.GetPageAsync(sortBy, pageNumber, pageSize, token);
        return mapper.Map<List<OrganizationModel>>(result);
    }

    /// <summary>
    /// Добавляет организацию
    /// </summary>
    public async Task<OrganizationModel> AddAsync(OrganizationBaseModel source, CancellationToken token)
    {
        var IsExist = organizationReadRepository.IsExist(mapper.Map<Organization>(source));
        if (IsExist)
        {
            throw new InvalidOperationPurchasingEntityServiceException($"Огранизация {source.Name} с {source.Address} и {source.StructuralUnit} уже существует");
        }

        var result = mapper.Map<Organization>(source);
        result.Id = Guid.NewGuid();
        organizationWriteRepository.Add(result);
        await unitOfWork.SaveChangesAsync(token);

        return mapper.Map<OrganizationModel>(result);
    }

    /// <summary>
    /// Удаляет организацию по Id
    /// </summary>
    public async Task DeleteByIdAsync(Guid id, CancellationToken token)
    {
        var result = await organizationReadRepository.GetAsync(id, token);
        if (result != null)
        {
            organizationWriteRepository.Delete(result);
            await unitOfWork.SaveChangesAsync(token);
            return;
        }
        throw new PurchasingEntityNotFoundByIdServiceExeption<Organization>(id);
    }

    /// <summary>
    /// Возвращает все организации
    /// </summary>
    public async Task<List<OrganizationModel>> GetAllAsync(CancellationToken token)
    {
        var result = await organizationReadRepository.GetAllAsync(token);
        return mapper.Map<List<OrganizationModel>>(result);
    }

    /// <summary>
    /// Возвращает организацию по Id
    /// </summary>
    public async Task<OrganizationModel> GetAsync(Guid id, CancellationToken token)
    {
        var result = await organizationReadRepository.GetAsync(id, token);
        if (result == null)
        {
            throw new PurchasingEntityNotFoundByIdServiceExeption<Organization>(id);
        }
        return mapper.Map<OrganizationModel>(result);
    }

    /// <summary>
    /// Изменяет организацию
    /// </summary>
    public async Task<OrganizationModel> UpdateAsync(OrganizationModel source, CancellationToken token)
    {
        var result = await organizationReadRepository.GetAsync(source.Id, token);
        if (result != null)
        {
            mapper.Map(source, result);
            organizationWriteRepository.Update(result);
            await unitOfWork.SaveChangesAsync(token);
            return source;
        }
        throw new PurchasingEntityNotFoundByIdServiceExeption<Organization>(source.Id);
    }

    /// <summary>
    /// Возвращает организацию по названию
    /// </summary>
    public async Task<OrganizationModel?> GetByNameAsync(string name, CancellationToken token)
    {
        var result = await organizationReadRepository.GetByNameAsync(name, token);
        if (result == null)
        {
            throw new PurchasingEntityNotFoundByFieldServiceExeption<Organization>(nameof(name), name);
        }
        return mapper.Map<OrganizationModel>(result);
    }
}
