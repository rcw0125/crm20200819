using System;
namespace NF.MODEL
{
	/// <summary>
	/// 合同完成工差
	/// </summary>
	[Serializable]
	public partial class Mod_TMB_COMDIFF
    {
		public Mod_TMB_COMDIFF()
		{}
        #region Model
        private string _c_id = Guid.NewGuid().ToString();
		private decimal? _d_min;
		private decimal? _d_max;
		private string _c_range;
		private decimal? _n_status=1;
		private string _c_emp_id;
		private string _c_emp_name;
		private DateTime? _d_mod_dt= Convert.ToDateTime(DateTime.Now);
		/// <summary>
		/// 主键
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 最小值
		/// </summary>
		public decimal? D_MIN
		{
			set{ _d_min=value;}
			get{return _d_min;}
		}
		/// <summary>
		/// 最大值
		/// </summary>
		public decimal? D_MAX
		{
			set{ _d_max=value;}
			get{return _d_max;}
		}
		/// <summary>
		/// 误差范围
		/// </summary>
		public string C_RANGE
		{
			set{ _c_range=value;}
			get{return _c_range;}
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

