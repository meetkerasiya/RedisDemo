using APIwithRedis.CacheService;
using APIwithRedis.CacheSetup;
using APIwithRedis.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Caching.Distributed;

namespace APIwithRedis.Repository
{
    public class DataRepository : IDataRepository
    {
        
        private readonly IDistributedCache _cache;
        private readonly ICacheService<List<PaymentOptions>> _cacheService;
        private readonly IValidator<PaymentOptions> _validator;
        private readonly ICacheSetup _cacheSetup;
        private static string recordId = "abc";
        public DataRepository(ICacheService<List<PaymentOptions>> cacheService,IValidator<PaymentOptions> validator,ICacheSetup cacheSetup)
        {

            _cacheService = cacheService;
            _validator = validator;
            _cacheSetup = cacheSetup;
        }
        public async Task<List<PaymentOptions>> paymentResults(string Vendor, string? Payment_method, string? ProcessingType, string? PaymentSystem)
        {
            await _cacheSetup.LoadData();
            var result = await _cacheService.GetValueAsync(recordId);
            return result.FindAll(p =>
               (Vendor.Equals(p.Vendor.ToLower())) &&
               (Payment_method?.Equals(p.PaymentMethod.ToLower()) ?? true) &&
               (PaymentSystem?.Equals(p.PaymentSystemName.ToLower()) ?? true) &&
               (ProcessingType?.Equals(p.ProcessingType.ToLower()) ?? true));

        }

        public async Task<ValidationResult> CheckValidation(string Vendor, string? Payment_method, string? ProcessingType, string? PaymentSystem)
        {
            PaymentOptions payop = new PaymentOptions()
            {
                Vendor = Vendor,
                PaymentMethod = Payment_method,
                ProcessingType = ProcessingType,
                PaymentSystemName = PaymentSystem
            };
            return await _validator.ValidateAsync(payop);
        }
    }
}
