using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.WriteRepositories;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.WriteRepositories;

/// <summary>
/// Репозиторий на запись подписей
/// </summary>
public class SignatureWriteRepository : BaseWriteRepository<Signature>, ISignatureWriteRepository
{
    public SignatureWriteRepository(IDbWriter writer)
        : base(writer)
    {

    }
}

