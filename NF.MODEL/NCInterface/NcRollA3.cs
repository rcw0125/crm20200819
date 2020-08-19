using System;
namespace MODEL
{
    public partial class NcRollA3
    {
        /// <summary>
        /// 
        /// </summary>
        public string hzdrid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string hpch { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string hwlbmid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string hjldwid { get; set; }


        /// <summary>
        /// 制单日期
        /// </summary>
        public DateTime hzdrq { get; set; }

        /// <summary>
        /// 成品自由项1
        /// </summary>
        public string hfreeitemvalue1 { get; set; }

        /// <summary>
        /// 成品自由项2
        /// </summary>
        public string hfreeitemvalue2 { get; set; }

        /// <summary>
        /// 成品包装要求
        /// </summary>
        public string hfreeitemvalue3 { get; set; }

        /// <summary>
        /// 库管员
        /// </summary>
        public string kgyid { get; set; }

        /// <summary>
        /// 批次号 炉号
        /// </summary>
        public string pch { get; set; }

        /// <summary>
        /// 物料编码ID C_PK_INVBASDOC
        /// </summary>
        public string wlbmid { get; set; }

        /// <summary>
        /// 计量单位ID
        /// </summary>
        public string jldwid { get; set; }

        /// <summary>
        /// 辅计量单位ID
        /// </summary>
        public string fjldwid { get; set; }
        
        /// <summary>
        /// 制单日期
        /// </summary>
        public DateTime zdrq { get; set; }

        /// <summary>
        /// 线材自由项1
        /// </summary>
        public string freeitemvalue1 { get; set; }

        /// <summary>
        /// 线材自由项2
        /// </summary>
        public string freeitemvalue2 { get; set; }

        /// <summary>
        /// 线材包装要求
        /// </summary>
        public string freeitemvalue3 { get; set; }

        /// <summary>
        /// 出库仓库ID
        /// </summary>
        public string ckckid { get; set; }

        /// <summary>
        /// 累计出库数量
        /// </summary>
        public string ljcksl { get; set; }

        /// <summary>
        /// 辅累计出库数量
        /// </summary>
        public string fljcksl { get; set; }

        /// <summary>
        /// 工作中心ID
        /// </summary>
        public string gzzxid { get; set; }

        /// <summary>
        /// 出炉日期
        /// </summary>
        public string flrq { get; set; }


    }
}
