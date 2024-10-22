using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Tests;
using FluentAssertions;
using Xunit;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Tests.ReadRepositories.Tests;

/// <summary>
/// Тесты для <see cref="IEmployeePositionReadRepository"/>
/// </summary>
public class EmployeePositionReadRepositoryTests : PurchasingInMemoryContext
{
    private readonly IEmployeePositionReadRepository employeePositionReadRepository;

    public EmployeePositionReadRepositoryTests()
    {
        employeePositionReadRepository = new EmployeePositionReadRepository(Reader);
    }

    /// <summary>
    /// Вернёт должность по названию 
    /// </summary>
    [Fact]
    public async Task GetByNameShouldReturnValue()
    {
        // arrange
        var eP1 = GetEmployeePosition(ep => ep.Name = "Стажер");
        var eP2 = GetEmployeePosition(ep => ep.Name = "Бухгалтер");
        await PurchasingContext.AddRangeAsync(eP1, eP2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await employeePositionReadRepository.GetByNameAsync(eP1.Name, CancellationToken.None);

        // assert
        result.Should().NotBeNull()
            .And.BeEquivalentTo(eP1);
    }

    /// <summary>
    /// Не вернул должность сотрудника по названию
    /// </summary>
    [Fact]
    public async Task GetByNameShouldReturnNull()
    {
        // arrange
        var eP1 = GetEmployeePosition(ep => ep.Name = "Стажер");
        var eP2 = GetEmployeePosition(ep => ep.Name = "Бухгалтер");
        var eP3 = GetEmployeePosition();
        await PurchasingContext.AddRangeAsync(eP1, eP2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await employeePositionReadRepository.GetByNameAsync(eP3.Name, CancellationToken.None);

        // assert
        result.Should().BeNull();
    }

    /// <summary>
    /// Вернули пустой спискок должностей сотрудника
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnEmpty()
    {
        // act
        var result = await employeePositionReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().BeEmpty();
    }

    /// <summary>
    /// Вернули список всех должностей сотрудника
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnValue()
    {
        // arrange
        var eP = GetEmployeePosition();
        await PurchasingContext.AddAsync(eP);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await employeePositionReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(1)
            .And.ContainSingle(ep => ep.Id == eP.Id);
    }

    /// <summary>
    /// Вернули сортированный список должностей сотрудника
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnOrderedValue()
    {
        // arrange
        var eP1 = GetEmployeePosition(ep => ep.Name = "Бухгалтер");
        var eP2 = GetEmployeePosition(ep => ep.Name = "Стажер");
        await PurchasingContext.AddRangeAsync(eP1, eP2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await employeePositionReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(2)
            .And.ContainSingle(ep => ep.Id == eP1.Id)
            .And.ContainSingle(ep => ep.Id == eP2.Id);
        result[0].Id.Should().Be(eP1.Id);
        result[1].Id.Should().Be(eP2.Id);
    }

    /// <summary>
    /// Не вернул должность сотрудника по id
    /// </summary>
    [Fact]
    public async Task GetShouldReturnNull()
    {
        // arrange
        var eP = GetEmployeePosition();
        await PurchasingContext.AddAsync(eP);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await employeePositionReadRepository.GetAsync(Guid.NewGuid(), CancellationToken.None);

        // assert
        result.Should().BeNull();
    }

    /// <summary>
    /// Вернул должность сотрудника по id
    /// </summary>
    [Fact]
    public async Task GetShouldReturnValue()
    {
        // arrange
        var eP1 = GetEmployeePosition();
        var eP2 = GetEmployeePosition();
        await PurchasingContext.AddRangeAsync(eP1, eP2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await employeePositionReadRepository.GetAsync(eP1.Id, CancellationToken.None);

        // assert
        result.Should().NotBeNull()
            .And.BeEquivalentTo(eP1);
    }

    /// <summary>
    /// Нашел должность сотрудника и вернул true
    /// </summary>
    [Fact]
    public async Task IsExistShouldReturnTrue()
    {
        // arrange
        var eP1 = GetEmployeePosition();
        var eP2 = GetEmployeePosition();
        await PurchasingContext.AddRangeAsync(eP1, eP2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = employeePositionReadRepository.IsExist(eP1);

        // assert
        result.Should().BeTrue();
    }

    /// <summary>
    /// Не нашел должность сотрудника и вернул false
    /// </summary>
    [Fact]
    public async Task IsExistShouldReturnFalse()
    {
        // arrange
        var eP1 = GetEmployeePosition();
        var eP2 = GetEmployeePosition();
        var eP3 = GetEmployeePosition();
        await PurchasingContext.AddRangeAsync(eP1, eP2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = employeePositionReadRepository.IsExist(eP3);

        // assert
        result.Should().BeFalse();
    }

    /// <summary>
    /// Возвращает отсортированную страницу из должностей по имени по возрастанию
    /// </summary>
    [Fact]
    public async Task GetPageShouldReturnOrderedInAscendingOrderValue()
    {
        // arrange
        var position1 = GetEmployeePosition(p => p.Name = "Менеджер");
        var position2 = GetEmployeePosition(p => p.Name = "Директор");
        var position3 = GetEmployeePosition(p => p.Name = "Секретарь");
        await PurchasingContext.AddRangeAsync(position1, position2, position3);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await employeePositionReadRepository.GetPageAsync(EmployeePositionSortBy.Name, 1, 3, CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(3);
        result[0].Should().BeEquivalentTo(position2); // Директор
        result[1].Should().BeEquivalentTo(position1); // Менеджер
        result[2].Should().BeEquivalentTo(position3); // Секретарь
    }

    /// <summary>
    /// Возвращает отсортированную страницу из 2-х должностей по имени по возрастанию
    /// </summary>
    [Fact]
    public async Task GetPageShouldReturnPageWithPagination()
    {
        // arrange
        var position1 = GetEmployeePosition(p => p.Name = "Менеджер");
        var position2 = GetEmployeePosition(p => p.Name = "Директор");
        var position3 = GetEmployeePosition(p => p.Name = "Секретарь");
        await PurchasingContext.AddRangeAsync(position1, position2, position3);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await employeePositionReadRepository.GetPageAsync(EmployeePositionSortBy.Name, 1, 2, CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(2);
        result[0].Should().BeEquivalentTo(position2); // Директор
        result[1].Should().BeEquivalentTo(position1); // Менеджер
    }

    /// <summary>
    /// Возвращает пустую страницу
    /// </summary>
    [Fact]
    public async Task GetPageShouldReturnEmpty()
    {
        // act
        var result = await employeePositionReadRepository.GetPageAsync(EmployeePositionSortBy.Name, 1, 3, CancellationToken.None);

        // assert
        result.Should().BeEmpty();
    }

    /// <summary>
    /// Возвращает отсортированную страницу из должностей по имени по убыванию
    /// </summary>
    [Fact]
    public async Task GetPageShouldReturnOrderedInDescendingOrderValue()
    {
        // arrange
        var position1 = GetEmployeePosition(p => p.Name = "Менеджер");
        var position2 = GetEmployeePosition(p => p.Name = "Директор");
        var position3 = GetEmployeePosition(p => p.Name = "Секретарь");
        await PurchasingContext.AddRangeAsync(position1, position2, position3);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await employeePositionReadRepository.GetPageAsync(EmployeePositionSortBy.NameDesc, 1, 3, CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(3);
        result[0].Should().BeEquivalentTo(position3); // Секретарь
        result[1].Should().BeEquivalentTo(position1); // Менеджер
        result[2].Should().BeEquivalentTo(position2); // Директор
    }

    /// <summary>
    /// Генерирует должность сотрудника
    /// </summary>
    private static EmployeePosition GetEmployeePosition(Action<EmployeePosition>? settings = null)
    {
        var result = new EmployeePosition();
        result.Id = Guid.NewGuid();
        result.Name = $"название: {Guid.NewGuid()}";
        result.DateOfCreation = DateTime.UtcNow;
        result.DateOfCreation = DateTime.UtcNow;
        settings?.Invoke(result);
        return result;
    }
}
