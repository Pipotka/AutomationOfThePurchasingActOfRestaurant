using Company.AutomationOfThePurchasingActOfRestaurant.Client;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.App.Infrastructure.Validators.RequestModel;

/// <summary>
/// Валидатор для <see cref="MeasurementUnitRequest"/>
/// </summary>
public class MeasurementUnitRequestValidator : AbstractValidator<MeasurementUnitRequest>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="MeasurementUnitRequest"/>
    /// </summary>
    public MeasurementUnitRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Наименование единицы измерения не указано");

        RuleFor(x => x.OkeiKey)
            .InclusiveBetween(1, 999)
            .WithMessage($"Код по ОКЕИ должен быть в диапазоне от 1 до 999");
    }
}
