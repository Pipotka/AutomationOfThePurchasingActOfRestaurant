﻿
using System.Runtime.Serialization;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;

/// <summary>
/// перечисление сортировки утверждающего
/// </summary>
public enum ApproverSortBy
{
    [EnumMember(Value = "Id")]
    Id,
    [EnumMember(Value = "DateOfCreation")]
    DateOfCreation,
    [EnumMember(Value = "DateOfLastChange")]
    DateOfLastChange,
    [EnumMember(Value = "FirstName")]
    FirstName,
    [EnumMember(Value = "LastName")]
    LastName,
    [EnumMember(Value = "Patronymic")]
    Patronymic,
    [EnumMember(Value = "DateOfCreationDesc")]
    DateOfCreationDesc,
    [EnumMember(Value = "DateOfLastChangeDesc")]
    DateOfLastChangeDesc,
    [EnumMember(Value = "FirstNameDesc")]
    FirstNameDesc,
    [EnumMember(Value = "LastNameDesc")]
    LastNameDesc,
    [EnumMember(Value = "PatronymicDesc")]
    PatronymicDesc,
}