using AutomationOfThePurchasingActOfRestaurant.Models;
using AutomationOfThePurchasingActOfRestaurant.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutomationOfThePurchasingActOfRestaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeesRepository employeeRepository;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="EmployeeController"/>
        /// </summary>
        public EmployeeController(EmployeesRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Получает сотрудника по идентификатору
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            var result = await employeeRepository.GetAsync(id, token);
            if (result == null)
            {
                return NotFound($"Сотрудник с id = {id} не найден");
            }
            return Ok(result);
        }

        /// <summary>
        /// Получает список всех сотрудников
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var result = await employeeRepository.GetAllAsync(token);

            return Ok(result);
        }

        /// <summary>
        /// Изменяет сотрудника
        /// </summary>
        /// <param name="updatedEmployee">
        /// Изменённый сотрудник
        /// </param>
        [HttpPut]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(Employee updatedEmployee, CancellationToken token)
        {
            if (await employeeRepository.IsExistByIdAsync(updatedEmployee.Id, token))
            {
                await employeeRepository.EditAsync(updatedEmployee, token);

                return Ok(updatedEmployee);
            }
            return NotFound($"Сотрудник с id = {updatedEmployee.Id} не найден");
        }

        /// <summary>
        /// Удаляет сотрудника по Id
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken token)
        {
            if (await employeeRepository.IsExistByIdAsync(id, token))
            {
                await employeeRepository.DeleteAsync(id, token);

                return Ok();
            }
            return NotFound($"Сотрудник с id = {id} не найден");
        }

        /// <summary>
        /// Добавляет сотрудника
        /// </summary>
        /// <param name="addableEmployee">
        /// Добавляемый сотрудник
        /// </param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] Employee addableEmployee, CancellationToken token)
        {
            if (employeeRepository.IsExist(addableEmployee))
            {
                return BadRequest("Данный сотрудник уже существует");
            }
            await employeeRepository.CreateAsync(addableEmployee, token);

            return Ok(addableEmployee);
        }
    }
}
