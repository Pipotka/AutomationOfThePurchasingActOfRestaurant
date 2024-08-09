using System.ComponentModel.DataAnnotations;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutomationOfThePurchasingActOfRestaurant.Models.SubModels
{
    /// <summary>
    /// ИНН(Идентификационный номер налогоплательщика)
    /// </summary>
    public struct TaxpayerIdentificationNumber
    {
        /// <summary>
        /// длина кода субъекта Российской Федерации
        /// </summary>
        private const short keyLengthOfTheSubjectOfTheRF = 2;
        /// <summary>
        /// Наибольший код субъекта Российской Федерации
        /// </summary>
        private const short maxSubjectOfTheRFKey = 99;
        /// <summary>
        /// длина порядкового номера налогоплательщика
        /// </summary>
        private const short lengthOfTheSerialNumberOfTaxpayer = 2;
        /// <summary>
        /// Наибольший порядковый номер налогоплательщика
        /// </summary>
        private const short maxSerialNumberOfTaxpayer = 99;
        /// <summary>
        /// длина порядкового номера организации
        /// </summary>
        private const short lengthOfTheOrganizationSequenceNumber = 5;
        /// <summary>
        /// Наибольший порядковый номер организации
        /// </summary>
        private const int maxOrganizationSequenceNumber = 99999;
        /// <summary>
        /// Длина контрольной цифры
        /// </summary>
        private const short lengthOfCheckDigit= 1;
        /// <summary>
        /// Наибольшая контрольная цифра
        /// </summary>
        private const short maxCheckDigit = 9;
        /// <summary>
        /// код субъекта Российской Федерации
        /// </summary>
        [Required]
        [Range(1, maxSubjectOfTheRFKey)]
        public short SubjectOfTheRFKey;
        /// <summary>
        /// Порядковый номер налогоплательщика
        /// </summary>
        [Required]
        [Range(1, maxSerialNumberOfTaxpayer)]
        public short SerialNumberOfTaxpayer;
        /// <summary>
        /// порядковый номер организации
        /// </summary>
        [Required]
        [Range(1, maxOrganizationSequenceNumber)]
        public int OrganizationSequenceNumber;
        /// <summary>
        /// Контрольная цифра
        /// </summary>
        [Required]
        [Range(1, maxCheckDigit)]
        public short CheckDigit;

        /// <summary>
        /// Конструктор <see cref="TaxpayerIdentificationNumber"/>
        /// </summary>
        /// <param name="subjectOfTheRFKey">
        /// <inheritdoc cref="SubjectOfTheRFKey" path="/summary"/>
        /// </param>
        /// <param name="serialNumberOfTaxpayer">
        /// <inheritdoc cref="SerialNumberOfTaxpayer" path="/summary"/>
        /// </param>
        /// <param name="organizationSequenceNumber">
        /// <inheritdoc cref="OrganizationSequenceNumber" path="/summary"/>
        /// </param>
        /// <param name="checkDigit">
        /// <inheritdoc cref="CheckDigit" path="/summary"/>
        /// </param>
        public TaxpayerIdentificationNumber(short subjectOfTheRFKey, short serialNumberOfTaxpayer,
            int organizationSequenceNumber, short checkDigit)
        {
            SubjectOfTheRFKey = subjectOfTheRFKey;
            SerialNumberOfTaxpayer  = serialNumberOfTaxpayer;
            OrganizationSequenceNumber = organizationSequenceNumber;
            CheckDigit = checkDigit;
        }

        /// <summary>
        /// Превращает <see cref="TaxpayerIdentificationNumber"/> в строку
        /// </summary>
        /// <returns>
        /// <see cref="TaxpayerIdentificationNumber"/> в виде строки
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(keyLengthOfTheSubjectOfTheRF 
                + lengthOfTheSerialNumberOfTaxpayer
                + lengthOfTheOrganizationSequenceNumber
                + lengthOfCheckDigit);

            if (SubjectOfTheRFKey < 10)
            {
                sb.Append('0');
            }
            sb.Append(SubjectOfTheRFKey);
            if (SerialNumberOfTaxpayer  < 10)
            {
                sb.Append('0');
            }
            sb.Append(SerialNumberOfTaxpayer );
            int difference = lengthOfTheOrganizationSequenceNumber - OrganizationSequenceNumber.ToString().Length;
            for (int i = 0; i < difference; i++)
            {
                sb.Append('0');
            }
            sb.Append(OrganizationSequenceNumber);
            sb.Append(CheckDigit);
            return sb.ToString();
        }
    }
}
