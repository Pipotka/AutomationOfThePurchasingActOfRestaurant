﻿using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using FluentValidation;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Validators.ModelValidators;

/// <summary>
/// Валидатор для <see cref="PurchaseFormModel"/>
/// </summary>
public class PurchaseFormModelValidator : AbstractValidator<PurchaseFormModel>
{
    /// <summary>
    /// Создает экземпляр валидатора для <see cref="PurchaseFormModel"/>
    /// </summary>
    public PurchaseFormModelValidator()
    {
        RuleFor(x => x.FormKeyId)
            .NotEqual(Guid.Empty)
            .WithMessage("Код формы не указан");

        RuleFor(x => x.SponsorOrganizationId)
            .NotEqual(Guid.Empty)
            .WithMessage("Организация-закзчик не указана");

        RuleFor(x => x.ApprovingOfficerId)
            .NotEqual(Guid.Empty)
            .WithMessage("Утверждающее должностное лицо не указано");

        RuleFor(x => x.DocumentNumber)
            .GreaterThan(0)
            .WithMessage("Номер документа должен быть положительным");

        RuleFor(x => x.DocumentDate)
            .NotEmpty()
            .WithMessage("Дата составления документа не указана");

        RuleFor(x => x.AddressOfPurchase)
            .NotEmpty()
            .WithMessage("Место закупки не указано");

        RuleFor(x => x.ProcurementSpecialistId)
            .NotEqual(Guid.Empty)
            .WithMessage("Специалист по закупкам не указан");

        RuleFor(x => x.SalesmanId)
            .NotEqual(Guid.Empty)
            .WithMessage("Поставщик не указан");

        RuleFor(x => x.PurchasedMerchandises)
            .NotEmpty()
            .WithMessage("Закупленные товары не указаны");

        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Id сущности не указан");
    }
}