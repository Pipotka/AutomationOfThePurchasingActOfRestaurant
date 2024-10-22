using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Validators.BaseModelValidators;

/// <summary>
/// Валидатор для <see cref="MerchandiseBaseModel"/>
/// </summary>
public class MerchandiseBaseModelValidator : AbstractValidator<MerchandiseBaseModel>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="MerchandiseBaseModel"/>
    /// </summary>
    public MerchandiseBaseModelValidator()
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

        RuleFor(x => x.Price)
            .NotNull()
            .WithMessage("Цена не указана");
    }
}
