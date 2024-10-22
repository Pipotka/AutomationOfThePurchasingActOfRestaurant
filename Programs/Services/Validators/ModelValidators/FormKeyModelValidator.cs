using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Validators.ModelValidators;

/// <summary>
/// Валидатор для <see cref="FormKeyModel"/>
/// </summary>
public class FormKeyModelValidator : AbstractValidator<FormKeyModel>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="FormKeyModel"/>
    /// </summary>
    public FormKeyModelValidator()
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
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Id сущности не указан");
    }
}
