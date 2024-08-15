using System.ComponentModel.DataAnnotations;

namespace AutomationOfThePurchasingActOfRestaurant.Models
{
    /// <summary>
    /// Должность сотрудника
    /// </summary>
    public enum EmployeePosition
    {
        /// <summary>
        /// Специалист по закупкам
        /// </summary>
        [Display(Name = "Специалист по закупкам")]
        ProcurementSpecialist,
        /// <summary>
        /// Директор
        /// </summary>
        [Display(Name = "Директор")]
        Director
    }
}
