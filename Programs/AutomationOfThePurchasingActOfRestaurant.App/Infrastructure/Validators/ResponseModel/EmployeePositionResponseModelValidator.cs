using FluentValidation;
using Company.AutomationOfThePurchasingActOfRestaurant.Client;

namespace Company.AutomationOfThePurchasingActOfRestaurant.App.Infrastructure.Validators.ResponceModel;

/// <summary>
/// Валидатор для <see cref="EmployeePositionResponseModel"/>
/// </summary>
public class EmployeePositionResponseModelValidator : AbstractValidator<EmployeePositionResponseModel>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="EmployeePositionResponseModel"/>
    /// </summary>
    public EmployeePositionResponseModelValidator()
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
