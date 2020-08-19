using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework
{
    public  class EnumHelper
    {
        /// <summary>
        /// 返回枚举值的描述信息。
        /// </summary>
        /// <param name="value">要获取描述信息的枚举值。</param>
        /// <returns>枚举值的描述信息。</returns>
        public static string GetEnumDesc<T>(T value)
        {
            Type enumType = typeof(T);
            DescriptionAttribute attr = null;
            string name = System.Enum.GetName(enumType, value);
            if (name != null)
            {
                FieldInfo fieldInfo = enumType.GetField(name);
                if (fieldInfo != null)
                {
                    attr = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute), false) as DescriptionAttribute;
                }
            }
            if (attr != null && !string.IsNullOrEmpty(attr.Description))
                return attr.Description;
            else
                return string.Empty;
            
        }

        public static Dictionary<string, object> GetEnumDic<T>()
        {
            var arrValue = Enum.GetValues(typeof(T));
            var result = new Dictionary<string, object>();
            foreach (var item in arrValue)
            {
                result.Add(GetEnumDisplayName((T)item), Convert.ChangeType((T)item, Enum.GetUnderlyingType(typeof(T))));
            }
            return result;
        }

        public static string GetEnumDisplayName<TEnum>(TEnum value)
        {
            Type enumType = typeof(TEnum);
            DescriptionAttribute attr = null;
            var name = Enum.GetName(enumType, value);
            if (name != null)
            {
                var fieldInfo = enumType.GetField(name);
                if (fieldInfo != null)
                {
                    attr = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute), false) as DescriptionAttribute;
                }
            }
            if (attr != null)
                return attr.Description;
            else
                return string.Empty;
        }
    }
}
