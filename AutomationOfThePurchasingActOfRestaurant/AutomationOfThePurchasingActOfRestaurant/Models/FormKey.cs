using System.ComponentModel.DataAnnotations;

namespace AutomationOfThePurchasingActOfRestaurant.Models
{
    /// <summary>
    /// Код формы
    /// </summary>
    public class FormKey
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid FormKeyId { get; set; }
        /// <summary>
        /// <see cref="PurchaseForm"/> Id
        /// </summary>
        public Guid PurchaseFormId { get; set; }
        /// <summary>
        /// <see cref="PurchaseForm"/>
        /// </summary>
        public PurchaseForm PurchaseForm { get; set; }
        /// <summary>
        /// Длина <see cref="OKUD"/>
        /// </summary>
        private const int lengthOfTheOKUD = 8;
        /// <summary>
        /// ОКУД(Общероссийский классификатор управленческой документации)
        /// </summary>
        [Required(ErrorMessage = "ОКУД не указан")]
        [Display(Name = "ОКУД")]
        [Length(maximumLength: lengthOfTheOKUD,
            minimumLength: lengthOfTheOKUD)]
        public string OKUD { get; set; }
        /// <summary>
        /// Длина <see cref="OKPO"/>
        /// </summary>
        private const int lengthOfTheOKPO = 8;
        /// <summary>
        /// ОКПО юридического лица(Общероссийский классификатор предприятий и организаций)
        /// </summary>
        [Required(ErrorMessage = "ОКПО не указан")]
        [Display(Name = "ОКПО")]
        [Length(minimumLength: lengthOfTheOKPO, maximumLength: lengthOfTheOKPO)]
        public string OKPO { get; set; }
        /// <summary>
        /// Длина <see cref="TIN"/>
        /// </summary>
        private const int lengthOfTheTIN = 10;
        /// <summary>
        /// ИНН(Идентификационный номер налогоплательщика)
        /// </summary>
        [Required(ErrorMessage = "ИНН не указан")]
        [Display(Name = "ИНН")]
        [Length(minimumLength: lengthOfTheTIN, maximumLength: lengthOfTheTIN)]
        public string TIN { get; set; }
        /// <summary>
        /// ОКДП (Общероссийский классификатор видов экономической деятельности, продукции и услуг)
        /// </summary>
        [Required(ErrorMessage = "ОКДП не указан")]
        [Display(Name = "ОКДП")]
        public string OKDP { get; set; }

        /// <summary>
        /// Пустой конструктор <see cref="FormKey"/>
        /// </summary>
        public FormKey() { }
    }
}
