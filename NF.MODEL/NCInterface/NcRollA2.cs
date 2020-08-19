using System;
namespace MODEL
{
    public partial class NcRollA2
    {
        /// <summary>
        /// C_PK_INVBASDOC
        /// </summary>
        public string wlbmid { get; set; }

        /// <summary>
        /// 物料PK
        /// </summary>
        public string pk_produce { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        public string invcode { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        public string pch { get; set; }

        /// <summary>
        /// 生产部门ID
        /// </summary>
        public string scbmid { get; set; }

        /// <summary>
        /// 工作中心ID
        /// </summary>
        public string gzzxid { get; set; }

        /// <summary>
        /// 班次ID
        /// </summary>
        public string bcid { get; set; }

        /// <summary>
        /// 班组ID
        /// </summary>
        public string bzid { get; set; }

        /// <summary>
        /// 计划开工日期
        /// </summary>
        public DateTime jhkgrq { get; set; }

        /// <summary>
        /// 计划完工日期
        /// </summary>
        public DateTime jhwgrq { get; set; }

        /// <summary>
        /// 计划开始时间
        /// </summary>
        public DateTime jhkssj { get; set; }

        /// <summary>
        /// 计划结束时间
        /// </summary>
        public DateTime jhjssj { get; set; }

        /// <summary>
        ///实际开工日期 完工单日期
        /// </summary>
        public DateTime sjkgrq { get; set; }

        /// <summary>
        ///实际完工日期 完工单日期
        /// </summary>
        public DateTime sjwgrq { get; set; }

        /// <summary>
        ///实际开始时间 完工单开始时间
        /// </summary>
        public DateTime sjkssj { get; set; }

        /// <summary>
        ///实际结束时间 完工单结束时间
        /// </summary>
        public DateTime sjjssj { get; set; }

        /// <summary>
        /// 计划完工数量
        /// </summary>
        public string jhwgsl { get; set; }

        /// <summary>
        /// 辅计量数量
        /// </summary>
        public string fjhsl { get; set; }

        /// <summary>
        /// 计量单位ID
        /// </summary>
        public string jldwid { get; set; }

        /// <summary>
        /// 辅计量ID
        /// </summary>
        public string fjlid { get; set; }

        /// <summary>
        /// 实际完工数量 完工数量
        /// </summary>
        public string sjwgsl { get; set; }

        public string freeitemvalue1 { get; set; }
        public string freeitemvalue2 { get; set; }
        public string freeitemvalue3 { get; set; }

        /// <summary>
        /// 操作人(用户编码)
        /// </summary>
        public string zdrid { get; set; }

        /// <summary>
        /// PCI计划订单主键
        /// </summary>
        public string freeitemvalue5 { get; set; }

    }
}
