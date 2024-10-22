using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Validators.BaseModelValidators;

/// <summary>
/// Валидатор для <see cref="ApproverBaseModel"/>
/// </summary>
public class ApproverBaseModelValidator : AbstractValidator<ApproverBaseModel>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="ApproverBaseModel"/>
    /// </summary>
    public ApproverBaseModelValidator()
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
        RuleFor(x => x.SignatureDecryption)
            .NotEmpty()
            .WithMessage("Необходима расшифровка подписи")
            .Matches(Approver.RegularExpressionForSignatureDecryption)
            .WithMessage("Неправильная расшифровка подписи");
    }
}