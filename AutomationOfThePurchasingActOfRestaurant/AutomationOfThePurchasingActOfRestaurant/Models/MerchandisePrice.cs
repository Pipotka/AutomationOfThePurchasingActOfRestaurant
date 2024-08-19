using System.ComponentModel.DataAnnotations;

namespace AutomationOfThePurchasingActOfRestaurant.Models
{
    /// <summary>
    /// Цена товара
    /// </summary>
    public class MerchandisePrice
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid MerchandisePriceId { get; set; }
        /// <summary>
        /// <see cref="PurchaseForm"/> в которых используется данная цена
        /// </summary>
        public ICollection<PurchaseForm> PurchaseForms { get; set; }
        /// <summary>
        /// <see cref="Models.Merchandise"/> Id
        /// </summary>
        public Guid MerchandiseId { get; set; }
        public Merchandise Merchandise { get; set; }
        /// <summary>
        /// Цена за единицу товара
        /// </summary>
        [Required(ErrorMessage = "Цена за единицу товара не указана")]
        [Display(Name = "Цена за единицу товара")]
        [Range(0.0, double.MaxValue)]
        public double CostPerUnit { get; set; }

        /// <summary>
        /// Пустой конструктор <see cref="MerchandisePrice"/>
        /// </summary>
        public MerchandisePrice() { }
    }
}
