using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.MODEL
{
    public class WWContractInfo : NF.MODEL.Mod_TMO_ORDER
    {
        /// <summary>
        /// 可组批量
        /// </summary>
        public decimal SumWgt { get; set; }

        /// <summary>
        /// 已组批量
        /// </summary>
        public decimal HasSumWgt { get; set; }

        /// <summary>
        /// 质量等级
        /// </summary>
        public string ZLDJ { get; set; }
    }

    public class WWCFXNInfo
    {
        public string C_CHARACTER_ID { get; set; }

        public string C_ITEM_NAME { get; set; }

        public string C_TYPE { get; set; }

        public string C_VALUE { get; set; }
        public string C_VALUE1 { get; set; }
        public string C_VALUE2 { get; set; }
        public string C_VALUE3 { get; set; }


        public string C_REMARK { get; set; }

        public bool IsAdd { get; set; } = false;

        public string C_IS_PRINT { get; set; }

        public string C_IS_DECIDE { get; set; }
    }
}
