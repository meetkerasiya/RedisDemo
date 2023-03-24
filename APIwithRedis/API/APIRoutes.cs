using APIwithRedis.Models;
using APIwithRedis.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APIwithRedis.API
{
    public class APIRoutes
    {

        private static string recordId = "PaymentOptions";

        public static void MapRoutes(WebApplication app)
        {
            //app.MapGet("/getall", async (ICacheSetup cacheSetup,
            //    ICacheService<List<PaymentOptions>> cacheService) =>
            //{ 
            //    var result = await cacheService.GetValueAsync(recordId);
            //    return result;
            //});
            app.MapGet("/payments", async ([FromQuery] string? vendor,
                [FromQuery] string? paymentMethod,
                [FromQuery] string? processingType,
                [FromQuery] string? paymentSystem,
                IDataRepository dataRepository,
                HttpContext context,
                IErrorResponse errorResponse
               ) =>
            {

                var validationResult = await dataRepository.CheckValidation(vendor?.ToLower().Trim(),
                    paymentMethod?.ToLower().Trim(),
                    processingType?.ToLower().Trim(),
                    paymentSystem?.ToLower().Trim());
                if (!validationResult.IsValid)
                {

                    var result = validationResult.Errors;
                    var response=new List<ErrorResponceDTO>();
                  
                    for(int i=0; i<result.Count; i++)
                    {
                        response.Add(new ErrorResponceDTO()
                        {
                            Code = result[i].ErrorCode,
                            Message = result[i].ErrorMessage
                        });
                    }    
                          
                    return Results.Json(response, statusCode: (int)errorResponse.GetErrorResponse(result[0].ErrorCode).HttpStatusCode);
                    //var errors = ErrorExtension.GetErrors();
                    //ErrorExtension.ClearErrors();
                    //return Results.Json(errors, statusCode: (int)errorResponse.GetErrorResponse(result[0].ErrorCode).HttpStatusCode);


                }

                var results = await dataRepository.paymentResults(vendor?.ToLower().Trim(),
                        paymentMethod?.ToLower().Trim(),
                        processingType?.ToLower().Trim(),
                        paymentSystem?.ToLower().Trim());
                    return TypedResults.Ok(results);
               
            });
        }

      
    }
}
