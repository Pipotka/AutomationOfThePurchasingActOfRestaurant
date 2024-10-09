using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Validators.ModelValidators;

/// <summary>
/// Валидатор для <see cref="EmployeePositionModel"/>
/// </summary>
public class EmployeePositionModelValidator : AbstractValidator<EmployeePositionModel>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="EmployeePositionModel"/>
    /// </summary>
    public EmployeePositionModelValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("Название должности не указанно")
            .NotEmpty()
            .WithMessage("Название должности не указанно");
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Id сущности не указан");
    }
}
