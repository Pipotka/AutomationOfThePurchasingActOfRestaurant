using AutoMapper;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.WriteRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Infrastructure;
using Company.AutomationOfThePurchasingActOfRestaurant.Models.CreateModelRequest;
using Company.AutomationOfThePurchasingActOfRestaurant.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.ModelServices;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts;
using Swashbuckle.AspNetCore.Annotations;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Controllers
{
    /// <summary>
    /// Контроллер для работы с поставщиками
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService supplierService;
        private readonly IPurchasingValidateService purchasingValidateService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="SupplierController"/>
        /// </summary>
        public SupplierController(ISupplierService supplierService
            , IMapper mapper
            , IPurchasingValidateService purchasingValidateService)
        {
            this.supplierService = supplierService;
            this.mapper = mapper;
            this.purchasingValidateService = purchasingValidateService;
        }

        /// <summary>
        /// Получает поставщика по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(SupplierResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [SwaggerOperation(OperationId = "GetSupplierById")]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
        {
            var result = await supplierService.GetAsync(id, token);
            return Ok(mapper.Map<SupplierResponseModel>(result));
        }

        /// <summary>
        /// Получает список всех поставщиков
        /// </summary>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(IEnumerable<SupplierResponseModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(OperationId = "GetAllSuppliers")]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var result = await supplierService.GetAllAsync(token);
            return Ok(mapper.Map<IEnumerable<SupplierResponseModel>>(result));
        }

        /// <summary>
        /// Получает поставщика по фамилии
        /// </summary>
        [HttpGet("byLastName")]
        [ProducesResponseType(typeof(SupplierResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [SwaggerOperation(OperationId = "GetSupplierByLastName")]
        public async Task<IActionResult> GetByLastName([FromBody] string lastName, CancellationToken token)
        {
            var result = await supplierService.GetByLastNameAsync(lastName, token);
            return Ok(mapper.Map<SupplierResponseModel>(result));
        }

        /// <summary>
        /// Изменяет поставщика
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(SupplierResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation(OperationId = "UpdateSupplier")]
        public async Task<IActionResult> Edit([FromBody] SupplierResponseModel request, CancellationToken token)
        {
            var model = mapper.Map<SupplierModel>(request);
            await purchasingValidateService.ValidateAsync(model, token);
            var result = await supplierService.UpdateAsync(model, token);
            return Ok(mapper.Map<SupplierResponseModel>(result));
        }

        /// <summary>
        /// Удаляет поставщика по Id
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [SwaggerOperation(OperationId = "DeleteSupplier")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            await supplierService.DeleteByIdAsync(id, token);
            return Ok();
        }

        /// <summary>
        /// Добавляет нового поставщика
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(typeof(SupplierResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation(OperationId = "AddSupplier")]
        public async Task<IActionResult> Create([FromBody] SupplierRequest request, CancellationToken token)
        {
            var model = mapper.Map<SupplierBaseModel>(request);
            await purchasingValidateService.ValidateAsync(model, token);
            var result = await supplierService.AddAsync(model, token);
            return Ok(mapper.Map<SupplierResponseModel>(result));
        }

        /// <summary>
        /// Возвращает страницу поставщиков с сортировкой
        /// </summary>
        [HttpGet("GetPage")]
        [ProducesResponseType(typeof(IEnumerable<SupplierResponseModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(OperationId = "GetPageOfSuppliers")]
        public async Task<IActionResult> GetPage([FromQuery] SupplierSortBy sortBy, [FromQuery] int pageNumber, [FromQuery] int pageSize, CancellationToken token)
        {
            var result = await supplierService.GetPageAsync(sortBy, pageNumber, pageSize, token);
            return Ok(mapper.Map<IEnumerable<SupplierResponseModel>>(result));
        }
    }
}
