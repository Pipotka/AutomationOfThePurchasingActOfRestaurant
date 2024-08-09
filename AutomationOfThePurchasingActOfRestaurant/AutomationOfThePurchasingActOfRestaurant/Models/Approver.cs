using System.ComponentModel.DataAnnotations;

namespace AutomationOfThePurchasingActOfRestaurant.Models
{
    /// <summary>
    /// Утверждающий
    /// </summary>
    public class Approver : Specialist
    {
        /// <summary>
        /// <inheritdoc cref="Models.Signature" path="/summary"/>
        /// </summary>
        [Required]
        public Signature Signature;
        /// <summary>
        /// Расшифровка подписи
        /// </summary>
        [Required]
        public string SignatureDecryption;

        /// <summary>
        /// Конструктор <see cref="Approver"/>
        /// </summary>
        /// <param name="post">
        /// <inheritdoc cref="Specialist.Post" path="/summary"/>
        /// </param>
        /// <param name="signature">
        /// <inheritdoc cref="Models.Signature" path="/summary"/>
        /// </param>
        /// <param name="signatureDecryption">
        /// <inheritdoc cref="SignatureDecryption" path="/summary"/>
        /// </param>
        /// <param name="firstName">
        /// <inheritdoc cref="Human.FirstName" path="/summary"/>
        /// </param>
        /// <param name="lastName">
        /// <inheritdoc cref="Human.LastName" path="/summary"/>
        /// </param>
        /// <param name="patronymic">
        /// <inheritdoc cref="Human.Patronymic" path="/summary"/>
        /// </param>
        public Approver(string post, Signature signature, string signatureDecryption, string firstName, string lastName,
            string? patronymic = null) 
            : base(post, firstName, lastName, patronymic)
        {
            SignatureDecryption = signatureDecryption;
            Signature = new Signature(signature);
        }
    }
}
