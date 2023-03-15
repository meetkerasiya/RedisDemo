using Microsoft.Extensions.Caching.Distributed;

namespace APIwithRedis.API
{
    public class APIRoutes
    {
        private readonly IDistributedCache _distributedCache;

        public APIRoutes(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        public static void MapRoutes(WebApplication app)
        {
            app.MapGet("/payments", async(string vendor, string? payment_method,string? ProcessingType,string? PaymentSystem)=>
            {
                
            }); ;
        }
    }
}
