
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Tests;
using FluentAssertions;
using Xunit;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Tests.ReadRepositories.Tests;

/// <summary>
/// Тесты для <see cref="IFormKeyReadRepository"/>
/// </summary>
public class FormKeyReadRepositoryTests : PurchasingInMemoryContext
{
    private readonly IFormKeyReadRepository formKeyReadRepository;

    public FormKeyReadRepositoryTests()
    {
        this.formKeyReadRepository = new FormKeyReadRepository(Reader);
    }

    /// <summary>
    /// Вернули пустой спискок должностей сотрудника
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnEmpty()
    {
        // act
        var result = await formKeyReadRepository.GetAllAsync(CancellationToken.None);

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
        var fK = GetFormKey();
        await PurchasingContext.AddAsync(fK);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await formKeyReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(1)
            .And.ContainSingle(fk => fk.Id == fK.Id);
    }

    /// <summary>
    /// Вернули сортированный список должностей сотрудника
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnOrderedValue()
    {
        // arrange
        var fK1 = GetFormKey();
        var fK2 = GetFormKey();
        var firstGuid = Guid.NewGuid();
        var secondGuid = Guid.NewGuid();
        if (firstGuid > secondGuid)
        {
            fK1.Id = secondGuid;
            fK2.Id = firstGuid;
        }
        else
        {
            fK1.Id = firstGuid;
            fK2.Id = secondGuid;
        }

        await PurchasingContext.AddRangeAsync(fK1, fK2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await formKeyReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(2)
            .And.ContainSingle(fk => fk.Id == fK1.Id)
            .And.ContainSingle(fk => fk.Id == fK2.Id);
        result[0].Id.Should().Be(fK1.Id);
        result[1].Id.Should().Be(fK2.Id);
    }

    /// <summary>
    /// Не вернул должность сотрудника по id
    /// </summary>
    [Fact]
    public async Task GetShouldReturnNull()
    {
        // arrange
        var fK = GetFormKey();
        await PurchasingContext.AddAsync(fK);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await formKeyReadRepository.GetAsync(Guid.NewGuid(), CancellationToken.None);

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
        var fK1 = GetFormKey();
        var fK2 = GetFormKey();
        await PurchasingContext.AddRangeAsync(fK1, fK2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await formKeyReadRepository.GetAsync(fK1.Id, CancellationToken.None);

        // assert
        result.Should().NotBeNull()
            .And.BeEquivalentTo(fK1);
    }

    /// <summary>
    /// Нашел должность сотрудника и вернул true
    /// </summary>
    [Fact]
    public async Task IsExistShouldReturnTrue()
    {
        // arrange
        var fK1 = GetFormKey();
        var fK2 = GetFormKey();
        await PurchasingContext.AddRangeAsync(fK1, fK2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = formKeyReadRepository.IsExist(fK1);

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
        var fK1 = GetFormKey();
        var fK2 = GetFormKey();
        var fK3 = GetFormKey();
        await PurchasingContext.AddRangeAsync(fK1, fK2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = formKeyReadRepository.IsExist(fK3);

        // assert
        result.Should().BeFalse();
    }

    /// <summary>
    /// Возвращает отсортированную страницу из форм по TIN по возрастанию
    /// </summary>
    [Fact]
    public async Task GetPageShouldReturnOrderedInAscendingOrderValue()
    {
        // arrange
        var formKey1 = GetFormKey(f => f.TIN = "Петров");
        var formKey2 = GetFormKey(f => f.TIN = "Сидоров");
        var formKey3 = GetFormKey(f => f.TIN = "Иванов");
        await PurchasingContext.AddRangeAsync(formKey1, formKey2, formKey3);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await formKeyReadRepository.GetPageAsync(FormKeySortBy.TIN, 1, 3, CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(3);
        result[0].Should().BeEquivalentTo(formKey3); // Иванов
        result[1].Should().BeEquivalentTo(formKey1); // Петров
        result[2].Should().BeEquivalentTo(formKey2); // Сидоров
    }

    /// <summary>
    /// Возвращает отсортированную страницу из 2-х форм по TIN по возрастанию
    /// </summary>
    [Fact]
    public async Task GetPageShouldReturnPageWithPagination()
    {
        // arrange
        var formKey1 = GetFormKey(f => f.TIN = "Петров");
        var formKey2 = GetFormKey(f => f.TIN = "Сидоров");
        var formKey3 = GetFormKey(f => f.TIN = "Иванов");
        await PurchasingContext.AddRangeAsync(formKey1, formKey2, formKey3);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await formKeyReadRepository.GetPageAsync(FormKeySortBy.TIN, 1, 2, CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(2);
        result[0].Should().BeEquivalentTo(formKey3); // Иванов
        result[1].Should().BeEquivalentTo(formKey1); // Петров
    }

    /// <summary>
    /// Возвращает пустую страницу
    /// </summary>
    [Fact]
    public async Task GetPageShouldReturnEmpty()
    {
        // act
        var result = await formKeyReadRepository.GetPageAsync(FormKeySortBy.TIN, 1, 3, CancellationToken.None);

        // assert
        result.Should().BeEmpty();
    }

    /// <summary>
    /// Возвращает отсортированную страницу из форм по TIN по убыванию
    /// </summary>
    [Fact]
    public async Task GetPageShouldReturnOrderedInDescendingOrderValue()
    {
        // arrange
        var formKey1 = GetFormKey(f => f.TIN = "Петров");
        var formKey2 = GetFormKey(f => f.TIN = "Сидоров");
        var formKey3 = GetFormKey(f => f.TIN = "Иванов");
        await PurchasingContext.AddRangeAsync(formKey1, formKey2, formKey3);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await formKeyReadRepository.GetPageAsync(FormKeySortBy.TINDesc, 1, 3, CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(3);
        result[0].Should().BeEquivalentTo(formKey2); // Сидоров
        result[1].Should().BeEquivalentTo(formKey1); // Петров
        result[2].Should().BeEquivalentTo(formKey3); // Иванов
    }

    /// <summary>
    /// Генерирует должность сотрудника
    /// </summary>
    private static FormKey GetFormKey(Action<FormKey>? settings = null)
    {
        var result = new FormKey();
        result.Id = Guid.NewGuid();
        result.TIN = $"TIN: {Guid.NewGuid()}";
        result.OKPO = $"OKPO: {Guid.NewGuid()}";
        result.OKUD = $"OKUD: {Guid.NewGuid()}";
        result.OKDP = $"OKDP: {Guid.NewGuid()}";
        result.DateOfCreation = DateTime.UtcNow;
        result.DateOfCreation = DateTime.UtcNow;
        settings?.Invoke(result);
        return result;
    }
}
