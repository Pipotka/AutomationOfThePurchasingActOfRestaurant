using System.ComponentModel.DataAnnotations;

namespace AutomationOfThePurchasingActOfRestaurant.Models
{
    /// <summary>
    /// Организация
    /// </summary>
    public class Organization
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid OrganizationId { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Название
        /// </summary>
        [Required(ErrorMessage = "Название не указано")]
        [Display(Name = "Название")]
        public string Name { get; set; }
        /// <summary>
        /// Адрес организации
        /// </summary>
        [Required(ErrorMessage = "Адрес организации не указан")]
        [Display(Name = "Адрес организации")]
        public string Address { get; set; }
        /// <summary>
        /// Структурное подразделение
        /// </summary>
        [Required(ErrorMessage = "Структурное подразделение не указано")]
        [Display(Name = "Структурное подразделение")]
        public string StructuralUnit { get; set; }

        /// <summary>
        /// Пустой конструктор <see cref="Organization"/>
        /// </summary>
        public Organization() { }

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
