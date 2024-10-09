using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Tests;
using FluentAssertions;
using Xunit;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Tests.ReadRepositories.Tests;

public class MerchandisePriceReadRepositoryTests : PurchasingInMemoryContext
{
    private readonly MerchandisePriceReadRepository merchandisePriceReadRepository;

    public MerchandisePriceReadRepositoryTests()
    {
        merchandisePriceReadRepository = new MerchandisePriceReadRepository(Reader);
    }

    /// <summary>
    /// Вернул пустой спискок цен товаров
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnEmpty()
    {
        // act
        var result = await merchandisePriceReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().BeEmpty();
    }

    /// <summary>
    /// Вернул список цен товаров
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnValue()
    {
        // arrange
        var merchandisePrice = GetMerchandisePrice();
        await PurchasingContext.AddAsync(merchandisePrice);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await merchandisePriceReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(1)
            .And.ContainSingle(a => a.Id == merchandisePrice.Id);
    }

    /// <summary>
    /// Вернул сортированный список цен товаров
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
        var merchandisePrice1 = GetMerchandisePrice(a => a.Id = guid1);
        var merchandisePrice2 = GetMerchandisePrice(a => a.Id = guid2);
        await PurchasingContext.AddRangeAsync(merchandisePrice1, merchandisePrice2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await merchandisePriceReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(2)
            .And.ContainSingle(a => a.Id == merchandisePrice1.Id)
            .And.ContainSingle(a => a.Id == merchandisePrice2.Id);
        result[0].Id.Should().Be(merchandisePrice1.Id);
        result[1].Id.Should().Be(merchandisePrice2.Id);
    }

    /// <summary>
    /// Не вернул цену товара по id
    /// </summary>
    [Fact]
    public async Task GetShouldReturnNull()
    {
        // arrange
        var merchandisePrice = GetMerchandisePrice();
        await PurchasingContext.AddAsync(merchandisePrice);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await merchandisePriceReadRepository.GetAsync(Guid.NewGuid(), CancellationToken.None);

        // assert
        result.Should().BeNull();
    }

    /// <summary>
    /// Вернул цену товара по id
    /// </summary>
    [Fact]
    public async Task GetShouldReturnValue()
    {
        // arrange
        var merchandisePrice1 = GetMerchandisePrice();
        var merchandisePrice2 = GetMerchandisePrice();
        await PurchasingContext.AddRangeAsync(merchandisePrice1, merchandisePrice2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await merchandisePriceReadRepository.GetAsync(merchandisePrice1.Id, CancellationToken.None);

        // assert
        result.Should().NotBeNull()
            .And.BeEquivalentTo(merchandisePrice1);
    }

    /// <summary>
    /// Нашел цену товара и вернул true
    /// </summary>
    [Fact]
    public async Task IsExistShouldReturnTrue()
    {
        // arrange
        var merchandisePrice1 = GetMerchandisePrice();
        var merchandisePrice2 = GetMerchandisePrice();
        await PurchasingContext.AddRangeAsync(merchandisePrice1, merchandisePrice2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = merchandisePriceReadRepository.IsExist(merchandisePrice1);

        // assert
        result.Should().BeTrue();
    }

    /// <summary>
    /// Не нашел цену товара и вернул false
    /// </summary>
    [Fact]
    public async Task IsExistShouldReturnFalse()
    {
        // arrange
        var merchandisePrice1 = GetMerchandisePrice();
        var merchandisePrice2 = GetMerchandisePrice();
        var merchandisePrice3 = GetMerchandisePrice();
        await PurchasingContext.AddRangeAsync(merchandisePrice1, merchandisePrice2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = merchandisePriceReadRepository.IsExist(merchandisePrice3);

        // assert
        result.Should().BeFalse();
    }

    /// <summary>
    /// Генерирует цену товара
    /// </summary>
    private static MerchandisePrice GetMerchandisePrice(Action<MerchandisePrice>? settings = null)
    {
        var rand = new Random();
        var result = new MerchandisePrice()
        {
            Id = Guid.NewGuid(),
            CostPerUnit = rand.Next(1000),
        };

        settings?.Invoke(result);
        return result;
    }
}
