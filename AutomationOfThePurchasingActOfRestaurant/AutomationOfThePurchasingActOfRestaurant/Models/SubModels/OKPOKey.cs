using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutomationOfThePurchasingActOfRestaurant.Models.SubModels
{
    /// <summary>
    /// ОКПО юридического лица(Общероссийский классификатор предприятий и организаций)
    /// </summary>
    public struct OKPOKey
    {
        /// <summary>
        /// длина порядкового номера
        /// </summary>
        private const int lengthSerialNumber = 7;
        /// <summary>
        /// Наибольший порядковый номер
        /// </summary>
        private const int maxSerialNumber = 9999999;
        /// <summary>
        /// Наибольшая контрольная цифра
        /// </summary>
        private const short maxCheckDigit = 9;
        /// <summary>
        /// порядковый номер,
        /// под которым предприятие зарегистрировано в классификаторе
        /// </summary>
        [Required]
        [Range(1, maxSerialNumber)]
        public int SerialNumber;
        /// <summary>
        /// Контрольная цифра
        /// </summary>
        [Required]
        [Range(1, maxCheckDigit)]
        public short CheckDigit;

        /// <summary>
        /// Конструктор <see cref="OKPOKey"/>
        /// </summary>
        /// <param name="serialNumber">
        /// <inheritdoc cref="SerialNumber" path="/summary"/>
        /// </param>
        /// <param name="checkDigit">
        /// <inheritdoc cref="CheckDigit" path="/summary"/>
        /// </param>
        public OKPOKey(int serialNumber, short checkDigit)
        {
            SerialNumber = serialNumber;
            CheckDigit = checkDigit;
        }

        /// <summary>
        /// Превращает <see cref="OKPOKey"/> в строку
        /// </summary>
        /// <returns>
        /// <see cref="OKPOKey"/> в виде строкм
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(lengthSerialNumber + 1);
            int difference = lengthSerialNumber - SerialNumber.ToString().Length;
            
            for (int i = 0; i < difference; i++)
            {
                sb.Append('0');
            }
            sb.Append(SerialNumber.ToString());
            sb.Append(CheckDigit.ToString());

            return sb.ToString();
        }
    }
}
