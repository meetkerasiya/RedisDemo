namespace APIwithRedis.Models
{
    public class PaymentOptions
    {
        public string Vendor { get; set; }
        public string PaymentMethod { get; set; }
        public string ProcessingType { get; set; }
        public string PaymentSystemName { get; set; }
        public string BankAccountName { get; set; }
    }
}
