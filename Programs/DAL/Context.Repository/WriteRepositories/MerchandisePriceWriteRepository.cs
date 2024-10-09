using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.WriteRepositories;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.WriteRepositories;

/// <summary>
/// Репозиторий на запись цен продуктов
/// </summary>
public class MerchandisePriceWriteRepository : BaseWriteRepository<MerchandisePrice>, IMerchandisePriceWriteRepository
{
    public MerchandisePriceWriteRepository(IDbWriter writer)
        : base(writer)
    {

    }
}

