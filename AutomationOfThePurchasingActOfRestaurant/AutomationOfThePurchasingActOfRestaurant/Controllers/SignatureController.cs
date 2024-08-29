using AutomationOfThePurchasingActOfRestaurant.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutomationOfThePurchasingActOfRestaurant.Models;
using AutomationOfThePurchasingActOfRestaurant.Repositories;


namespace AutomationOfThePurchasingActOfRestaurant.Controllers
{
    /// <summary>
    /// Контроллер для работы с подписями
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class SignatureController : ControllerBase
    {
        private readonly SignaturesRepository signatureRepository;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="SignatureController"/>
        /// </summary>
        public SignatureController(SignaturesRepository signatureRepository)
        {
            this.signatureRepository = signatureRepository;
        }

        /// <summary>
        /// Получает подпись по идентификатору
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Signature), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            var result = await signatureRepository.GetAsync(id, token);
            if (result == null)
            {
                return NotFound($"Подпись с id = {id} не найдена");
            }
            return Ok(result);
        }

        /// <summary>
        /// Получает список всех подписей
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var result = await signatureRepository.GetAllAsync(token);

            return Ok(result);
        }

        /// <summary>
        /// Изменяет подпись
        /// </summary>
        /// <param name="updatedSignature">
        /// Изменённая подпись
        /// </param>
        [HttpPut]
        [ProducesResponseType(typeof(Signature), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(Signature updatedSignature, CancellationToken token)
        {
            if (await signatureRepository.IsExistByIdAsync(updatedSignature.Id, token))
            {
                await signatureRepository.EditAsync(updatedSignature, token);

                return Ok(updatedSignature);
            }
            return NotFound($"Подпись с id = {updatedSignature.Id} не найдена");
        }

        /// <summary>
        /// Удаляет подпись по Id
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken token)
        {
            if (await signatureRepository.IsExistByIdAsync(id, token))
            {
                await signatureRepository.DeleteAsync(id, token);

                return Ok();
            }
            return NotFound($"Подпись с id = {id} не найдена");
        }

        /// <summary>
        /// Добавляет подпись
        /// </summary>
        /// <param name="addableSignature">
        /// Добавляемая подпись
        /// </param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Signature), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] Signature addableSignature, CancellationToken token)
        {
            if (signatureRepository.IsExist(addableSignature))
            {
                return BadRequest("Данная подпись уже существует");
            }
            await signatureRepository.CreateAsync(addableSignature, token);

            return Ok(addableSignature);
        }
    }
}