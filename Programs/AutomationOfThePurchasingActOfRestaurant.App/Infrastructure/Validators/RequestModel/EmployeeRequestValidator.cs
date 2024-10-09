using Company.AutomationOfThePurchasingActOfRestaurant.Client;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.App.Infrastructure.Validators.RequestModel;

/// <summary>
/// Валидатор для <see cref="EmployeeRequest"/>
/// </summary>
public class EmployeeRequestValidator : AbstractValidator<EmployeeRequest>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="EmployeeRequest"/>
    /// </summary>
    public EmployeeRequestValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("Имя не указано");
        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Фамилия не указана");
        RuleFor(x => x.PositionId)
            .NotEqual(Guid.Empty)
            .WithMessage("Должность не указана");
    }
}
