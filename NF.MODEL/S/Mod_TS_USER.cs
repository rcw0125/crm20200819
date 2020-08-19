using System;
namespace NF.MODEL
{
	/// <summary>
	/// 用户表
	/// </summary>
	[Serializable]
	public partial class Mod_TS_USER
    {
		public Mod_TS_USER()
		{}
        #region Model
        private string _c_id = Guid.NewGuid().ToString();
        private string _c_name;
        private string _c_account;
        private string _c_password;
        private string _c_email;
        private string _c_mobile;
        private decimal? _n_type;
        private decimal? _n_status = 1;
		private string _c_desc;
        private DateTime? _d_lastlogintime = Convert.ToDateTime(DateTime.Now);
        private string _c_emp_id;
        private string _c_emp_name;
        private DateTime? _d_mod_dt = Convert.ToDateTime(DateTime.Now);
        private string _c_mobile2;
        private string _c_phone;
        private string _c_shortname;
        private string _c_cust_id;
        private string _c_token_id;
        private string _c_cjname;
        private string _c_cjintro;
        private string _c_stl_grd;
        private string _c_legalrepres;
        private string _c_cgjcr;
        private string _c_job;
        private string _c_jctel;
        private string _c_address;
        private string _c_area;
        private string _c_manager;
        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string C_NAME
        {
            set { _c_name = value; }
            get { return _c_name; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string C_ACCOUNT
        {
            set { _c_account = value; }
            get { return _c_account; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string C_PASSWORD
        {
            set { _c_password = value; }
            get { return _c_password; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string C_EMAIL
        {
            set { _c_email = value; }
            get { return _c_email; }
        }
        /// <summary>
        /// 手机
        /// </summary>
        public string C_MOBILE
        {
            set { _c_mobile = value; }
            get { return _c_mobile; }
        }
        /// <summary>
        /// 用户类型（1内部，2新用户,3PCI用户）
        /// </summary>
        public decimal? N_TYPE
        {
            set { _n_type = value; }
            get { return _n_type; }
        }
        /// <summary>
        /// 状态(1正常，2，3，4冻结)
        /// </summary>
        public decimal? N_STATUS
        {
            set { _n_status = value; }
            get { return _n_status; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string C_DESC
        {
            set { _c_desc = value; }
            get { return _c_desc; }
        }
        /// <summary>
        /// 最后登陆时间
        /// </summary>
        public DateTime? D_LASTLOGINTIME
        {
            set { _d_lastlogintime = value; }
            get { return _d_lastlogintime; }
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
        public DateTime? D_MOD_DT
        {
            set { _d_mod_dt = value; }
            get { return _d_mod_dt; }
        }
        /// <summary>
        /// 手机2
        /// </summary>
        public string C_MOBILE2
        {
            set { _c_mobile2 = value; }
            get { return _c_mobile2; }
        }
        /// <summary>
        /// 座机
        /// </summary>
        public string C_PHONE
        {
            set { _c_phone = value; }
            get { return _c_phone; }
        }
        /// <summary>
        /// 短名称
        /// </summary>
        public string C_SHORTNAME
        {
            set { _c_shortname = value; }
            get { return _c_shortname; }
        }
        /// <summary>
        /// 客户档案ID -NC
        /// </summary>
        public string C_CUST_ID
        {
            set { _c_cust_id = value; }
            get { return _c_cust_id; }
        }
        /// <summary>
        /// TOKEN_ID
        /// </summary>
        public string C_TOKEN_ID
        {
            set { _c_token_id = value; }
            get { return _c_token_id; }
        }
        /// <summary>
        /// 厂家名称
        /// </summary>
        public string C_CJNAME
        {
            set { _c_cjname = value; }
            get { return _c_cjname; }
        }
        /// <summary>
        /// 厂家简介
        /// </summary>
        public string C_CJINTRO
        {
            set { _c_cjintro = value; }
            get { return _c_cjintro; }
        }
        /// <summary>
        /// 使用钢种
        /// </summary>
        public string C_STL_GRD
        {
            set { _c_stl_grd = value; }
            get { return _c_stl_grd; }
        }
        /// <summary>
        /// 法人代表
        /// </summary>
        public string C_LEGALREPRES
        {
            set { _c_legalrepres = value; }
            get { return _c_legalrepres; }
        }
        /// <summary>
        /// 采购决策人员姓名
        /// </summary>
        public string C_CGJCR
        {
            set { _c_cgjcr = value; }
            get { return _c_cgjcr; }
        }
        /// <summary>
        /// 采购决策人员姓名职务
        /// </summary>
        public string C_JOB
        {
            set { _c_job = value; }
            get { return _c_job; }
        }
        /// <summary>
        /// 采购决策人员电话
        /// </summary>
        public string C_JCTEL
        {
            set { _c_jctel = value; }
            get { return _c_jctel; }
        }
        /// <summary>
        /// 具体地址
        /// </summary>
        public string C_ADDRESS
        {
            set { _c_address = value; }
            get { return _c_address; }
        }
        /// <summary>
        /// 区域
        /// </summary>
        public string C_AREA
        {
            set { _c_area = value; }
            get { return _c_area; }
        }
        /// <summary>
        /// 客户经理
        /// </summary>
        public string C_MANAGER
        {
            set { _c_manager = value; }
            get { return _c_manager; }
        }
        #endregion Model

    }
}

