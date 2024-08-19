using System.ComponentModel.DataAnnotations;

namespace AutomationOfThePurchasingActOfRestaurant.Models
{
    /// <summary>
    /// Закупочный акт
    /// </summary>
    public class PurchaseForm
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid PurchaseFormId { get; set; }
        /// <summary>
        /// <see cref="FormKey"/> Id
        /// </summary>
        public Guid FormKeyId {  get; set; }
        /// <summary>
        /// <inheritdoc cref="Models.FormKey" path="/summary"/>
        /// </summary>
        [Required(ErrorMessage = "Код формы не указан")]
        [Display(Name = "Код формы")]
        public FormKey FormKey { get; set; }
        /// <summary>
        /// <see cref="SponsorOrganization"/> Id
        /// </summary>
        public Guid SponsorOrganizationId { get; set; }
        /// <summary>
        /// Организация-закзчик
        /// </summary>
        [Required(ErrorMessage = "Организация-закзчик не указана")]
        [Display(Name = "Организация-закзчик")]
        public Organization SponsorOrganization { get; set; }
        /// <summary>
        /// <see cref="ApprovingOfficer"/> Id
        /// </summary>
        public Guid ApprovingOfficerId { get; set; }
        /// <summary>
        /// Утверждающее должностное лицо
        /// </summary>
        [Required(ErrorMessage = "Утверждающее должностное лицо не указано")]
        [Display(Name = "Утверждающее должностное лицо")]
        public Approver ApprovingOfficer { get; set; }
        /// <summary>
        /// Номер документа
        /// </summary>
        [Required(ErrorMessage = "Номер документа не указан")]
        [Display(Name = "Номер документа")]
        [Range(1, int.MaxValue)]
        public int DocumentNumber { get; set; }
        /// <summary>
        /// Дата составления документа
        /// </summary>
        [Required(ErrorMessage = "Дата составления документа не указана")]
        [Display(Name = "Дата составления документа")]
        public DateTime DocumentDate { get; set; }
        /// <summary>
        /// Место закупки
        /// </summary>
        [Required(ErrorMessage = "Место закупки не указано")]
        [Display(Name = "Место закупки")]
        public string AddressOfPurchase { get; set; }
        /// <summary>
        /// <see cref="ProcurementSpecialist"/> Id
        /// </summary>
        public Guid ProcurementSpecialistId { get; set; }
        /// <summary>
        /// Специалист по закупкам
        /// </summary>
        [Required(ErrorMessage = "Специалист по закупкам не указан")]
        [Display(Name = "Специалист по закупкам")]
        public Employee ProcurementSpecialist { get; set; }
        /// <summary>
        /// <see cref="Salesman"/> Id
        /// </summary>
        public Guid SalesmanId { get; set; }
        /// <summary>
        /// <inheritdoc cref="Models.Supplier" path="/summary"/>
        /// </summary>
        [Required(ErrorMessage = "Поставщик не указан")]
        [Display(Name = "Поставщик")]
        public Supplier Salesman { get; set; }
        /// <summary>
        /// Закупленные товары
        /// </summary>
        [Required(ErrorMessage = "Закупленные товары не указаны")]
        [Display(Name = "Закупленные товары")]
        public ICollection<Merchandise> PurchasedMerchandises {  get; set; }
        /// <summary>
        /// Цены
        /// </summary>
        [Required(ErrorMessage = "Цены на товары не указаны")]
        [Display(Name = "Цены на товары")]
        public ICollection<MerchandisePrice> Prices { get; set; }

        /// <summary>
        /// Пустой конструктор <see cref="PurchaseForm"/>
        /// </summary>
        public PurchaseForm() { }

        /// <summary>
        /// Рассчитывает полную стоимость <see cref="PurchasedMerchandises"/>
        /// </summary>
        /// <returns>Полная стоимасть <see cref="PurchasedMerchandises"/></returns>
        public double GetTotalCost()
        {
            var totalCost = 0.0;
            MerchandisePrice merchandisePrice;
            foreach (Merchandise merchandise in PurchasedMerchandises)
            {
                merchandisePrice = Prices.FirstOrDefault(mp => mp.MerchandiseId == merchandise.MerchandiseId);
                totalCost += merchandisePrice.CostPerUnit * merchandise.Count;
            }
            return totalCost;
        }
    }
}
