using System;
namespace NF.MODEL
{
    /// <summary>
    /// 合同
    /// </summary>
    [Serializable]
    public partial class Mod_TMO_CON_END
    {
        public Mod_TMO_CON_END()
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
        /// 0未确认，1已确认
        /// </summary>
        public string C_FLAG { set; get; }
        /// <summary>
        /// 客户操作人ID
        /// </summary>
        public string C_EMPID { set; get; }
        /// <summary>
        ///客户操作时间
        /// </summary>
        public DateTime D_EMPDT { set; get; }
        /// <summary>
        /// 业务员ID
        /// </summary>
        public string C_SALEEMPID { set; get; }
        /// <summary>
        /// 业务员操作时间
        /// </summary>
        public DateTime D_SALEDT { set; get; }
        /// <summary>
        /// 备注原因
        /// </summary>
        public string C_REMARK { set; get; }
        /// <summary>
        /// 合同号
        /// </summary>
        public string C_CONNO { set; get; }
        public string C_AREA { set; get; }
    }
}

