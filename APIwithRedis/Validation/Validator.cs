using APIwithRedis.Models;
using FluentValidation;

namespace APIwithRedis.Validation
{
    public class Validator : AbstractValidator<PaymentOptions>
    {
        public Validator()
        {
            RuleFor(x => x.Vendor)
                .NotEmpty()
                .Must(v => new[] { "Publisher", "Seller", "Charity", "Carrier" }.Contains(v))
                .WithErrorCode(errorCode: "invalid_vendor_type")
                .WithMessage("Vendor Type invalid");

            When(x => x.PaymentMethod != null , () =>
            {
                RuleFor(x => x.PaymentMethod)
                    .Must(v => new[] { "Check", "Bank transfer" }.Contains(v))
                    .WithErrorCode("invalid_payment_method_type")
                    .WithMessage("Payment Method Type invalid");
            });
            When(x => x.ProcessingType != null, () =>
            {
                RuleFor(x => x.ProcessingType)
                .Must(v => new[] { "Manual", "Automated" }.Contains(v))
                .WithErrorCode("invalid_payment_processing_type")
                .WithMessage("Payment Processing Type invalid");
            });

            When(x => x.PaymentSystemName != null, () =>
            {
                RuleFor(x => x.PaymentSystemName)
                .Must(v => new[] { "Peddle", "Lob", "Checkbook_io", "Paddle_carrier" }.Contains(v))
                .WithErrorCode("invalid_payment_processor")
                .WithMessage("Payment Processor invalid");
            });
            
        }
    }
}
