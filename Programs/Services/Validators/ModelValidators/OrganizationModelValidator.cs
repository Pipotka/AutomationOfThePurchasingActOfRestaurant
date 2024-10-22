using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Validators.ModelValidators;

/// <summary>
/// Валидатор для <see cref="OrganizationModel"/>
/// </summary>
public class OrganizationModelValidator : AbstractValidator<OrganizationModel>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="OrganizationModel"/>
    /// </summary>
    public OrganizationModelValidator()
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
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Id сущности не указан");
    }
}
