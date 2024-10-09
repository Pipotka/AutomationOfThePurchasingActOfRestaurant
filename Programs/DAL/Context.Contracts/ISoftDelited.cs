namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;

/// <summary>
/// Интерфейс мягкого удаления
/// </summary>
public interface ISoftDelited
{
    /// <summary>
    /// Дата удаления
    /// </summary>
    public DateTime DateOfDeletion { get; set; }
    /// <summary>
    /// Указывает на то, удалена ли сущность из БД. Если удалена то <c>True</c>, иначе <c>False</c>
    /// </summary>
    public bool IsDelited { get; set; }
}
