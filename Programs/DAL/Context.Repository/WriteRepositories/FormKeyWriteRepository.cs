using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.WriteRepositories;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.WriteRepositories;

/// <summary>
/// Репозиторий на запись кодов формы
/// </summary>
public class FormKeyWriteRepository : BaseWriteRepository<FormKey>, IFormKeyWriteRepository
{
    public FormKeyWriteRepository(IDbWriter writer)
        : base(writer)
    {

    }
}

