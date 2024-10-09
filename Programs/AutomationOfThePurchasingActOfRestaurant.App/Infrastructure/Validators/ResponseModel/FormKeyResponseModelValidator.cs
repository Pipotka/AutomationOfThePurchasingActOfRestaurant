using FluentValidation;
using Company.AutomationOfThePurchasingActOfRestaurant.Client;

namespace Company.AutomationOfThePurchasingActOfRestaurant.App.Infrastructure.Validators.ResponceModel;

/// <summary>
/// Валидатор для <see cref="FormKeyResponseModel"/>
/// </summary>
public class FormKeyResponseModelValidator : AbstractValidator<FormKeyResponseModel>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="FormKeyResponseModel"/>
    /// </summary>
    public FormKeyResponseModelValidator()
    {
        RuleFor(x => x.Okud)
            .NotNull()
            .WithMessage("ОКУД не указан")
            .NotEmpty()
            .WithMessage("ОКУД не указан")
            .Length(8)
            .WithMessage($"Размер строки должен быть равен 8")
            .Matches(@"^\d+$")
            .WithMessage("В строке должны быть только цифры");
        RuleFor(x => x.Okpo)
            .NotNull()
            .WithMessage("ОКПО не указан")
            .NotEmpty()
            .WithMessage("ОКПО не указан")
            .Length(8)
            .WithMessage($"Размер строки должен быть равен 8")
            .Matches(@"^\d+$")
            .WithMessage("В строке должны быть только цифры");
        RuleFor(x => x.Tin)
            .NotNull()
            .WithMessage("ИНН не указан")
            .NotEmpty()
            .WithMessage("ИНН не указан")
            .Length(10)
            .WithMessage($"Размер строки должен быть равен 10")
            .Matches(@"^\d+$")
            .WithMessage("В строке должны быть только цифры");
        RuleFor(x => x.Okdp)
            .NotNull()
            .WithMessage("ОКДП не указан")
            .NotEmpty()
            .WithMessage("ОКДП не указан")
            .Matches(@"^\d+(\.\d+)*$")
            .WithMessage("Не соответсвует шаблону. первый символ - цифра, остальные символы - цифры или точки");
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Id сущности не указан");
    }
}
