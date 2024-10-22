using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Validators.BaseModelValidators;

/// <summary>
/// Валидатор для <see cref="OrganizationBaseModel"/>
/// </summary>
public class OrganizationBaseModelValidator : AbstractValidator<OrganizationBaseModel>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="OrganizationBaseModel"/>
    /// </summary>
    public OrganizationBaseModelValidator()
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
