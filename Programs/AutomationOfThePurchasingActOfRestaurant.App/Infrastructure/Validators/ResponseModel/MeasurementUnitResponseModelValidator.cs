using FluentValidation;
using Company.AutomationOfThePurchasingActOfRestaurant.Client;

namespace Company.AutomationOfThePurchasingActOfRestaurant.App.Infrastructure.Validators.ResponceModel;

/// <summary>
/// Валидатор для <see cref="MeasurementUnitResponseModel"/>
/// </summary>
public class MeasurementUnitResponseModelValidator : AbstractValidator<MeasurementUnitResponseModel>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="MeasurementUnitResponseModel"/>
    /// </summary>
    public MeasurementUnitResponseModelValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("Наименование единицы измерения не указано")
            .NotEmpty()
            .WithMessage("Наименование единицы измерения не указано");

        RuleFor(x => int.Parse(x.OkeiKey))
            .InclusiveBetween(1, 999)
            .WithMessage($"Код по ОКЕИ должен быть в диапазоне от 1 до 999");
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Id сущности не указан");
    }
}
