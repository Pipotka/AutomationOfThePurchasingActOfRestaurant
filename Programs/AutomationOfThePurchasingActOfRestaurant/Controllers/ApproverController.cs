using AutoMapper;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;
using Company.AutomationOfThePurchasingActOfRestaurant.Infrastructure;
using Company.AutomationOfThePurchasingActOfRestaurant.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Models.CreateModelRequest;
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
    /// Контроллер для работы с утверждающими
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ApproverController : ControllerBase
    {
        private readonly IApproverService approverService;
        private readonly IPurchasingValidateService purchasingValidateService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ApproverController"/>
        /// </summary>
        public ApproverController(IApproverService approverService
            , IPurchasingValidateService purchasingValidateService
            , IMapper mapper)
        {
            this.approverService = approverService;
            this.mapper = mapper;
            this.purchasingValidateService = purchasingValidateService;
        }

        /// <summary>
        /// Получает утверждающего по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ApproverResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [SwaggerOperation(OperationId = "GetApproverById")]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
        {
            var result = await approverService.GetAsync(id, token);

            return Ok(mapper.Map<ApproverResponseModel>(result));
        }

        /// <summary>
        /// Получает список всех утверждающих
        /// </summary>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(IEnumerable<ApproverResponseModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(OperationId = "GetAllApprovers")]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var result = await approverService.GetAllAsync(token);

            return Ok(mapper.Map<IEnumerable<ApproverResponseModel>>(result));
        }

        /// <summary>
        /// Получает список всех утверждающих с их связями
        /// </summary>
        [HttpGet("GetAllWithAllLinks")]
        [ProducesResponseType(typeof(IEnumerable<ApproverResponseModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(OperationId = "GetAllApproversWithAllLinks")]
        public async Task<IActionResult> GetAllWithAllLinks(CancellationToken token)
        {
            var result = await approverService.GetAllWithAllLinksAsync(token);

            return Ok(mapper.Map<IEnumerable<ApproverResponseModel>>(result));
        }

        /// <summary>
        /// Получает утверждающего по имени
        /// </summary>
        [HttpGet("byLastName")]
        [ProducesResponseType(typeof(ApproverResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [SwaggerOperation(OperationId = "GetApproverByLastName")]
        public async Task<IActionResult> GetByLastName([FromBody] string lastName, CancellationToken token)
        {
            var result = await approverService.GetByLastNameAsync(lastName, token);

            return Ok(mapper.Map<ApproverResponseModel>(result));
        }

        /// <summary>
        /// Изменяет утверждающего
        /// </summary>
        /// <param name="request">
        /// Изменённый утверждающий
        /// </param>
        [HttpPut]
        [ProducesResponseType(typeof(ApproverResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation(OperationId = "UpdateApprover")]
        public async Task<IActionResult> Edit([FromBody] ApproverResponseModel request, CancellationToken token)
        {
            var model = mapper.Map<ApproverModel>(request);
            await purchasingValidateService.ValidateAsync(model, token);
            var result = await approverService.UpdateAsync(model, token);

            return Ok(mapper.Map<ApproverResponseModel>(result));
        }

        /// <summary>
        /// Удаляет утверждающего по Id
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [SwaggerOperation(OperationId = "DeleteApprover")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            await approverService.DeleteByIdAsync(id, token);

            return Ok();
        }

        /// <summary>
        /// Добавляет утверждающего
        /// </summary>
        /// <param name="request">
        /// Добавляемый утверждающий
        /// </param>
        [HttpPost]
        [ProducesResponseType(typeof(ApproverResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation(OperationId = "AddApprover")]
        public async Task<IActionResult> Create([FromBody] ApproverRequest request, CancellationToken token)
        {
            var model = mapper.Map<ApproverBaseModel>(request);
            await purchasingValidateService.ValidateAsync(model, token);
            var result = await approverService.AddAsync(model, token);

            return Ok(mapper.Map<ApproverResponseModel>(result));
        }

        /// <summary>
        /// возвращает сраницу утверждающих
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
        [ProducesResponseType(typeof(IEnumerable<ApproverResponseModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(OperationId = "GetPageOfApprovers")]
        public async Task<IActionResult> GetPage([FromQuery] ApproverSortBy sortBy, [FromQuery] int pageNumber, [FromQuery] int pageSize, CancellationToken token)
        {
            var result = await approverService.GetPageAsync(sortBy, pageNumber, pageSize, token);

            return Ok(mapper.Map<ApproverResponseModel>(result));
        }
    }
}
