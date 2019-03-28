using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace EasyHarmonica.Common.Extensions
{
    public static class EnumDisplayNameExtension
    {
        public static string GetDescription(this Enum value)
        {
            return value.GetType()
                .GetMember(value.ToString())
                .FirstOrDefault()
                ?.GetCustomAttribute<DescriptionAttribute>()
                ?.Description;
        }
    }
}
