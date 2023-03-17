using System.ComponentModel;

namespace APIwithRedis.EnumClasses
{
    public static class EnumExtension
    {
        public static string GetEnumDescription(this Enum value)
        {
            var field=value.GetType().GetField(value.ToString());
            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                return attribute.Description;
            }
            throw new ArgumentException("Description not found",nameof(value));
        }
    }
}
