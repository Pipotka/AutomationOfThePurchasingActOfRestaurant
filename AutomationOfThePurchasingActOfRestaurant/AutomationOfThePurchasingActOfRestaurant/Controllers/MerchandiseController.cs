using AutomationOfThePurchasingActOfRestaurant.Models;
using AutomationOfThePurchasingActOfRestaurant.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutomationOfThePurchasingActOfRestaurant.Controllers
{
    /// <summary>
    /// Контроллер для работы с товарами
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class MerchandiseController : ControllerBase
    {
        private readonly MerchandiseRepository merchandiseRepository;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="MerchandiseController"/>
        /// </summary>
        public MerchandiseController(MerchandiseRepository merchandiseRepository)
        {
            this.merchandiseRepository = merchandiseRepository;
        }

        /// <summary>
        /// Получает товар по идентификатору
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Merchandise), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            var result = await merchandiseRepository.GetAsync(id, token);
            if (result == null)
            {
                return NotFound($"Товар с id = {id} не найден");
            }
            return Ok(result);
        }

        /// <summary>
        /// Получает список всех товаров
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var result = await merchandiseRepository.GetAllAsync(token);

            return Ok(result);
        }

        /// <summary>
        /// Изменяет товар
        /// </summary>
        /// <param name="updatedMerchandise">
        /// Изменённый товар
        /// </param>
        [HttpPut]
        [ProducesResponseType(typeof(Merchandise), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(Merchandise updatedMerchandise, CancellationToken token)
        {
            if (await merchandiseRepository.IsExistByIdAsync(updatedMerchandise.Id, token))
            {
                await merchandiseRepository.EditAsync(updatedMerchandise, token);

                return Ok(updatedMerchandise);
            }
            return NotFound($"Товар с id = {updatedMerchandise.Id} не найден");
        }

        /// <summary>
        /// Удаляет товар по Id
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken token)
        {
            if (await merchandiseRepository.IsExistByIdAsync(id, token))
            {
                await merchandiseRepository.DeleteAsync(id, token);

                return Ok();
            }
            return NotFound($"Товар с id = {id} не найден");
        }

        /// <summary>
        /// Добавляет товар
        /// </summary>
        /// <param name="addableMerchandise">
        /// Добавляемый товар
        /// </param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Merchandise), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] Merchandise addableMerchandise, CancellationToken token)
        {
            if (merchandiseRepository.IsExist(addableMerchandise))
            {
                return BadRequest("Данный товар уже существует");
            }
            await merchandiseRepository.CreateAsync(addableMerchandise, token);

            return Ok(addableMerchandise);
        }
    }
}