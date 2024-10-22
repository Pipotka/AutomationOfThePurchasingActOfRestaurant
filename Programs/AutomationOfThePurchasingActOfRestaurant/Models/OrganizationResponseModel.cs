
using Company.AutomationOfThePurchasingActOfRestaurant.Models.CreateModelRequest;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Models;

/// <summary>
/// Модель ответа по организации для API
/// </summary>
public class OrganizationResponseModel
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// <inheritdoc cref="OrganizationRequest.Name" path="/summary"/>
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// <inheritdoc cref="OrganizationRequest.Address" path="/summary"/>
    /// </summary>
    public string Address { get; set; }
    /// <summary>
    /// <inheritdoc cref="OrganizationRequest.StructuralUnit" path="/summary"/>
    /// </summary>
    public string StructuralUnit { get; set; }
}
