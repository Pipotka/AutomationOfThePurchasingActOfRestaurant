using AutomationOfThePurchasingActOfRestaurant.Models;
using AutomationOfThePurchasingActOfRestaurant.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutomationOfThePurchasingActOfRestaurant.Controllers
{
    /// <summary>
    /// Контроллер для работы с единицами измерения
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class MeasurementUnitController : ControllerBase
    {
        private readonly MeasurementUnitsRepository measurementUnitRepository;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="MeasurementUnitController"/>
        /// </summary>
        public MeasurementUnitController(MeasurementUnitsRepository measurementUnitRepository)
        {
            this.measurementUnitRepository = measurementUnitRepository;
        }

        /// <summary>
        /// Получает единицу измерения по идентификатору
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MeasurementUnit), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            var result = await measurementUnitRepository.GetAsync(id, token);
            if (result == null)
            {
                return NotFound($"Единица измерения с id = {id} не найдена");
            }
            return Ok(result);
        }

        /// <summary>
        /// Получает список всех единиц измерения
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var result = await measurementUnitRepository.GetAllAsync(token);

            return Ok(result);
        }

        /// <summary>
        /// Изменяет единицу измерения
        /// </summary>
        /// <param name="updatedMeasurementUnit">
        /// Изменённая единица измерения
        /// </param>
        [HttpPut]
        [ProducesResponseType(typeof(MeasurementUnit), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(MeasurementUnit updatedMeasurementUnit, CancellationToken token)
        {
            if (await measurementUnitRepository.IsExistByIdAsync(updatedMeasurementUnit.Id, token))
            {
                await measurementUnitRepository.EditAsync(updatedMeasurementUnit, token);

                return Ok(updatedMeasurementUnit);
            }
            return NotFound($"Единица измерения с id = {updatedMeasurementUnit.Id} не найдена");
        }

        /// <summary>
        /// Удаляет единицу измерения по Id
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken token)
        {
            if (await measurementUnitRepository.IsExistByIdAsync(id, token))
            {
                await measurementUnitRepository.DeleteAsync(id, token);

                return Ok();
            }
            return NotFound($"Единица измерения с id = {id} не найдена");
        }

        /// <summary>
        /// Добавляет единицу измерения
        /// </summary>
        /// <param name="addableMeasurementUnit">
        /// Добавляемая единица измерения
        /// </param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MeasurementUnit), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] MeasurementUnit addableMeasurementUnit, CancellationToken token)
        {
            if (measurementUnitRepository.IsExist(addableMeasurementUnit))
            {
                return BadRequest("Данная единица измерения уже существует");
            }
            await measurementUnitRepository.CreateAsync(addableMeasurementUnit, token);

            return Ok(addableMeasurementUnit);
        }
    }
}
