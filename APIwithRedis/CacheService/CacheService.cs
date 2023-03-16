using APIwithRedis.Models;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace APIwithRedis.CacheService
{
    public class CacheService<TCacheValue> : ICacheService<TCacheValue>
    {
        private readonly ILogger<CacheService<TCacheValue>> _logger;
        private readonly IDistributedCache _distributedCache;
        private readonly string _key = "abc";

        public CacheService(ILogger<CacheService<TCacheValue>> logger, IDistributedCache distributedCache)
        {
            _logger = logger;
            _distributedCache = distributedCache;
            

        }

        public async Task<TCacheValue> GetValueAsync(string key)
        {
            if (key is null) throw new ArgumentNullException(nameof(key));

            try
            {
                var value = await GetValuesAsync(key);
                return string.IsNullOrEmpty(value) ? default : JsonSerializer.Deserialize<TCacheValue>(value);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "failed to load from redis");
            }
            return default(TCacheValue);
        }

        private async Task<string> GetValuesAsync(string key)
        {
            return await _distributedCache.GetStringAsync(key);
        }

        public async Task SetValueAsync(string key, TCacheValue value)
        {
            try
            {
                var valueString = JsonSerializer.Serialize(value);
                var distributedCacheEntryOptions = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                };
                await _distributedCache.SetStringAsync(key, valueString, distributedCacheEntryOptions);
            }
            catch
            {

            }
        }

        private readonly List<PaymentOptions> paymentOptions = new List<PaymentOptions>()
                {

                    new PaymentOptions
                    {
                    Vendor = "Carrier",
                    PaymentMethod = "Bank transfer",
                    ProcessingType = "Manual",
                    PaymentSystemName = "Peddle",
                    BankAccountName = "Frost Bank XX5108"
                    },
                    new PaymentOptions
                    {
                    Vendor = "Carrier",
                    PaymentMethod = "Bank transfer",
                    ProcessingType = "Automated",
                    PaymentSystemName = "Frost",
                    BankAccountName = "Frost Bank XX5108"
                    },

                    new PaymentOptions
                    {
                        Vendor = "Carrier",
                        PaymentMethod = "Check",
                        ProcessingType = "Manual",
                        PaymentSystemName = "Peddle",
                        BankAccountName = "Frost Bank XX5108"
                    },
                    new PaymentOptions
                    {
                        Vendor = "Carrier",
                        PaymentMethod = "Check",
                        ProcessingType = "Automated",
                        PaymentSystemName = "Lob",
                        BankAccountName = "Frost Bank XX5108"
                    },
                    new PaymentOptions
                    {
                        Vendor = "Publisher",
                        PaymentMethod = "Bank transfer",
                        ProcessingType = "Manual",
                        PaymentSystemName = "Peddle",
                        BankAccountName = "Frost Bank XX5108"
                    },
                    new PaymentOptions
                    {
                        Vendor = "Publisher",
                        PaymentMethod = "Bank transfer",
                        ProcessingType = "Automated",
                        PaymentSystemName = "Frost",
                        BankAccountName = "Frost Bank XX5108"
                    },
                    new PaymentOptions
                    {
                        Vendor = "Publisher",
                        PaymentMethod = "Check",
                        ProcessingType = "Manual",
                        PaymentSystemName = "Peddle",
                        BankAccountName = "Frost Bank XX5108"
                    },
                    new PaymentOptions
                    {
                        Vendor = "Publisher",
                        PaymentMethod = "Check",
                        ProcessingType = "Automated",
                        PaymentSystemName = "Lob",
                        BankAccountName = "Frost Bank XX5108"
                    },
                    new PaymentOptions
                    {
                        Vendor = "Seller",
                        PaymentMethod = "Bank transfer",
                        ProcessingType = "Manual",
                        PaymentSystemName = "Peddle",
                        BankAccountName = "Frost Bank XX5108"
                    },
                    new PaymentOptions
                    {
                        Vendor = "Seller",
                        PaymentMethod = "Bank transfer",
                        ProcessingType = "Automated",
                        PaymentSystemName = "Frost",
                        BankAccountName = "Frost Bank XX5108"
                    },
                    new PaymentOptions
                    {
                        Vendor = "Seller",
                        PaymentMethod = "Check",
                        ProcessingType = "Manual",
                        PaymentSystemName = "Peddle",
                        BankAccountName = "Frost Bank XX5108"
                    },
                    new PaymentOptions
                    {
                        Vendor = "Seller",
                        PaymentMethod = "Check",
                        ProcessingType = "Automated",
                        PaymentSystemName = "Lob",
                        BankAccountName = "Frost Bank XX5108"
                    },
                    new PaymentOptions
                    {
                        Vendor = "Seller",
                        PaymentMethod = "Peddle Carrier check",
                        ProcessingType = "Manual",
                        PaymentSystemName = "Peddle Carrier",
                        BankAccountName = "Frost Bank XX0678"
                    },
                    new PaymentOptions
                    {
                        Vendor = "Charity",
                        PaymentMethod = "Bank transfer",
                        ProcessingType = "Manual",
                        PaymentSystemName = "Peddle",
                        BankAccountName = "Frost Bank XX5108"
                    },
                    new PaymentOptions
                    {
                        Vendor = "Charity",
                        PaymentMethod = "Bank transfer",
                        ProcessingType = "Automated",
                        PaymentSystemName = "Frost",
                        BankAccountName = "Frost Bank XX5108"
                    },
                    new PaymentOptions
                    {
                        Vendor = "Charity",
                        PaymentMethod = "Check",
                        ProcessingType = "Manual",
                        PaymentSystemName = "Peddle",
                        BankAccountName = "Frost Bank XX5108"
                    },
                    new PaymentOptions
                    {
                        Vendor = "Charity",
                        PaymentMethod = "Check",
                        ProcessingType = "Automated",
                        PaymentSystemName = "Lob",
                        BankAccountName = "Frost Bank XX5108"
                    },
                    new PaymentOptions
                    {
                        Vendor = "Carrier",
                        PaymentMethod = "Check",
                        ProcessingType = "Automated",
                        PaymentSystemName = "Checkbook.io",
                        BankAccountName = "Frost Bank XX0678"
                    },
                    new PaymentOptions
                    {
                        Vendor = "Publisher",
                        PaymentMethod = "Check",
                        ProcessingType = "Automated",
                        PaymentSystemName = "Checkbook.io",
                        BankAccountName = "Frost Bank XX0678"
                    },
                    new PaymentOptions
                    {
                        Vendor = "Seller",
                        PaymentMethod = "Check",
                        ProcessingType = "Automated",
                        PaymentSystemName = "Checkbook.io",
                        BankAccountName = "Frost Bank XX0678"
                    },
                    new PaymentOptions
                    {
                        Vendor = "Charity",
                        PaymentMethod = "Check",
                        ProcessingType = "Automated",
                        PaymentSystemName = "Checkbook.io",
                        BankAccountName = "Frost Bank XX0678"
                    },
                    new PaymentOptions
                    {
                        Vendor = "Seller",
                        PaymentMethod = "Check",
                        ProcessingType = "Manual",
                        PaymentSystemName = "Peddle Carrier",
                        BankAccountName = "Frost Bank XX0678"
                    }

                };
    }

}
