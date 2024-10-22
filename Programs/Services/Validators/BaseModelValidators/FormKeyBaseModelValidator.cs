using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Validators.BaseModelValidators;

/// <summary>
/// Валидатор для <see cref="FormKeyBaseModel"/>
/// </summary>
public class FormKeyBaseModelValidator : AbstractValidator<FormKeyBaseModel>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="FormKeyBaseModel"/>
    /// </summary>
    public FormKeyBaseModelValidator()
    {
        RuleFor(x => x.OKUD)
            .NotNull()
            .WithMessage("ОКУД не указан")
            .NotEmpty()
            .WithMessage("ОКУД не указан")
            .Length(FormKey.lengthOfTheOKUD)
            .WithMessage($"Размер строки должен быть равен {FormKey.lengthOfTheOKUD}")
            .Matches(FormKey.RegularExpressionForOKUD)
            .WithMessage("В строке должны быть только цифры");
        RuleFor(x => x.OKPO)
            .NotNull()
            .WithMessage("ОКПО не указан")
            .NotEmpty()
            .WithMessage("ОКПО не указан")
            .Length(FormKey.lengthOfTheOKPO)
            .WithMessage($"Размер строки должен быть равен {FormKey.lengthOfTheOKPO}")
            .Matches(FormKey.RegularExpressionForOKPO)
            .WithMessage("В строке должны быть только цифры");
        RuleFor(x => x.TIN)
            .NotNull()
            .WithMessage("ИНН не указан")
            .NotEmpty()
            .WithMessage("ИНН не указан")
            .Length(FormKey.lengthOfTheTIN)
            .WithMessage($"Размер строки должен быть равен {FormKey.lengthOfTheTIN}")
            .Matches(FormKey.RegularExpressionForTIN)
            .WithMessage("В строке должны быть только цифры");
        RuleFor(x => x.OKDP)
            .NotNull()
            .WithMessage("ОКДП не указан")
            .NotEmpty()
            .WithMessage("ОКДП не указан")
            .Matches(FormKey.RegularExpressionForOKDP)
            .WithMessage("Не соответсвует шаблону. первый символ - цифра, остальные символы - цифры или точки");

    }
}
