using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.WriteRepositories;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.WriteRepositories;

/// <summary>
/// Репозиторий на запись поставщиков
/// </summary>
public class SupplierWriteRepository : BaseWriteRepository<Supplier>, ISupplierWriteRepository
{
    public SupplierWriteRepository(IDbWriter writer)
        : base(writer)
    {

    }
}

