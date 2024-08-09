namespace AutomationOfThePurchasingActOfRestaurant.Models
{
    /// <summary>
    /// Организация
    /// </summary>
    public class Organization
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name;
        /// <summary>
        /// Адрес организации
        /// </summary>
        public string Address;
        /// <summary>
        /// Структурное подразделение
        /// </summary>
        public string StructuralUnit;

        /// <summary>
        /// Конструктор <see cref="Organization"/>
        /// </summary>
        /// <param name="name">
        /// <inheritdoc cref="Name" path="/summary"/>
        /// </param>
        /// <param name="address">
        /// <inheritdoc cref="Address" path="/summary"/>
        /// </param>
        /// <param name="structuralUnit">
        /// <inheritdoc cref="StructuralUnit" path="/summary"/>
        /// </param>
        public Organization(string name, string address, string structuralUnit)
        {
            Name = name;
            Address = address;
            StructuralUnit = structuralUnit;
        }
    }
}
