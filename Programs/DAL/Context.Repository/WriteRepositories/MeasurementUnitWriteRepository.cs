using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.WriteRepositories;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.WriteRepositories;

/// <summary>
/// Репозиторий на запись единиц измерения
/// </summary>
public class MeasurementUnitWriteRepository : BaseWriteRepository<MeasurementUnit>, IMeasurementUnitWriteRepository
{
    public MeasurementUnitWriteRepository(IDbWriter writer)
        : base(writer)
    {

    }
}

