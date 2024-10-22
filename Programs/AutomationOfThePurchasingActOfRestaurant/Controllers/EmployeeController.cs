using AutoMapper;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.WriteRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Infrastructure;
using Company.AutomationOfThePurchasingActOfRestaurant.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Models.CreateModelRequest;
using Company.AutomationOfThePurchasingActOfRestaurant.Services;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.ModelServices;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Controllers
{
    /// <summary>
    /// Контроллер для работы с сотрудниками
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        private readonly IPurchasingValidateService purchasingValidateService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="EmployeeController"/>
        /// </summary>
        public EmployeeController(IEmployeeService employeeService,
            IMapper mapper,
            IPurchasingValidateService purchasingValidateService)
        {
            this.employeeService = employeeService;
            this.mapper = mapper;
            this.purchasingValidateService = purchasingValidateService;
        }

        /// <summary>
        /// Получает сотрудника по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(EmployeeResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [SwaggerOperation(OperationId = "GetEmployeeById")]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
        {
            var result = await employeeService.GetAsync(id, token);

            return Ok(mapper.Map<EmployeeResponseModel>(result));
        }

        /// <summary>
        /// Получает список всех сотрудников
        /// </summary>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(IEnumerable<EmployeeResponseModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(OperationId = "GetAllEmployees")]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var result = await employeeService.GetAllAsync(token);

            return Ok(mapper.Map<IEnumerable<EmployeeResponseModel>>(result));
        }

        /// <summary>
        /// Получает список всех сотрудников с их связями
        /// </summary>
        [HttpGet("getAllWithLinks")]
        [ProducesResponseType(typeof(IEnumerable<EmployeeResponseModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(OperationId = "GetAllEmployeesWithLinks")]
        public async Task<IActionResult> GetAllWithLinks(CancellationToken token)
        {
            var result = await employeeService.GetAllWithLinksAsync(token);

            return Ok(mapper.Map<IEnumerable<EmployeeResponseModel>>(result));
        }

        /// <summary>
        /// Получает сотрудника по имени
        /// </summary>
        [HttpGet("byLastName")]
        [ProducesResponseType(typeof(EmployeeResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [SwaggerOperation(OperationId = "GetEmployeeByLastName")]
        public async Task<IActionResult> GetByLastName([FromBody] string lastName, CancellationToken token)
        {
            var result = await employeeService.GetByLastNameAsync(lastName, token);

            return Ok(mapper.Map<EmployeeResponseModel>(result));
        }

        /// <summary>
        /// Изменяет сотрудника
        /// </summary>
        /// <param name="request">
        /// Изменённый сотрудник
        /// </param>
        [HttpPut]
        [ProducesResponseType(typeof(EmployeeResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation(OperationId = "UpdateEmployee")]
        public async Task<IActionResult> Edit([FromBody] EmployeeResponseModel request, CancellationToken token)
        {
            var model = mapper.Map<EmployeeModel>(request);
            await purchasingValidateService.ValidateAsync(model, token);
            var result = await employeeService.UpdateAsync(model, token);

            return Ok(mapper.Map<EmployeeResponseModel>(result));
        }

        /// <summary>
        /// Удаляет сотрудника по Id
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [SwaggerOperation(OperationId = "DeleteEmployee")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            await employeeService.DeleteByIdAsync(id, token);

            return Ok();
        }

        /// <summary>
        /// Добавляет сотрудника
        /// </summary>
        /// <param name="request">
        /// Добавляемый сотрудник
        /// </param>
        [HttpPost]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(typeof(EmployeeResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation(OperationId = "AddEmployee")]
        public async Task<IActionResult> Create([FromBody] EmployeeRequest request, CancellationToken token)
        {
            var model = mapper.Map<EmployeeBaseModel>(request);
            await purchasingValidateService.ValidateAsync(model, token);
            var result = await employeeService.AddAsync(model, token);

            return Ok(mapper.Map<EmployeeResponseModel>(result));
        }

        /// <summary>
        /// возвращает сраницу сотрудников
        /// </summary>
        /// <param name="sortBy">
        /// метод сортировки
        /// </param>
        /// <param name="pageNumber">
        /// номер страницы
        /// </param>
        /// <param name="pageSize">
        /// размер страницы
        /// </param>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EmployeeResponseModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(OperationId = "GetPageOfEmployees")]
        public async Task<IActionResult> GetPage([FromQuery] EmployeeSortBy sortBy, [FromQuery] int pageNumber, [FromQuery] int pageSize, CancellationToken token)
        {
            var result = await employeeService.GetPageAsync(sortBy, pageNumber, pageSize, token);

            return Ok(mapper.Map<EmployeeResponseModel>(result));
        }
    }
}
