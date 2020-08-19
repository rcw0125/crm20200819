using System;
namespace NF.MODEL
{
    /// <summary>
    /// 客户档案
    /// </summary>
    [Serializable]
    public partial class Mod_TS_CUST_SF
    {
        public Mod_TS_CUST_SF()
        { }
        #region Model

        /// <summary>
        /// 
        /// </summary>
        public string C_ID
        {
            set; get;
        }
        /// <summary>
        /// 三方客户编码
        /// </summary>
        public string C_CUSTCODE
        {
            set; get;
        }
        /// <summary>
        /// 上级客户编码
        /// </summary>
        public string C_CUSTCODE_PARENT
        {
            set; get;
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? D_DT
        {
            set; get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string C_EMPNAME
        {
            set; get;
        }
        /// <summary>
        /// 三方客户名称
        /// </summary>
        public string C_CUSTNAME
        {
            set; get;
        }
        #endregion Model

    }
}

