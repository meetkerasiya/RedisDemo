using APIwithRedis.Models;

namespace APIwithRedis.DBSetup
{
    public interface ICacheSetup
    {
        Task<List<PaymentOptions>> GetPaymentOptionsAsync();
        Task LoadData();
    }
}