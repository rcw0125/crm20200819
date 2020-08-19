using System;
namespace NF.MODEL
{
    /// <summary>
    /// 到货地点费用
    /// </summary>
    [Serializable]
    public partial class Mod_TMB_NCADDRESS_COST
    {
        public Mod_TMB_NCADDRESS_COST()
        { }
        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID { set; get; }
        /// <summary>
        /// 承运商
        /// </summary>
        public string C_CHENGYUN { set; get; }
        /// <summary>
        /// 发运方式
        /// </summary>
        public string C_FAYUN { set; get; }
        /// <summary>
        /// 到货编码
        /// </summary>
        public string C_ADDRCODE { set; get; }
        /// <summary>
        /// 到货地点
        /// </summary>
        public string C_ADDRNAME { set; get; }
        /// <summary>
        /// 费用
        /// </summary>
        public decimal N_PRICE { set; get; }
        /// <summary>
        /// 生效日期
        /// </summary>
        public DateTime D_START_DT { set; get; }
        /// <summary>
        /// 失效日期
        /// </summary>
        public DateTime D_END_DT { set; get; }
        /// <summary>
        /// 制单人
        /// </summary>
        public string C_CREATE_EMP { set; get; }
        /// <summary>
        /// 制单时间
        /// </summary>
        public DateTime D_CREATE_DT { set; get; }
        /// <summary>
        /// 到货NC主键
        /// </summary>
        public string C_ADDR_NCPK { set; get; }
        /// <summary>
        /// 到货区域主键
        /// </summary>
        public string C_AREA_PK { set; get; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string C_EMP { set; get; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime D_EMP { set; get; }

    }
}

