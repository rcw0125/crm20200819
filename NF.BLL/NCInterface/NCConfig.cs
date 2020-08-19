using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.BLL.NCInterface
{
    public static class NCConfig
    {
        /// <summary>
        /// NC接口URL
        /// </summary>
        //public static string Url { get; set; } = "http://192.168.2.230:80/service/XChangeServlet?account=001&receiver=101";
        public static string Url { get; set; } = "http://192.168.2.231:80/service/XChangeServlet?account=001&receiver=101";

        /// <summary>
        /// NC接口开关
        /// </summary>
        public static bool IsSendToNC { get; set; } = true;
    }
}
