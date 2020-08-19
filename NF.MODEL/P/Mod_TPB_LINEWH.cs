using System;
namespace NF.MODEL
{
	/// <summary>
	/// 线材库信息
	/// </summary>
	[Serializable]
	public partial class Mod_TPB_LINEWH
	{
		public Mod_TPB_LINEWH()
		{}
        #region Model
        private string _c_id = "sys_guid";
        private string _c_linewh_code;
        private string _c_linewh_name;
        private decimal _n_status = 1M;
        private string _c_emp_id;
        private DateTime _d_mod_dt = Convert.ToDateTime(DateTime.Now);
        private string _c_remark;
        private DateTime? _d_start_date;
        private DateTime? _d_end_date;
        private string _c_nc_code;
        private string _c_rf_code;
        private string _c_nc_pk;
        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 线材仓库编码
        /// </summary>
        public string C_LINEWH_CODE
        {
            set { _c_linewh_code = value; }
            get { return _c_linewh_code; }
        }
        /// <summary>
        /// 线材仓库描述
        /// </summary>
        public string C_LINEWH_NAME
        {
            set { _c_linewh_name = value; }
            get { return _c_linewh_name; }
        }
        /// <summary>
        /// 使用状态   1-可用；0-停用
        /// </summary>
        public decimal N_STATUS
        {
            set { _n_status = value; }
            get { return _n_status; }
        }
        /// <summary>
        /// 操作人
        /// </summary>
        public string C_EMP_ID
        {
            set { _c_emp_id = value; }
            get { return _c_emp_id; }
        }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime D_MOD_DT
        {
            set { _d_mod_dt = value; }
            get { return _d_mod_dt; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string C_REMARK
        {
            set { _c_remark = value; }
            get { return _c_remark; }
        }
        /// <summary>
        /// 启用时间
        /// </summary>
        public DateTime? D_START_DATE
        {
            set { _d_start_date = value; }
            get { return _d_start_date; }
        }
        /// <summary>
        /// 停用时间
        /// </summary>
        public DateTime? D_END_DATE
        {
            set { _d_end_date = value; }
            get { return _d_end_date; }
        }
        /// <summary>
        /// NC表代码
        /// </summary>
        public string C_NC_CODE
        {
            set { _c_nc_code = value; }
            get { return _c_nc_code; }
        }
        /// <summary>
        /// 条码表主键
        /// </summary>
        public string C_RF_CODE
        {
            set { _c_rf_code = value; }
            get { return _c_rf_code; }
        }
        /// <summary>
        /// NC表主键
        /// </summary>
        public string C_NC_PK
        {
            set { _c_nc_pk = value; }
            get { return _c_nc_pk; }
        }
        #endregion Model

    }
}

