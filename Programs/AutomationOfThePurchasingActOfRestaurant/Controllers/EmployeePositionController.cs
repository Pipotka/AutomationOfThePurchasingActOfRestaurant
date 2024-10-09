using AutoMapper;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.WriteRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Infrastructure;
using Company.AutomationOfThePurchasingActOfRestaurant.Models.CreateModelRequest;
using Company.AutomationOfThePurchasingActOfRestaurant.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Company.AutomationOfThePurchasingActOfRestaurant.Services;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.ModelServices;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts;
using Swashbuckle.AspNetCore.Annotations;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Controllers
{
    /// <summary>
    /// Контроллер для работы с должностями сотрудников
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class EmployeePositionController : ControllerBase
    {
        private readonly IEmployeePositionService employeePositionService;
        private readonly IPurchasingValidateService purchasingValidateService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="EmployeePositionController"/>
        /// </summary>
        public EmployeePositionController(IEmployeePositionService employeePositionService,
            IMapper mapper,
            IPurchasingValidateService purchasingValidateService)
        {
            this.employeePositionService = employeePositionService;
            this.mapper = mapper;
            this.purchasingValidateService = purchasingValidateService;
        }

        /// <summary>
        /// Получает должность по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(EmployeePositionResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [SwaggerOperation(OperationId = "GetEmployeePositionById")]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
        {
            var result = await employeePositionService.GetAsync(id, token);
            return Ok(mapper.Map<EmployeePositionResponseModel>(result));
        }

        /// <summary>
        /// Получает список всех должностей
        /// </summary>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(IEnumerable<EmployeePositionResponseModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(OperationId = "GetAllEmployeePositions")]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var result = await employeePositionService.GetAllAsync(token);
            return Ok(mapper.Map<IEnumerable<EmployeePositionResponseModel>>(result));
        }

        /// <summary>
        /// Получает должность сотрудника по названию
        /// </summary>
        [HttpGet("byName")]
        [ProducesResponseType(typeof(EmployeePositionResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
		[SwaggerOperation(OperationId = "GetEmployeePositionByName")]
		public async Task<IActionResult> GetByName([FromBody] string name, CancellationToken token)
        {
            var result = await employeePositionService.GetByNameAsync(name, token);

            return Ok(mapper.Map<EmployeeResponseModel>(result));
        }

        /// <summary>
        /// Изменяет должность
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(EmployeePositionResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation(OperationId = "UpdateEmployeePosition")]
        public async Task<IActionResult> Edit([FromBody] EmployeePositionResponseModel request, CancellationToken token)
        {
            var model = mapper.Map<EmployeePositionModel>(request);
            await purchasingValidateService.ValidateAsync(model, token);
            var result = await employeePositionService.UpdateAsync(model, token);
            return Ok(mapper.Map<EmployeePositionResponseModel>(result));
        }

        /// <summary>
        /// Удаляет должность по Id
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [SwaggerOperation(OperationId = "DeleteEmployeePosition")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            await employeePositionService.DeleteByIdAsync(id, token);
            return Ok();
        }

        /// <summary>
        /// Добавляет должность
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(typeof(EmployeePositionResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation(OperationId = "AddEmployeePosition")]
        public async Task<IActionResult> Create([FromBody] EmployeePositionRequest request, CancellationToken token)
        {
            var model = mapper.Map<EmployeePositionBaseModel>(request);
            await purchasingValidateService.ValidateAsync(model, token);
            var result = await employeePositionService.AddAsync(model, token);
            return Ok(mapper.Map<EmployeePositionResponseModel>(result));
        }

        /// <summary>
        /// Возвращает страницу должностей
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EmployeePositionResponseModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(OperationId = "GetPageOfEmployeePositions")]
        public async Task<IActionResult> GetPage([FromQuery] EmployeePositionSortBy sortBy, [FromQuery] int pageNumber, [FromQuery] int pageSize, CancellationToken token)
        {
            var result = await employeePositionService.GetPageAsync(sortBy, pageNumber, pageSize, token);
            return Ok(mapper.Map<EmployeePositionResponseModel>(result));
        }
    }
}
