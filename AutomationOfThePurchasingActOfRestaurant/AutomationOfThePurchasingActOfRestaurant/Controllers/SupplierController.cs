using AutomationOfThePurchasingActOfRestaurant.Models;
using AutomationOfThePurchasingActOfRestaurant.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutomationOfThePurchasingActOfRestaurant.Controllers
{
    /// <summary>
    /// Контроллер для работы с поставщиками
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class SupplierController : ControllerBase
    {
        private readonly SuppliersRepository supplierRepository;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="SupplierController"/>
        /// </summary>
        public SupplierController(SuppliersRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        /// <summary>
        /// Получает поставщика по идентификатору
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Supplier), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            var result = await supplierRepository.GetAsync(id, token);
            if (result == null)
            {
                return NotFound($"Поставщик с id = {id} не найден");
            }
            return Ok(result);
        }

        /// <summary>
        /// Получает список всех поставщиков
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var result = await supplierRepository.GetAllAsync(token);

            return Ok(result);
        }

        /// <summary>
        /// Изменяет поставщика
        /// </summary>
        /// <param name="updatedSupplier">
        /// Изменённый поставщик
        /// </param>
        [HttpPut]
        [ProducesResponseType(typeof(Supplier), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(Supplier updatedSupplier, CancellationToken token)
        {
            if (await supplierRepository.IsExistByIdAsync(updatedSupplier.Id, token))
            {
                await supplierRepository.EditAsync(updatedSupplier, token);

                return Ok(updatedSupplier);
            }
            return NotFound($"Поставщик с id = {updatedSupplier.Id} не найден");
        }

        /// <summary>
        /// Удаляет поставщика по Id
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken token)
        {
            if (await supplierRepository.IsExistByIdAsync(id, token))
            {
                await supplierRepository.DeleteAsync(id, token);

                return Ok();
            }
            return NotFound($"Поставщик с id = {id} не найден");
        }

        /// <summary>
        /// Добавляет поставщика
        /// </summary>
        /// <param name="addableSupplier">
        /// Добавляемый поставщик
        /// </param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Supplier), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] Supplier addableSupplier, CancellationToken token)
        {
            if (supplierRepository.IsExist(addableSupplier))
            {
                return BadRequest("Данный поставщик уже существует");
            }
            await supplierRepository.CreateAsync(addableSupplier, token);

            return Ok(addableSupplier);
        }
    }
}
