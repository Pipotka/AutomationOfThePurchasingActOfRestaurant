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
    /// Контроллер для работы с кодом форм
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class FormKeyController : ControllerBase
    {
        private readonly IFormKeyService formKeyService;
        private readonly IPurchasingValidateService purchasingValidateService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="FormKeyController"/>
        /// </summary>
        public FormKeyController(IFormKeyService formKeyService,
            IMapper mapper
            ,IPurchasingValidateService purchasingValidateService)
        {
            this.formKeyService = formKeyService;
            this.mapper = mapper;
            this.purchasingValidateService = purchasingValidateService;
        }

        /// <summary>
        /// Получает код формы по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(FormKeyResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [SwaggerOperation(OperationId = "GetFormKeyById")]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
        {
            var result = await formKeyService.GetAsync(id, token);
            return Ok(mapper.Map<FormKeyResponseModel>(result));
        }

        /// <summary>
        /// Получает список всех кодов форм
        /// </summary>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(IEnumerable<FormKeyResponseModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(OperationId = "GetAllFormKeys")]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var result = await formKeyService.GetAllAsync(token);
            return Ok(mapper.Map<IEnumerable<FormKeyResponseModel>>(result));
        }

        /// <summary>
        /// Изменяет код формы
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(FormKeyResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation(OperationId = "UpdateFormKey")]
        public async Task<IActionResult> Edit([FromBody] FormKeyResponseModel request, CancellationToken token)
        {
            var model = mapper.Map<FormKeyModel>(request);
            await purchasingValidateService.ValidateAsync(model, token);
            var result = await formKeyService.UpdateAsync(model, token);
            return Ok(mapper.Map<FormKeyResponseModel>(result));
        }

        /// <summary>
        /// Удаляет код формы по Id
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [SwaggerOperation(OperationId = "DeleteFormKey")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            await formKeyService.DeleteByIdAsync(id, token);
            return Ok();
        }

        /// <summary>
        /// Добавляет новый код формы
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(typeof(FormKeyResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation(OperationId = "AddFormKey")]
        public async Task<IActionResult> Create([FromBody] FormKeyRequest request, CancellationToken token)
        {
            var model = mapper.Map<FormKeyBaseModel>(request);
            await purchasingValidateService.ValidateAsync(model, token);
            var result = await formKeyService.AddAsync(model, token);
            return Ok(mapper.Map<FormKeyResponseModel>(result));
        }

        /// <summary>
        /// Возвращает страницу код форм
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FormKeyResponseModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(OperationId = "GetPageOfFormKeys")]
        public async Task<IActionResult> GetPage([FromQuery] FormKeySortBy sortBy, [FromQuery] int pageNumber, [FromQuery] int pageSize, CancellationToken token)
        {
            var result = await formKeyService.GetPageAsync(sortBy, pageNumber, pageSize, token);
            return Ok(mapper.Map<FormKeyResponseModel>(result));
        }
    }

}
