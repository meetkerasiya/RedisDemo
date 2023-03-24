using APIwithRedis.CacheService;
using APIwithRedis.CacheSetup;
using APIwithRedis.Models;
using APIwithRedis.Repository;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace APIwithRedis.API
{
    public class APIRoutes
    {

        private static string recordId = "RedisKey";

        public static void MapRoutes(WebApplication app)
        {
            //app.MapGet("/getall", async (ICacheSetup cacheSetup,
            //    ICacheService<List<PaymentOptions>> cacheService) =>
            //{ 
            //    var result = await cacheService.GetValueAsync(recordId);
            //    return result;
            //});
            app.MapGet("/payments", async ([FromQuery] string? Vendor,
                [FromQuery] string? Payment_method,
                [FromQuery] string? ProcessingType,
                [FromQuery] string? PaymentSystem,
                IDataRepository dataRepository,
                HttpContext context,
                IErrorResponse errorResponse
               ) =>
            {


            var validationResult = await dataRepository.CheckValidation(Vendor?.ToLower().Trim(),
                Payment_method?.ToLower().Trim(),
                ProcessingType?.ToLower().Trim(),
                PaymentSystem?.ToLower().Trim());
            if (!validationResult.IsValid)
            {
                var result = validationResult.Errors;
                    var response =
                        
                           new ErrorResponceDTO()
                           {
                               Code = result[0].ErrorCode,
                               Message = result[0].ErrorMessage
                           };
                    throw new Exception();
                    return Results.Json(response, statusCode: (int)errorResponse.GetErrorResponse(result[0].ErrorCode).HttpStatusCode);
                  
          
               }
                var results=await  dataRepository.paymentResults(Vendor.ToLower().Trim(),
                    Payment_method?.ToLower().Trim(),
                    ProcessingType?.ToLower().Trim(),
                    PaymentSystem?.ToLower().Trim());
                return TypedResults.Ok(results);
            });
        }

      
    }
}
