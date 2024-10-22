using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.WriteRepositories;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.WriteRepositories;

/// <summary>
/// Репозиторий на запись организаций
/// </summary>
public class OrganizationWriteRepository : BaseWriteRepository<Organization>, IOrganizationWriteRepository
{
    public OrganizationWriteRepository(IDbWriter writer)
        : base(writer)
    {

    }
}

