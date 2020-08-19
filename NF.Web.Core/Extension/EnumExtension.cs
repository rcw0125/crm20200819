using NF.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NF.Web.Core
{
    /// <summary>
    /// 扩展枚举
    /// </summary>
    public static class EnumExtension
    {
        private static Logger logger = Logger.CreateLogger(typeof(EnumExtension));

        /// <summary>
        /// 获取当前枚举值的Remark
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetRemark(this Enum value)
        {
            string remark = string.Empty;
            Type type = value.GetType();
            FieldInfo fieldinfo = type.GetField(value.ToString());
            try
            {
                object[] objs = fieldinfo.GetCustomAttributes(typeof(RemarkAttribute), false);
                RemarkAttribute attr = (RemarkAttribute)objs.FirstOrDefault(x => x is RemarkAttribute);
                if (attr == null)
                    remark = fieldinfo.Name;
                else
                    remark = attr.Remark;
            }
            catch (Exception)
            {
                logger.Debug("EnumExtension的GetRemark出现异常");
            }
            return remark;
        }

        /// <summary>
        /// 获取全部Remark
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static List<KeyValuePair<string, string>> GetRemarks(this Enum value)
        {
            List<KeyValuePair<string, string>> remarks = new List<KeyValuePair<string, string>>();
            Type type = value.GetType();
            FieldInfo[] fieldinfos = type.GetFields();
            foreach (FieldInfo item in fieldinfos)
            {
                if (item.FieldType.IsEnum)
                {
                    object obj = item.GetValue(value);
                    Enum enumValue = (Enum)obj;
                    int key = (int)obj;
                    remarks.Add(new KeyValuePair<string, string>(key.ToString(), enumValue.ToString()));
                }
            }
            return remarks;
        }

    }

    public class RemarkAttribute : Attribute
    {
        private string _remark = string.Empty;

        public RemarkAttribute(string remark)
        {
            _remark = remark;
        }

        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        public string Description { get; set; }

    }

}
