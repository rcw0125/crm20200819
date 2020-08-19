using System;
namespace MODEL
{
    public partial class NcRollA1
    {
        /// <summary>
        /// 部门id
        /// </summary>
        public string bmid { get; set; }

        /// <summary>
        /// 计划日期
        /// </summary>
        public DateTime jhrq { get; set; }

        /// <summary>
        /// 下限数量
        /// </summary>
        public string jhxxsl { get; set; }

        /// <summary>
        /// 计划员id
        /// </summary>
        public string jhyid { get; set; }

        /// <summary>
        /// 计量单位ID
        /// </summary>
        public string jldwid { get; set; }

        /// <summary>
        /// 物料PK
        /// </summary>
        public string pk_produce { get; set; }

        /// <summary>
        /// 生产部门id
        /// </summary>
        public string scbmid { get; set; }

        /// <summary>
        /// 操作员
        /// </summary>
        public string shrid { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime shrq { get; set; }

        /// <summary>
        /// 需求日期（生完成日期）
        /// </summary>
        public DateTime slrq { get; set; }

        /// <summary>
        /// 下单日期
        /// </summary>
        public DateTime xdrq { get; set; }

        /// <summary>
        /// 交货日期
        /// </summary>
        public DateTime xqrq { get; set; }

        /// <summary>
        /// 制单日期
        /// </summary>
        public DateTime zdrq { get; set; }

        /// <summary>
        /// 计划量
        /// </summary>
        public string xqsl { get; set; }

        /// <summary>
        /// C_PK_INVBASDOC
        /// </summary>
        public string wlbmid { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string memo { get; set; }

        /// <summary>
        /// 自由项
        /// </summary>
        public string zyx1 { get; set; }

        /// <summary>
        /// 自由项2
        /// </summary>
        public string zyx2 { get; set; }

        /// <summary>
        /// 包装要求
        /// </summary>
        public string zyx3 { get; set; }

        /// <summary>
        /// pci主键
        /// </summary>
        public string zyx5 { get; set; }

    }
}
