
using System.Runtime.Serialization;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;

/// <summary>
/// Перечисление сортировок для организации
/// </summary>
public enum OrganizationSortBy
{
    [EnumMember(Value = "Id")]
    Id,
    [EnumMember(Value = "DateOfCreation")]
    DateOfCreation,
    [EnumMember(Value = "DateOfLastChange")]
    DateOfLastChange,
    [EnumMember(Value = "Name")]
    Name,
    [EnumMember(Value = "Address")]
    Address,
    [EnumMember(Value = "StructuralUnit")]
    StructuralUnit,
    [EnumMember(Value = "DateOfCreationDesc")]
    DateOfCreationDesc,
    [EnumMember(Value = "DateOfLastChangeDesc")]
    DateOfLastChangeDesc,
    [EnumMember(Value = "NameDesc")]
    NameDesc,
    [EnumMember(Value = "AddressDesc")]
    AddressDesc,
    [EnumMember(Value = "StructuralUnitDesc")]
    StructuralUnitDesc
}
