using AutomationOfThePurchasingActOfRestaurant.Models;
using AutomationOfThePurchasingActOfRestaurant.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutomationOfThePurchasingActOfRestaurant.Controllers
{
    /// <summary>
    /// Контроллер для работы с ценами на товары
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class MerchandisePriceController : ControllerBase
    {
        private readonly MerchandisePricesRepository merchandisePriceRepository;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="MerchandisePriceController"/>
        /// </summary>
        public MerchandisePriceController(MerchandisePricesRepository merchandisePriceRepository)
        {
            this.merchandisePriceRepository = merchandisePriceRepository;
        }

        /// <summary>
        /// Получает цену товара по идентификатору
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MerchandisePrice), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            var result = await merchandisePriceRepository.GetAsync(id, token);
            if (result == null)
            {
                return NotFound($"Цена товара с id = {id} не найдена");
            }
            return Ok(result);
        }

        /// <summary>
        /// Получает список всех цен на товары
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var result = await merchandisePriceRepository.GetAllAsync(token);

            return Ok(result);
        }

        /// <summary>
        /// Изменяет цену товара
        /// </summary>
        /// <param name="updatedMerchandisePrice">
        /// Изменённая цена товара
        /// </param>
        [HttpPut]
        [ProducesResponseType(typeof(MerchandisePrice), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(MerchandisePrice updatedMerchandisePrice, CancellationToken token)
        {
            if (await merchandisePriceRepository.IsExistByIdAsync(updatedMerchandisePrice.Id, token))
            {
                await merchandisePriceRepository.EditAsync(updatedMerchandisePrice, token);

                return Ok(updatedMerchandisePrice);
            }
            return NotFound($"Цена товара с id = {updatedMerchandisePrice.Id} не найдена");
        }

        /// <summary>
        /// Удаляет цену товара по Id
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken token)
        {
            if (await merchandisePriceRepository.IsExistByIdAsync(id, token))
            {
                await merchandisePriceRepository.DeleteAsync(id, token);

                return Ok();
            }
            return NotFound($"Цена товара с id = {id} не найдена");
        }

        /// <summary>
        /// Добавляет цену товара
        /// </summary>
        /// <param name="addableMerchandisePrice">
        /// Добавляемая цена товара
        /// </param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MerchandisePrice), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] MerchandisePrice addableMerchandisePrice, CancellationToken token)
        {
            if (merchandisePriceRepository.IsExist(addableMerchandisePrice))
            {
                return BadRequest("Данная цена товара уже существует");
            }
            await merchandisePriceRepository.CreateAsync(addableMerchandisePrice, token);

            return Ok(addableMerchandisePrice);
        }
    }
}
