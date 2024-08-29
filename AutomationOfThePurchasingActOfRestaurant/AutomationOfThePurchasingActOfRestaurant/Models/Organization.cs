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
        public Guid Id { get; set; }
        /// <summary>
        /// <see cref="PurchaseForm"/>
        /// </summary>
        public ICollection<PurchaseForm> PurchaseForms { get; set; }
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
    }
}
