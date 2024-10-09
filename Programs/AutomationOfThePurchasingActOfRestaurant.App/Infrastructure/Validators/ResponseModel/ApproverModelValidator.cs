using FluentValidation;
using Company.AutomationOfThePurchasingActOfRestaurant.Client;

namespace Company.AutomationOfThePurchasingActOfRestaurant.App.Infrastructure.Validators.ResponceModel;

/// <summary>
/// Валидатор для <see cref="ApproverResponseModel"/>
/// </summary>
public class ApproverResponseModelValidator : AbstractValidator<ApproverResponseModel>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="ApproverResponseModel"/>
    /// </summary>
    public ApproverResponseModelValidator()
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
        RuleFor(x => x.SignatureId)
            .NotEqual(Guid.Empty)
            .WithMessage("Подпись не указана");
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Id сущности не указан");
    }
}