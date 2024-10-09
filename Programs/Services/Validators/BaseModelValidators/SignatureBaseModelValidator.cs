using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Validators.BaseModelValidators;

/// <summary>
/// Валидатор для <see cref="SignatureBaseModel"/>
/// </summary>
public class SignatureBaseModelValidator : AbstractValidator<SignatureBaseModel>
{
    /// <summary>
    /// Валидатор для <see cref="SignatureBaseModel"/>
    /// </summary>
    public SignatureBaseModelValidator()
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
    }
}
