using APIwithRedis.Models;
using FluentValidation;
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
				var response=context.Response;
				
					
				
				
			}
			catch (Exception ex)
			{
				ErrorResponse errorResponse=null;
				var response=context.Response;
				switch(ex)
				{
					case ValidationException validationException:
						var errorResult = _errorResponse.GetErrorResponse(
							string.IsNullOrWhiteSpace(validationException.Errors.First().ErrorCode)
							? validationException.Errors.First().ErrorMessage
							: validationException.Errors.First().ErrorCode )??
							ErrorResponse.UnhandleException;
						response.StatusCode = (int)errorResult.HttpStatusCode;

						break;

					default:
						 errorResponse= ErrorResponse.UnhandleException;
						 response.StatusCode= (int)errorResponse.HttpStatusCode;
						break;
				}

				var result = errorResponse == null ? string.Empty :
					JsonSerializer.Serialize(

						new ErrorResponceDTO
						{
							Code = errorResponse.Code,
							Message = errorResponse.Message,
						});
				await response.WriteAsync(result);
			}
        }

    }
}
