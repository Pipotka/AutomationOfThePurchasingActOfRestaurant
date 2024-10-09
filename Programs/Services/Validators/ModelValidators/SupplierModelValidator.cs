using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Validators.ModelValidators;

/// <summary>
/// Валидатор для <see cref="SupplierModel"/>
/// </summary>
public class SupplierModelValidator : AbstractValidator<SupplierModel>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="SupplierModel"/>
    /// </summary>
    public SupplierModelValidator()
    {
        RuleFor(x => x.FirstName)
            .NotNull()
            .WithMessage("Имя не указано")
            .NotEmpty()
            .WithMessage("Имя не указано");
        RuleFor(x => x.LastName)
            .NotNull()
            .WithMessage("Фамилия не указана")
            .NotEmpty()
            .WithMessage("Фамилия не указана");
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Id сущности не указан");
    }
}
