using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Exceptions;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Validators.BaseModelValidators;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Validators.ModelValidators;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.ModelServices;

/// <summary>
/// Сервис валидации
/// </summary>
public class PurchasingValidateService : IPurchasingValidateService
{
    private readonly IDictionary<Type, IValidator> validators;
    /// <summary>
    /// Конструктор <see cref="PurchasingValidateService"/>
    /// </summary>
    public PurchasingValidateService()
    {
        validators = new Dictionary<Type, IValidator>();

        validators.Add(typeof(ApproverBaseModel), new ApproverBaseModelValidator());
        validators.Add(typeof(EmployeeBaseModel), new EmployeeBaseModelValidator());
        validators.Add(typeof(EmployeePositionBaseModel), new EmployeePositionBaseModelValidator());
        validators.Add(typeof(FormKeyBaseModel), new FormKeyBaseModelValidator());
        validators.Add(typeof(MeasurementUnitBaseModel), new MeasurementUnitBaseModelValidator());
        validators.Add(typeof(MerchandiseBaseModel), new MerchandiseBaseModelValidator());
        validators.Add(typeof(OrganizationBaseModel), new OrganizationBaseModelValidator());
        validators.Add(typeof(PurchaseFormBaseModel), new PurchaseFormBaseModelValidator());
        validators.Add(typeof(SupplierBaseModel), new SupplierBaseModelValidator());

        validators.Add(typeof(ApproverModel), new ApproverModelValidator());
        validators.Add(typeof(EmployeeModel), new EmployeeModelValidator());
        validators.Add(typeof(EmployeePositionModel), new EmployeePositionModelValidator());
        validators.Add(typeof(FormKeyModel), new FormKeyModelValidator());
        validators.Add(typeof(MeasurementUnitModel), new MeasurementUnitModelValidator());
        validators.Add(typeof(MerchandiseModel), new MerchandiseModelValidator());
        validators.Add(typeof(OrganizationModel), new OrganizationModelValidator());
        validators.Add(typeof(PurchaseFormModel), new PurchaseFormModelValidator());
        validators.Add(typeof(SupplierModel), new SupplierModelValidator());
    }

    /// <summary>
    /// Валидация модели
    /// </summary>
    /// <typeparam name="TModel">Тип модели</typeparam>
    /// <param name="model">модель</param>
    public async Task ValidateAsync<TModel>(TModel model, CancellationToken token) where TModel : class
    {
        validators.TryGetValue(typeof(TModel), out var validator);

        if (validator == null)
        {
            throw new InvalidOperationException($"Валидатор для {model.GetType().Name} не найден");
        }

        var validationResult = await validator.ValidateAsync(new ValidationContext<TModel>(model), token);
        if (!validationResult.IsValid)
        {
            throw new PirchasingValidationExeption(string.Join(';', validationResult.Errors.Select(x => $"{x.PropertyName} - {x.ErrorMessage}")));
        }
    }
}
