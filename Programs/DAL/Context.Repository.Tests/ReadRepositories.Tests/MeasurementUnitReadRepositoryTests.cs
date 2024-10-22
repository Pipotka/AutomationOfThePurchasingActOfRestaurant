using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Tests;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Tests.ReadRepositories.Tests;

public class MeasurementUnitReadRepositoryTests : PurchasingInMemoryContext
{
    private readonly MeasurementUnitReadRepository measurementUnitReadRepository;

    public MeasurementUnitReadRepositoryTests()
    {
        measurementUnitReadRepository = new MeasurementUnitReadRepository(Reader);
    }

    /// <summary>
    /// Вернул пустой спискок единиц измерения
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnEmpty()
    {
        // act
        var result = await measurementUnitReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().BeEmpty();
    }

    /// <summary>
    /// Вернул список единиц измерения
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnValue()
    {
        // arrange
        var measurementUnit = GetMeasurementUnit();
        await PurchasingContext.AddAsync(measurementUnit);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await measurementUnitReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(1)
            .And.ContainSingle(a => a.Id == measurementUnit.Id);
    }

    /// <summary>
    /// Вернул сортированный список единиц измерения
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
        var measurementUnit1 = GetMeasurementUnit(a => a.Id = guid1);
        var measurementUnit2 = GetMeasurementUnit(a => a.Id = guid2);
        await PurchasingContext.AddRangeAsync(measurementUnit1, measurementUnit2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await measurementUnitReadRepository.GetAllAsync(CancellationToken.None);

        // assert
        result.Should().NotBeEmpty()
            .And.HaveCount(2)
            .And.ContainSingle(a => a.Id == measurementUnit1.Id)
            .And.ContainSingle(a => a.Id == measurementUnit2.Id);
        result[0].Id.Should().Be(measurementUnit1.Id);
        result[1].Id.Should().Be(measurementUnit2.Id);
    }

    /// <summary>
    /// Не вернул единицу измерения по id
    /// </summary>
    [Fact]
    public async Task GetShouldReturnNull()
    {
        // arrange
        var measurementUnit = GetMeasurementUnit();
        await PurchasingContext.AddAsync(measurementUnit);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await measurementUnitReadRepository.GetAsync(Guid.NewGuid(), CancellationToken.None);

        // assert
        result.Should().BeNull();
    }

    /// <summary>
    /// Вернул единицу измерения по id
    /// </summary>
    [Fact]
    public async Task GetShouldReturnValue()
    {
        // arrange
        var measurementUnit1 = GetMeasurementUnit();
        var measurementUnit2 = GetMeasurementUnit();
        await PurchasingContext.AddRangeAsync(measurementUnit1, measurementUnit2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = await measurementUnitReadRepository.GetAsync(measurementUnit1.Id, CancellationToken.None);

        // assert
        result.Should().NotBeNull()
            .And.BeEquivalentTo(measurementUnit1);
    }

    /// <summary>
    /// Нашел единицу измерения и вернул true
    /// </summary>
    [Fact]
    public async Task IsExistShouldReturnTrue()
    {
        // arrange
        var measurementUnit1 = GetMeasurementUnit();
        var measurementUnit2 = GetMeasurementUnit();
        await PurchasingContext.AddRangeAsync(measurementUnit1, measurementUnit2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = measurementUnitReadRepository.IsExist(measurementUnit1);

        // assert
        result.Should().BeTrue();
    }

    /// <summary>
    /// Не нашел единицу измерения и вернул false
    /// </summary>
    [Fact]
    public async Task IsExistShouldReturnFalse()
    {
        // arrange
        var measurementUnit1 = GetMeasurementUnit();
        var measurementUnit2 = GetMeasurementUnit();
        var measurementUnit3 = GetMeasurementUnit();
        await PurchasingContext.AddRangeAsync(measurementUnit1, measurementUnit2);
        await PurchasingContext.SaveChangesAsync();

        // act
        var result = measurementUnitReadRepository.IsExist(measurementUnit3);

        // assert
        result.Should().BeFalse();
    }

    /// <summary>
    /// Генерирует единицу измерения
    /// </summary>
    private static MeasurementUnit GetMeasurementUnit(Action<MeasurementUnit>? settings = null)
    {
        var result = new MeasurementUnit()
        {
            Id = Guid.NewGuid(),
            Name = $"Название{Guid.NewGuid():N}",
            OKEIKey = $"ОКЕИ код{Guid.NewGuid():N}"
        };

        settings?.Invoke(result);
        return result;
    }
}
