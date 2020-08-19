using System;
namespace NF.MODEL
{
	/// <summary>
	/// 执行标准信息主表
	/// </summary>
	[Serializable]
	public partial class Mod_TQB_STD_MAIN
	{
		public Mod_TQB_STD_MAIN()
		{}
        #region Model
        private string _c_id = Guid.NewGuid().ToString ();
        private string _c_std_type;
        private string _c_std_code;
        private string _c_std_desc;
        private string _c_stl_grd;
        private string _c_prod_name;
        private string _c_prod_kind;
        private string _c_uses;
        private decimal? _n_edit_num;
        private string _c_edition;
        private string _c_is_lf = "否";
        private string _c_is_rh = "否";
        private string _c_is_hl;
        private string _c_is_xm = "否";
        private string _c_iron_require;
        private string _c_stock_require;
        private string _c_delivery_state;
        private string _c_physics_time;
        private decimal _n_is_check = 0;
		private decimal _n_status = 1;
		private string _c_remark;
        private string _c_emp_id;
        private DateTime _d_mod_dt = Convert.ToDateTime(DateTime.Now);
        private string _c_is_design = "0";
        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 执行表标准类型表主键
        /// </summary>
        public string C_STD_TYPE
        {
            set { _c_std_type = value; }
            get { return _c_std_type; }
        }
        /// <summary>
        /// 执行标准代码
        /// </summary>
        public string C_STD_CODE
        {
            set { _c_std_code = value; }
            get { return _c_std_code; }
        }
        /// <summary>
        /// 执行标准描述
        /// </summary>
        public string C_STD_DESC
        {
            set { _c_std_desc = value; }
            get { return _c_std_desc; }
        }
        /// <summary>
        /// 钢种
        /// </summary>
        public string C_STL_GRD
        {
            set { _c_stl_grd = value; }
            get { return _c_stl_grd; }
        }
        /// <summary>
        /// 类别
        /// </summary>
        public string C_PROD_NAME
        {
            set { _c_prod_name = value; }
            get { return _c_prod_name; }
        }
        /// <summary>
        /// 品种
        /// </summary>
        public string C_PROD_KIND
        {
            set { _c_prod_kind = value; }
            get { return _c_prod_kind; }
        }
        /// <summary>
        /// 用途
        /// </summary>
        public string C_USES
        {
            set { _c_uses = value; }
            get { return _c_uses; }
        }
        /// <summary>
        /// 修改次数
        /// </summary>
        public decimal? N_EDIT_NUM
        {
            set { _n_edit_num = value; }
            get { return _n_edit_num; }
        }
        /// <summary>
        /// 版本号
        /// </summary>
        public string C_EDITION
        {
            set { _c_edition = value; }
            get { return _c_edition; }
        }
        /// <summary>
        /// 是否LF
        /// </summary>
        public string C_IS_LF
        {
            set { _c_is_lf = value; }
            get { return _c_is_lf; }
        }
        /// <summary>
        /// 是否RH
        /// </summary>
        public string C_IS_RH
        {
            set { _c_is_rh = value; }
            get { return _c_is_rh; }
        }
        /// <summary>
        /// 是否缓冷
        /// </summary>
        public string C_IS_HL
        {
            set { _c_is_hl = value; }
            get { return _c_is_hl; }
        }
        /// <summary>
        /// 是否修磨
        /// </summary>
        public string C_IS_XM
        {
            set { _c_is_xm = value; }
            get { return _c_is_xm; }
        }
        /// <summary>
        /// 铁水要求
        /// </summary>
        public string C_IRON_REQUIRE
        {
            set { _c_iron_require = value; }
            get { return _c_iron_require; }
        }
        /// <summary>
        /// 库存条件
        /// </summary>
        public string C_STOCK_REQUIRE
        {
            set { _c_stock_require = value; }
            get { return _c_stock_require; }
        }
        /// <summary>
        /// 交货状态
        /// </summary>
        public string C_DELIVERY_STATE
        {
            set { _c_delivery_state = value; }
            get { return _c_delivery_state; }
        }
        /// <summary>
        /// 性能检验时效
        /// </summary>
        public string C_PHYSICS_TIME
        {
            set { _c_physics_time = value; }
            get { return _c_physics_time; }
        }
        /// <summary>
        /// 是否审核   1-已审核；0-未审核
        /// </summary>
        public decimal N_IS_CHECK
        {
            set { _n_is_check = value; }
            get { return _n_is_check; }
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
        /// 备注
        /// </summary>
        public string C_REMARK
        {
            set { _c_remark = value; }
            get { return _c_remark; }
        }
        /// <summary>
        /// 维护人
        /// </summary>
        public string C_EMP_ID
        {
            set { _c_emp_id = value; }
            get { return _c_emp_id; }
        }
        /// <summary>
        /// 维护时间
        /// </summary>
        public DateTime D_MOD_DT
        {
            set { _d_mod_dt = value; }
            get { return _d_mod_dt; }
        }
        /// <summary>
        /// 是否已经质量设计；0未设计；1已设计
        /// </summary>
        public string C_IS_DESIGN
        {
            set { _c_is_design = value; }
            get { return _c_is_design; }
        }
        #endregion Model

    }
}

