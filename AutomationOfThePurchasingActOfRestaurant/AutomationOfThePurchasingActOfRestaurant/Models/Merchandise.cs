using System.ComponentModel.DataAnnotations;

namespace AutomationOfThePurchasingActOfRestaurant.Models
{
    /// <summary>
    /// Товар
    /// </summary>
    public class Merchandise
    {
        /// <summary>
        /// Наименование, характеристика товара
        /// </summary>
        [Required]
        public string Name;
        /// <summary>
        /// Код товара
        /// </summary>
        [Required]
        [Range(1, int.MaxValue)]
        public string MerchandiseKey;
        /// <summary>
        /// Единица измерения товара
        /// </summary>
        [Required]
        public MeasurementUnit MUnit;
        /// <summary>
        /// Количество товара
        /// </summary>
        [Required]
        [Range(1, int.MaxValue)]
        public int Count;
        /// <summary>
        /// Цена за единицу товара
        /// </summary>
        [Required]
        [Range(0.0, float.MaxValue)]
        public float CostPerUnit;
        /// <summary>
        /// Полная стоимость
        /// </summary>
        [Required]
        [Range(0.0, float.MaxValue)]
        public float TotalCost;


        public Merchandise()
        {
            
        }
    }
}
