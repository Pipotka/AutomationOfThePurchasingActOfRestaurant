using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.WriteRepositories;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.WriteRepositories;

/// <summary>
/// Репозиторий на запись утверждающих
/// </summary>
public class ApproverWriteRepository : BaseWriteRepository<Approver>, IApproverWriteRepository
{
    public ApproverWriteRepository(IDbWriter writer)
        : base(writer)
    {

    }
}