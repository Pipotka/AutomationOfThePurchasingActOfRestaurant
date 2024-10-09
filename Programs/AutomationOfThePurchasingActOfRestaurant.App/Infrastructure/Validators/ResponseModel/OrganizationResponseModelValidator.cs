using FluentValidation;
using Company.AutomationOfThePurchasingActOfRestaurant.Client;

namespace Company.AutomationOfThePurchasingActOfRestaurant.App.Infrastructure.Validators.ResponceModel;

/// <summary>
/// Валидатор для <see cref="OrganizationResponseModel"/>
/// </summary>
public class OrganizationResponseModelValidator : AbstractValidator<OrganizationResponseModel>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="OrganizationResponseModel"/>
    /// </summary>
    public OrganizationResponseModelValidator()
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
