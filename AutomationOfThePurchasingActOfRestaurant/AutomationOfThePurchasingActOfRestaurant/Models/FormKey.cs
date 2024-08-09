using AutomationOfThePurchasingActOfRestaurant.Models.SubModels;
using System.ComponentModel.DataAnnotations;

namespace AutomationOfThePurchasingActOfRestaurant.Models
{
    /// <summary>
    /// Код формы
    /// </summary>
    public class FormKey
    {
        /// <summary>
        /// <inheritdoc cref="FormAccordingToOKUD" path="/summary"/>
        /// </summary>
        [Required]
        public FormAccordingToOKUD OKUD;
        /// <summary>
        /// <inheritdoc cref="OKPOKey" path="/summary"/>
        /// </summary>
        [Required]
        public OKPOKey OKPO;
        /// <summary>
        /// <inheritdoc cref="TaxpayerIdentificationNumber" path="/summary"/>
        /// </summary>
        [Required]
        public TaxpayerIdentificationNumber TIN;
        /// <summary>
        /// ОКДП (Общероссийский классификатор видов экономической деятельности, продукции и услуг)
        /// </summary>
        [Required]
        public string OKDP;

        /// <summary>
        /// Конструктор <see cref="FormKey"/>
        /// </summary>
        /// <param name="OKUD">
        /// <inheritdoc cref="FormAccordingToOKUD" path="/summary"/>
        /// </param>
        /// <param name="OKPO">
        /// <inheritdoc cref="OKPOKey" path="/summary"/>
        /// </param>
        /// <param name="TIN">
        /// <inheritdoc cref="TaxpayerIdentificationNumber" path="/summary"/>
        /// </param>
        /// <param name="OKDP">
        /// <inheritdoc cref="OKDP" path="/summary"/>
        /// </param>
        public FormKey(FormAccordingToOKUD OKUD, OKPOKey OKPO,
            TaxpayerIdentificationNumber TIN, string OKDP)
        {
            this.OKUD = OKUD;
            this.OKPO = OKPO;
            this.OKDP = OKDP;
            this.TIN = TIN;
        }
    }
}
