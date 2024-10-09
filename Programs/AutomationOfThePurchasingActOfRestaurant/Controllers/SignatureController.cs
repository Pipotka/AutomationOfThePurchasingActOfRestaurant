using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.WriteRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using AutoMapper;
using Company.AutomationOfThePurchasingActOfRestaurant.Infrastructure;
using Company.AutomationOfThePurchasingActOfRestaurant.Models.CreateModelRequest;
using Company.AutomationOfThePurchasingActOfRestaurant.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.ModelServices;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.Utilities;
using System.Drawing;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts;
using Swashbuckle.AspNetCore.Annotations;


namespace Company.AutomationOfThePurchasingActOfRestaurant.Controllers
{
    /// <summary>
    /// Контроллер для работы с подписями
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class SignatureController : ControllerBase
    {
        private readonly ISignatureService signatureService;
        private readonly IPurchasingValidateService purchasingValidateService;
        private readonly IImageCreatorService imageCreatorService;
        private readonly IImageEditorService imageEditorService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="SignatureController"/>
        /// </summary>
        public SignatureController(ISignatureService signatureService,
            IMapper mapper,
            IImageEditorService imageEditorService,
            IImageCreatorService imageCreatorService
            , IPurchasingValidateService purchasingValidateService)
        {
            this.signatureService = signatureService;
            this.mapper = mapper;
            this.imageEditorService = imageEditorService;
            this.imageCreatorService = imageCreatorService;
            this.purchasingValidateService = purchasingValidateService;
        }

        /// <summary>
        /// Получает подпись по идентификатору
        /// </summary>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(SignatureResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [SwaggerOperation(OperationId = "GetSignatureById")]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
        {
            var result = await signatureService.GetAsync(id, token);
            return Ok(mapper.Map<SignatureResponseModel>(result));
        }

        /// <summary>
        /// Получает список всех подписей
        /// </summary>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(IEnumerable<SignatureResponseModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(OperationId = "GetAllSignatures")]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var result = await signatureService.GetAllAsync(token);
            return Ok(mapper.Map<IEnumerable<SignatureResponseModel>>(result));
        }

        /// <summary>
        /// Получает подпись по идентификатору утверждающего
        /// </summary>
        [HttpGet("approverId={approverId:guid}")]
        [ProducesResponseType(typeof(SignatureResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
		[SwaggerOperation(OperationId = "GetSignatureByApproverId")]
		public async Task<IActionResult> GetByApproverId([FromRoute] Guid approverId, CancellationToken token)
        {
            var result = await signatureService.GetByApproverIdAsync(approverId, token);
            return Ok(mapper.Map<SignatureResponseModel>(result));
        }

        /// <summary>
        /// Создаёт Bmp изображение подписи
        /// </summary>
        /// <param name="height">высота изображения</param>
        /// <param name="width">ширина изображения</param>
        /// <param name="isTransparent">
        /// Указывает нужно ли делать задний фон прозрачным
        /// </param>
        /// <param name="isProportional">
        /// Указывает нужно ли изменить изображение пропорционально.
        /// если <c>True</c> то стороны изменённого изображения 
        /// будут пропорциональны сторонам исходного изображения
        /// </param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet("SignatureToImage Id={id:guid}")]
        [ProducesResponseType(typeof(Bitmap), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
		[SwaggerOperation(OperationId = "ConvertSignatureToImage")]
		public async Task<IActionResult> ConvertSignatureToImage([FromRoute] Guid id,
            [FromQuery] int height,
            [FromQuery] int width,
            [FromQuery] bool isTransparent,
            [FromQuery] bool isProportional,
            CancellationToken token)
        {
            var image = await imageCreatorService.CreateSingatireBmpImage(id, isTransparent, token);
            var result = await imageEditorService.ReducingTheSizeOfBmpImage(image, height, width, isTransparent, isProportional, token);
            return Ok(result);
        }

        /// <summary>
        /// Изменяет подпись
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(SignatureResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation(OperationId = "UpdateSignature")]
        public async Task<IActionResult> Edit([FromBody] SignatureResponseModel request, CancellationToken token)
        {
            var model = mapper.Map<SignatureModel>(request);
            await purchasingValidateService.ValidateAsync(model, token);
            var result = await signatureService.UpdateAsync(model, token);
            return Ok(mapper.Map<SignatureResponseModel>(result));
        }

        /// <summary>
        /// Удаляет подпись по Id
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status404NotFound)]
        [SwaggerOperation(OperationId = "DeleteSignature")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            await signatureService.DeleteByIdAsync(id, token);
            return Ok();
        }

        /// <summary>
        /// Добавляет новую подпись
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(typeof(SignatureResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiExeptionDetails), StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation(OperationId = "AddSignature")]
        public async Task<IActionResult> Create([FromBody] SignatureRequest request, CancellationToken token)
        {
            var model = mapper.Map<SignatureBaseModel>(request);
            await purchasingValidateService.ValidateAsync(model, token);
            var result = await signatureService.AddAsync(model, token);
            return Ok(mapper.Map<SignatureResponseModel>(result));
        }
    }
}