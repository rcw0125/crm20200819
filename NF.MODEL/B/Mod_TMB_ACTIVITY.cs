using System;
namespace NF.MODEL
{
	/// <summary>
	/// 折扣-税率-单价表
	/// </summary>
	[Serializable]
	public partial class Mod_TMB_ACTIVITY
    {
		public Mod_TMB_ACTIVITY()
		{}
        #region Model
        private string _c_id;
        private string _c_mat_code;
        private string _c_mat_name;
        private string _c_stl_grd;
        private string _c_spec;
        private decimal? _n_price;
        private decimal? _n_price2;
        private decimal _c_status;
        private string _c_remark;
        private string _c_emp_id;
        private string _c_emp_name;
        private DateTime _d_mod_dt;
        private string _c_areamax;
        private string _c_prod_name;
        private DateTime? _d_start_dt;
        private DateTime? _d_end_dt;
        /// <summary>
        /// C_ID
        /// </summary>
        public string C_ID
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string C_MAT_CODE
        {
            set { _c_mat_code = value; }
            get { return _c_mat_code; }
        }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string C_MAT_NAME
        {
            set { _c_mat_name = value; }
            get { return _c_mat_name; }
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
        /// 规格
        /// </summary>
        public string C_SPEC
        {
            set { _c_spec = value; }
            get { return _c_spec; }
        }
        /// <summary>
        /// 成本价
        /// </summary>
        public decimal? N_PRICE
        {
            set { _n_price = value; }
            get { return _n_price; }
        }
        /// <summary>
        /// 售价
        /// </summary>
        public decimal? N_PRICE2
        {
            set { _n_price2 = value; }
            get { return _n_price2; }
        }
        /// <summary>
        /// 状态：0停用  1启用
        /// </summary>
        public decimal C_STATUS
        {
            set { _c_status = value; }
            get { return _c_status; }
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
        /// 操作人ID
        /// </summary>
        public string C_EMP_ID
        {
            set { _c_emp_id = value; }
            get { return _c_emp_id; }
        }
        /// <summary>
        /// 操作人
        /// </summary>
        public string C_EMP_NAME
        {
            set { _c_emp_name = value; }
            get { return _c_emp_name; }
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
        /// 区域
        /// </summary>
        public string C_AREAMAX
        {
            set { _c_areamax = value; }
            get { return _c_areamax; }
        }
        /// <summary>
        /// 物料组编码
        /// </summary>
        public string C_PROD_NAME
        {
            set { _c_prod_name = value; }
            get { return _c_prod_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? D_START_DT
        {
            set { _d_start_dt = value; }
            get { return _d_start_dt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? D_END_DT
        {
            set { _d_end_dt = value; }
            get { return _d_end_dt; }
        }
        #endregion Model
    }
}

