using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.WriteRepositories;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.WriteRepositories;

/// <summary>
/// Репозиторий на запись закупочных актов
/// </summary>
public class PurchaseFormWriteRepository : BaseWriteRepository<PurchaseForm>, IPurchaseFormWriteRepository
{
    public PurchaseFormWriteRepository(IDbWriter writer)
        : base(writer)
    {

    }
}

