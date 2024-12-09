 using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Tests;
using FluentAssertions;
using Xunit;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Tests.ReadRepositories.Tests;

/// <summary>
/// Тесты для <see cref="IApproverReadRepository"/>
/// </summary>
public class ApproverReadRepositoryTests : PurchasingInMemoryContext
{
    private readonly IApproverReadRepository approverReadRepository;

    public ApproverReadRepositoryTests()
    {
        approverReadRepository = new ApproverReadRepository(Reader);
    }

    /// <summary>
    /// Вернул пустой спискок утверждающих
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnEmpty()
    {
        // act
        var result = await approverReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().BeEmpty();
    }

    /// <summary>
    /// Вернул список утверждающих
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnValue()
    {
        // arrange
        var approver = GetApprover();
        await PurchasingContext.AddAsync(approver);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await approverReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(1)
            .And.ContainSingle(a => a.Id == approver.Id);
    }

    /// <summary>
    /// Вернул сортированный список утверждающих
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnOrderedValue()
    {
        // arrange
        var approver1 = GetApprover(a => a.LastName = "Абрамов");
        var approver2 = GetApprover(a => a.LastName = "Ярисов");
        await PurchasingContext.AddRangeAsync(approver1, approver2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await approverReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(2)
            .And.ContainSingle(a => a.Id == approver1.Id)
            .And.ContainSingle(a => a.Id == approver2.Id);
        result[0].Id.Should().Be(approver1.Id);
        result[1].Id.Should().Be(approver2.Id);
    }

    /// <summary>
    /// Вернул утверждающего по фамилии
    /// </summary>
    [Fact]
    public async Task GetByLastNameShouldReturnValue()
    {
        // arrange
        var approver = GetApprover(a => a.LastName = "Абдулгаджиев");
        await PurchasingContext.AddAsync(approver);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await approverReadRepository.GetByLastNameAsync(approver.LastName, CancellationToken.None);

        // assert
        result.Should().NotBeNull()
            .And.BeEquivalentTo(approver);
    }

    /// <summary>
    /// Не вернул утверждающего по фамилии
    /// </summary>
    [Fact]
    public async Task GetByLastNameShouldReturnNull()
    {
        // act
        var result = await approverReadRepository.GetByLastNameAsync("Абдулгаджиев", CancellationToken.None);

        // assert
        result.Should().BeNull();
    }

    /// <summary>
    /// Не вернул утверждающего по id
    /// </summary>
    [Fact]
    public async Task GetShouldReturnNull()
    {
        // arrange
        var approver = GetApprover();
        await PurchasingContext.AddAsync(approver);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await approverReadRepository.GetAsync(Guid.NewGuid(), CancellationToken.None);

        // assert
        result.Should().BeNull();
    }

    /// <summary>
    /// Вернул утверждающего по id
    /// </summary>
    [Fact]
    public async Task GetShouldReturnValue()
    {
        // arrange
        var approver1 = GetApprover();
        var approver2 = GetApprover();
        await PurchasingContext.AddRangeAsync(approver1, approver2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await approverReadRepository.GetAsync(approver1.Id, CancellationToken.None);

        // assert
        result.Should().NotBeNull()
            .And.BeEquivalentTo(approver1);
    }

    /// <summary>
    /// Нашел утверждающего и вернул true
    /// </summary>
    [Fact]
    public async Task IsExistShouldReturnTrue()
    {
        // arrange
        var approver1 = GetApprover();
        var approver2 = GetApprover();
        await PurchasingContext.AddRangeAsync(approver1, approver2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = approverReadRepository.IsExist(approver1);

        // assert
        result.Should().BeTrue();
    }

    /// <summary>
    /// Не нашел утверждающего и вернул false
    /// </summary>
    [Fact]
    public async Task IsExistShouldReturnFalse()
    {
        // arrange
        var approver1 = GetApprover();
        var approver2 = GetApprover();
        var approver3 = GetApprover();
        await PurchasingContext.AddRangeAsync(approver1, approver2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = approverReadRepository.IsExist(approver3);

        // assert
        result.Should().BeFalse();
    }

    /// <summary>
    /// Возвращает отсортировынную страницу из утверждающих по имени по возрастанию
    /// </summary>
    [Fact]
    public async Task GetPageShouldReturnOrderedInAscendingOrderValue()
    {
        // arrange
        var approver1 = GetApprover(a => a.LastName = "Абрамов");
        var approver2 = GetApprover(a => a.LastName = "Ярисов");
        var approver3 = GetApprover(a => a.LastName = "Кутузов");
        await PurchasingContext.AddRangeAsync(approver1, approver2, approver3);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await approverReadRepository.GetPageAsync(ApproverSortBy.LastName, 1, 3, CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(3);
        result[0].Should().BeEquivalentTo(approver1);
        result[1].Should().BeEquivalentTo(approver3);
        result[2].Should().BeEquivalentTo(approver2);
    }

    /// <summary>
    /// Возвращает отсортировынную страницу из 2-х утверждающих по имени по возрастанию
    /// </summary>spaginated page
    [Fact]
    public async Task GetPageShouldReturnPageWithPagination()
    {
        // arrange
        var approver1 = GetApprover(a => a.LastName = "Абрамов");
        var approver2 = GetApprover(a => a.LastName = "Ярисов");
        var approver3 = GetApprover(a => a.LastName = "Кутузов");
        await PurchasingContext.AddRangeAsync(approver1, approver2, approver3);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await approverReadRepository.GetPageAsync(ApproverSortBy.LastName, 1, 2, CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(2);
        result[0].Should().BeEquivalentTo(approver1);
        result[1].Should().BeEquivalentTo(approver3);
    }

    /// <summary>
    /// Возвращает пустую страницу
    /// </summary>
    [Fact]
    public async Task GetPageShouldReturnEmpty()
    {
        // act
        var result = await approverReadRepository.GetPageAsync(ApproverSortBy.LastName, 1, 3, CancellationToken.None);

        // assert
        result.Should().BeEmpty();
    }

    /// <summary>
    /// Возвращает отсортировынную страницу из утверждающих по имени по убыванию
    /// </summary>
    [Fact]
    public async Task GetPageShouldReturnOrderedInDescendingOrderValue()
    {
        // arrange
        var approver1 = GetApprover(a => a.LastName = "Абрамов");
        var approver2 = GetApprover(a => a.LastName = "Ярисов");
        var approver3 = GetApprover(a => a.LastName = "Кутузов");
        await PurchasingContext.AddRangeAsync(approver1, approver2, approver3);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await approverReadRepository.GetPageAsync(ApproverSortBy.LastNameDesc, 1, 3, CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(3);
        result[0].Should().BeEquivalentTo(approver2);
        result[1].Should().BeEquivalentTo(approver3);
        result[2].Should().BeEquivalentTo(approver1);
    }


    /// <summary>
    /// Генерирует утверждающего
    /// </summary>
    private static Approver GetApprover(Action<Approver>? settings = null)
    {
        var result = new Approver()
        {
            Id = Guid.NewGuid(),
            FirstName = $"Имя{Guid.NewGuid():N}",
            LastName = $"Фамилия{Guid.NewGuid():N}",
            Patronymic = $"Отчество{Guid.NewGuid():N}",
            SignatureDecryption = $"Расшифровка подписи:{Guid.NewGuid():N}",
            PositionId = Guid.NewGuid(),
    };

        settings?.Invoke(result);
        return result;
    }

}
