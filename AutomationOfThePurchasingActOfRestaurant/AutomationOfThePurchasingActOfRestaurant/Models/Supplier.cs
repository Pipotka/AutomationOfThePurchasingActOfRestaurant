using System.ComponentModel.DataAnnotations;

namespace AutomationOfThePurchasingActOfRestaurant.Models
{
    /// <summary>
    /// Поставщик
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid SupplierId { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Имя
        /// </summary>
        [Required(ErrorMessage = "Имя не указано")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        [Required(ErrorMessage = "Фамилия не указана")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        [Display(Name = "Отчество")]
        public string? Patronymic { get; set; }

        /// <summary>
        /// Пустой конструктор <see cref="Supplier"/>
        /// </summary>
        public Supplier() { }
        /// <summary>
        /// Конструктор <see cref="Supplier"/>
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
        public Supplier(string firstName, string lastName,
            string? patronymic = null)
        {
            patronymic ??= string.Empty;

            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
        }
    }
}
