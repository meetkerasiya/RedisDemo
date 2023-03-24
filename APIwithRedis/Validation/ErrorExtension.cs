using APIwithRedis.Models;
using FluentValidation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace APIwithRedis.Validation
{
    public static class ErrorExtension
    {
        public static List<ErrorResponceDTO> errors = new List<ErrorResponceDTO>();

        public static void AddError(this IRuleBuilderOptions<PaymentOptions,string> builder,
            ErrorResponceDTO error)
        {
            errors.Add(error);
        }

        public static List<ErrorResponceDTO> GetErrors()
        {
            if(errors.Any()) return errors;
            return default;
        }

        public static void ClearErrors()
        {
            errors.Clear();
        }

        internal static void AddError(ErrorResponceDTO error)
        {
            errors.Add(error);
        }
    }
}
