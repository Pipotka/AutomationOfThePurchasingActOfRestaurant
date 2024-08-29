using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutomationOfThePurchasingActOfRestaurant.Models;
using AutomationOfThePurchasingActOfRestaurant.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AutomationOfThePurchasingActOfRestaurant.Controllers
{
    /// <summary>
    /// Контроллер для работы с закупочными актами
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PurchaseFormController : ControllerBase
    {
        private readonly PurchaseFormsRepository purchaseFormsRepository;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="PurchaseFormController"/>
        /// </summary>
        public PurchaseFormController(PurchaseFormsRepository purchaseFormsRepository)
        {
            this.purchaseFormsRepository = purchaseFormsRepository;
        }

        /// <summary>
        /// Получает закупочный акт по индентификатору
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PurchaseForm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            var result = await purchaseFormsRepository.GetAsync(id, token);
            if (result == null)
            {
                return NotFound($"Закупочный акт с id = {id} не найден");
            }
            return Ok(result);
        }

        /// <summary>
        /// Получает список всех закупочных актов
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var result = await purchaseFormsRepository.GetAllAsync(token);

            return Ok(result);
        }

        /// <summary>
        /// Изменяет закупочный акт
        /// </summary>
        /// <param name="updatedPurchaseForm">
        /// Изменённый закупочный акт
        /// </param>
        [HttpPut]
        [ProducesResponseType(typeof(PurchaseForm),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(PurchaseForm updatedPurchaseForm, CancellationToken token)
        {
            if (await purchaseFormsRepository.IsExistByIdAsync(updatedPurchaseForm.Id, token))
            {
                await purchaseFormsRepository
                    .EditAsync(updatedPurchaseForm, token);

                return Ok(updatedPurchaseForm);
            }
            return NotFound($"Закупочный акт с id = {updatedPurchaseForm.Id} не найден");
        }

        /// <summary>
        /// Удаляет закупочный акт по Id
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken token)
        {
            if (await purchaseFormsRepository.IsExistByIdAsync(id, token))
            {
                await purchaseFormsRepository.DeleteAsync(id, token);

                return Ok();
            }
            return NotFound($"Закупочный акт с id = {id} не найден");
        }

        /// <summary>
        /// Добавляет закупочный акт
        /// </summary>
        /// <param name="addablePurchaseForm">
        /// Добавляемый закупочный акт
        /// </param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(PurchaseForm),StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] PurchaseForm addablePurchaseForm, CancellationToken token)
        {
            if (purchaseFormsRepository.IsExist(addablePurchaseForm))
            {
                return BadRequest("Закупочный акт с данным кодом формы уже существует");
            }
            await purchaseFormsRepository.CreateAsync(addablePurchaseForm, token);

            return Ok(addablePurchaseForm);
        }
    }
}
