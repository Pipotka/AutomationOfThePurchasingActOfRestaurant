using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Tests;
using FluentAssertions;
using Xunit;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Tests.ReadRepositories.Tests;

public class PurchaseFormReadRepositoryTests : PurchasingInMemoryContext
{
    private readonly PurchaseFormReadRepository purchaseFormReadRepository;

    public PurchaseFormReadRepositoryTests()
    {
        purchaseFormReadRepository = new PurchaseFormReadRepository(Reader);
    }

    /// <summary>
    /// Вернул пустой закупочных форм
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnEmpty()
    {
        // act
        var result = await purchaseFormReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().BeEmpty();
    }

    /// <summary>
    /// Вернул список закупочных форм
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnValue()
    {
        // arrange
        var purchaseForm = GetPurchaseForm();
        await PurchasingContext.AddAsync(purchaseForm);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await purchaseFormReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(1)
            .And.ContainSingle(a => a.Id == purchaseForm.Id);
    }

    /// <summary>
    /// Вернул сортированный список закупочных форм
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
        var purchaseForm1 = GetPurchaseForm(a => a.Id = guid1);
        var purchaseForm2 = GetPurchaseForm(a => a.Id = guid2);
        await PurchasingContext.AddRangeAsync(purchaseForm1, purchaseForm2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await purchaseFormReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(2)
            .And.ContainSingle(a => a.Id == purchaseForm1.Id)
            .And.ContainSingle(a => a.Id == purchaseForm2.Id);
        result[0].Id.Should().Be(purchaseForm1.Id);
        result[1].Id.Should().Be(purchaseForm2.Id);
    }

    /// <summary>
    /// Не вернул закупочную форму по id
    /// </summary>
    [Fact]
    public async Task GetShouldReturnNull()
    {
        // arrange
        var purchaseForm = GetPurchaseForm();
        await PurchasingContext.AddAsync(purchaseForm);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await purchaseFormReadRepository.GetAsync(Guid.NewGuid(), CancellationToken.None);

        // assert
        result.Should().BeNull();
    }

    /// <summary>
    /// Вернул закупочную форму по id
    /// </summary>
    [Fact]
    public async Task GetShouldReturnValue()
    {
        // arrange
        var purchaseForm1 = GetPurchaseForm();
        var purchaseForm2 = GetPurchaseForm();
        await PurchasingContext.AddRangeAsync(purchaseForm1, purchaseForm2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await purchaseFormReadRepository.GetAsync(purchaseForm1.Id, CancellationToken.None);

        // assert
        result.Should().NotBeNull()
            .And.BeEquivalentTo(purchaseForm1);
    }

    /// <summary>
    /// Нашел закупочную форму и вернул true
    /// </summary>
    [Fact]
    public async Task IsExistShouldReturnTrue()
    {
        // arrange
        var purchaseForm1 = GetPurchaseForm();
        var purchaseForm2 = GetPurchaseForm();
        await PurchasingContext.AddRangeAsync(purchaseForm1, purchaseForm2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = purchaseFormReadRepository.IsExist(purchaseForm1);

        // assert
        result.Should().BeTrue();
    }

    /// <summary>
    /// Не нашел закупочную форму и вернул false
    /// </summary>
    [Fact]
    public async Task IsExistShouldReturnFalse()
    {
        // arrange
        var purchaseForm1 = GetPurchaseForm();
        var purchaseForm2 = GetPurchaseForm();
        var purchaseForm3 = GetPurchaseForm();
        await PurchasingContext.AddRangeAsync(purchaseForm1, purchaseForm2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = purchaseFormReadRepository.IsExist(purchaseForm3);

        // assert
        result.Should().BeFalse();
    }

    /// <summary>
    /// Генерирует закупочную форму
    /// </summary>
    private static PurchaseForm GetPurchaseForm(Action<PurchaseForm>? settings = null)
    {
        var rand = new Random();
        var result = new PurchaseForm()
        {
            Id = Guid.NewGuid(),
            AddressOfPurchase = $"Адрес закупки{Guid.NewGuid():N}",
            DateOfCreation = DateTime.Now,
            DocumentNumber = rand.Next(1000),
            FormKeyId = Guid.NewGuid(),
        };

        settings?.Invoke(result);
        return result;
    }
}
