using System;
namespace NF.MODEL
{
    /// <summary>
    /// 每月低毛利限量指标
    /// </summary>
    [Serializable]
    public partial class Mod_TMB_STLGRD_PRICE_WGT
    {
        public Mod_TMB_STLGRD_PRICE_WGT()
        { }

        public string C_ID { set; get; }

        /// <summary>
        /// 月份
        /// </summary>
        public DateTime D_MONTH { set; get; }
        /// <summary>
        /// 物料组编码
        /// </summary>
        public string C_MAT_GROUP_CODE { set; get; }
        /// <summary>
        /// 物料组名称
        /// </summary>
        public string C_MAT_GROUP_NAME { set; get; }
        /// <summary>
        /// 品种
        /// </summary>
        public string C_PROD_KIND { set; get; }
        /// <summary>
        /// 规则最小值
        /// </summary>
        public string C_SPEC_MIN { set; get; }
        /// <summary>
        /// 规格最大值
        /// </summary>
        public string C_SPEC_MAX { set; get; }
        /// <summary>
        /// 单价
        /// </summary>
        public string C_PRICE { set; get; }
        /// <summary>
        /// 毛利
        /// </summary>
        public string C_MAOLI { set; get; }
        /// <summary>
        /// 成本
        /// </summary>
        public string C_COST { set; get; }
        /// <summary>
        /// 边际贡献
        /// </summary>
        public string C_BJGX { set; get; }
        /// <summary>
        /// 固定成本
        /// </summary>
        public string C_FIX_COST { set; get; }
        /// <summary>
        /// 销售组织
        /// </summary>
        public string C_SALESORG { set; get; }
        /// <summary>
        /// 低毛利钢种限量范围
        /// </summary>
        public decimal N_WGT { set; get; }
        /// <summary>
        /// 最新修改人主键
        /// </summary>
        public string C_EMPID { set; get; }
        /// <summary>
        /// 最新修改人姓名
        /// </summary>
        public string C_EMPNAME { set; get; }
        /// <summary>
        /// 最新修改时间
        /// </summary>
        public DateTime D_DT { set; get; }

   
    }
}

