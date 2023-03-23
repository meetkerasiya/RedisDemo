using System.Net;

namespace APIwithRedis.Models
{
    public class ErrorResponse : IErrorResponse
    {
        public ErrorResponse() { }
        public ErrorResponse(string code, string message, HttpStatusCode httpStatusCode)
        {
            Message = message;
            Code = code;
            HttpStatusCode = httpStatusCode;
            errorResponses.Add(this);
        }

        public static List<ErrorResponse> errorResponses { get; } = new List<ErrorResponse>();
        public string Message { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public string Code { get; set; }

        public static readonly ErrorResponse UnhandleException = new ErrorResponse(
            "internal_server_error", "Something went wrong", HttpStatusCode.InternalServerError);

        public static readonly ErrorResponse NullVendorException = new ErrorResponse(
            "null_vendor_type", "Vendor type is null", HttpStatusCode.Forbidden);

        public static readonly ErrorResponse InvalidVendorTyepe = new ErrorResponse(
            "invalid_vendor_type", "Vendor Type invalid", HttpStatusCode.Conflict);

        public static readonly ErrorResponse InvalidPaymentMethodType = new ErrorResponse(
            "invalid_payment_method_type", "Payment Method Type invalid", HttpStatusCode.MethodNotAllowed);

        public static readonly ErrorResponse InvalidProcessingType = new ErrorResponse(
            "invalid_payment_processing_type", "Payment Processing Type invalid", HttpStatusCode.NotAcceptable);

        public static readonly ErrorResponse InvalidProcessorType = new ErrorResponse(
            "invalid_payment_processor", "Payment Processor invalid", HttpStatusCode.UnavailableForLegalReasons);


        public ErrorResponse GetErrorResponse(string errorCode)
        {
            return errorResponses.First(err =>
                err.Code.ToLower().Equals(errorCode.ToLower()));
        }

    }
}
