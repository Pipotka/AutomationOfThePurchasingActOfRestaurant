﻿using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.WriteRepositories;

/// <summary>
/// Интерфейс репозитория на запись утверждающих
/// </summary>
public interface IApproverWriteRepository : IWriteRepository<Approver>
{

}