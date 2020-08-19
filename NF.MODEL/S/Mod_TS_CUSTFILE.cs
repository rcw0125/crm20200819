using System;
namespace NF.MODEL
{
	/// <summary>
	/// 客户档案
	/// </summary>
	[Serializable]
	public partial class Mod_TS_CUSTFILE
    {
		public Mod_TS_CUSTFILE()
		{}
        #region Model
        private string _c_id = Guid.NewGuid().ToString ();
        private string _c_nc_id;
        private string _c_nc_m_id;
        private decimal? _n_isflag;
        private string _c_no;
        private string _c_name;
        private string _c_shorname;
        private string _c_areatype;
        private string _c_legalrepres;
        private string _c_agent;
        private string _c_operator;
        private string _c_fax;
        private string _c_taxpayerno;
        private decimal _n_level = 1;
		private decimal _n_status = 1;
		private decimal? _n_type;
        private string _c_extend1;
        private string _c_extend2;
        private string _c_extend3;
        private string _c_extend4;
        private string _c_extend5;
        private string _c_emp_id;
        private string _c_emp_name;
        private DateTime _d_mod_dt = Convert.ToDateTime(DateTime.Now);
        private decimal? _n_isgps = 0;
		private string _c_areammax;
        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// NC客商档案主键
        /// </summary>
        public string C_NC_ID
        {
            set { _c_nc_id = value; }
            get { return _c_nc_id; }
        }
        /// <summary>
        /// NC客商管理档案主键
        /// </summary>
        public string C_NC_M_ID
        {
            set { _c_nc_m_id = value; }
            get { return _c_nc_m_id; }
        }
        /// <summary>
        /// 是否客户    2是，1否
        /// </summary>
        public decimal? N_ISFLAG
        {
            set { _n_isflag = value; }
            get { return _n_isflag; }
        }
        /// <summary>
        /// 客商编号
        /// </summary>
        public string C_NO
        {
            set { _c_no = value; }
            get { return _c_no; }
        }
        /// <summary>
        /// 客商名称
        /// </summary>
        public string C_NAME
        {
            set { _c_name = value; }
            get { return _c_name; }
        }
        /// <summary>
        /// 客商简称
        /// </summary>
        public string C_SHORNAME
        {
            set { _c_shorname = value; }
            get { return _c_shorname; }
        }
        /// <summary>
        /// 地区分类
        /// </summary>
        public string C_AREATYPE
        {
            set { _c_areatype = value; }
            get { return _c_areatype; }
        }
        /// <summary>
        /// 法定代表人
        /// </summary>
        public string C_LEGALREPRES
        {
            set { _c_legalrepres = value; }
            get { return _c_legalrepres; }
        }
        /// <summary>
        /// 委托代理人
        /// </summary>
        public string C_AGENT
        {
            set { _c_agent = value; }
            get { return _c_agent; }
        }
        /// <summary>
        /// 经办人
        /// </summary>
        public string C_OPERATOR
        {
            set { _c_operator = value; }
            get { return _c_operator; }
        }
        /// <summary>
        /// 传真
        /// </summary>
        public string C_FAX
        {
            set { _c_fax = value; }
            get { return _c_fax; }
        }
        /// <summary>
        /// 纳税人登记号
        /// </summary>
        public string C_TAXPAYERNO
        {
            set { _c_taxpayerno = value; }
            get { return _c_taxpayerno; }
        }
        /// <summary>
        /// 客户级别：1优先  2普通
        /// </summary>
        public decimal N_LEVEL
        {
            set { _n_level = value; }
            get { return _n_level; }
        }
        /// <summary>
        /// 客户状态：1启用，0停用
        /// </summary>
        public decimal N_STATUS
        {
            set { _n_status = value; }
            get { return _n_status; }
        }
        /// <summary>
        /// 客户类别: 1经销商  2直销商
        /// </summary>
        public decimal? N_TYPE
        {
            set { _n_type = value; }
            get { return _n_type; }
        }
        /// <summary>
        /// 扩展字段1
        /// </summary>
        public string C_EXTEND1
        {
            set { _c_extend1 = value; }
            get { return _c_extend1; }
        }
        /// <summary>
        /// 扩展字段2
        /// </summary>
        public string C_EXTEND2
        {
            set { _c_extend2 = value; }
            get { return _c_extend2; }
        }
        /// <summary>
        /// 扩展字段3
        /// </summary>
        public string C_EXTEND3
        {
            set { _c_extend3 = value; }
            get { return _c_extend3; }
        }
        /// <summary>
        /// 扩展字段4
        /// </summary>
        public string C_EXTEND4
        {
            set { _c_extend4 = value; }
            get { return _c_extend4; }
        }
        /// <summary>
        /// 扩展字段5
        /// </summary>
        public string C_EXTEND5
        {
            set { _c_extend5 = value; }
            get { return _c_extend5; }
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
        /// 是否GPS  0否，1是
        /// </summary>
        public decimal? N_ISGPS
        {
            set { _n_isgps = value; }
            get { return _n_isgps; }
        }
        /// <summary>
        /// 区域
        /// </summary>
        public string C_AREAMMAX
        {
            set { _c_areammax = value; }
            get { return _c_areammax; }
        }
        #endregion Model

    }
}

