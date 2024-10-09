﻿using Company.AutomationOfThePurchasingActOfRestaurant.Models.CreateModelRequest;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Models;

/// <summary>
/// Модель ответа по должности сотрудника для API
/// </summary>
public class EmployeePositionResponseModel
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// <inheritdoc cref="EmployeePositionRequest.Approvers" path="/summary"/>
    /// </summary>
    public ICollection<ApproverResponseModel> Approvers { get; set; } = new List<ApproverResponseModel>();
    /// <summary>
    /// <inheritdoc cref="EmployeePositionRequest.Employees" path="/summary"/>
    /// </summary>
    public ICollection<EmployeeResponseModel> Employees { get; set; } = new List<EmployeeResponseModel>();
    /// <summary>
    /// <inheritdoc cref="EmployeePositionRequest.Name" path="/summary"/>
    /// </summary>
    public string Name { get; set; }
}
