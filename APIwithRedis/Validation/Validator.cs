using APIwithRedis.EnumClasses;
using APIwithRedis.Models;
using FluentValidation;
 
namespace APIwithRedis.Validation
{
    public class Validator : AbstractValidator<PaymentOptions>
    {
        public Validator()
        {
            When(x => x.Vendor is null, () =>
            {
                RuleFor(x => x.Vendor)
                .NotEmpty()
                .WithErrorCode("null_vendor_type")
                .WithMessage("Vendor type is null");
                
            });
            When(x => x.Vendor != null, () =>
            {


                RuleFor(x => x.Vendor)
                    .NotEmpty()
                    .Must(v => new[] { VendorEnums.carrier.ToString(),
                    VendorEnums.publisher.ToString(),
                    VendorEnums.charity.ToString(),
                    VendorEnums.seller.ToString() }.Contains(v))
                    .WithErrorCode(errorCode: "invalid_vendor_type")
                    .WithMessage("Vendor Type invalid");
            });

            When(x => x.PaymentMethod != null , () =>
            {
                RuleFor(x => x.PaymentMethod)
                    .Must(v => new[] { PaymentMethodEnums.check.ToString(),
                        PaymentMethodEnums.bank_transfer.ToString() }.Contains(v))
                    .WithErrorCode("invalid_payment_method_type")
                    .WithMessage("Payment Method Type invalid");
            });
            When(x => x.ProcessingType != null, () =>
            {
                RuleFor(x => x.ProcessingType)
                .Must(v => new[] { ProcessingTypeEnums.manual.ToString(),
                    ProcessingTypeEnums.automated.ToString() }.Contains(v))
                .WithErrorCode("invalid_payment_processing_type")
                .WithMessage("Payment Processing Type invalid");
            });

            When(x => x.PaymentSystemName != null, () =>
            {
                RuleFor(x => x.PaymentSystemName)
                .Must(v => new[] { ProcessorTypesEnums.peddle.ToString(),
                    ProcessorTypesEnums.lob.ToString(),
                    ProcessorTypesEnums.checkbook_io.ToString(),
                 
                    ProcessorTypesEnums.peddle_carrier.ToString(),  }.Contains(v))
                .WithErrorCode("invalid_payment_processor")
                .WithMessage("Payment Processor invalid");
            });
            
        }
    }
}
