using AutoMapper;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Models.CreateModelRequest;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Extensions;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Extentoins;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Infrastructure.AutoMapper;

/// <summary>
/// Конфигурация AutoMapper для API
/// </summary>
public class PurchasingApiProfile : Profile
{
    /// <summary>
    /// Конструктор <see cref="PurchasingApiProfile"/>
    /// </summary>
    public PurchasingApiProfile()
    {
        CreateMap<ApproverRequest, ApproverBaseModel>(MemberList.Destination);
        CreateMap<EmployeeRequest, EmployeeBaseModel>(MemberList.Destination);
        CreateMap<EmployeePositionRequest, EmployeePositionBaseModel>(MemberList.Destination);
        CreateMap<FormKeyRequest, FormKeyBaseModel>(MemberList.Destination);
        CreateMap<MeasurementUnitRequest, MeasurementUnitBaseModel>(MemberList.Destination);
        CreateMap<MerchandiseRequest, MerchandiseBaseModel>(MemberList.Destination);
        CreateMap<OrganizationRequest, OrganizationBaseModel>(MemberList.Destination);
        CreateMap<PurchaseFormRequest, PurchaseFormBaseModel>(MemberList.Destination);
        CreateMap<SupplierRequest, SupplierBaseModel>(MemberList.Destination);

        CreateMap<ApproverRequest, ApproverModel>(MemberList.Destination)
            .ForMember(x => x.Id, opt => opt.Ignore());
        CreateMap<EmployeeRequest, EmployeeModel>(MemberList.Destination)
            .ForMember(x => x.Id, opt => opt.Ignore());
        CreateMap<EmployeePositionRequest, EmployeePositionModel>()
            .ForMember(x => x.Id, opt => opt.Ignore());
        CreateMap<FormKeyRequest, FormKeyModel>(MemberList.Destination)
            .ForMember(x => x.Id, opt => opt.Ignore());
        CreateMap<MeasurementUnitRequest, MeasurementUnitModel>(MemberList.Destination)
            .ForMember(x => x.Id, opt => opt.Ignore());
        CreateMap<MerchandiseRequest, MerchandiseModel>(MemberList.Destination)
            .ForMember(x => x.Id, opt => opt.Ignore());
        CreateMap<OrganizationRequest, OrganizationModel>(MemberList.Destination)
            .ForMember(x => x.Id, opt => opt.Ignore());
        CreateMap<PurchaseFormRequest, PurchaseFormModel>(MemberList.Destination)
            .ForMember(x => x.Id, opt => opt.Ignore());
        CreateMap<SupplierRequest, SupplierModel>(MemberList.Destination)
            .ForMember(x => x.Id, opt => opt.Ignore());

        CreateMap<MeasurementUnitResponseModel, MeasurementUnitBaseModel>(MemberList.Destination);
        CreateMap<EmployeePositionResponseModel, EmployeePositionBaseModel>(MemberList.Destination);

        CreateMap<ApproverModel, ApproverResponseModel>(MemberList.Destination);
        CreateMap<EmployeeModel, EmployeeResponseModel>(MemberList.Destination);
        CreateMap<EmployeePositionModel, EmployeePositionResponseModel>(MemberList.Destination);
        CreateMap<FormKeyModel, FormKeyResponseModel>(MemberList.Destination);
        CreateMap<MeasurementUnitModel, MeasurementUnitResponseModel>(MemberList.Destination);
        CreateMap<MerchandiseModel, MerchandiseResponseModel>(MemberList.Destination);
        CreateMap<OrganizationModel, OrganizationResponseModel>(MemberList.Destination);
        CreateMap<PurchaseFormModel, PurchaseFormResponseModel>(MemberList.Destination)
            .ForMember(x => x.TotalCost, opt => opt.MapFrom(x => x.GetTotalCost()));
        CreateMap<SupplierModel, SupplierResponseModel>(MemberList.Destination);

        CreateMap<ApproverResponseModel, ApproverModel>(MemberList.Destination);
        CreateMap<EmployeeResponseModel, EmployeeModel>(MemberList.Destination);
        CreateMap<EmployeePositionResponseModel, EmployeePositionModel>(MemberList.Destination);
        CreateMap<FormKeyResponseModel, FormKeyModel>(MemberList.Destination);
        CreateMap<MeasurementUnitResponseModel, MeasurementUnitModel>(MemberList.Destination);
        CreateMap<MerchandiseResponseModel, MerchandiseModel>(MemberList.Destination);
        CreateMap<OrganizationResponseModel, OrganizationModel>(MemberList.Destination);
        CreateMap<PurchaseFormResponseModel, PurchaseFormModel>(MemberList.Destination);
        CreateMap<SupplierResponseModel, SupplierModel>(MemberList.Destination);


        CreateMap<ApproverBaseModel, Approver>(MemberList.Destination)
            .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.FirstName.Trim()))
            .ForMember(x => x.LastName, opt => opt.MapFrom(x => x.LastName.Trim()))
            .ForMember(x => x.Patronymic, opt => opt.MapFrom(x => x.Patronymic != null ? x.Patronymic.Trim() : null));
    }
}
