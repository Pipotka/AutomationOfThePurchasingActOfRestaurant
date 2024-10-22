using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.WriteRepositories;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.WriteRepositories;

/// <summary>
/// Репозиторий на запись продуктов
/// </summary>
public class MerchandiseWriteRepository : BaseWriteRepository<Merchandise>, IMerchandiseWriteRepository
{
    public MerchandiseWriteRepository(IDbWriter writer)
        : base(writer)
    {

    }
}

