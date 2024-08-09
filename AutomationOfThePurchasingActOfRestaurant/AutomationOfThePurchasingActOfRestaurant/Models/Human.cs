namespace AutomationOfThePurchasingActOfRestaurant.Models
{
    /// <summary>
    /// Человек
    /// </summary>
    public class Human
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName;
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName;
        /// <summary>
        /// Отчество
        /// </summary>
        public string? Patronymic;

        /// <summary>
        /// Конструктор <see cref="Human"/>
        /// </summary>
        /// <param name="firstName">
        /// <inheritdoc cref="FirstName" path="/summary"/>
        /// </param>
        /// <param name="lastName">
        /// <inheritdoc cref="LastName" path="/summary"/>
        /// </param>
        /// <param name="patronymic">
        /// <inheritdoc cref="Patronymic" path="/summary"/>
        /// </param>
        public Human(string firstName, string lastName,
            string? patronymic = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
        }
    }
}
