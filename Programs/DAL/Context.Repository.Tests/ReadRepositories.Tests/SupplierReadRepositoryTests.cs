using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;
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
            .And.ContainSingle(s => s.Id == supplier.Id);
    }

    /// <summary>
    /// Вернул сортированный список поставшиков
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnOrderedValue()
    {
        // arrange
        var supplier1 = GetSupplier(s => s.LastName = "Абрамович");
        var supplier2 = GetSupplier(s => s.LastName = "Якорь");
        await PurchasingContext.AddRangeAsync(supplier1, supplier2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await supplierReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(2)
            .And.ContainSingle(s => s.Id == supplier1.Id)
            .And.ContainSingle(s => s.Id == supplier2.Id);
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
        var supplier = GetSupplier(s => s.LastName = "Абдулгаджиев");
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
        var supplier = GetSupplier(s => s.LastName = "Абрамович");
        await PurchasingContext.AddAsync(supplier);
        await PurchasingContext.SaveChangesAsync();
        // act
        var result = await supplierReadRepository.GetByLastNameAsync("Абдулгаджиев", CancellationToken.None);

        // assert
        result.Should().BeNull();
    }

    /// <summary>
    /// Возвращает отсортировынную страницу из поставщиков по имени по возрастанию
    /// </summary>
    [Fact]
    public async Task GetPageShouldReturnOrderedInAscendingOrderValue()
    {
        // arrange
        var supplier1 = GetSupplier(s => s.LastName = "Абрамов");
        var supplier2 = GetSupplier(s => s.LastName = "Ярисов");
        var supplier3 = GetSupplier(s => s.LastName = "Кутузов");
        await PurchasingContext.AddRangeAsync(supplier1, supplier2, supplier3);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await supplierReadRepository.GetPageAsync(SupplierSortBy.LastName, 1, 3, CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(3);
        result[0].Should().BeEquivalentTo(supplier1);
        result[1].Should().BeEquivalentTo(supplier3);
        result[2].Should().BeEquivalentTo(supplier2);
    }

    /// <summary>
    /// Возвращает отсортировынную страницу из 2-х поставщиков по имени по возрастанию
    /// </summary>spaginated page
    [Fact]
    public async Task GetPageShouldReturnPageWithPagination()
    {
        // arrange
        var supplier1 = GetSupplier(s => s.LastName = "Абрамов");
        var supplier2 = GetSupplier(s => s.LastName = "Ярисов");
        var supplier3 = GetSupplier(s => s.LastName = "Кутузов");
        await PurchasingContext.AddRangeAsync(supplier1, supplier2, supplier3);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await supplierReadRepository.GetPageAsync(SupplierSortBy.LastName, 1, 2, CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(2);
        result[0].Should().BeEquivalentTo(supplier1);
        result[1].Should().BeEquivalentTo(supplier3);
    }

    /// <summary>
    /// Возвращает пустую страницу
    /// </summary>
    [Fact]
    public async Task GetPageShouldReturnEmpty()
    {
        // act
        var result = await supplierReadRepository.GetPageAsync(SupplierSortBy.LastName, 1, 3, CancellationToken.None);

        // assert
        result.Should().BeEmpty();
    }

    /// <summary>
    /// Возвращает отсортировынную страницу из поставщиков по имени по убыванию
    /// </summary>
    [Fact]
    public async Task GetPageShouldReturnOrderedInDescendingOrderValue()
    {
        // arrange
        var supplier1 = GetSupplier(x => x.LastName = "Абрамов");
        var supplier2 = GetSupplier(x => x.LastName = "Ярисов");
        var supplier3 = GetSupplier(x => x.LastName = "Кутузов");
        await PurchasingContext.AddRangeAsync(supplier1, supplier2, supplier3);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await supplierReadRepository.GetPageAsync(SupplierSortBy.LastNameDesc, 1, 3, CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(3);
        result[0].Should().BeEquivalentTo(supplier2);
        result[1].Should().BeEquivalentTo(supplier3);
        result[2].Should().BeEquivalentTo(supplier1);
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