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
    /// Контроллер для работы с товарами
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class MerchandiseController : ControllerBase
    {
        private readonly IMerchandiseService merchandiseService;
        private readonly IPurchasingValidateService purchasingValidateService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="MerchandiseController"/>
        /// </summary>
        public MerchandiseController(IMerchandiseService merchandiseService,
            IMapper mapper,
            IPurchasingValidateService purchasingValidateService)
        {
            this.merchandiseService = merchandiseService;
            this.mapper = mapper;
            this.purchasingValidateService = purchasingValidateService;
        }

        /// <summary>
        /// Получает товар по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(MerchandiseResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [SwaggerOperation(OperationId = "GetMerchandiseById")]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
        {
            var result = await merchandiseService.GetAsync(id, token);
            return Ok(mapper.Map<MerchandiseResponseModel>(result));
        }

        /// <summary>
        /// Получает список всех товаров
        /// </summary>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(IEnumerable<MerchandiseResponseModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(OperationId = "GetAllMerchandises")]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var result = await merchandiseService.GetAllAsync(token);
            return Ok(mapper.Map<IEnumerable<MerchandiseResponseModel>>(result));
        }

        /// <summary>
        /// Получает список всех товаров с их связями
        /// </summary>
        [HttpGet("getAllWithLinks")]
        [ProducesResponseType(typeof(IEnumerable<MerchandiseResponseModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(OperationId = "GetAllMerchandisesWithLinks")]
        public async Task<IActionResult> GetAllWithLinksAsync(CancellationToken token)
        {
            var result = await merchandiseService.GetAllWithLinksAsync(token);
            return Ok(mapper.Map<IEnumerable<MerchandiseResponseModel>>(result));
        }

        /// <summary>
        /// Получает товар по названию
        /// </summary>
        [HttpGet("byName")]
        [ProducesResponseType(typeof(MerchandiseResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
		[SwaggerOperation(OperationId = "GetMerchandiseByName")]
		public async Task<IActionResult> GetByName([FromBody] string name, CancellationToken token)
        {
            var result = await merchandiseService.GetByNameAsync(name, token);
            return Ok(mapper.Map<MerchandiseResponseModel>(result));
        }

        /// <summary>
        /// Изменяет товар
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(MerchandiseResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation(OperationId = "UpdateMerchandise")]
        public async Task<IActionResult> Edit([FromBody] MerchandiseResponseModel request, CancellationToken token)
        {
            var model = mapper.Map<MerchandiseModel>(request);
            await purchasingValidateService.ValidateAsync(model, token);
            var result = await merchandiseService.UpdateAsync(model, token);
            return Ok(mapper.Map<MerchandiseResponseModel>(result));
        }

        /// <summary>
        /// Удаляет товар по Id
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [SwaggerOperation(OperationId = "DeleteMerchandise")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            await merchandiseService.DeleteByIdAsync(id, token);
            return Ok();
        }

        /// <summary>
        /// Добавляет новый товар
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(typeof(MerchandiseResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation(OperationId = "AddMerchandise")]
        public async Task<IActionResult> Create([FromBody] MerchandiseRequest request, CancellationToken token)
        {
            var model = mapper.Map<MerchandiseBaseModel>(request);
            await purchasingValidateService.ValidateAsync(model, token);
            var result = await merchandiseService.AddAsync(model, token);
            return Ok(mapper.Map<MerchandiseResponseModel>(result));
        }

        /// <summary>
        /// Возвращает страницу товаров
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MerchandiseResponseModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(OperationId = "GetPageOfMerchandises")]
        public async Task<IActionResult> GetPage([FromQuery] MerchandiseSortBy sortBy, [FromQuery] int pageNumber, [FromQuery] int pageSize, CancellationToken token)
        {
            var result = await merchandiseService.GetPageAsync(sortBy, pageNumber, pageSize, token);
            return Ok(mapper.Map<MerchandiseResponseModel>(result));
        }
    }
}