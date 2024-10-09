using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Validators.BaseModelValidators;

/// <summary>
/// Валидатор для <see cref="MerchandisePriceBaseModel"/>
/// </summary>
public class MerchandisePriceBaseModelValidator : AbstractValidator<MerchandisePriceBaseModel>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="MerchandisePriceBaseModel"/>
    /// </summary>
    public MerchandisePriceBaseModelValidator()
    {
        RuleFor(x => x.CostPerUnit)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Цена за единицу товара должна быть больше или равна 0")
            .NotNull()
            .WithMessage("Цена за единицу товара не указана");
    }
}
