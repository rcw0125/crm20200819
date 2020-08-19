using System;
namespace NF.MODEL
{
    /// <summary>
    /// 低毛利订单
    /// </summary>
    [Serializable]
    public partial class Mod_TMO_LOWMAOLI_ORDER
    {
        public Mod_TMO_LOWMAOLI_ORDER()
        { }
        public string C_ID { set; get; }

        /// <summary>
        /// 客户编码
        /// </summary>
        public string C_CUSTNO { set; get; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string C_CUSTNAME { set; get; }
        /// <summary>
        /// 合同号
        /// </summary>
        public string C_CONNO { set; get; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string C_ORDERNO { set; get; }
        /// <summary>
        /// 钢种
        /// </summary>
        public string C_STLGRD { set; get; }
        /// <summary>
        /// 规格
        /// </summary>
        public string C_SPEC { set; get; }
        /// <summary>
        /// 毛利
        /// </summary>
        public string C_MAOLI { set; get; }
        /// <summary>
        /// 签单量
        /// </summary>
        public decimal N_WGT { set; get; }
        /// <summary>
        /// 业务人员ID
        /// </summary>
        public string C_EMPID { set; get; }
        /// <summary>
        /// 业务姓名
        /// </summary>
        public string C_EMPNAME { set; get; }
        /// <summary>
        /// 签署日期
        /// </summary>
        public DateTime D_CONSING_DT { set; get; }
        /// <summary>
        /// 合同生效日期
        /// </summary>
        public DateTime D_CONEFFE_DT { set; get; }
        /// <summary>
        /// 销售组织
        /// </summary>
        public string C_SALEORG { set; get; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal N_PRICE { set; get; }
        /// <summary>
        /// 成本价
        /// </summary>
        public decimal N_COSTPRICE { set; get; }


    }
}

