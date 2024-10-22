using AutoMapper;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.AutoMapper;

/// <summary>
/// Конфигурация AutoMapper
/// </summary>
public class PurchasingProfile : Profile
{
    /// <summary>
    /// Конструктор <see cref="PurchasingProfile"/>
    /// </summary>
    public PurchasingProfile()
    {
        CreateMap<Approver, ApproverModel>(MemberList.Destination);
        CreateMap<Employee, EmployeeModel>(MemberList.Destination);
        CreateMap<EmployeePosition, EmployeePositionModel>(MemberList.Destination);
        CreateMap<FormKey, FormKeyModel>(MemberList.Destination);
        CreateMap<MeasurementUnit, MeasurementUnitModel>(MemberList.Destination);
        CreateMap<Merchandise, MerchandiseModel>(MemberList.Destination);
        CreateMap<Organization, OrganizationModel>(MemberList.Destination);
        CreateMap<PurchaseForm, PurchaseFormModel>(MemberList.Destination);
        CreateMap<Supplier, SupplierModel>(MemberList.Destination);

        CreateMap<ApproverBaseModel, Approver>(MemberList.Destination);
        CreateMap<EmployeeBaseModel, Employee>(MemberList.Destination);
        CreateMap<EmployeePositionBaseModel, EmployeePosition>(MemberList.Destination);
        CreateMap<FormKeyBaseModel, FormKey>(MemberList.Destination);
        CreateMap<MeasurementUnitBaseModel, MeasurementUnit>(MemberList.Destination);
        CreateMap<MerchandiseBaseModel, Merchandise>(MemberList.Destination);
        CreateMap<OrganizationBaseModel, Organization>(MemberList.Destination);
        CreateMap<PurchaseFormBaseModel, PurchaseForm>(MemberList.Destination);
        CreateMap<SupplierBaseModel, Supplier>(MemberList.Destination);


        CreateMap<ApproverModel, Approver>(MemberList.Destination)
            .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.FirstName.Trim()))
            .ForMember(x => x.LastName, opt => opt.MapFrom(x => x.LastName.Trim()))
            .ForMember(x => x.Patronymic, opt => opt.MapFrom(x => x.Patronymic != null ? x.Patronymic.Trim() : null));

        CreateMap<EmployeeModel, Employee>(MemberList.Destination)
            .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.FirstName.Trim()))
            .ForMember(x => x.LastName, opt => opt.MapFrom(x => x.LastName.Trim()))
            .ForMember(x => x.Patronymic, opt => opt.MapFrom(x => x.Patronymic != null ? x.Patronymic.Trim() : null));

        CreateMap<EmployeePositionModel, EmployeePosition>(MemberList.Destination)
            .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name.Trim()));

        CreateMap<FormKeyModel, FormKey>(MemberList.Destination)
            .ForMember(x => x.OKPO, opt => opt.MapFrom(x => x.OKPO.Trim()))
            .ForMember(x => x.OKDP, opt => opt.MapFrom(x => x.OKDP.Trim()))
            .ForMember(x => x.TIN, opt => opt.MapFrom(x => x.TIN.Trim()))
            .ForMember(x => x.OKUD, opt => opt.MapFrom(x => x.OKUD.Trim()));

        CreateMap<MeasurementUnitModel, MeasurementUnit>(MemberList.Destination)
            .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name.Trim()));

        CreateMap<MerchandiseModel, Merchandise>(MemberList.Destination)
            .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name.Trim()));

        CreateMap<OrganizationModel, Organization>(MemberList.Destination)
            .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name.Trim()));

        CreateMap<PurchaseFormModel, PurchaseForm>(MemberList.Destination);

        CreateMap<SupplierModel, Supplier>(MemberList.Destination)
            .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.FirstName.Trim()))
            .ForMember(x => x.LastName, opt => opt.MapFrom(x => x.LastName.Trim()))
            .ForMember(x => x.Patronymic, opt => opt.MapFrom(x => x.Patronymic != null ? x.Patronymic.Trim() : null));
    }
}
