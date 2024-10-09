using FluentValidation;
using Company.AutomationOfThePurchasingActOfRestaurant.Client;

namespace Company.AutomationOfThePurchasingActOfRestaurant.App.Infrastructure.Validators.ResponceModel;

/// <summary>
/// Валидатор для <see cref="MerchandiseResponseModel"/>
/// </summary>
public class MerchandiseResponseModelValidator : AbstractValidator<MerchandiseResponseModel>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="MerchandiseResponseModel"/>
    /// </summary>
    public MerchandiseResponseModelValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("Наименование и характеристика товара не указаны")
            .NotEmpty()
            .WithMessage("Наименование и характеристика товара не указаны");

        RuleFor(x => x.MerchandiseKey)
            .GreaterThan(0)
            .WithMessage("Код товара должен быть больше 0");

        RuleFor(x => x.MeasurementUnitId)
            .NotEqual(Guid.Empty)
            .WithMessage("Единица измерения не указана");

        RuleFor(x => x.Count)
            .GreaterThan(0)
            .WithMessage("Количество товара должно быть больше 0");
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Id сущности не указан");
    }
}
