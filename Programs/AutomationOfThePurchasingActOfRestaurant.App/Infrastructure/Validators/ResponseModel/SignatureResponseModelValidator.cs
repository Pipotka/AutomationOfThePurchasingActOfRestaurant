using FluentValidation;
using Company.AutomationOfThePurchasingActOfRestaurant.Client;

namespace Company.AutomationOfThePurchasingActOfRestaurant.App.Infrastructure.Validators.ResponceModel;

/// <summary>
/// Валидатор для <see cref="SignatureResponseModel"/>
/// </summary>
public class SignatureResponseModelValidator : AbstractValidator<SignatureResponseModel>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="SignatureResponseModel"/>
    /// </summary>
    public SignatureResponseModelValidator()
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
            .WithMessage("Неправильная расшифровка подписи");
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Id сущности не указан");
    }
}
