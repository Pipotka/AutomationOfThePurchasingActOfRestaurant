using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Validators.ModelValidators;

/// <summary>
/// Валидатор для <see cref="ApproverModel"/>
/// </summary>
public class ApproverModelValidator : AbstractValidator<ApproverModel>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="ApproverModel"/>
    /// </summary>
    public ApproverModelValidator()
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
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Id сущности не указан");
    }
}