using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Validators.BaseModelValidators;

/// <summary>
/// Валидатор для <see cref="SupplierBaseModel"/>
/// </summary>
public class SupplierBaseModelValidator : AbstractValidator<SupplierBaseModel>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="SupplierBaseModel"/>
    /// </summary>
    public SupplierBaseModelValidator()
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
    }
}
