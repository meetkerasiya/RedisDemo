using APIwithRedis.CacheService;
using APIwithRedis.Models;
using Microsoft.Extensions.Caching.Distributed;

namespace APIwithRedis.CacheSetup
{
    public class CacheSetup : ICacheSetup
    {
        string recordKey = "abc";
        public CacheSetup(ICacheService<List<PaymentOptions>> cacheService, ILogger<CacheSetup> logger)
        {

            _cacheService = cacheService;
            _logger = logger;
 
        }
        private readonly IDistributedCache _cache;
        private readonly ICacheService<List<PaymentOptions>> _cacheService;
        private readonly ILogger _logger;
        private static List<PaymentOptions> paymentOptions;
        
        public async Task LoadData()
        {
            
            paymentOptions = await _cacheService.GetValueAsync(recordKey);
            if (paymentOptions is null)
            {
                paymentOptions = new List<PaymentOptions>()
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
                await _cacheService.SetValueAsync(recordKey, paymentOptions);
                _logger.LogInformation("Data added to cache");
            }
            else
            {
                _logger.LogInformation("Data is alredy in cache");
            }


        }

      

    }
}
