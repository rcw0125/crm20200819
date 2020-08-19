using System;
namespace MODEL
{
    public partial class NcRollA4
    {
        /// <summary>
        ///操作人
        /// </summary>
        public string zdrid { get; set; }

        /// <summary>
        ///完工日期
        /// </summary>
        public DateTime rq { get; set; }

        /// <summary>
        ///报告时间
        /// </summary>
        public DateTime sj { get; set; }

        /// <summary>
        ///开始日期
        /// </summary>
        public DateTime ksrq { get; set; }

        /// <summary>
        ///结束日期
        /// </summary>
        public DateTime jsrq { get; set; }

        /// <summary>
        /// 工作中心编码
        /// </summary>
        public string gzzxbmid { get; set; }

        /// <summary>
        /// 生产部门ID
        /// </summary>
        public string scbmid { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        public string pch { get; set; }

        /// <summary>
        /// 物料编码ID
        /// </summary>
        public string wlbmid { get; set; }

        /// <summary>
        /// 计量单位ID
        /// </summary>
        public string jldwid { get; set; }

        /// <summary>
        /// 工作中心ID
        /// </summary>
        public string gzzxid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ccxh { get; set; }

        /// <summary>
        /// 物料PK
        /// </summary>
        public string pk_produce { get; set; }

        /// <summary>
        /// 合格数量
        /// </summary>
        public string hgsl { get; set; }

        /// <summary>
        /// 辅合格数量
        /// </summary>
        public string fhgsl { get; set; }

        /// <summary>
        /// 是否联副产品
        /// </summary>
        public string sflfcp { get; set; }

        /// <summary>
        /// 是否发生改判
        /// </summary>
        public string sffsgp { get; set; }

        public string freeitemvalue1 { get; set; }
        public string freeitemvalue2 { get; set; }
        public string freeitemvalue3 { get; set; }
    }
}
