using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Validators.BaseModelValidators;

/// <summary>
/// Валидатор для <see cref="EmployeeBaseModel"/>
/// </summary>
public class EmployeeBaseModelValidator : AbstractValidator<EmployeeBaseModel>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="EmployeeBaseModel"/>
    /// </summary>
    public EmployeeBaseModelValidator()
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
        RuleFor(x => x.PositionId)
            .NotEqual(Guid.Empty)
            .WithMessage("Должность не указана");
    }
}
