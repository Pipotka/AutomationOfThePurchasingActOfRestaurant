using FluentValidation;
using Company.AutomationOfThePurchasingActOfRestaurant.Client;

namespace Company.AutomationOfThePurchasingActOfRestaurant.App.Infrastructure.Validators.ResponceModel;

/// <summary>
/// Валидатор для <see cref="MerchandisePriceResponseModel"/>
/// </summary>
public class MerchandisePriceResponseModelValidator : AbstractValidator<MerchandisePriceResponseModel>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="MerchandisePriceResponseModel"/>
    /// </summary>
    public MerchandisePriceResponseModelValidator()
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
