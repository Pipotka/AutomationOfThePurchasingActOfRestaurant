using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.WriteRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.ReadRepositories;
using AutoMapper;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.Sorts;
using Company.AutomationOfThePurchasingActOfRestaurant.Infrastructure;
using Company.AutomationOfThePurchasingActOfRestaurant.Models.CreateModelRequest;
using Company.AutomationOfThePurchasingActOfRestaurant.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.ModelServices;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts;
using Swashbuckle.AspNetCore.Annotations;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.OpenXML.Excel;
using System.Net.Http;
using DocumentFormat.OpenXml.Vml.Office;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Controllers
{
    /// <summary>
    /// Контроллер для работы с формами закупок
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PurchaseFormController : ControllerBase
    {
        private readonly IPurchaseFormService purchaseFormService;
        private readonly IMerchandiseService merchandiseService;
        private readonly IPurchasingValidateService purchasingValidateService;
        private readonly IExcelTableService excelTableService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="PurchaseFormController"/>
        /// </summary>
        public PurchaseFormController(IPurchaseFormService purchaseFormService
            , IMapper mapper
            , IPurchasingValidateService purchasingValidateService
            , IExcelTableService excelTableService,
            IMerchandiseService merchandiseService)
        {
            this.purchaseFormService = purchaseFormService;
            this.mapper = mapper;
            this.purchasingValidateService = purchasingValidateService;
            this.excelTableService = excelTableService;
            this.merchandiseService = merchandiseService;
        }

        /// <summary>
        /// Получает форму закупки по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(PurchaseFormResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [SwaggerOperation(OperationId = "GetPurchaseFormById")]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
        {
            var result = await purchaseFormService.GetAsync(id, token);
            return Ok(mapper.Map<PurchaseFormResponseModel>(result));
        }

        /// <summary>
        /// Получает форму закупки со всеми связями по идентификатору
        /// </summary>
        [HttpGet("GetPurchaseFormWithAllLinks{id:guid}")]
        [ProducesResponseType(typeof(PurchaseFormResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [SwaggerOperation(OperationId = "GetPurchaseFormWithAllLinksById")]
        public async Task<IActionResult> GetWithAllLinks([FromRoute] Guid id, CancellationToken token)
        {
            var result = await purchaseFormService.GetWithAllLinksAsync(id, token);
            return Ok(mapper.Map<PurchaseFormResponseModel>(result));
        }

        /// <summary>
        /// Получает список всех форм закупок
        /// </summary>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(IEnumerable<PurchaseFormResponseModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(OperationId = "GetAllPurchaseForms")]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var result = await purchaseFormService.GetAllAsync(token);
            return Ok(mapper.Map<IEnumerable<PurchaseFormResponseModel>>(result));
        }

        /// <summary>
        /// Получает список всех форм закупок с их связями
        /// </summary>
        [HttpGet("GetAllWithAllLinks")]
        [ProducesResponseType(typeof(IEnumerable<PurchaseFormResponseModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(OperationId = "GetAllPurchaseFormsWithAllLinks")]
        public async Task<IActionResult> GetAllWithAllLinks(CancellationToken token)
        {
            var result = await purchaseFormService.GetAllWithAllLinksAsync(token);
            return Ok(mapper.Map<IEnumerable<PurchaseFormResponseModel>>(result));
        }

        /// <summary>
        /// Получает форму закупки по идентификатору кода формы
        /// </summary>
        [HttpGet("formKeyId={formKeyId:guid}")]
        [ProducesResponseType(typeof(PurchaseFormResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
		[SwaggerOperation(OperationId = "GetPurchaseFormByFormKey")]
		public async Task<IActionResult> GetByFormKey([FromRoute] Guid formKeyId, CancellationToken token)
        {
            var result = await purchaseFormService.GetByFormKeyAsync(formKeyId, token);
            return Ok(mapper.Map<PurchaseFormResponseModel>(result));
        }

        /// <summary>
        /// Изменяет форму закупки
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(PurchaseFormResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation(OperationId = "UpdatePurchaseForm")]
        public async Task<IActionResult> Edit([FromBody] PurchaseFormResponseModel request, CancellationToken token)
        {
            var model = mapper.Map<PurchaseFormModel>(request);
            await purchasingValidateService.ValidateAsync(model, token);
            for(var i = 0; i < model.PurchasedMerchandises.Count; i++)
            {
                var merchendise = model.PurchasedMerchandises.ElementAt(i);
                merchendise.PurchaseForm = model;
                await merchandiseService.UpdateAsync(merchendise, token);
            }
            var result = await purchaseFormService.UpdateAsync(model, token);
            return Ok(mapper.Map<PurchaseFormResponseModel>(result));
        }

        /// <summary>
        /// Удаляет форму закупки по Id
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [SwaggerOperation(OperationId = "DeletePurchaseForm")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            await purchaseFormService.DeleteByIdAsync(id, token);
            return Ok();
        }

        /// <summary>
        /// Добавляет новую форму закупки
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(typeof(PurchaseFormResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation(OperationId = "AddPurchaseForm")]
        public async Task<IActionResult> Create([FromBody] PurchaseFormRequest request, CancellationToken token)
        {
            var model = mapper.Map<PurchaseFormBaseModel>(request);
            await purchasingValidateService.ValidateAsync(model, token);
            var result = await purchaseFormService.AddAsync(model, token);
            for (var i = 0; i < model.PurchasedMerchandises.Count; i++)
            {
                var merchendise = model.PurchasedMerchandises.ElementAt(i);
                merchendise.PurchaseForm = result;
                await merchandiseService.UpdateAsync(merchendise, token);
            }
            return Ok(mapper.Map<PurchaseFormResponseModel>(result));
        }

        /// <summary>
        /// Возвращает страницу форм закупок с сортировкой
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PurchaseFormResponseModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(OperationId = "GetPageOfPurchaseForms")]
        public async Task<IActionResult> GetPage([FromQuery] PurchaseFormSortBy sortBy, [FromQuery] int pageNumber, [FromQuery] int pageSize, CancellationToken token)
        {
            var result = await purchaseFormService.GetPageAsync(sortBy, pageNumber, pageSize, token);
            return Ok(mapper.Map<IEnumerable<PurchaseFormResponseModel>>(result));
        }

        /// <summary>
        /// Возвращает Excel таблицу закупочного акта
        /// </summary>
        [HttpGet("ExportToExcelTable:{id:guid}")]
        [Produces("application/octet-stream")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [SwaggerOperation(OperationId = "ExportPurchaseFormToExcelTable")]
        public async Task<IActionResult> ExportToExcelTable([FromRoute] Guid id, CancellationToken token)
        {
            var result = await excelTableService.ExportPurchasingFormInTableAsync(id, token);
            
            result.Position = 0;

            return File(result,
                "application/octet-stream", 
                $"PurchaseFormExcelTable{id:N}.xlsx");
        }
    }
}
