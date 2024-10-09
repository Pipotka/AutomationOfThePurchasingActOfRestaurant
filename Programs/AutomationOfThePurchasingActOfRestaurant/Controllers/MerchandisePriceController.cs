using AutoMapper;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
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
    /// Контроллер для работы с ценами товаров
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class MerchandisePriceController : ControllerBase
    {
        private readonly IMerchandisePriceService merchandisePriceService;
        private readonly IPurchasingValidateService purchasingValidateService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="MerchandisePriceController"/>
        /// </summary>
        public MerchandisePriceController(IMerchandisePriceService merchandisePriceService,
            IMapper mapper,
            IPurchasingValidateService purchasingValidateService)
        {
            this.merchandisePriceService = merchandisePriceService;
            this.mapper = mapper;
            this.purchasingValidateService = purchasingValidateService;
        }

        /// <summary>
        /// Получает цену товара по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(MerchandisePriceResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [SwaggerOperation(OperationId = "GetMerchandisePriceById")]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
        {
            var result = await merchandisePriceService.GetAsync(id, token);
            return Ok(mapper.Map<MerchandisePriceResponseModel>(result));
        }

        /// <summary>
        /// Получает список всех цен товаров
        /// </summary>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(IEnumerable<MerchandisePriceResponseModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(OperationId = "GetAllMerchandisePrices")]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var result = await merchandisePriceService.GetAllAsync(token);
            return Ok(mapper.Map<IEnumerable<MerchandisePriceResponseModel>>(result));
        }

        /// <summary>
        /// Получает цену по идентификатору товара
        /// </summary>
        [HttpGet("MerchandiseId={merchandiseId:guid}")]
        [ProducesResponseType(typeof(MerchandisePriceResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
		[SwaggerOperation(OperationId = "GetMerchandisePriceByMerchandiseId")]
		public async Task<IActionResult> GetByMerchandiseId([FromRoute] Guid merchandiseId, CancellationToken token)
        {
            var result = await merchandisePriceService.GetByMerchandiseIdAsync(merchandiseId, token);
            return Ok(mapper.Map<MerchandisePriceResponseModel>(result));
        }

        /// <summary>
        /// Изменяет цену товара
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(MerchandisePriceResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation(OperationId = "UpdateMerchandisePrice")]
        public async Task<IActionResult> Edit([FromBody] MerchandisePriceResponseModel request, CancellationToken token)
        {
            var model = mapper.Map<MerchandisePriceModel>(request);
            await purchasingValidateService.ValidateAsync(model, token);
            var result = await merchandisePriceService.UpdateAsync(model, token);
            return Ok(mapper.Map<MerchandisePriceResponseModel>(result));
        }

        /// <summary>
        /// Удаляет цену товара по Id
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [SwaggerOperation(OperationId = "DeleteMerchandisePrice")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            await merchandisePriceService.DeleteByIdAsync(id, token);
            return Ok();
        }

        /// <summary>
        /// Добавляет новую цену товара
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(typeof(MerchandisePriceResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation(OperationId = "AddMerchandisePrice")]
        public async Task<IActionResult> Create([FromBody] MerchandisePriceRequest request, CancellationToken token)
        {
            var model = mapper.Map<MerchandisePriceBaseModel>(request);
            await purchasingValidateService.ValidateAsync(model, token);
            var result = await merchandisePriceService.AddAsync(model, token);
            return Ok(mapper.Map<MerchandisePriceResponseModel>(result));
        }
    }
}
