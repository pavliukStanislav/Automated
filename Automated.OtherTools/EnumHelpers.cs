using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Automated.OtherTools
{
    public static class EnumHelper
    {
        public static string GetDescription(this Enum enumType)
        {
            var fieldName = enumType.ToString();

            FieldInfo fieldInfo = enumType.GetType().GetField(fieldName);

            var attributes =
              (DescriptionAttribute[])fieldInfo?.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes!.Any() ? attributes.First().Description : fieldName;
        }

        public static string GetDisplayName(this Enum enumType)
        {
            var fieldName = enumType.ToString();

            FieldInfo fieldInfo = enumType.GetType().GetField(fieldName);

            var attributes =
              (DisplayAttribute[])fieldInfo?.GetCustomAttributes(typeof(DisplayAttribute), false);

            return attributes!.Any() ? attributes.First().Name : fieldName;
        }

        public static string GetDisplayShortName(this Enum enumType)
        {
            var fieldName = enumType.ToString();

            FieldInfo fieldInfo = enumType.GetType().GetField(fieldName);

            var attributes =
              (DisplayAttribute[])fieldInfo?.GetCustomAttributes(typeof(DisplayAttribute), false);

            return attributes!.Any() ? attributes.First().ShortName : fieldName;
        }

        public static T GetValueFromDisplayName<T>(string name)
        {
            Type type = typeof(T);

            if (!type.IsEnum)
            {
                throw new InvalidOperationException();
            }

            foreach (FieldInfo field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) is DisplayAttribute attribute)
                {
                    if (attribute.Name == name)
                    {
                        return (T)field.GetValue(null);
                    }
                }
                else
                {
                    if (field.Name == name)
                    {
                        return (T)field.GetValue(null);
                    }
                }
            }

            throw new ArgumentOutOfRangeException(nameof(name));
        }
    }
}
