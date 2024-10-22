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
/// Сервис по работе с должностями сотрудников
/// </summary>
public class EmployeePositionService : IEmployeePositionService
{
    private readonly IEmployeePositionReadRepository employeePositionReadRepository;
    private readonly IEmployeePositionWriteRepository employeePositionWriteRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    /// <summary>
    /// Конструктор <see cref="EmployeePositionService"/>
    /// </summary>
    public EmployeePositionService(IEmployeePositionReadRepository employeePositionReadRepository
        , IEmployeePositionWriteRepository employeePositionWriteRepository
        , IUnitOfWork unitOfWork
        , IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.employeePositionWriteRepository = employeePositionWriteRepository;
        this.employeePositionReadRepository = employeePositionReadRepository;
        this.mapper = mapper;
    }

    /// <summary>
    /// Получает <paramref name="pageNumber"/> страницу,
    /// из <paramref name="pageSize"/> моделей утверждающих
    /// </summary>
    /// <param name="sortBy">
    /// Перечисление сортировок для <see cref="EmployeePosition"/>
    /// </param>
    /// <param name="pageNumber">
    /// Номер страницы
    /// </param>
    /// <param name="pageSize">
    /// размер страницы
    /// </param>
    public async Task<List<EmployeePositionModel>> GetPageAsync(EmployeePositionSortBy sortBy, int pageNumber, int pageSize, CancellationToken token)
    {
        var result = await employeePositionReadRepository.GetPageAsync(sortBy, pageNumber, pageSize, token);
        return mapper.Map<List<EmployeePositionModel>>(result);
    }

    /// <summary>
    /// Добавляет должность сотрудника
    /// </summary>
    public async Task<EmployeePositionModel> AddAsync(EmployeePositionBaseModel source, CancellationToken token)
    {
        var result = await employeePositionReadRepository.GetByNameAsync(source.Name, token);
        if (result != null)
        {
            throw new InvalidOperationPurchasingEntityServiceException($"Должность {source.Name} уже существует");
        }

        result = mapper.Map<EmployeePosition>(source);
        result.Id = Guid.NewGuid();
        employeePositionWriteRepository.Add(result);
        await unitOfWork.SaveChangesAsync(token);

        return mapper.Map<EmployeePositionModel>(result);
    }

    /// <summary>
    /// Удаляет должность сотрудника по Id
    /// </summary>
    public async Task DeleteByIdAsync(Guid id, CancellationToken token)
    {
        var result = await employeePositionReadRepository.GetAsync(id, token);
        if (result != null)
        {
            employeePositionWriteRepository.Delete(result);
            await unitOfWork.SaveChangesAsync(token);
            return;
        }
        throw new PurchasingEntityNotFoundByIdServiceExeption<EmployeePositionModel>(id);
    }

    /// <summary>
    /// Возвращает все должности сотрудников
    /// </summary>
    public async Task<List<EmployeePositionModel>> GetAllAsync(CancellationToken token)
    {
        var result = await employeePositionReadRepository.GetAllAsync(token);
        return mapper.Map<List<EmployeePositionModel>>(result);
    }

    /// <summary>
    /// Возвращает должность сотрудника по Id
    /// </summary>
    public async Task<EmployeePositionModel> GetAsync(Guid id, CancellationToken token)
    {
        var result = await employeePositionReadRepository.GetAsync(id, token);
        if (result == null)
        {
            throw new PurchasingEntityNotFoundByIdServiceExeption<EmployeePosition>(id);
        }
        return mapper.Map<EmployeePositionModel>(result);
    }

    /// <summary>
    /// Изменяет должность сотрудника
    /// </summary>
    public async Task<EmployeePositionModel> UpdateAsync(EmployeePositionModel source, CancellationToken token)
    {
        var result = await employeePositionReadRepository.GetAsync(source.Id, token);
        if (result != null)
        {
            mapper.Map(source, result);
            employeePositionWriteRepository.Update(result);
            await unitOfWork.SaveChangesAsync(token);
            return source;
        }
        throw new PurchasingEntityNotFoundByIdServiceExeption<EmployeePosition>(source.Id);
    }

    /// <summary>
    /// Возвращает должность сотрудника по названию
    /// </summary>
    /// <param name="name">Название</param>
    public async Task<EmployeePositionModel?> GetByNameAsync(string name, CancellationToken token)
    {
        var result = await employeePositionReadRepository.GetByNameAsync(name, token);
        if (result == null)
        {
            throw new PurchasingEntityNotFoundByFieldServiceExeption<EmployeePosition>(nameof(name), name);
        }

        return mapper.Map<EmployeePositionModel>(result);
    }
}
