using APIwithRedis.Models;
using APIwithRedis.Validation;
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace APIwithRedis.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IErrorResponse _errorResponse;

        public ErrorHandlerMiddleware(RequestDelegate next, IErrorResponse errorResponse)
		{
            _next = next;
            _errorResponse = errorResponse;
        }
        public async Task Invoke(HttpContext context)
        {
			try
			{ 
                await _next(context);
				
				
					
				
				
			}
			catch(BulkValidationException ex)
			{
                var response = context.Response;

                await response.WriteAsJsonAsync(ex.BulkErrors);

            }
            catch (Exception ex)
			{
				ErrorResponse errorResponse=null;
				var response=context.Response;

				context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				await context.Response.WriteAsync(JsonSerializer.Serialize( new ErrorResponceDTO
				{
					Code = "internal_server_error",
					Message = "Internal server error"
				}));
				return;
				//switch(ex)
				//{
				//	case ValidationException validationException:
				//		var errorResult = _errorResponse.GetErrorResponse(
				//			string.IsNullOrWhiteSpace(validationException.Errors.First().ErrorCode)
				//			? validationException.Errors.First().ErrorMessage
				//			: validationException.Errors.First().ErrorCode )??
				//			ErrorResponse.UnhandleException;
				//		response.StatusCode = (int)errorResult.HttpStatusCode;
				//		if(validationException is BulkValidationException)
				//		{
				//			await response.WriteAsJsonAsync(validationException.Errors);

    //                    }
				//		break;

				//	default:
				//		 errorResponse= ErrorResponse.UnhandleException;
				//		 response.StatusCode= (int)errorResponse.HttpStatusCode;
				//		break;
				//}

				//var result = errorResponse == null ? string.Empty :
				//	JsonSerializer.Serialize(

				//		new ErrorResponceDTO
				//		{
				//			Code = errorResponse.Code,
				//			Message = errorResponse.Message,
				//		});
				//await response.WriteAsync(result);
			}
        }

    }
}
