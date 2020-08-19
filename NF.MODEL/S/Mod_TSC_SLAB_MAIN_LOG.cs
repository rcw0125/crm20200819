using System;
namespace NF.MODEL
{
    /// <summary>
    /// 钢坯实绩记录表
    /// </summary>
    [Serializable]
    public partial class Mod_TSC_SLAB_MAIN_LOG
    {
        public Mod_TSC_SLAB_MAIN_LOG()
        { }
        #region Model
        private string _c_id = "sys_guid";
        private string _c_main_id;
        private string _c_ckdh;
        private decimal? _n_status;
        private DateTime? _d_date;
        private string _c_bc;
        private string _c_bz;
        private string _c_emp_id;
        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 实绩主键
        /// </summary>
        public string C_MAIN_ID
        {
            set { _c_main_id = value; }
            get { return _c_main_id; }
        }
        /// <summary>
        /// 出库单号
        /// </summary>
        public string C_CKDH
        {
            set { _c_ckdh = value; }
            get { return _c_ckdh; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public decimal? N_STATUS
        {
            set { _n_status = value; }
            get { return _n_status; }
        }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime? D_DATE
        {
            set { _d_date = value; }
            get { return _d_date; }
        }
        /// <summary>
        /// 班次
        /// </summary>
        public string C_BC
        {
            set { _c_bc = value; }
            get { return _c_bc; }
        }
        /// <summary>
        /// 班组
        /// </summary>
        public string C_BZ
        {
            set { _c_bz = value; }
            get { return _c_bz; }
        }
        /// <summary>
        /// 操作人
        /// </summary>
        public string C_EMP_ID
        {
            set { _c_emp_id = value; }
            get { return _c_emp_id; }
        }
        #endregion Model

    }
}
