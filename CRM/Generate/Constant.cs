using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM
{
    public static class Constant
    {
        static Constant()
        {
            WireSale.Add("是", "0001NC10000000007H28");
            WireSale.Add("否", "0001NC10000000007H29");  
        }
        public const string RESET_PWD_TOKEN = "30D73A3EC5AB4BA1934699749F7D8C81";
        public static Dictionary<string, string> WireSale = new Dictionary<string, string>();

    }
}