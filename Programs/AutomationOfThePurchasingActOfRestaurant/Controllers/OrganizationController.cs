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
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.ModelServices;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts;
using Swashbuckle.AspNetCore.Annotations;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Controllers
{
    /// <summary>
    /// Контроллер для работы с организациями
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService organizationService;
        private readonly IPurchasingValidateService purchasingValidateService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="OrganizationController"/>
        /// </summary>
        public OrganizationController(IOrganizationService organizationService
            , IMapper mapper
            , IPurchasingValidateService purchasingValidateService)
        {
            this.organizationService = organizationService;
            this.mapper = mapper;
            this.purchasingValidateService = purchasingValidateService;
        }

        /// <summary>
        /// Получает организацию по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(OrganizationResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [SwaggerOperation(OperationId = "GetOrganizationById")]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
        {
            var result = await organizationService.GetAsync(id, token);
            return Ok(mapper.Map<OrganizationResponseModel>(result));
        }

        /// <summary>
        /// Получает список всех организаций
        /// </summary>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(IEnumerable<OrganizationResponseModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(OperationId = "GetAllOrganizations")]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var result = await organizationService.GetAllAsync(token);
            return Ok(mapper.Map<IEnumerable<OrganizationResponseModel>>(result));
        }

        /// <summary>
        /// Получает организацию по названию
        /// </summary>
        [HttpGet("byName")]
        [ProducesResponseType(typeof(OrganizationResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
		[SwaggerOperation(OperationId = "GetOrganizationByName")]
		public async Task<IActionResult> GetByName([FromBody] string name, CancellationToken token)
        {
            var result = await organizationService.GetByNameAsync(name, token);
            return Ok(mapper.Map<OrganizationResponseModel>(result));
        }

        /// <summary>
        /// Изменяет организацию
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(OrganizationResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation(OperationId = "UpdateOrganization")]
        public async Task<IActionResult> Edit([FromBody] OrganizationResponseModel request, CancellationToken token)
        {
            var model = mapper.Map<OrganizationModel>(request);
            await purchasingValidateService.ValidateAsync(model, token);
            var result = await organizationService.UpdateAsync(model, token);
            return Ok(mapper.Map<OrganizationResponseModel>(result));
        }

        /// <summary>
        /// Удаляет организацию по Id
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [SwaggerOperation(OperationId = "DeleteOrganization")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            await organizationService.DeleteByIdAsync(id, token);
            return Ok();
        }

        /// <summary>
        /// Добавляет новую организацию
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(typeof(OrganizationResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation(OperationId = "AddOrganization")]
        public async Task<IActionResult> Create([FromBody] OrganizationRequest request, CancellationToken token)
        {
            var model = mapper.Map<OrganizationBaseModel>(request);
            await purchasingValidateService.ValidateAsync(model, token);
            var result = await organizationService.AddAsync(model, token);
            return Ok(mapper.Map<OrganizationResponseModel>(result));
        }

        /// <summary>
        /// Возвращает страницу организаций с сортировкой
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrganizationResponseModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(OperationId = "GetPageOfOrganizations")]
        public async Task<IActionResult> GetPage([FromQuery] OrganizationSortBy sortBy, [FromQuery] int pageNumber, [FromQuery] int pageSize, CancellationToken token)
        {
            var result = await organizationService.GetPageAsync(sortBy, pageNumber, pageSize, token);
            return Ok(mapper.Map<IEnumerable<OrganizationResponseModel>>(result));
        }
    }
}
