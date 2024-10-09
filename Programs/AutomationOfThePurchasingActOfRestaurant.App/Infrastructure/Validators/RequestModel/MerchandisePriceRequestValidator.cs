using Company.AutomationOfThePurchasingActOfRestaurant.Client;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.App.Infrastructure.Validators.RequestModel;

/// <summary>
/// Валидатор для <see cref="MerchandisePriceRequest"/>
/// </summary>
public class MerchandisePriceRequestValidator : AbstractValidator<MerchandisePriceRequest>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="MerchandisePriceRequest"/>
    /// </summary>
    public MerchandisePriceRequestValidator()
    {
        RuleFor(x => x.CostPerUnit)
            .NotNull()
            .WithMessage("Цена за единицу товара не указана")
            .GreaterThanOrEqualTo(0)
            .WithMessage("Цена за единицу товара должна быть больше или равна 0");
    }
}
