using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace APIwithRedis.EnumClasses
{
    public enum VendorEnums
    {
        [EnumMember(Value = "publisher")]
        [Description("Publisher")]
        publisher,

        [EnumMember(Value ="seller")]
        [Description("Seller")]
        seller,

        [EnumMember(Value ="charity")]
        [Description("Charity")]
        charity,

        [EnumMember(Value ="carrier")]
        [Description("Carrier")]
        carrier,
    }
}
