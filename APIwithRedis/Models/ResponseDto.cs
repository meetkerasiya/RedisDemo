namespace APIwithRedis.Models
{
    public class ResponseDto
    {
        public ResponseField vendor_type { get; set; }
        public ResponseField payment_processing_type { get; set; }
        public ResponseField payment_method_type { get; set; }
        public ResponseField processor_type { get; set;  }
        public string bank_account { get; set; }
    }
}
