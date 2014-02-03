using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class AgensiEnumEx
    {
        /// <summary>
        /// Enumに指定したEnumValueAttributeから値をする。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <returns></returns>
        public static T GetValue<T>(this Enum o)
        {
            return GetValue<T>(o, null);
        }

        public static T GetValue<T>(this Enum o, string category)
        {
            var type = o.GetType();
            var fieldInfo = type.GetField(o.ToString());
            var attribs = fieldInfo.GetCustomAttributes(typeof(EnumValueAttribute), false) as EnumValueAttribute[];

            if (attribs.Count(a => a.Category == category) > 0)
                return (T)Convert.ChangeType(attribs.Where(a => a.Category == category).ElementAt(0).Value, typeof(T));
            else
                return default(T);
        }

        public static object ParseByValue(Type enumType, object value)
        {
            return ParseByValue(enumType, value, null);
        }

        public static object ParseByValue(Type enumType, object value, string category)
        {
            foreach (FieldInfo fieldInfo in enumType.GetFields())
            {
                var attribs = fieldInfo.GetCustomAttributes(typeof(EnumValueAttribute), false) as EnumValueAttribute[];

                if (attribs.Count(a => a.Category == category) > 0 && attribs.Where(a => a.Category == category).ElementAt(0).Value.ToString() == value.ToString())
                    return (Enum)fieldInfo.GetValue(null);
            }
            throw new ArgumentException(string.Format("\"{0}\"を{1}に変換できません", value, enumType));
        }

        public static IEnumerable<T> AsEnumerable<T>()
            where T : struct, IConvertible
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class EnumValueAttribute : Attribute
    {
        public string Category { get; private set; }
        public object Value { get; private set; }

        public EnumValueAttribute(object val)
        {
            Value = val;
        }

        public EnumValueAttribute(string category, object val)
        {
            Category = category;
            Value = val;
        }
    }
}