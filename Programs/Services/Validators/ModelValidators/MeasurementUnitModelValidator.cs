using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Validators.ModelValidators;

/// <summary>
/// Валидатор для <see cref="MeasurementUnitModel"/>
/// </summary>
public class MeasurementUnitModelValidator : AbstractValidator<MeasurementUnitModel>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="MeasurementUnitModel"/>
    /// </summary>
    public MeasurementUnitModelValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("Наименование единицы измерения не указано")
            .NotEmpty()
            .WithMessage("Наименование единицы измерения не указано");

        RuleFor(x => (int)x.OKEIKey)
            .InclusiveBetween(1, 999)
            .WithMessage($"Код по ОКЕИ должен быть в диапазоне от 1 до 999");
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Id сущности не указан");
    }
}
