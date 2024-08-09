using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutomationOfThePurchasingActOfRestaurant.Models.SubModels
{
    /// <summary>
    /// Общероссийский классификатор управленческой документации
    /// </summary>
    public struct FormAccordingToOKUD
    {
        /// <summary>
        /// Максимальная длина ОКУД
        /// </summary>
        private const int MaxLengthOfTheOKUD = 8;
        /// <summary>
        /// Наибольший класс формы
        /// </summary>
        private const short maxFormClassKey = 99;
        /// <summary>
        /// Наибольший подкласс формы
        /// </summary>
        private const short maxFormsSubclassKey = 99;
        /// <summary>
        /// Наибольший регистрационный номер
        /// </summary>
        private const short maxRegistrationNumber = 999;
        /// <summary>
        /// Наибольшее контрольное число
        /// </summary>
        private const short maxControlNumber = 9;
        /// <summary>
        /// Класс формы
        /// </summary>
        [Required]
        [Range(1, maxFormClassKey)]
        public short FormClass;
        /// <summary>
        /// Подкласс формы
        /// </summary>
        [Required]
        [Range(1, maxFormsSubclassKey)]
        public short FormsSubclass;
        /// <summary>
        /// Регистрационный номер
        /// </summary>
        [Required]
        [Range(1, maxRegistrationNumber)]
        public short RegistrationNumber;
        /// <summary>
        /// Контрольное число
        /// </summary>
        [Required]
        [Range(1, maxControlNumber)]
        public short ControlNumber;

        /// <summary>
        /// Конструктор <see cref="FormAccordingToOKUD"/>
        /// </summary>
        /// <param name="formClass">
        /// <inheritdoc cref="FormClass" path="/summary"/>
        /// </param>
        /// <param name="formsSubclass">
        /// <inheritdoc cref="FormsSubclass" path="/summary"/>
        /// </param>
        /// <param name="registrationNumber">
        /// <inheritdoc cref="RegistrationNumber" path="/summary"/>
        /// </param>
        /// <param name="controlNumber">
        /// <inheritdoc cref="ControlNumber" path="/summary"/>
        /// </param>
        public FormAccordingToOKUD(byte formClass, byte formsSubclass,
            byte registrationNumber, byte controlNumber)
        {
            FormClass = formClass;
            FormsSubclass = formsSubclass;
            RegistrationNumber = registrationNumber;
            ControlNumber = controlNumber;
        }

        /// <summary>
        /// Превращает <see cref="FormAccordingToOKUD"/> в строку
        /// </summary>
        /// <returns><see cref="FormAccordingToOKUD"/> в виде строки</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder(MaxLengthOfTheOKUD);

            if (FormClass < 10)
            {
                stringBuilder.Append('0');
            }
            stringBuilder.Append(FormClass);

            if (FormsSubclass < 10)
            {
                stringBuilder.Append('0');
            }
            stringBuilder.Append(FormsSubclass);

            if (RegistrationNumber < 100)
            {
                stringBuilder.Append('0');
                if (RegistrationNumber < 10)
                {
                    stringBuilder.Append('0');
                }
            }
            stringBuilder.Append(RegistrationNumber);

            stringBuilder.Append(ControlNumber);

            return stringBuilder.ToString();
        }
    }
}
