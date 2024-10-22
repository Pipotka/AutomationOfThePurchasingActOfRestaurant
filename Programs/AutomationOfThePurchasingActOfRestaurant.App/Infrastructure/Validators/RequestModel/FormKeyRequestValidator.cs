using Company.AutomationOfThePurchasingActOfRestaurant.Client;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.App.Infrastructure.Validators.RequestModel;

/// <summary>
/// Валидатор для <see cref="FormKeyRequest"/>
/// </summary>
public class FormKeyRequestValidator : AbstractValidator<FormKeyRequest>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="FormKeyRequest"/>
    /// </summary>
    public FormKeyRequestValidator()
    {
        RuleFor(x => x.Okud)
            .NotEmpty()
            .WithMessage("ОКУД не указан")
            .Length(8)
            .WithMessage($"Размер строки должен быть равен 8")
            .Matches(@"^\d+$")
            .WithMessage("В строке должны быть только цифры");
        RuleFor(x => x.Okpo)
            .NotEmpty()
            .WithMessage("ОКПО не указан")
            .Length(8)
            .WithMessage($"Размер строки должен быть равен 8")
            .Matches(@"^\d+$")
            .WithMessage("В строке должны быть только цифры");
        RuleFor(x => x.Tin)
            .NotEmpty()
            .WithMessage("ИНН не указан")
            .Length(10)
            .WithMessage($"Размер строки должен быть равен 10")
            .Matches(@"^\d+$")
            .WithMessage("В строке должны быть только цифры");
        RuleFor(x => x.Okdp)
            .NotEmpty()
            .WithMessage("ОКДП не указан")
            .Matches(@"^\d+(\.\d+)*$")
            .WithMessage("Не соответсвует шаблону. первый символ - цифра, остальные символы - цифры или точки");
    }
}
