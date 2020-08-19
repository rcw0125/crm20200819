using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework
{
    public enum PrintRemarkEnum:int
    {
        [Description("线材")]
        XC = 1,
        [Description("钢坯")]
        GP = 2,
        [Description("委外")]
        WW=3
    }

    public enum PrintTypeEnum : int
    {
        [Description("质证书打印")]
        P = 1,
        [Description("委外质证书打印")]
        WWP = 2
    }
    public enum PrintStateEnum : int
    {
        [Description("未打印")]
        NoPrint = 0,
        [Description("已打印")]
        YesPrint = 1,
        [Description("异常项")]
        Ex = 2,
        [Description("补打")]
        RePrint = 3
    }
}
