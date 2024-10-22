using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.WriteRepositories;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.WriteRepositories;

/// <summary>
/// Репозиторий на запись сотрудников
/// </summary>
public class EmployeeWriteRepository : BaseWriteRepository<Employee>, IEmployeeWriteRepository
{
    public EmployeeWriteRepository(IDbWriter writer)
        : base(writer)
    {

    }
}

