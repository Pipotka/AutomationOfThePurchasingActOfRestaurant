
using System.Runtime.Serialization;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;

/// <summary>
/// Перечисление сортировок для закупочного акта
/// </summary>
public enum PurchaseFormSortBy
{
    [EnumMember(Value = "Id")]
    Id,
    [EnumMember(Value = "DateOfCreation")]
    DateOfCreation,
    [EnumMember(Value = "DateOfLastChange")]
    DateOfLastChange,
    [EnumMember(Value = "DocumentNumber")]
    DocumentNumber,
    [EnumMember(Value = "DocumentDate")]
    DocumentDate,
    [EnumMember(Value = "AddressOfPurchase")]
    AddressOfPurchase,
    [EnumMember(Value = "SponsorOrganizationName")]
    SponsorOrganizationName,
    [EnumMember(Value = "ApprovingOfficerName")]
    ApprovingOfficerName,
    [EnumMember(Value = "ProcurementSpecialistName")]
    ProcurementSpecialistName,
    [EnumMember(Value = "SalesmanName")]
    SalesmanName,
    [EnumMember(Value = "DateOfCreationDesc")]
    DateOfCreationDesc,
    [EnumMember(Value = "DateOfLastChangeDesc")]
    DateOfLastChangeDesc,
    [EnumMember(Value = "DocumentNumberDesc")]
    DocumentNumberDesc,
    [EnumMember(Value = "DocumentDateDesc")]
    DocumentDateDesc,
    [EnumMember(Value = "AddressOfPurchaseDesc")]
    AddressOfPurchaseDesc,
    [EnumMember(Value = "SponsorOrganizationNameDesc")]
    SponsorOrganizationNameDesc,
    [EnumMember(Value = "ApprovingOfficerNameDesc")]
    ApprovingOfficerNameDesc,
    [EnumMember(Value = "ProcurementSpecialistNameDesc")]
    ProcurementSpecialistNameDesc,
    [EnumMember(Value = "SalesmanNameDesc")]
    SalesmanNameDesc
}
