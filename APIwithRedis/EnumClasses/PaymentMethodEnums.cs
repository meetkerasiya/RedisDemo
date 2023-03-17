using System.ComponentModel;
using System.Runtime.Serialization;

namespace APIwithRedis.EnumClasses
{
    public enum PaymentMethodEnums
    {
        [EnumMember(Value ="check")]
        [Description("Check")]
        check=10,

        [EnumMember(Value="bank_transfer")]
        [Description("Bank transfer")]
        bank_transfer=2,

        [EnumMember(Value ="card")]
        [Description("Card")]
        card=1,

        [EnumMember(Value="adjustment")]
        [Description("Adjustment")]
        adjustment=5,

        [EnumMember(Value = "peddle_carrier_check ")]
        [Description("Peddle Carrier Check")]
        peddle_carrier_check=17


    }
}
