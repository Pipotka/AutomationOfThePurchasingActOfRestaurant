using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Validators.BaseModelValidators;

/// <summary>
/// Валидатор для <see cref="EmployeePositionBaseModel"/>
/// </summary>
public class EmployeePositionBaseModelValidator : AbstractValidator<EmployeePositionBaseModel>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="EmployeePositionBaseModel"/>
    /// </summary>
    public EmployeePositionBaseModelValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("Название должности не указанно")
            .NotEmpty()
            .WithMessage("Название должности не указанно");
    }
}
