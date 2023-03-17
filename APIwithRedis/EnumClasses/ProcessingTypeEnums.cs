using System.ComponentModel;
using System.Runtime.Serialization;

namespace APIwithRedis.EnumClasses
{
    public enum ProcessingTypeEnums
    {
        [EnumMember(Value ="manual")]
        [Description("Manual")]
        manual=1,
        
        [EnumMember(Value ="automated")]
        [Description("Automated")]
        automated=2,
    }
}
