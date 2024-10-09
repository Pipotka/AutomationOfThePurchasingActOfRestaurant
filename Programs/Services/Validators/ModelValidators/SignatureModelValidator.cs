using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Validators.ModelValidators;

/// <summary>
/// Валидатор для <see cref="SignatureModel"/>
/// </summary>
public class SignatureModelValidator : AbstractValidator<SignatureModel>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="SignatureModel"/>
    /// </summary>
    public SignatureModelValidator()
    {
        RuleFor(x => x.Points)
            .NotNull()
            .WithMessage("Точки подписи не могут быть пустыми")
            .Must(points => points.Length > 0)
            .WithMessage("Необходимо указать хотя бы одну точку подписи");

        RuleFor(x => x.SignatureDecryption)
            .NotEmpty()
            .WithMessage("Необходима расшифровка подписи")
            .Matches(Signature.RegularExpressionForSignatureDecryption)
            .WithMessage("Неправильная расшифровка подписи");
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Id сущности не указан");
    }
}
