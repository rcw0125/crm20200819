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
        private string _c_id = Guid.NewGuid().ToString();
        private string _c_mat_code;
        private string _c_mat_name;
        private string _c_stl_grd;
        private string _c_spec;
        private decimal? _n_price;
        private decimal? _n_discount;
        private decimal? _n_rate;
        private decimal? _n_orimoto;
        private decimal? _c_status = 1;
		private string _c_remark;
        private string _c_emp_id;
        private string _c_emp_name;
        private DateTime? _d_mod_dt = Convert.ToDateTime(DateTime.Now);
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
        /// 单价
        /// </summary>
        public decimal? N_PRICE
        {
            set { _n_price = value; }
            get { return _n_price; }
        }
        /// <summary>
        /// 折扣
        /// </summary>
        public decimal? N_DISCOUNT
        {
            set { _n_discount = value; }
            get { return _n_discount; }
        }
        /// <summary>
        /// 税率
        /// </summary>
        public decimal? N_RATE
        {
            set { _n_rate = value; }
            get { return _n_rate; }
        }
        /// <summary>
        /// 折本汇率
        /// </summary>
        public decimal? N_ORIMOTO
        {
            set { _n_orimoto = value; }
            get { return _n_orimoto; }
        }
        /// <summary>
        /// 状态：0停用  1启用
        /// </summary>
        public decimal? C_STATUS
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
        public DateTime? D_MOD_DT
        {
            set { _d_mod_dt = value; }
            get { return _d_mod_dt; }
        }
        #endregion Model
    }
}

