using APIwithRedis.Extensions;
using APIwithRedis.Models;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System.Data;
using System.Threading;

namespace APIwithRedis.DBSetup
{
    public class CacheSetup : ICacheSetup
    {
        public CacheSetup(IDistributedCache cache, ILogger<CacheSetup> logger)
        {
            _cache = cache;
            _logger = logger;
        }
        static string[] vendors = { "Carrier", "Carrier", "Carrier", "Carrier", "Publisher", "Publisher", "Publisher", "Publisher", "Seller", "Seller", "Seller", "Seller", "Seller", "Charity", "Charity", "Charity", "Charity", "Carrier", "Publisher", "Seller", "Charity", "Seller" };
        static string[] paymentMethod = { "Bank transfer", "Bank transfer", "Check", "Check", "Bank transfer", "Bank transfer", "Check", "Check", "Bank transfer", "Bank transfer", "Check", "Check", "Peddle Carrier check", "Bank transfer", "Bank transfer", "Check", "Check", "Check", "Check", "Check", "Check", "Check" };
        static string[] processingType = { "Manual", "Automated", "Manual", "Automated", "Manual", "Automated", "Manual", "Automated", "Manual", "Automated", "Manual", "Automated", "Manual", "Manual", "Automated", "Manual", "Automated", "Automated", "Automated", "Automated", "Automated", "Manual" };
        static string[] paymentSystemName = { "Peddle", "Frost", "Peddle", "Lob", "Peddle", "Frost", "Peddle", "Lob", "Peddle", "Frost", "Peddle", "Lob", "Peddle Carrier", "Peddle", "Frost", "Peddle", "Lob", "Checkbook.io", "Checkbook.io", "Checkbook.io", "Checkbook.io", "Peddle Carrier" };
        static string[] bankAccountName = { "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX0678", "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX5108", "Frost Bank XX0678", "Frost Bank XX0678", "Frost Bank XX0678", "Frost Bank XX0678", "Frost Bank XX0678" };
        private readonly IDistributedCache _cache;
        private readonly ILogger _logger;
        private static List<PaymentOptions> paymentOptions;


        public async Task LoadData()
        {
            string recordKey = "abc";
            paymentOptions = await _cache.GetRecordAsync<List<PaymentOptions>>(recordKey);
            if (paymentOptions is null)
            {
                paymentOptions = await GetPaymentOptionsAsync();
                await _cache.SetRecordAsync(recordKey, paymentOptions);
                _logger.LogInformation("Data added to cache");
            }
            else
            {
                _logger.LogInformation("Data is alredy in cache");
            }


        }

        public async Task<List<PaymentOptions>> GetPaymentOptionsAsync()
        {
            return Enumerable.Range(0, vendors.Length).Select(i => new PaymentOptions
            {
                Vendor = vendors[i],
                PaymentMethod = paymentMethod[i],
                ProcessingType = processingType[i],
                PaymentSystemName = paymentSystemName[i],
                BankAccountName = bankAccountName[i],
            }).ToList();
        }

    }
}
