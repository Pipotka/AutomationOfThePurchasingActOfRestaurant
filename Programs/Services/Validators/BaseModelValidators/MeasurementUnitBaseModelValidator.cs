using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Validators.BaseModelValidators;

/// <summary>
/// Валидатор для <see cref="MeasurementUnitBaseModel"/>
/// </summary>
public class MeasurementUnitBaseModelValidator : AbstractValidator<MeasurementUnitBaseModel>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="MeasurementUnitBaseModel"/>
    /// </summary>
    public MeasurementUnitBaseModelValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("Наименование единицы измерения не указано")
            .NotEmpty()
            .WithMessage("Наименование единицы измерения не указано");

        RuleFor(x => (int)x.OKEIKey)
            .InclusiveBetween(1, 999)
            .WithMessage($"Код по ОКЕИ должен быть в диапазоне от 1 до 999");
    }
}
