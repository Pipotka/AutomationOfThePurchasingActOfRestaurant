
using System.Runtime.Serialization;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;

/// <summary>
/// Перечисление сортировок для кодов формы
/// </summary>
public enum FormKeySortBy
{
    [EnumMember(Value = "Id")]
    Id,
    [EnumMember(Value = "DateOfCreation")]
    DateOfCreation,
    [EnumMember(Value = "DateOfLastChange")]
    DateOfLastChange,
    [EnumMember(Value = "OKUD")]
    OKUD,
    [EnumMember(Value = "OKPO")]
    OKPO,
    [EnumMember(Value = "TIN")]
    TIN,
    [EnumMember(Value = "OKDP")]
    OKDP,
    [EnumMember(Value = "DateOfCreationDesc")]
    DateOfCreationDesc,
    [EnumMember(Value = "DateOfLastChangeDesc")]
    DateOfLastChangeDesc,
    [EnumMember(Value = "OKUDDesc")]
    OKUDDesc,
    [EnumMember(Value = "OKPODesc")]
    OKPODesc,
    [EnumMember(Value = "TINDesc")]
    TINDesc,
    [EnumMember(Value = "OKDPDesc")]
    OKDPDesc
}
