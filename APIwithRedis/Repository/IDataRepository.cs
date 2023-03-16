using APIwithRedis.Models;
using FluentValidation.Results;

namespace APIwithRedis.Repository
{
    public interface IDataRepository
    {
        Task<ValidationResult> CheckValidation(string Vendor, string? Payment_method, string? ProcessingType, string? PaymentSystem);
        Task<List<PaymentOptions>> paymentResults(string Vendor, string? Payment_method, string? ProcessingType, string? PaymentSystem);
    }
}