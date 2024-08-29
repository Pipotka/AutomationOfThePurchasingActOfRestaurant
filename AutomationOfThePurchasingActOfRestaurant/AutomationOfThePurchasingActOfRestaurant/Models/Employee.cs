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
        public Guid Id { get; set; }
        /// <summary>
        /// <see cref="PurchaseForm"/>
        /// </summary>
        public ICollection<PurchaseForm> PurchaseForms { get; set; }
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
        /// <see cref="EmployeePosition"/> Id
        /// </summary>
        public Guid PositionId { get; set; }
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
    }
}
