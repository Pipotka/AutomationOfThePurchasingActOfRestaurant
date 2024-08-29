using AutomationOfThePurchasingActOfRestaurant.Models;
using AutomationOfThePurchasingActOfRestaurant.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutomationOfThePurchasingActOfRestaurant.Controllers
{
    /// <summary>
    /// Контроллер для работы с должностями сотрудников
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class EmployeePositionController : ControllerBase
    {
        private readonly EmployeePositionsRepository employeePositionRepository;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="EmployeePositionController"/>
        /// </summary>
        public EmployeePositionController(EmployeePositionsRepository employeePositionRepository)
        {
            this.employeePositionRepository = employeePositionRepository;
        }

        /// <summary>
        /// Получает должность сотрудника по идентификатору
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EmployeePosition), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            var result = await employeePositionRepository.GetAsync(id, token);
            if (result == null)
            {
                return NotFound($"Должность сотрудника с id = {id} не найдена");
            }
            return Ok(result);
        }

        /// <summary>
        /// Получает список всех должностей сотрудников
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var result = await employeePositionRepository.GetAllAsync(token);

            return Ok(result);
        }

        /// <summary>
        /// Изменяет должность сотрудника
        /// </summary>
        /// <param name="updatedEmployeePosition">
        /// Изменённая должность сотрудника
        /// </param>
        [HttpPut]
        [ProducesResponseType(typeof(EmployeePosition), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(EmployeePosition updatedEmployeePosition, CancellationToken token)
        {
            if (await employeePositionRepository.IsExistByIdAsync(updatedEmployeePosition.Id, token))
            {
                await employeePositionRepository.EditAsync(updatedEmployeePosition, token);

                return Ok(updatedEmployeePosition);
            }
            return NotFound($"Должность сотрудника с id = {updatedEmployeePosition.Id} не найдена");
        }

        /// <summary>
        /// Удаляет должность сотрудника по Id
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken token)
        {
            if (await employeePositionRepository.IsExistByIdAsync(id, token))
            {
                await employeePositionRepository.DeleteAsync(id, token);

                return Ok();
            }
            return NotFound($"Должность сотрудника с id = {id} не найдена");
        }

        /// <summary>
        /// Добавляет должность сотрудника
        /// </summary>
        /// <param name="addableEmployeePosition">
        /// Добавляемая должность сотрудника
        /// </param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(EmployeePosition), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] EmployeePosition addableEmployeePosition, CancellationToken token)
        {
            if (employeePositionRepository.IsExist(addableEmployeePosition))
            {
                return BadRequest("Данная должность сотрудника уже существует");
            }
            await employeePositionRepository.CreateAsync(addableEmployeePosition, token);

            return Ok(addableEmployeePosition);
        }
    }
}
