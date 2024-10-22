using Company.AutomationOfThePurchasingActOfRestaurant.Client;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.App.Infrastructure.Validators.RequestModel;

/// <summary>
/// Валидатор для <see cref="OrganizationRequest"/>
/// </summary>
public class OrganizationRequestValidator : AbstractValidator<OrganizationRequest>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="OrganizationRequest"/>
    /// </summary>
    public OrganizationRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Название не указано");

        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage("Адрес организации не указан");

        RuleFor(x => x.StructuralUnit)
            .NotEmpty()
            .WithMessage("Структурное подразделение не указано");
    }
}
