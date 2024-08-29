using System.ComponentModel.DataAnnotations;

namespace AutomationOfThePurchasingActOfRestaurant.Models
{
    /// <summary>
    /// Должность сотрудника
    /// </summary>
    public class EmployeePosition
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// <see cref="Approver"/>
        /// </summary>
        public ICollection<Approver> Approvers { get; set; }
        /// <summary>
        /// <see cref="Employee"/>
        /// </summary>
        public ICollection<Employee> Employees { get; set; }
        /// <summary>
        /// Название должности
        /// </summary>
        [Required(ErrorMessage = "Название должности не указанно")]
        [Display(Name = "Название должности")]
        public string Name { get; set; }

        /// <summary>
        /// Пустой конструктор <see cref="EmployeePosition"/>
        /// </summary>
        public EmployeePosition() { }
    }
}
