using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework
{
    public class AjaxResult
    {
        public AjaxResult()
        { }
        public string Result { get; set; }
        public DoResult Code { get; set; }
    }
    public enum DoResult
    {
        Failed = 0,
        Success = 1,
        OverTime = 2,
        NoAuthorization = 3,
        Other = 255
    }
}
