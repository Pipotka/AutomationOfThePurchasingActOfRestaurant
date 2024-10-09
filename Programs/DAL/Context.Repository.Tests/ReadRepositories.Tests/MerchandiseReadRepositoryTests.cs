using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Tests;
using FluentAssertions;
using Xunit;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Tests.ReadRepositories.Tests;

public class MerchandiseReadRepositoryTests : PurchasingInMemoryContext
{
    private readonly MerchandiseReadRepository merchandiseReadRepository;

    public MerchandiseReadRepositoryTests()
    {
        merchandiseReadRepository = new MerchandiseReadRepository(Reader);
    }

    /// <summary>
    /// Вернул пустой спискок товаров
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnEmpty()
    {
        // act
        var result = await merchandiseReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().BeEmpty();
    }

    /// <summary>
    /// Вернул список товаров
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnValue()
    {
        // arrange
        var merchandise = GetMerchandise();
        await PurchasingContext.AddAsync(merchandise);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await merchandiseReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(1)
            .And.ContainSingle(a => a.Id == merchandise.Id);
    }

    /// <summary>
    /// Вернул сортированный список товаров
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnOrderedValue()
    {
        // arrange
        var guid1 = Guid.NewGuid();
        var guid2 = Guid.NewGuid();
        if (guid1 > guid2)
        {
            var broker = guid1;
            guid1 = guid2;
            guid2 = broker;
        }
        var merchandise1 = GetMerchandise(a => a.Id = guid1);
        var merchandise2 = GetMerchandise(a => a.Id = guid2);
        await PurchasingContext.AddRangeAsync(merchandise1, merchandise2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await merchandiseReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(2)
            .And.ContainSingle(a => a.Id == merchandise1.Id)
            .And.ContainSingle(a => a.Id == merchandise2.Id);
        result[0].Id.Should().Be(merchandise1.Id);
        result[1].Id.Should().Be(merchandise2.Id);
    }

    /// <summary>
    /// Не вернул товар по id
    /// </summary>
    [Fact]
    public async Task GetShouldReturnNull()
    {
        // arrange
        var merchandise = GetMerchandise();
        await PurchasingContext.AddAsync(merchandise);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await merchandiseReadRepository.GetAsync(Guid.NewGuid(), CancellationToken.None);

        // assert
        result.Should().BeNull();
    }

    /// <summary>
    /// Вернул товар по id
    /// </summary>
    [Fact]
    public async Task GetShouldReturnValue()
    {
        // arrange
        var merchandise1 = GetMerchandise();
        var merchandise2 = GetMerchandise();
        await PurchasingContext.AddRangeAsync(merchandise1, merchandise2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await merchandiseReadRepository.GetAsync(merchandise1.Id, CancellationToken.None);

        // assert
        result.Should().NotBeNull()
            .And.BeEquivalentTo(merchandise1);
    }

    /// <summary>
    /// Нашел товар и вернул true
    /// </summary>
    [Fact]
    public async Task IsExistShouldReturnTrue()
    {
        // arrange
        var merchandise1 = GetMerchandise();
        var merchandise2 = GetMerchandise();
        await PurchasingContext.AddRangeAsync(merchandise1, merchandise2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = merchandiseReadRepository.IsExist(merchandise1);

        // assert
        result.Should().BeTrue();
    }

    /// <summary>
    /// Не нашел товар и вернул false
    /// </summary>
    [Fact]
    public async Task IsExistShouldReturnFalse()
    {
        // arrange
        var merchandise1 = GetMerchandise();
        var merchandise2 = GetMerchandise();
        var merchandise3 = GetMerchandise();
        await PurchasingContext.AddRangeAsync(merchandise1, merchandise2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = merchandiseReadRepository.IsExist(merchandise3);

        // assert
        result.Should().BeFalse();
    }

    /// <summary>
    /// Генерирует товар
    /// </summary>
    private static Merchandise GetMerchandise(Action<Merchandise>? settings = null)
    {
        var rand = new Random();
        var result = new Merchandise()
        {
            Id = Guid.NewGuid(),
            Count = rand.Next(1000),
            MerchandiseKey = rand.Next(999),
            Name = $"Название{Guid.NewGuid():N}",
        };

        settings?.Invoke(result);
        return result;
    }
}
