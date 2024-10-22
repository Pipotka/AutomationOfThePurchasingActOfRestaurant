using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Infrastructure;

/// <summary>
/// Фильтр обработки событий
/// </summary>
public class PurchasingEntityExceptionFilter : IExceptionFilter
{
    /// <summary>
    /// <inheritdoc cref="IExceptionFilter.OnException(ExceptionContext)" path="/summary"/>
    /// </summary>
    public void OnException(ExceptionContext context)
    {
        var exeption = context.Exception as EntityServiceException;
        if (exeption == null)
        {
            return;
        }

        switch (exeption)
        {
            case InvalidOperationPurchasingEntityServiceException ex:
                SetExeptionContext(new BadRequestObjectResult(new ApiExeptionDetails() { Message = ex.Message })
                {
                    StatusCode = StatusCodes.Status406NotAcceptable
                }, context);
                break;

            case EntityNotFoundServiceExeption ex:
                SetExeptionContext(new NotFoundObjectResult(new ApiExeptionDetails()
                {
                    Message = ex.Message,
                }), context);
                break;

            case PirchasingValidationExeption ex:
                SetExeptionContext(new BadRequestObjectResult(new ApiExeptionDetails { Message = ex.Message })
                {
                    StatusCode = StatusCodes.Status422UnprocessableEntity
                },
                    context);
                break;

            default:
                SetExeptionContext(new BadRequestObjectResult(new ApiExeptionDetails()
                {
                    Message = exeption.Message
                }), context);
                break;
        }

        return;

        static void SetExeptionContext(ObjectResult result, ExceptionContext context)
        {
            context.ExceptionHandled = true;
            var response = context.HttpContext.Response;
            response.StatusCode = result.StatusCode ?? StatusCodes.Status400BadRequest;
            context.Result = result;
        }
    }
}
