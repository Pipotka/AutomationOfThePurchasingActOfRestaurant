using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Tests;
using FluentAssertions;
using Xunit;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Tests.ReadRepositories.Tests;

public class OrganizationReadRepositoryTests : PurchasingInMemoryContext
{
    private readonly OrganizationReadRepository оrganizationReadRepository;

    public OrganizationReadRepositoryTests()
    {
        оrganizationReadRepository = new OrganizationReadRepository(Reader);
    }

    /// <summary>
    /// Вернул пустой спискок организаций
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnEmpty()
    {
        // act
        var result = await оrganizationReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().BeEmpty();
    }

    /// <summary>
    /// Вернул список организаций
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnValue()
    {
        // arrange
        var оrganization = GetOrganization();
        await PurchasingContext.AddAsync(оrganization);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await оrganizationReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(1)
            .And.ContainSingle(a => a.Id == оrganization.Id);
    }

    /// <summary>
    /// Вернул сортированный список организаций
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
        var оrganization1 = GetOrganization(a => a.Id = guid1);
        var оrganization2 = GetOrganization(a => a.Id = guid2);
        await PurchasingContext.AddRangeAsync(оrganization1, оrganization2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await оrganizationReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(2)
            .And.ContainSingle(a => a.Id == оrganization1.Id)
            .And.ContainSingle(a => a.Id == оrganization2.Id);
        result[0].Id.Should().Be(оrganization1.Id);
        result[1].Id.Should().Be(оrganization2.Id);
    }

    /// <summary>
    /// Не вернул организацию по id
    /// </summary>
    [Fact]
    public async Task GetShouldReturnNull()
    {
        // arrange
        var оrganization = GetOrganization();
        await PurchasingContext.AddAsync(оrganization);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await оrganizationReadRepository.GetAsync(Guid.NewGuid(), CancellationToken.None);

        // assert
        result.Should().BeNull();
    }

    /// <summary>
    /// Вернул организацию по id
    /// </summary>
    [Fact]
    public async Task GetShouldReturnValue()
    {
        // arrange
        var оrganization1 = GetOrganization();
        var оrganization2 = GetOrganization();
        await PurchasingContext.AddRangeAsync(оrganization1, оrganization2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await оrganizationReadRepository.GetAsync(оrganization1.Id, CancellationToken.None);

        // assert
        result.Should().NotBeNull()
            .And.BeEquivalentTo(оrganization1);
    }

    /// <summary>
    /// Нашел организацию и вернул true
    /// </summary>
    [Fact]
    public async Task IsExistShouldReturnTrue()
    {
        // arrange
        var оrganization1 = GetOrganization();
        var оrganization2 = GetOrganization();
        await PurchasingContext.AddRangeAsync(оrganization1, оrganization2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = оrganizationReadRepository.IsExist(оrganization1);

        // assert
        result.Should().BeTrue();
    }

    /// <summary>
    /// Не нашел организацию и вернул false
    /// </summary>
    [Fact]
    public async Task IsExistShouldReturnFalse()
    {
        // arrange
        var оrganization1 = GetOrganization();
        var оrganization2 = GetOrganization();
        var оrganization3 = GetOrganization();
        await PurchasingContext.AddRangeAsync(оrganization1, оrganization2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = оrganizationReadRepository.IsExist(оrganization3);

        // assert
        result.Should().BeFalse();
    }

    /// <summary>
    /// Генерирует организацию
    /// </summary>
    private static Organization GetOrganization(Action<Organization>? settings = null)
    {
        var result = new Organization()
        {
            Id = Guid.NewGuid(),
            Address = $"Адресс{Guid.NewGuid():N}",
            StructuralUnit = $"Структурное подразделение{Guid.NewGuid():N}",
            Name = $"Название{Guid.NewGuid():N}",
        };

        settings?.Invoke(result);
        return result;
    }
}
