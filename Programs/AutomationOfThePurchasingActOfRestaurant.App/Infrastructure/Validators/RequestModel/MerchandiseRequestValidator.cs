using Company.AutomationOfThePurchasingActOfRestaurant.Client;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.App.Infrastructure.Validators.RequestModel;

/// <summary>
/// Валидатор для <see cref="MerchandiseRequest"/>
/// </summary>
public class MerchandiseRequestValidator : AbstractValidator<MerchandiseRequest>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="MerchandiseRequest"/>
    /// </summary>
    public MerchandiseRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Наименование и характеристика товара не указаны");

        RuleFor(x => x.MerchandiseKey)
            .GreaterThan(0)
            .WithMessage("Код товара должен быть больше 0");

        RuleFor(x => x.MeasurementUnitId)
            .NotEqual(Guid.Empty)
            .WithMessage("Единица измерения не указана");

        RuleFor(x => x.Count)
            .GreaterThan(0)
            .WithMessage("Количество товара должно быть больше 0");
    }
}
