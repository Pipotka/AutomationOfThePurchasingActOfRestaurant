using Company.AutomationOfThePurchasingActOfRestaurant.Client;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.App.Infrastructure.Validators.RequestModel;

/// <summary>
/// Валидатор для <see cref="SupplierRequest"/>
/// </summary>
public class SupplierRequestValidator : AbstractValidator<SupplierRequest>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="SupplierRequest"/>
    /// </summary>
    public SupplierRequestValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("Имя не указано");
        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Фамилия не указана");
    }
}
