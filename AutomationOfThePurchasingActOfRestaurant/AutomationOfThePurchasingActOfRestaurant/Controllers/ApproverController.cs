using AutomationOfThePurchasingActOfRestaurant.Models;
using AutomationOfThePurchasingActOfRestaurant.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutomationOfThePurchasingActOfRestaurant.Controllers
{
    /// <summary>
    /// Контроллер для работы с утверждающими
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ApproverController : ControllerBase
    {
        private readonly ApproversRepository approverRepository;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ApproverController"/>
        /// </summary>
        public ApproverController(ApproversRepository approverRepository)
        {
            this.approverRepository = approverRepository;
        }

        /// <summary>
        /// Получает утверждающего по идентификатору
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Approver), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            var result = await approverRepository.GetAsync(id, token);
            if (result == null)
            {
                return NotFound($"Утверждающий с id = {id} не найден");
            }
            return Ok(result);
        }

        /// <summary>
        /// Получает список всех утверждающих
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var result = await approverRepository.GetAllAsync(token);

            return Ok(result);
        }

        /// <summary>
        /// Изменяет утверждающего
        /// </summary>
        /// <param name="updatedApprover">
        /// Изменённый утверждающий
        /// </param>
        [HttpPut]
        [ProducesResponseType(typeof(Approver), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(Approver updatedApprover, CancellationToken token)
        {
            if (await approverRepository.IsExistByIdAsync(updatedApprover.Id, token))
            {
                await approverRepository.EditAsync(updatedApprover, token);
                return Ok(updatedApprover);
            }
            return NotFound($"Утверждающий с id = {updatedApprover.Id} не найден");
        }

        /// <summary>
        /// Удаляет утверждающего по Id
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken token)
        {
            if (await approverRepository.IsExistByIdAsync(id, token))
            {
                await approverRepository.DeleteAsync(id, token);
                return Ok();
            }
            return NotFound($"Утверждающий с id = {id} не найден");
        }

        /// <summary>
        /// Добавляет утверждающего
        /// </summary>
        /// <param name="addableApprover">
        /// Добавляемый утверждающий
        /// </param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Approver), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] Approver addableApprover, CancellationToken token)
        {
            if (approverRepository.IsExist(addableApprover))
            {
                return BadRequest("Данный утверждающий уже существует");
            }
            await approverRepository.CreateAsync(addableApprover, token);

            return Ok(addableApprover);
        }
    }
}
