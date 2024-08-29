using System.ComponentModel.DataAnnotations;

namespace AutomationOfThePurchasingActOfRestaurant.Models
{
    /// <summary>
    /// Единица измерения
    /// </summary>
    public class MeasurementUnit
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// <see cref="Merchandise"/>
        /// </summary>
        public ICollection<Merchandise> Merchandises { get; set; }
        /// <summary>
        /// Наибольший код по ОКЕИ
        /// </summary>
        private const short maxOKEIKey = 999;
        /// <summary>
        /// Наименование единицы измерения
        /// </summary>
        [Required(ErrorMessage = "Наименование единицы измерения не указано")]
        [Display(Name = "Наименование единицы измерения")]
        public string Name { get; set; }
        /// <summary>
        /// Код по ОКЕИ
        /// </summary>
        [Required(ErrorMessage = "Код по ОКЕИ не указан")]
        [Display(Name = "Код по ОКЕИ")]
        [Range(1, maxOKEIKey)]
        public short OKEIKey { get; set; }

        /// <summary>
        /// Пустой конструктор <see cref="MeasurementUnit"/>
        /// </summary>
        public MeasurementUnit() { }

        /// <summary>
        /// Превращает <see cref="OKEIKey"/> в строку
        /// </summary>
        /// <returns>Возвращает <see cref="OKEIKey"/> в виде строки</returns>
        public string OKEIKeyToString()
        {
            if (OKEIKey < 100)
            {
                if (OKEIKey < 10)
                {
                    return $"00{OKEIKey}";
                }
                return $"0{OKEIKey}";
            }
            return OKEIKey.ToString();
        }
    }
}
