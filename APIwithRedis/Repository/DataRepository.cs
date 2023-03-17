using APIwithRedis.CacheService;
using APIwithRedis.CacheSetup;
using APIwithRedis.EnumClasses;
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
        public async Task<List<ResponseDto>> paymentResults(string Vendor, string? Payment_method, string? ProcessingType, string? PaymentSystem)
        {
            await _cacheSetup.LoadData();
            var result = await _cacheService.GetValueAsync(recordId);
            var finalResult= result.FindAll(p =>
               (Vendor.Equals(p.Vendor.ToLower())) &&
               (Payment_method?.Equals(p.PaymentMethod.ToLower()) ?? true) &&
               (PaymentSystem?.Equals(p.PaymentSystemName.ToLower()) ?? true) &&
               (ProcessingType?.Equals(p.ProcessingType.ToLower()) ?? true));

            List<ResponseDto> response=new List<ResponseDto>();
            foreach(var item in finalResult)
            {
                var vendorEnum = (VendorEnums)Enum.Parse(typeof(VendorEnums), item.Vendor.ToLower());
                var methodEnum = (PaymentMethodEnums)Enum.Parse(typeof(PaymentMethodEnums), item.PaymentMethod.ToLower());
                var processingEnum = (ProcessingTypeEnums)Enum.Parse(typeof(ProcessingTypeEnums), item.ProcessingType.ToLower());
                var processorEnum = (ProcessorTypesEnums)Enum.Parse(typeof(ProcessorTypesEnums), item.PaymentSystemName.ToLower());

                ResponseDto res=new ResponseDto()
                {
                    vendor_type =
                    new ResponseField(){
                       code= vendorEnum.ToString(),
                       description = vendorEnum.GetEnumDescription(),
                    },
                    payment_method_type =
                    new ResponseField(){
                        code= methodEnum.ToString(),
                        description= methodEnum.GetEnumDescription(),

                    },
                    payment_processing_type =
                    new ResponseField(){
                       code= processingEnum.ToString(),
                       description = processingEnum.GetEnumDescription(),
                    },
                    processor_type =
                    new ResponseField(){
                        code= processorEnum.ToString(),
                        description= processorEnum.GetEnumDescription(),

                    },
                    bank_account = item.BankAccountName

                } ;
                response.Add(res);
                Console.WriteLine("Hello");
            }
            return response;

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
