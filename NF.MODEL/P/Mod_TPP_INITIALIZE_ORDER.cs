using System;
namespace NF.MODEL
{
	/// <summary>
	/// 排产初始化子表
	/// </summary>
	[Serializable]
	public partial class Mod_TPP_INITIALIZE_ORDER
    {
		public Mod_TPP_INITIALIZE_ORDER()
		{}
        #region Model
        private string _c_id = "sys_guid";
        private string _c_initialize_id;
        private string _c_order_id;
        private decimal? _n_wgt;
        private decimal? _n_mach_wgt;
        private string _c_design_no;
        private decimal _n_status = 0;
		private decimal _n_flag = 0;
		private string _c_remark;
        private string _c_emp_id;
        private string _c_emp_name;
        private DateTime _d_mod_dt = Convert.ToDateTime(DateTime.Now);
        private string _c_rh;
        private string _c_lf;
        private string _c_kp;
        private decimal? _n_hl_time;
        private string _c_hl;
        private decimal? _n_dfp_hl_time;
        private string _c_dfp_hl;
        private string _c_xm;
        private string _c_roll_sta_id;
        private string _c_ccm_sta_id;
        private decimal? _n_mach_wgt_ccm;
        private decimal _n_lgpc_status = 0 ;
		private decimal _n_exec_status = 0 ;
		private decimal? _n_roll_prod_wgt = 0;
		private decimal? _n_sms_prod_wgt = 0;
		/// <summary>
		/// 主键
		/// </summary>
		public string C_ID
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 方案表主键
        /// </summary>
        public string C_INITIALIZE_ID
        {
            set { _c_initialize_id = value; }
            get { return _c_initialize_id; }
        }
        /// <summary>
        /// 订单池表主键
        /// </summary>
        public string C_ORDER_ID
        {
            set { _c_order_id = value; }
            get { return _c_order_id; }
        }
        /// <summary>
        /// 初始化排产量
        /// </summary>
        public decimal? N_WGT
        {
            set { _n_wgt = value; }
            get { return _n_wgt; }
        }
        /// <summary>
        /// 机时产量（轧钢）
        /// </summary>
        public decimal? N_MACH_WGT
        {
            set { _n_mach_wgt = value; }
            get { return _n_mach_wgt; }
        }
        /// <summary>
        /// 质量设计号
        /// </summary>
        public string C_DESIGN_NO
        {
            set { _c_design_no = value; }
            get { return _c_design_no; }
        }
        /// <summary>
        /// 订单状态：0待生效，1已生效，2失效
        /// </summary>
        public decimal N_STATUS
        {
            set { _n_status = value; }
            get { return _n_status; }
        }
        /// <summary>
        /// 订单标识：0正常，1增订，2变更，3预测，4 附属品
        /// </summary>
        public decimal N_FLAG
        {
            set { _n_flag = value; }
            get { return _n_flag; }
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
        /// 系统操作人编号
        /// </summary>
        public string C_EMP_ID
        {
            set { _c_emp_id = value; }
            get { return _c_emp_id; }
        }
        /// <summary>
        /// 系统操作人姓名
        /// </summary>
        public string C_EMP_NAME
        {
            set { _c_emp_name = value; }
            get { return _c_emp_name; }
        }
        /// <summary>
        /// 系系统操作时间
        /// </summary>
        public DateTime D_MOD_DT
        {
            set { _d_mod_dt = value; }
            get { return _d_mod_dt; }
        }
        /// <summary>
        /// 过真空
        /// </summary>
        public string C_RH
        {
            set { _c_rh = value; }
            get { return _c_rh; }
        }
        /// <summary>
        /// 精炼
        /// </summary>
        public string C_LF
        {
            set { _c_lf = value; }
            get { return _c_lf; }
        }
        /// <summary>
        /// 开坯
        /// </summary>
        public string C_KP
        {
            set { _c_kp = value; }
            get { return _c_kp; }
        }
        /// <summary>
        /// 缓冷时间
        /// </summary>
        public decimal? N_HL_TIME
        {
            set { _n_hl_time = value; }
            get { return _n_hl_time; }
        }
        /// <summary>
        /// 缓冷
        /// </summary>
        public string C_HL
        {
            set { _c_hl = value; }
            get { return _c_hl; }
        }
        /// <summary>
        /// 大方坯缓冷时间
        /// </summary>
        public decimal? N_DFP_HL_TIME
        {
            set { _n_dfp_hl_time = value; }
            get { return _n_dfp_hl_time; }
        }
        /// <summary>
        /// 大方坯缓冷
        /// </summary>
        public string C_DFP_HL
        {
            set { _c_dfp_hl = value; }
            get { return _c_dfp_hl; }
        }
        /// <summary>
        /// 修磨
        /// </summary>
        public string C_XM
        {
            set { _c_xm = value; }
            get { return _c_xm; }
        }
        /// <summary>
        /// 轧线工位主键
        /// </summary>
        public string C_ROLL_STA_ID
        {
            set { _c_roll_sta_id = value; }
            get { return _c_roll_sta_id; }
        }
        /// <summary>
        /// 连铸工位主键
        /// </summary>
        public string C_CCM_STA_ID
        {
            set { _c_ccm_sta_id = value; }
            get { return _c_ccm_sta_id; }
        }
        /// <summary>
        /// 机时产量（连铸）
        /// </summary>
        public decimal? N_MACH_WGT_CCM
        {
            set { _n_mach_wgt_ccm = value; }
            get { return _n_mach_wgt_ccm; }
        }
        /// <summary>
        /// 炼钢排产状态
        /// </summary>
        public decimal N_LGPC_STATUS
        {
            set { _n_lgpc_status = value; }
            get { return _n_lgpc_status; }
        }
        /// <summary>
        /// 轧钢排产状态
        /// </summary>
        public decimal N_EXEC_STATUS
        {
            set { _n_exec_status = value; }
            get { return _n_exec_status; }
        }
        /// <summary>
        /// 轧钢排产量
        /// </summary>
        public decimal? N_ROLL_PROD_WGT
        {
            set { _n_roll_prod_wgt = value; }
            get { return _n_roll_prod_wgt; }
        }
        /// <summary>
        /// 炼钢排产量
        /// </summary>
        public decimal? N_SMS_PROD_WGT
        {
            set { _n_sms_prod_wgt = value; }
            get { return _n_sms_prod_wgt; }
        }
        #endregion Model

    }
}

