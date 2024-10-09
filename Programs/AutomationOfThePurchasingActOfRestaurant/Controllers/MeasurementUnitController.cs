using AutoMapper;
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
    /// Контроллер для работы с единицами измерения
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class MeasurementUnitController : ControllerBase
    {
        private readonly IMeasurementUnitService measurementUnitService;
        private readonly IPurchasingValidateService purchasingValidateService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="MeasurementUnitController"/>
        /// </summary>
        public MeasurementUnitController(IMeasurementUnitService measurementUnitService
            , IMapper mapper
            , IPurchasingValidateService purchasingValidateService)
        {
            this.measurementUnitService = measurementUnitService;
            this.mapper = mapper;
            this.purchasingValidateService = purchasingValidateService;
        }

        /// <summary>
        /// Получает единицу измерения по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(MeasurementUnitResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [SwaggerOperation(OperationId = "GetMeasurementUnitById")]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
        {
            var result = await measurementUnitService.GetAsync(id, token);
            return Ok(mapper.Map<MeasurementUnitResponseModel>(result));
        }

        /// <summary>
        /// Получает список всех единиц измерения
        /// </summary>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(IEnumerable<MeasurementUnitResponseModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(OperationId = "GetAllMeasurementUnits")]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var result = await measurementUnitService.GetAllAsync(token);
            return Ok(mapper.Map<IEnumerable<MeasurementUnitResponseModel>>(result));
        }

        /// <summary>
        /// Получает единицу измерения по названию
        /// </summary>
        [HttpGet("byName")]
        [ProducesResponseType(typeof(MeasurementUnitResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
		[SwaggerOperation(OperationId = "GetMeasurementUnitByName")]
		public async Task<IActionResult> GetByName([FromBody] string name, CancellationToken token)
        {
            var result = await measurementUnitService.GetByNameAsync(name, token);
            return Ok(mapper.Map<MeasurementUnitResponseModel>(result));
        }

        /// <summary>
        /// Получает единицу измерения по коду ОКЕИ
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(MeasurementUnitResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
		[SwaggerOperation(OperationId = "GetMeasurementUnitByOKEI")]
		public async Task<IActionResult> GetByOKEIKey([FromBody] string OKEIKey, CancellationToken token)
        {
            var result = await measurementUnitService.GetByOKEIKeyAsync(OKEIKey, token);
            return Ok(mapper.Map<MeasurementUnitResponseModel>(result));
        }

        /// <summary>
        /// Изменяет единицу измерения
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(MeasurementUnitResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation(OperationId = "UpdateMeasurementUnit")]
        public async Task<IActionResult> Edit([FromBody] MeasurementUnitResponseModel request, CancellationToken token)
        {
            var model = mapper.Map<MeasurementUnitModel>(request);
            await purchasingValidateService.ValidateAsync(model, token);
            var result = await measurementUnitService.UpdateAsync(model, token);
            return Ok(mapper.Map<MeasurementUnitResponseModel>(result));
        }

        /// <summary>
        /// Удаляет единицу измерения по Id
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [SwaggerOperation(OperationId = "DeleteMeasurementUnit")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            await measurementUnitService.DeleteByIdAsync(id, token);
            return Ok();
        }

        /// <summary>
        /// Добавляет новую единицу измерения
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(typeof(MeasurementUnitResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation(OperationId = "AddMeasurementUnit")]
        public async Task<IActionResult> Create([FromBody] MeasurementUnitRequest request, CancellationToken token)
        {
            var model = mapper.Map<MeasurementUnitBaseModel>(request);
            await purchasingValidateService.ValidateAsync(model, token);
            var result = await measurementUnitService.AddAsync(model, token);
            return Ok(mapper.Map<MeasurementUnitResponseModel>(result));
        }
    }
}
