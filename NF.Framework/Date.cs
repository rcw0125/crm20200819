using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework
{
    public class Date
    {

        /// <summary>
        /// 获取计划交货日期
        /// </summary>
        /// <param name="STL_GRD">钢种</param>
        /// <param name="SPEC">规格</param>
        /// <param name="STD_CODE">执行标准</param>
        /// <param name="WGT">重量</param>
        /// <returns></returns>
        public static DateTime GetDeliveryDate(string STL_GRD,string SPEC,string STD_CODE,string WGT)
        {
            DateTime dt = DateTime.Now;
            return dt;
        }
    }
}
