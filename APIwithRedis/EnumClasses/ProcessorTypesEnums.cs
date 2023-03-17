using System.ComponentModel;
using System.Runtime.Serialization;

namespace APIwithRedis.EnumClasses
{
    public enum ProcessorTypesEnums
    {
       

        [EnumMember(Value = "lob")]
        [Description("Lob")]
        lob=1,

        [EnumMember(Value ="frost")]
        [Description("Frost")]
        frost=2,

        [EnumMember(Value = "peddle")]
        [Description("Peddle")]
        peddle=3,

        [EnumMember(Value = "checkbook_io")]
        [Description("Checkbook.io")]
        checkbook_io=4,

        [EnumMember(Value ="peddle_carrier")]
        [Description("Peddle Carrier")]
        peddle_carrier=5
    }
}
