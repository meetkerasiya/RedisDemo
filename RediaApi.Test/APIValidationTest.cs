using APIwithRedis.Models;
using APIwithRedis.Validation;
using FluentValidation.TestHelper;

namespace RedisApi.Test
{
    public class APIValidationTest
    {
        private readonly Validator _validator;
        public APIValidationTest()
        {
            _validator = new Validator();
        }

        [Fact]
        public async Task Given_valid_query_param_then_should_not_throw_error()
        {
            //arrange
            var paymentOption = new PaymentOptions()
            {
                Vendor = "seller",
                PaymentMethod = "check",
                PaymentSystemName = "peddle",
                ProcessingType = "manual"
            };

            //act
            var result= await _validator.TestValidateAsync(paymentOption);

            //assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task Given_null_vendor_in_query_param_then_throw_error()
        {
            var paymentOption = new PaymentOptions()
            {
                Vendor = null
            };

            var result = await _validator.ValidateAsync(paymentOption);
            //assert
            Assert.Equal("null_vendor_type", result.Errors[0].ErrorCode);
        }

        [Fact]
        public async Task Given_invalid_vendor_in_query_param_then_throw_error()
        {
            var paymentOption = new PaymentOptions()
            {
                Vendor = "abc",

            };

            var result = await _validator.ValidateAsync(paymentOption);
            //assert
            Assert.Equal("invalid_vendor_type", result.Errors[0].ErrorCode);

        }

        
        [Fact]
        public async Task Given_invalid_payment_method_in_query_param_then_throw_error()
        {
            var paymentOption = new PaymentOptions()
            {
                Vendor = "publisher",
                PaymentMethod="card"
            };

            var result = await _validator.ValidateAsync(paymentOption);
            //assert
            Assert.Equal("invalid_payment_method_type", result.Errors[0].ErrorCode);

        }

        [Fact]
        public async Task Given_invalid_payment_processing_type_in_query_param_then_throw_error()
        {
            var paymentOption = new PaymentOptions()
            {
                Vendor = "publisher",
                ProcessingType="custom"
            };

            var result = await _validator.ValidateAsync(paymentOption);
            //assert
            Assert.Equal("invalid_payment_processing_type", result.Errors[0].ErrorCode);

        }

        [Fact]
        public async Task Given_invalid_payment_processor_type_in_query_param_then_throw_error()
        {
            var paymentOption = new PaymentOptions()
            {
                Vendor = "publisher",
                PaymentSystemName="frost"
            };

            var result = await _validator.ValidateAsync(paymentOption);
            //assert
            Assert.Equal("invalid_payment_processor", result.Errors[0].ErrorCode);

        }


    }
}