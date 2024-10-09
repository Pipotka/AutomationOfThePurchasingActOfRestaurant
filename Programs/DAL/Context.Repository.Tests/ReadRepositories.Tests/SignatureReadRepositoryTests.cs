using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Tests;
using FluentAssertions;
using System.Drawing;
using Xunit;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Tests.ReadRepositories.Tests;

public class SignatureReadRepositoryTests : PurchasingInMemoryContext
{
    private readonly SignatureReadRepository signatureReadRepository;

    public SignatureReadRepositoryTests()
    {
        signatureReadRepository = new SignatureReadRepository(Reader);
    }

    /// <summary>
    /// Вернул пустой список подписей
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnEmpty()
    {
        // act
        var result = await signatureReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().BeEmpty();
    }

    /// <summary>
    /// Вернул список подписей
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnValue()
    {
        // arrange
        var signature = GetSignature();
        await PurchasingContext.AddAsync(signature);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await signatureReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(1)
            .And.ContainSingle(a => a.Id == signature.Id);
    }

    /// <summary>
    /// Вернул сортированный список подписей
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
        var signature1 = GetSignature(a => a.Id = guid1);
        var signature2 = GetSignature(a => a.Id = guid2);
        await PurchasingContext.AddRangeAsync(signature1, signature2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await signatureReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(2)
            .And.ContainSingle(a => a.Id == signature1.Id)
            .And.ContainSingle(a => a.Id == signature2.Id);
        result[0].Id.Should().Be(signature1.Id);
        result[1].Id.Should().Be(signature2.Id);
    }

    /// <summary>
    /// Не вернул подпись по id
    /// </summary>
    [Fact]
    public async Task GetShouldReturnNull()
    {
        // arrange
        var signature = GetSignature();
        await PurchasingContext.AddAsync(signature);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await signatureReadRepository.GetAsync(Guid.NewGuid(), CancellationToken.None);

        // assert
        result.Should().BeNull();
    }

    /// <summary>
    /// Вернул подпись по id
    /// </summary>
    [Fact]
    public async Task GetShouldReturnValue()
    {
        // arrange
        var signature1 = GetSignature();
        var signature2 = GetSignature();
        await PurchasingContext.AddRangeAsync(signature1, signature2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await signatureReadRepository.GetAsync(signature1.Id, CancellationToken.None);

        // assert
        result.Should().NotBeNull()
            .And.BeEquivalentTo(signature1);
    }

    /// <summary>
    /// Нашел подпись и вернул true
    /// </summary>
    [Fact]
    public async Task IsExistShouldReturnTrue()
    {
        // arrange
        var signature1 = GetSignature();
        var signature2 = GetSignature();
        await PurchasingContext.AddRangeAsync(signature1, signature2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = signatureReadRepository.IsExist(signature1);

        // assert
        result.Should().BeTrue();
    }

    /// <summary>
    /// Не нашел подпись и вернул false
    /// </summary>
    [Fact]
    public async Task IsExistShouldReturnFalse()
    {
        // arrange
        var signature1 = GetSignature();
        var signature2 = GetSignature();
        var signature3 = GetSignature();
        await PurchasingContext.AddRangeAsync(signature1, signature2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = signatureReadRepository.IsExist(signature3);

        // assert
        result.Should().BeFalse();
    }

    /// <summary>
    /// Генерирует подпись
    /// </summary>
    private static Signature GetSignature(Action<Signature>? settings = null)
    {
        var rand = new Random();
        var result = new Signature()
        {
            Id = Guid.NewGuid(),
            SignatureDecryption = $"Расшифровка подписи{Guid.NewGuid():N}",
            Points = new Point[0],
            ApproverId = Guid.NewGuid(),
        };
        settings?.Invoke(result);
        return result;
    }
}
