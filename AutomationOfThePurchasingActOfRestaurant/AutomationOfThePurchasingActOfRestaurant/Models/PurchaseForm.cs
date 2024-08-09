using System.ComponentModel.DataAnnotations;

namespace AutomationOfThePurchasingActOfRestaurant.Models
{
    /// <summary>
    /// Закупочный акт
    /// </summary>
    public class PurchaseForm
    {
        /// <summary>
        /// Id закупочного акта для базы данных
        /// </summary>
        [Required]
        public readonly Guid Id = Guid.NewGuid();
        /// <summary>
        /// ГОСТ Формы
        /// </summary>
        [Required]
        public string StateStandardOfTheForm;
        /// <summary>
        /// Код формы
        /// </summary>
        [Required]
        public FormKey Key;
        /// <summary>
        /// Номер документа
        /// </summary>
        [Required]
        [Range(1, int.MaxValue)]
        public int DocumentNumber;
        /// <summary>
        /// Дата составления документа
        /// </summary>
        [Required]
        public DateTime DocumentDate;
        /// <summary>
        /// Место закупки
        /// </summary>
        [Required]
        public string AddressOfPurchase;
        /// <summary>
        /// Организация-заказчик
        /// </summary>
        [Required]
        public Organization SponsorOrganization;
        /// <summary>
        /// Утверждающий сотрудник
        /// </summary>
        [Required]
        public Approver ApprovingOfficer;
        /// <summary>
        /// Специалист по закупке
        /// </summary>
        [Required]
        public Specialist ProcurementSpecialist;
        /// <summary>
        /// Продавец
        /// </summary>
        [Required]
        public Human Salesman;
        /// <summary>
        /// Закупленные товары
        /// </summary>
        [Required]
        public List<Merchandise> PurchasedMerchandises;

        /// <summary>
        /// Конструктор <see cref="PurchaseForm"/>
        /// </summary>
        /// <param name="stateStandardOfTheForm">
        /// <inheritdoc cref="StateStandardOfTheForm" path="/summary"/>
        /// </param>
        /// <param name="key">
        /// <inheritdoc cref="Key" path="/summary"/>
        /// </param>
        /// <param name="documentNumber">
        /// <inheritdoc cref="DocumentNumber" path="/summary"/>
        /// </param>
        /// <param name="documentDate">
        /// <inheritdoc cref="DocumentDate" path="/summary"/>
        /// </param>
        /// <param name="addressOfPurchase">
        /// <inheritdoc cref="AddressOfPurchase" path="/summary"/>
        /// </param>
        /// <param name="sponsorOrganization">
        /// <inheritdoc cref="SponsorOrganization" path="/summary"/>
        /// </param>
        /// <param name="approvingOfficer">
        /// <inheritdoc cref="ApprovingOfficer" path="/summary"/>
        /// </param>
        /// <param name="procurementSpecialist">
        /// <inheritdoc cref="ProcurementSpecialist" path="/summary"/>
        /// </param>
        /// <param name="salesman">
        /// <inheritdoc cref="Salesman" path="/summary"/>
        /// </param>
        /// <param name="purchasedMerchandises">
        /// <inheritdoc cref="PurchasedMerchandises" path="/summary"/>
        /// </param>
        public PurchaseForm(string stateStandardOfTheForm, FormKey key,
            int documentNumber, DateTime documentDate, string addressOfPurchase,
            Organization sponsorOrganization, Approver approvingOfficer,
            Specialist procurementSpecialist, Human salesman,
            List<Merchandise> purchasedMerchandises)
        {
            StateStandardOfTheForm = stateStandardOfTheForm;
            Key = key;
            DocumentNumber = documentNumber;
            DocumentDate = documentDate;
            AddressOfPurchase = addressOfPurchase;
            SponsorOrganization = sponsorOrganization;
            ApprovingOfficer = approvingOfficer;
            ProcurementSpecialist = procurementSpecialist;
            Salesman = salesman;
            PurchasedMerchandises = purchasedMerchandises;
        }

        /// <summary>
        /// Рассчитывает полную стоимость <see cref="PurchasedMerchandises"/>
        /// </summary>
        /// <returns>Полная стоимасть <see cref="PurchasedMerchandises"/></returns>
        public float GetTotalCost()
        {
            float totalCost = 0.0f;
            foreach (Merchandise merchandise in PurchasedMerchandises)
            {
                totalCost += merchandise.TotalCost;
            }
            return totalCost;
        }
    }
}
