using APIwithRedis.CacheService;
using APIwithRedis.CacheSetup;
using APIwithRedis.Models;
using APIwithRedis.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APIwithRedis.API
{
    public class APIRoutes
    {

        private static string recordId = "abc";

        public static void MapRoutes(WebApplication app)
        {
            app.MapGet("/getall", async (ICacheSetup cacheSetup, ICacheService<List<PaymentOptions>> cacheService) =>
            { 
                var result = await cacheService.GetValueAsync(recordId);
                return result;
            });
            app.MapGet("/payments",  async ([FromQuery] string Vendor,
                [FromQuery] string? Payment_method, 
                [FromQuery] string? ProcessingType, 
                [FromQuery] string? PaymentSystem, 
                IDataRepository dataRepository,
                ICacheSetup setup) =>
            {

               
               var validationResult=await dataRepository.CheckValidation(Vendor, Payment_method, ProcessingType, PaymentSystem);
                if (!validationResult.IsValid)
                {
                    var result = validationResult.Errors;
                    var response = new ErrorResponceDTO()
                    {
                        Code = result[0].ErrorCode,
                        Message = result[0].ErrorMessage
                    };
                    return Results.BadRequest(response);
                }
                var results=await  dataRepository.paymentResults(Vendor, Payment_method, ProcessingType, PaymentSystem);
                return TypedResults.Ok(results);
            });
        }
    }
}
