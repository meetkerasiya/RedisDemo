using APIwithRedis.DBSetup;
using APIwithRedis.Extensions;
using APIwithRedis.Models;
using Microsoft.Extensions.Caching.Distributed;

namespace APIwithRedis.API
{
    public class APIRoutes
    {
        private static string recordId= "abc";

        public static void MapRoutes(WebApplication app)
        {
            app.MapGet("/getall", async (ICacheSetup cacheSetup, IDistributedCache cache) =>
            {
                await cacheSetup.LoadData();
                var result = await cache.GetRecordAsync<List<PaymentOptions>>(recordId);
                return result;
            });
            app.MapGet("/payments", async(string Vendor, string? Payment_method,string? ProcessingType,string? PaymentSystem, ICacheSetup cacheSetup,IDistributedCache cache)=>
            {
                await cacheSetup.LoadData();
                var result = await cache.GetRecordAsync<List<PaymentOptions>>(recordId);
                return TypedResults.Ok( result.FindAll(p =>
               ( p.Vendor.Equals(Vendor) ) && 
               ( Payment_method?.Equals(p.PaymentMethod) ?? true) &&
               ( PaymentSystem?.Equals(p.PaymentSystemName) ?? true) &&
               ( ProcessingType?.Equals(p.ProcessingType) ?? true)
                    ));
            }); ;
        }
    }
}
