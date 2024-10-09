using Company.AutomationOfThePurchasingActOfRestaurant.Client;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.App.Infrastructure.Validators.RequestModel;

/// <summary>
/// Валидатор для <see cref="EmployeePositionRequest"/>
/// </summary>
public class EmployeePositionRequestValidator : AbstractValidator<EmployeePositionRequest>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="EmployeePositionRequest"/>
    /// </summary>
    public EmployeePositionRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Название должности не указанно");
    }
}
