using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.DLL
{
    public static class DataTableExtends
    {

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<T> DataTableToList2<T>(this DataTable dt) where T : class, new()
        {
            var list = new List<T>();

            var fields = typeof(T).GetProperties().Where(x => dt.Columns.Contains(x.Name));

            foreach (DataRow row in dt.Rows)
            {
                var t = new T();
                foreach (var item in fields)
                {
                    var rowVal = row[item.Name];
                    if (rowVal != DBNull.Value && item.CanWrite)
                    {
                        if (item.PropertyType == typeof(string))
                        {
                            item.SetValue(t, rowVal?.ToString(), null);
                        }
                        else if (item.PropertyType == typeof(int) ||
                            item.PropertyType == typeof(int?))
                        {
                            item.SetValue(t, Convert.ToInt32(rowVal?.ToString() ?? "0"), null);
                        }
                        else if (item.PropertyType == typeof(double) ||
                            item.PropertyType == typeof(double?))
                        {
                            item.SetValue(t, Convert.ToDouble(rowVal?.ToString() ?? "0"), null);
                        }
                        else if (item.PropertyType == typeof(decimal) ||
                            item.PropertyType == typeof(decimal?))
                        {
                            item.SetValue(t, Convert.ToDecimal(rowVal?.ToString() ?? "0"), null);
                        }
                        else if (item.PropertyType == typeof(DateTime) ||
                            item.PropertyType == typeof(DateTime?))
                        {
                            item.SetValue(t, Convert.ToDateTime(rowVal?.ToString() ?? DateTime.MinValue.ToString("yyyy-MM-dd")), null);
                        }
                        else
                        {
                            throw new NotImplementedException($"指定转换无效{item.PropertyType}");
                        }
                    }
                }

                list.Add(t);
            }
            return list;
        }
    }
}
