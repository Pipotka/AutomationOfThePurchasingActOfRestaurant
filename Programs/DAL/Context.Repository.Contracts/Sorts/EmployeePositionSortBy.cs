
using System.Runtime.Serialization;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;

/// <summary>
/// перечисление сортировки должности сотрудника
/// </summary>
public enum EmployeePositionSortBy
{
    [EnumMember(Value = "Id")]
    Id,
    [EnumMember(Value = "DateOfCreation")]
    DateOfCreation,
    [EnumMember(Value = "DateOfLastChange")]
    DateOfLastChange,
    [EnumMember(Value = "Name")]
    Name,
    [EnumMember(Value = "DateOfCreationDesc")]
    DateOfCreationDesc,
    [EnumMember(Value = "DateOfLastChangeDesc")]
    DateOfLastChangeDesc,
    [EnumMember(Value = "NameDesc")]
    NameDesc,
}
