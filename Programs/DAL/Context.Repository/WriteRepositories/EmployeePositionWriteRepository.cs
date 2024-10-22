using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.WriteRepositories;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.WriteRepositories;

/// <summary>
/// Репозиторий на запись должностей сотрудников
/// </summary>
public class EmployeePositionWriteRepository : BaseWriteRepository<EmployeePosition>, IEmployeePositionWriteRepository
{
    public EmployeePositionWriteRepository(IDbWriter writer)
        : base(writer)
    {

    }
}

