using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Tests;
using FluentAssertions;
using Xunit;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Tests.ReadRepositories.Tests;

/// <summary>
/// Тесты для <see cref="IEmployeeReadRepository"/>
/// </summary>
public class EmployeeReadRepositoryTests : PurchasingInMemoryContext
{
    private readonly IEmployeeReadRepository employeeReadRepository;

    public EmployeeReadRepositoryTests()
    {
        this.employeeReadRepository = new EmployeeReadRepository(Reader);
    }

    /// <summary>
    /// Вернул пустой спискок сотрудников
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnEmpty()
    {
        // act
        var result = await employeeReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().BeEmpty();
    }

    /// <summary>
    /// Вернул список сотрудников
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnValue()
    {
        // arrange
        var employee = GetEmployee();
        await PurchasingContext.AddAsync(employee);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await employeeReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(1)
            .And.ContainSingle(e => e.Id == employee.Id);
    }

    /// <summary>
    /// Вернули сортированный список сотрудников
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnOrderedValue()
    {
        // arrange
        var employee1 = GetEmployee(a => a.LastName = "Абрамов");
        var employee2 = GetEmployee(a => a.LastName = "Ярисов");
        await PurchasingContext.AddRangeAsync(employee1, employee2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await employeeReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(2)
            .And.ContainSingle(e => e.Id == employee1.Id)
            .And.ContainSingle(e => e.Id == employee2.Id);
        result[0].Id.Should().Be(employee1.Id);
        result[1].Id.Should().Be(employee2.Id);
    }

    /// <summary>
    /// Вернул сотрудника по фамилии
    /// </summary>
    [Fact]
    public async Task GetByLastNameShouldReturnValue()
    {
        // arrange
        var employee = GetEmployee(a => a.LastName = "Абдулгаджиев");
        await PurchasingContext.AddAsync(employee);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await employeeReadRepository.GetByLastNameAsync(employee.LastName, CancellationToken.None);

        // assert
        result.Should().NotBeNull()
            .And.BeEquivalentTo(employee);
    }

    /// <summary>
    /// Не вернул сотрудника по фамилии
    /// </summary>
    [Fact]
    public async Task GetByLastNameShouldReturnNull()
    {
        // act
        var result = await employeeReadRepository.GetByLastNameAsync("Абдулгаджиев", CancellationToken.None);

        // assert
        result.Should().BeNull();
    }

    /// <summary>
    /// Не вернул сотрудника по id
    /// </summary>
    [Fact]
    public async Task GetShouldReturnNull()
    {
        // arrange
        var employee = GetEmployee();
        await PurchasingContext.AddAsync(employee);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await employeeReadRepository.GetAsync(Guid.NewGuid(), CancellationToken.None);

        // assert
        result.Should().BeNull();
    }

    /// <summary>
    /// Вернул сотрудника по id
    /// </summary>
    [Fact]
    public async Task GetShouldReturnValue()
    {
        // arrange
        var employee1 = GetEmployee();
        var employee2 = GetEmployee();
        await PurchasingContext.AddRangeAsync(employee1, employee2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await employeeReadRepository.GetAsync(employee1.Id, CancellationToken.None);

        // assert
        result.Should().NotBeNull()
            .And.BeEquivalentTo(employee1);
    }

    /// <summary>
    /// Нашел сотрудника и вернул true
    /// </summary>
    [Fact]
    public async Task IsExistShouldReturnTrue()
    {
        // arrange
        var employee1 = GetEmployee();
        var employee2 = GetEmployee();
        await PurchasingContext.AddRangeAsync(employee1, employee2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = employeeReadRepository.IsExist(employee1);

        // assert
        result.Should().BeTrue();
    }

    /// <summary>
    /// Не нашел сотрудника и вернул false
    /// </summary>
    [Fact]
    public async Task IsExistShouldReturnFalse()
    {
        // arrange
        var employee1 = GetEmployee();
        var employee2 = GetEmployee();
        var employee3 = GetEmployee();
        await PurchasingContext.AddRangeAsync(employee1, employee2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = employeeReadRepository.IsExist(employee3);

        // assert
        result.Should().BeFalse();
    }

    /// <summary>
    /// Возвращает отсортированную страницу из сотрудников по фамилии по возрастанию
    /// </summary>
    [Fact]
    public async Task GetPageShouldReturnOrderedInAscendingOrderValue()
    {
        // arrange
        var employee1 = GetEmployee(e => e.LastName = "Петров");
        var employee2 = GetEmployee(e => e.LastName = "Сидоров");
        var employee3 = GetEmployee(e => e.LastName = "Иванов");
        await PurchasingContext.AddRangeAsync(employee1, employee2, employee3);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await employeeReadRepository.GetPageAsync(EmployeeSortBy.LastName, 1, 3, CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(3);
        result[0].Should().BeEquivalentTo(employee3); // Иванов
        result[1].Should().BeEquivalentTo(employee1); // Петров
        result[2].Should().BeEquivalentTo(employee2); // Сидоров
    }

    /// <summary>
    /// Возвращает отсортированную страницу из 2-х сотрудников по фамилии по возрастанию
    /// </summary>
    [Fact]
    public async Task GetPageShouldReturnPageWithPagination()
    {
        // arrange
        var employee1 = GetEmployee(e => e.LastName = "Петров");
        var employee2 = GetEmployee(e => e.LastName = "Сидоров");
        var employee3 = GetEmployee(e => e.LastName = "Иванов");
        await PurchasingContext.AddRangeAsync(employee1, employee2, employee3);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await employeeReadRepository.GetPageAsync(EmployeeSortBy.LastName, 1, 2, CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(2);
        result[0].Should().BeEquivalentTo(employee3); // Иванов
        result[1].Should().BeEquivalentTo(employee1); // Петров
    }

    /// <summary>
    /// Возвращает пустую страницу
    /// </summary>
    [Fact]
    public async Task GetPageShouldReturnEmpty()
    {
        // act
        var result = await employeeReadRepository.GetPageAsync(EmployeeSortBy.LastName, 1, 3, CancellationToken.None);

        // assert
        result.Should().BeEmpty();
    }

    /// <summary>
    /// Возвращает отсортированную страницу из сотрудников по фамилии по убыванию
    /// </summary>
    [Fact]
    public async Task GetPageShouldReturnOrderedInDescendingOrderValue()
    {
        // arrange
        var employee1 = GetEmployee(e => e.LastName = "Петров");
        var employee2 = GetEmployee(e => e.LastName = "Сидоров");
        var employee3 = GetEmployee(e => e.LastName = "Иванов");
        await PurchasingContext.AddRangeAsync(employee1, employee2, employee3);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await employeeReadRepository.GetPageAsync(EmployeeSortBy.LastNameDesc, 1, 3, CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(3);
        result[0].Should().BeEquivalentTo(employee2); // Сидоров
        result[1].Should().BeEquivalentTo(employee1); // Петров
        result[2].Should().BeEquivalentTo(employee3); // Иванов
    }

    /// <summary>
    /// Генерирует сотрудника
    /// </summary>
    private static Employee GetEmployee(Action<Employee>? settings = null)
    {
        var result = new Employee()
        {
            Id = Guid.NewGuid(),
            FirstName = $"Имя{Guid.NewGuid():N}",
            LastName = $"Фамилия{Guid.NewGuid():N}",
            Patronymic = $"Отчество{Guid.NewGuid():N}",
            PositionId = Guid.NewGuid(),
        };

        settings?.Invoke(result);
        return result;
    }
}
