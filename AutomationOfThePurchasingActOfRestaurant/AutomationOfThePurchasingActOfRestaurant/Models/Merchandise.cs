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
        public Guid MerchandiseId { get; set; } = Guid.NewGuid();
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
        /// Цена за единицу товара
        /// </summary>
        [Required(ErrorMessage = "Цена за единицу товара не указана")]
        [Display(Name = "Цена за единицу товара")]
        [Range(0.0, float.MaxValue)]
        public float CostPerUnit { get; set; }
        /// <summary>
        /// Закупочные акты, в которых присутствует
        /// <inheritdoc cref="Merchandise" path="/summary"/>
        /// </summary>
        public ICollection<PurchaseForm> PurchaseForms { get; set; }

        /// <summary>
        /// Пустой конструктор <see cref="Merchandise"/>
        /// </summary>
        public Merchandise() { }

        /// <summary>
        /// Конструктор <see cref="Merchandise"/>
        /// </summary>
        /// <param name="name">
        /// <inheritdoc cref="Name" path="/summary"/>
        /// </param>
        /// <param name="merchandiseKey">
        /// <inheritdoc cref="MerchandiseKey" path="/summary"/>
        /// </param>
        /// <param name="measurementUnit">
        /// <inheritdoc cref="MeasurementUnit" path="/summary"/>
        /// </param>
        /// <param name="count">
        /// <inheritdoc cref="Count" path="/summary"/>
        /// </param>
        /// <param name="costPerUnit">
        /// <inheritdoc cref="CostPerUnit" path="/summary"/>
        /// </param>
        public Merchandise(string name, int merchandiseKey,
            MeasurementUnit measurementUnit, int count,
            float costPerUnit)
        {
            Name = name;
            MerchandiseKey = merchandiseKey;
            MeasurementUnit = measurementUnit;
            Count = count;
            CostPerUnit = costPerUnit;
        }
    }
}
