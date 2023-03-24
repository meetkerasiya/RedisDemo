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
				
			}
        }

    }
}
