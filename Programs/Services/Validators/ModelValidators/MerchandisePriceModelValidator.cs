using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Validators.ModelValidators;

/// <summary>
/// Валидатор для <see cref="MerchandisePriceModel"/>
/// </summary>
public class MerchandisePriceModelValidator : AbstractValidator<MerchandisePriceModel>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="MerchandisePriceModel"/>
    /// </summary>
    public MerchandisePriceModelValidator()
    {
        RuleFor(x => x.CostPerUnit)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Цена за единицу товара должна быть больше или равна 0")
            .NotNull()
            .WithMessage("Цена за единицу товара не указана");
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Id сущности не указан");
    }
}
