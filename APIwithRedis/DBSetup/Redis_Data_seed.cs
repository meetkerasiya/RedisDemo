using APIwithRedis.Models;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System.Data;
using System.Threading;

namespace APIwithRedis.DBSetup
{
    public  class Redis_Data_seed
    {
        public Redis_Data_seed(IDistributedCache cache)
        {
            _cache = cache;
        }
        static string[] vendors = { "Carrier", "Carrier", "Carrier", "Carrier", "Publisher", "Publisher", "Publisher", "Publisher", "Seller", "Seller", "Seller", "Seller", "Seller", "Charity", "Charity", "Charity", "Charity", "Carrier", "Publisher", "Seller", "Charity", "Seller" };
        static string[] paymentMethod = { "Bank transfer", "Bank transfer", "Check", "Check", "Bank transfer", "Bank transfer", "Check", "Check", "Bank transfer", "Bank transfer", "Check", "Check", "Peddle Carrier check", "Bank transfer", "Bank transfer", "Check", "Check", "Check", "Check", "Check", "Check", "Check" };
        static string[] processingType = { "Manual", "Automated", "Manual", "Automated", "Manual", "Automated", "Manual", "Automated", "Manual", "Automated", "Manual", "Automated", "Manual", "Manual", "Automated", "Manual", "Automated", "Automated", "Automated", "Automated", "Automated", "Manual" };
        static string[] paymentSystemName = { "Peddle", "Frost", "Peddle", "Lob", "Peddle", "Frost", "Peddle", "Lob", "Peddle", "Frost", "Peddle", "Lob", "Peddle Carrier", "Peddle", "Frost", "Peddle", "Lob", "Checkbook.io", "Checkbook.io", "Checkbook.io", "Checkbook.io", "Peddle Carrier" };
        static string[] bankAccountName = { "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX0678", "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX0678", "Frost Bank XX0678", "Frost Bank XX0678", "Frost Bank XX0678", "Frost Bank XX0678" };
        private readonly IDistributedCache _cache;



        //public static async Task LoadData(WebApplicationBuilder builder)
        public static async Task LoadData()
        {
            //ConnectionMultiplexer redis = ConnectionMultiplexer.Connect( builder.Configuration.GetConnectionString("Redis"));

            //IDatabase db = redis.GetDatabase();

            
            

            //for(int i=0;i<vendors.Length;i++)
            //{
            //    var hash = new HashEntry[]

            //    {
            //        new HashEntry("Vendor",vendors[i]),
            //        new HashEntry("PaymentMethod",paymentMethod[i]),
            //        new HashEntry("ProcessingType",processingType[i]),
            //        new HashEntry("PaymentSystemName",paymentSystemName[i]),
            //        new HashEntry("BankAccountName",bankAccountName[i])
            //    };
            //    await db.HashSetAsync($"{i}",hash);

            //}
                       
            
        }

        public async Task<PaymentOptions[]> GetPaymentOptionsAsync()
        {
            return Enumerable.Range(1, vendors.Length).Select(i => new PaymentOptions
            {
                Vendor = vendors[i],
                PaymentMethod = paymentMethod[i],
                ProcessingType= processingType[i],
                PaymentSystemName= paymentSystemName[i],
                BankAccountName= bankAccountName[i],
            }).ToArray();
        }
        
    }
}
