using Company.AutomationOfThePurchasingActOfRestaurant.Client;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.App.Infrastructure.Validators.RequestModel;

/// <summary>
/// Валидатор для <see cref="SignatureRequest"/>
/// </summary>
public class SignatureRequestValidator : AbstractValidator<SignatureRequest>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="SignatureRequest"/>
    /// </summary>
    public SignatureRequestValidator()
    {
        RuleFor(x => x.Points)
            .NotNull()
            .WithMessage("Точки подписи не могут быть пустыми")
            .Must(points => points.Count > 0)
            .WithMessage("Необходимо указать хотя бы одну точку подписи");

        RuleFor(x => x.SignatureDecryption)
            .NotEmpty()
            .WithMessage("Необходима расшифровка подписи")
            .Matches(@"^[A-ZА-Я]\\.?([A-ZА-Я]\\.)? [A-ZА-Я][a-zа-я]*$")
            .WithMessage("Неправильная расшифровка подписи.\nПример расшифровки с отчеством: И.И. Иванов\nПример расшифровки без отчества: И. Иванов");
    }
}
