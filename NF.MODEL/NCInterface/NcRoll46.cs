using System;
namespace MODEL
{
    public partial class NcRoll46
    {
        /// <summary>
        /// 仓库ID
        /// </summary>
        public string cwarehouseid { get; set; }

        /// <summary>
        /// 库房签字时间 入库日期
        /// </summary>
        public DateTime taccounttime { get; set; }

        /// <summary>
        /// 入库人  
        /// </summary>
        public string coperatorid { get; set; }

        /// <summary>
        /// 质量等级NC主键  
        /// </summary>
        public string ccheckstate_bid { get; set; }

        /// <summary>
        /// 工作中心主键  
        /// </summary>
        public string cworkcenterid { get; set; }

        /// <summary>
        /// 业务日期 入库日期  
        /// </summary>
        public DateTime dbizdate { get; set; }

        /// <summary>
        /// 批次号  
        /// </summary>
        public string vbatchcode { get; set; }

        /// <summary>
        /// 存货基本ID C_PK_INVBASDOC  
        /// </summary>
        public string cinvbasid { get; set; }

        /// <summary>
        /// 物料PK C_PK_PRODUCE  
        /// </summary>
        public string pk_produce { get; set; }

        /// <summary>
        /// 实入数量 
        /// </summary>
        public string ninnum { get; set; }

        /// <summary>
        /// 实入辅数量 件数 
        /// </summary>
        public string ninassistnum { get; set; }

        /// <summary>
        /// 辅计量单位ID 
        /// </summary>
        public string castunitid { get; set; }

        public string vfree1 { get; set; }
        public string vfree2 { get; set; }
        public string vfree3 { get; set; }

    }
}
