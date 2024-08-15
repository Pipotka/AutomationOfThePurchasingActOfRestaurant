using System.ComponentModel.DataAnnotations;

namespace AutomationOfThePurchasingActOfRestaurant.Models
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid EmployeeId { get; set; } = Guid.NewGuid();
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
        /// Должность
        /// </summary>
        [Required(ErrorMessage = "Должность не указана")]
        [Display(Name = "Должность")]
        public EmployeePosition Position { get; set; }

        /// <summary>
        /// Пустой конструктор <see cref="Employee"/>
        /// </summary>
        public Employee() { }

        /// <summary>
        /// Конструктор <see cref="Employee"/>
        /// </summary>
        /// <param name="post">
        /// <inheritdoc cref="Position" path="/summary"/>
        /// </param>
        /// <param name="firstName">
        /// <inheritdoc cref="FirstName" path="/summary"/>
        /// </param>
        /// <param name="lastName">
        /// <inheritdoc cref="LastName" path="/summary"/>
        /// </param>
        /// <param name="patronymic">
        /// <inheritdoc cref="Patronymic" path="/summary"/>
        /// </param>
        public Employee(EmployeePosition position, string firstName, string lastName,
            string? patronymic = null)
        {
            patronymic ??= string.Empty;

            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            Position = position;
        }
    }
}
