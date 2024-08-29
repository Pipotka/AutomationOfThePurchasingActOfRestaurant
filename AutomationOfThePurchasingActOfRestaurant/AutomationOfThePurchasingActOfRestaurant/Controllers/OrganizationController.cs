using AutomationOfThePurchasingActOfRestaurant.Models;
using AutomationOfThePurchasingActOfRestaurant.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutomationOfThePurchasingActOfRestaurant.Controllers
{
    /// <summary>
    /// Контроллер для работы с организациями
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class OrganizationController : ControllerBase
    {
        private readonly OrganizationsRepository OrganizationRepository;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="FormKeyController"/>
        /// </summary>
        public OrganizationController(OrganizationsRepository organizationRepository)
        {
            this.OrganizationRepository = organizationRepository;
        }

        /// <summary>
        /// Получает организацию по индентификатору
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Organization), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            var result = await OrganizationRepository.GetAsync(id, token);
            if (result == null)
            {
                return NotFound($"Организация с id = {id} не найдена");
            }
            return Ok(result);
        }

        /// <summary>
        /// Получает список всех организаций
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var result = await OrganizationRepository.GetAllAsync(token);

            return Ok(result);
        }

        /// <summary>
        /// Изменяет организацию
        /// </summary>
        /// <param name="updatedOrganization">
        /// Изменённая организация
        /// </param>
        [HttpPut]
        [ProducesResponseType(typeof(Organization), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(Organization updatedOrganization, CancellationToken token)
        {
            if (await OrganizationRepository.IsExistByIdAsync(updatedOrganization.Id, token))
            {
                await OrganizationRepository
                    .EditAsync(updatedOrganization, token);

                return Ok(updatedOrganization);
            }
            return NotFound($"Организация с id = {updatedOrganization.Id} не найдена");
        }

        /// <summary>
        /// Удаляет организацию по Id
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken token)
        {
            if (await OrganizationRepository.IsExistByIdAsync(id, token))
            {
                await OrganizationRepository.DeleteAsync(id, token);

                return Ok();
            }
            return NotFound($"Организация с id = {id} не найден");
        }

        /// <summary>
        /// Добавляет организацию
        /// </summary>
        /// <param name="addableOrganization">
        /// Добавляемая организация
        /// </param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Organization), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] Organization addableOrganization, CancellationToken token)
        {
            if (OrganizationRepository.IsExist(addableOrganization))
            {
                return BadRequest("Данная организация уже существует");
            }
            await OrganizationRepository.CreateAsync(addableOrganization, token);

            return Ok(addableOrganization);
        }
    }
}
