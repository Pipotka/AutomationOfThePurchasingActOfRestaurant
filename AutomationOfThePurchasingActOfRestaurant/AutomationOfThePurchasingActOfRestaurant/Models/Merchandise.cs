using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AutomationOfThePurchasingActOfRestaurant.Models
{
    /// <summary>
    /// Товар
    /// </summary>
    public class Merchandise
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
        /// Наименование, характеристика товара
        /// </summary>
        [Required(ErrorMessage = "Наименование и характеристика товара не указаны")]
        [Display(Name = "Наименование, характеристика товара")]
        public string Name { get; set; }
        /// <summary>
        /// Код товара
        /// </summary>
        [Required(ErrorMessage = "Код товара не указан")]
        [Display(Name = "Код товара")]
        [Range(1, int.MaxValue)]
        public int MerchandiseKey { get; set; }
        /// <summary>
        /// <see cref="MeasurementUnit"/> Id
        /// </summary>
        public Guid MeasurementUnitId { get; set; }
        /// <summary>
        /// <inheritdoc cref="Models.MeasurementUnit" path="/summary"/>
        /// </summary>
        [Required(ErrorMessage = "Единица измерения не указана")]
        [Display(Name = "Единица измерения")]
        public MeasurementUnit MeasurementUnit { get; set; }
        /// <summary>
        /// Количество товара
        /// </summary>
        [Required(ErrorMessage = "Количество товара не указано")]
        [Display(Name = "Количество товара")]
        [Range(1, int.MaxValue)]
        public int Count { get; set; }
        /// <summary>
        /// Цены
        /// </summary>
        public ICollection<MerchandisePrice> Prices { get; set; }

        /// <summary>
        /// Пустой конструктор <see cref="Merchandise"/>
        /// </summary>
        public Merchandise() { }
    }
}
