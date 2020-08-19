using System;
namespace NF.MODEL
{
	/// <summary>
	/// 区域计划量表
	/// </summary>
	[Serializable]
	public partial class Mod_TMB_AREAPLAN
    {
		public Mod_TMB_AREAPLAN()
		{}
        #region Model
        private string _c_id = Guid.NewGuid().ToString();
		private string _c_aera_id;
		private decimal? _n_wgt;
		private DateTime? _d_start;
		private DateTime? _d_end;
		private string _c_remark;
        private decimal? _n_status = 1;
		private string _c_emp_id;
		private string _c_emp_name;
		private DateTime? _d_mod_dt= Convert.ToDateTime(DateTime.Now);

        /// <summary>
        /// 编号
        /// </summary>
        public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 区域ID
		/// </summary>
		public string C_AERA_ID
		{
			set{ _c_aera_id=value;}
			get{return _c_aera_id;}
		}
		/// <summary>
		/// 预算量
		/// </summary>
		public decimal? N_WGT
		{
			set{ _n_wgt=value;}
			get{return _n_wgt; }
		}
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime? D_START
		{
			set{ _d_start=value;}
			get{return _d_start;}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime? D_END
		{
			set{ _d_end=value;}
			get{return _d_end;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string C_REMARK
		{
			set{ _c_remark=value;}
			get{return _c_remark;}
		}
		/// <summary>
		/// 状态0停用1启用
		/// </summary>
		public decimal? N_STATUS
		{
			set{ _n_status=value;}
			get{return _n_status;}
		}
		/// <summary>
		/// 系统操作人编号
		/// </summary>
		public string C_EMP_ID
		{
			set{ _c_emp_id=value;}
			get{return _c_emp_id;}
		}
		/// <summary>
		/// 系统操作人姓名
		/// </summary>
		public string C_EMP_NAME
		{
			set{ _c_emp_name=value;}
			get{return _c_emp_name;}
		}
		/// <summary>
		/// 系系统操作时间
		/// </summary>
		public DateTime? D_MOD_DT
		{
			set{ _d_mod_dt=value;}
			get{return _d_mod_dt;}
		}

		#endregion Model

	}
}

