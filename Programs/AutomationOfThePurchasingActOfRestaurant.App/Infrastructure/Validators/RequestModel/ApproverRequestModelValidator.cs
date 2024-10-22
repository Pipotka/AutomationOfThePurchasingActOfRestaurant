using Company.AutomationOfThePurchasingActOfRestaurant.Client;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.App.Infrastructure.Validators.RequestModel;

/// <summary>
/// Валидатор для <see cref="ApproverRequest"/>
/// </summary>
public class ApproverRequestValidator : AbstractValidator<ApproverRequest>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="ApproverRequest"/>
    /// </summary>
    public ApproverRequestValidator()
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
        RuleFor(x => x.SignatureDecryption)
            .NotEmpty()
            .WithMessage("Необходима расшифровка подписи")
            .Matches(@"^[A-ZА-Я]\.([A-ZА-Я]\.)? [A-ZА-Я][a-zа-я]*$")
            .WithMessage("Неправильная расшифровка подписи.\nПример расшифровки с отчеством: И.И. Иванов\nПример расшифровки без отчества: И. Иванов");
    }
}