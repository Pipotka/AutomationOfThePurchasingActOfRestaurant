using AutomationOfThePurchasingActOfRestaurant.Models;
using AutomationOfThePurchasingActOfRestaurant.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace AutomationOfThePurchasingActOfRestaurant.Controllers
{
    /// <summary>
    /// Контроллер для работы с кодами формы
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class FormKeyController : ControllerBase
    {
        private readonly FormKeysRepository formKeyRepository;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="FormKeyController"/>
        /// </summary>
        public FormKeyController(FormKeysRepository formKeyRepository)
        {
            this.formKeyRepository = formKeyRepository;
        }

        /// <summary>
        /// Получает код формы по индентификатору
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FormKey), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            var result = await formKeyRepository.GetAsync(id, token);
            if (result == null)
            {
                return NotFound($"Код формы с id = {id} не найден");
            }
            return Ok(result);
        }

        /// <summary>
        /// Получает список всех кодов формы
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var result = await formKeyRepository.GetAllAsync(token);

            return Ok(result);
        }

        /// <summary>
        /// Изменяет код формы
        /// </summary>
        /// <param name="updatedFormKey">
        /// Изменённый код формы
        /// </param>
        [HttpPut]
        [ProducesResponseType(typeof(FormKey), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(FormKey updatedFormKey, CancellationToken token)
        {
            if (await formKeyRepository.IsExistByIdAsync(updatedFormKey.Id, token))
            {
                await formKeyRepository
                    .EditAsync(updatedFormKey, token);

                return Ok(updatedFormKey);
            }
            return NotFound($"Код формы с id = {updatedFormKey.Id} не найден");
        }

        /// <summary>
        /// Удаляет код формы по Id
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken token)
        {
            if (await formKeyRepository.IsExistByIdAsync(id, token))
            {
                await formKeyRepository.DeleteAsync(id, token);

                return Ok();
            }
            return NotFound($"Код формы с id = {id} не найден");
        }

        /// <summary>
        /// Добавляет код формы
        /// </summary>
        /// <param name="addableFormKey">
        /// Добавляемый код формы
        /// </param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(FormKey), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] FormKey addableFormKey, CancellationToken token)
        {
            if (formKeyRepository.IsExist(addableFormKey))
            {
                return BadRequest("Данный код формы уже существует");
            }
            await formKeyRepository.CreateAsync(addableFormKey, token);

            return Ok(addableFormKey);
        }
    }
}
