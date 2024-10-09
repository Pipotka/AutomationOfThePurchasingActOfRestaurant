
namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Exceptions;

/// <summary>
/// Ошибка валидации
/// </summary>
public class PirchasingValidationExeption : EntityServiceException
{
    public PirchasingValidationExeption(string message)
        : base(message)
    {
        
    }
}
