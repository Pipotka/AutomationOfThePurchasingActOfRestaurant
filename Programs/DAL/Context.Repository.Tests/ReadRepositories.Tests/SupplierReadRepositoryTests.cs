using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Tests;
using FluentAssertions;
using System.Drawing;
using Xunit;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Tests.ReadRepositories.Tests;

public class SupplierReadRepositoryTests : PurchasingInMemoryContext
{
    private readonly SupplierReadRepository supplierReadRepository;

    public SupplierReadRepositoryTests()
    {
        supplierReadRepository = new SupplierReadRepository(Reader);
    }

    /// <summary>
    /// Вернул пустой список поставшиков
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnEmpty()
    {
        // act
        var result = await supplierReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().BeEmpty();
    }

    /// <summary>
    /// Вернул список поставшиков
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnValue()
    {
        // arrange
        var supplier = GetSupplier();
        await PurchasingContext.AddAsync(supplier);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await supplierReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(1)
            .And.ContainSingle(a => a.Id == supplier.Id);
    }

    /// <summary>
    /// Вернул сортированный список поставшиков
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnOrderedValue()
    {
        // arrange
        var supplier1 = GetSupplier(a => a.LastName = "Абрамович");
        var supplier2 = GetSupplier(a => a.LastName = "Якорь");
        await PurchasingContext.AddRangeAsync(supplier1, supplier2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await supplierReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(2)
            .And.ContainSingle(a => a.Id == supplier1.Id)
            .And.ContainSingle(a => a.Id == supplier2.Id);
        result[0].Id.Should().Be(supplier1.Id);
        result[1].Id.Should().Be(supplier2.Id);
    }

    /// <summary>
    /// Не вернул поставшика по id
    /// </summary>
    [Fact]
    public async Task GetShouldReturnNull()
    {
        // arrange
        var supplier = GetSupplier();
        await PurchasingContext.AddAsync(supplier);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await supplierReadRepository.GetAsync(Guid.NewGuid(), CancellationToken.None);

        // assert
        result.Should().BeNull();
    }

    /// <summary>
    /// Вернул поставшика по id
    /// </summary>
    [Fact]
    public async Task GetShouldReturnValue()
    {
        // arrange
        var supplier1 = GetSupplier();
        var supplier2 = GetSupplier();
        await PurchasingContext.AddRangeAsync(supplier1, supplier2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await supplierReadRepository.GetAsync(supplier1.Id, CancellationToken.None);

        // assert
        result.Should().NotBeNull()
            .And.BeEquivalentTo(supplier1);
    }

    /// <summary>
    /// Нашел поставшика и вернул true
    /// </summary>
    [Fact]
    public async Task IsExistShouldReturnTrue()
    {
        // arrange
        var supplier1 = GetSupplier();
        var supplier2 = GetSupplier();
        await PurchasingContext.AddRangeAsync(supplier1, supplier2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = supplierReadRepository.IsExist(supplier1);

        // assert
        result.Should().BeTrue();
    }

    /// <summary>
    /// Не нашел поставшика и вернул false
    /// </summary>
    [Fact]
    public async Task IsExistShouldReturnFalse()
    {
        // arrange
        var supplier1 = GetSupplier();
        var supplier2 = GetSupplier();
        var supplier3 = GetSupplier();
        await PurchasingContext.AddRangeAsync(supplier1, supplier2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = supplierReadRepository.IsExist(supplier3);

        // assert
        result.Should().BeFalse();
    }

    /// <summary>
    /// Вернул утверждающего по фамилии
    /// </summary>
    [Fact]
    public async Task GetByLastNameShouldReturnValue()
    {
        // arrange
        var supplier = GetSupplier(a => a.LastName = "Абдулгаджиев");
        await PurchasingContext.AddAsync(supplier);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await supplierReadRepository.GetByLastNameAsync(supplier.LastName, CancellationToken.None);

        // assert
        result.Should().NotBeNull()
            .And.BeEquivalentTo(supplier);
    }

    /// <summary>
    /// Не вернул утверждающего по фамилии
    /// </summary>
    [Fact]
    public async Task GetByLastNameShouldReturnNull()
    {
        // arrange
        var supplier = GetSupplier(a => a.LastName = "Абрамович");
        await PurchasingContext.AddAsync(supplier);
        await PurchasingContext.SaveChangesAsync();
        // act
        var result = await supplierReadRepository.GetByLastNameAsync("Абдулгаджиев", CancellationToken.None);

        // assert
        result.Should().BeNull();
    }

    /// <summary>
    /// Генерирует поставшика
    /// </summary>
    private static Supplier GetSupplier(Action<Supplier>? settings = null)
    {
        var result = new Supplier()
        {
            Id = Guid.NewGuid(),
            FirstName = $"Имя{Guid.NewGuid():N}",
            LastName = $"Фамилия{Guid.NewGuid():N}",
            Patronymic = $"Отчество{Guid.NewGuid():N}",
        };
        settings?.Invoke(result);
        return result;
    }
}