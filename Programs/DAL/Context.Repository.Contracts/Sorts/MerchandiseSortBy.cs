
using System.Runtime.Serialization;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;

/// <summary>
/// Перечисление сортировок для товара
/// </summary>
public enum MerchandiseSortBy
{
    [EnumMember(Value = "Id")]
    Id,
    [EnumMember(Value = "DateOfCreation")]
    DateOfCreation,
    [EnumMember(Value = "DateOfLastChange")]
    DateOfLastChange,
    [EnumMember(Value = "Name")]
    Name,
    [EnumMember(Value = "MerchandiseKey")]
    MerchandiseKey,
    [EnumMember(Value = "Count")]
    Count,
    [EnumMember(Value = "DateOfCreationDesc")]
    DateOfCreationDesc,
    [EnumMember(Value = "DateOfLastChangeDesc")]
    DateOfLastChangeDesc,
    [EnumMember(Value = "NameDesc")]
    NameDesc,
    [EnumMember(Value = "MerchandiseKeyDesc")]
    MerchandiseKeyDesc,
    [EnumMember(Value = "CountDesc")]
    CountDesc
}
