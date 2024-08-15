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
        public Guid MeasurementUnitId { get; set; } = Guid.NewGuid();
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
        /// Конструктор <see cref="MeasurementUnit"/>
        /// </summary>
        /// <param name="name">
        /// <inheritdoc cref="Name" path="/summary"/>
        /// </param>
        /// <param name="OKEIKey">
        /// <inheritdoc cref="OKEIKey" path="/summary"/>
        /// </param>
        public MeasurementUnit(string name, short OKEIKey)
        {
            Name = name;
            this.OKEIKey = OKEIKey;
        }

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
