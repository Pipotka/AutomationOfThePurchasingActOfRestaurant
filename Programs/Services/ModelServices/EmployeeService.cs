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
/// Сервис по работе с сотрудниками
/// </summary>
public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeReadRepository employeeReadRepository;
    private readonly IEmployeeWriteRepository employeeWriteRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    /// <summary>
    /// Конструктор <see cref="EmployeeService"/>
    /// </summary>
    public EmployeeService(IEmployeeReadRepository employeeReadRepository
        , IEmployeeWriteRepository employeeWriteRepository
        , IUnitOfWork unitOfWork
        , IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.employeeWriteRepository = employeeWriteRepository;
        this.employeeReadRepository = employeeReadRepository;
        this.mapper = mapper;
    }

    /// <summary>
    /// Получает <paramref name="pageNumber"/> страницу,
    /// из <paramref name="pageSize"/> моделей утверждающих
    /// </summary>
    /// <param name="sortBy">
    /// Перечисление сортировок для <see cref="Employee"/>
    /// </param>
    /// <param name="pageNumber">
    /// Номер страницы
    /// </param>
    /// <param name="pageSize">
    /// размер страницы
    /// </param>
    public async Task<List<EmployeeModel>> GetPageAsync(EmployeeSortBy sortBy, int pageNumber, int pageSize, CancellationToken token)
    {
        var result = await employeeReadRepository.GetPageAsync(sortBy, pageNumber, pageSize, token);
        return mapper.Map<List<EmployeeModel>>(result);
    }

    /// <summary>
    /// Добавляет сотрудника
    /// </summary>
    public async Task<EmployeeModel> AddAsync(EmployeeBaseModel source, CancellationToken token)
    {
        var result = await employeeReadRepository.GetByLastNameAsync(source.LastName, token);
        if (result != null)
        {
            throw new InvalidOperationPurchasingEntityServiceException($"Сотрудник {source.LastName} уже существует");
        }

        result = mapper.Map<Employee>(source);
        result.Id = Guid.NewGuid();
        result.PositionId = Guid.NewGuid();
        employeeWriteRepository.Add(result);
        await unitOfWork.SaveChangesAsync(token);

        return mapper.Map<EmployeeModel>(result);
    }

    /// <summary>
    /// Удаляет сотрудника по Id
    /// </summary>
    public async Task DeleteByIdAsync(Guid id, CancellationToken token)
    {
        var result = await employeeReadRepository.GetAsync(id, token);
        if (result != null)
        {
            employeeWriteRepository.Delete(result);
            await unitOfWork.SaveChangesAsync(token);
            return;
        }
        throw new PurchasingEntityNotFoundByIdServiceExeption<Employee>(id);
    }

    /// <summary>
    /// Возвращает всех сотрудников
    /// </summary>
    public async Task<List<EmployeeModel>> GetAllAsync(CancellationToken token)
    {
        var result = await employeeReadRepository.GetAllAsync(token);
        return mapper.Map<List<EmployeeModel>>(result);
    }

    /// <summary>
    /// Возвращает сотрудника по Id
    /// </summary>
    public async Task<EmployeeModel> GetAsync(Guid id, CancellationToken token)
    {
        var result = await employeeReadRepository.GetAsync(id, token);
        if (result == null)
        {
            throw new PurchasingEntityNotFoundByIdServiceExeption<Employee>(id);
        }
        return mapper.Map<EmployeeModel>(result);
    }

    /// <summary>
    /// Вовращает сотрудника по фамилии
    /// </summary>
    public async Task<EmployeeModel?> GetByLastNameAsync(string lastName, CancellationToken token)
    {
        var result = await employeeReadRepository.GetByLastNameAsync(lastName, token);
        if (result == null)
        {
            throw new PurchasingEntityNotFoundByFieldServiceExeption<Employee>(nameof(lastName), lastName);
        }

        return mapper.Map<EmployeeModel>(result);
    }

    /// <summary>
    /// Изменяет сотрудника
    /// </summary>
    public async Task<EmployeeModel> UpdateAsync(EmployeeModel source, CancellationToken token)
    {
        var result = await employeeReadRepository.GetAsync(source.Id, token);
        if (result != null)
        {
            mapper.Map(source, result);
            employeeWriteRepository.Update(result);
            await unitOfWork.SaveChangesAsync(token);
            return source;
        }
        throw new PurchasingEntityNotFoundByIdServiceExeption<Employee>(source.Id);
    }
}
