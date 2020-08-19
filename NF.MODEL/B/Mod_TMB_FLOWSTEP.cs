using System;
namespace NF.MODEL
{
	/// <summary>
	/// 流程-步骤对应表
	/// </summary>
	[Serializable]
	public partial class Mod_TMB_FLOWSTEP
    {
		public Mod_TMB_FLOWSTEP()
		{}
		#region Model
		private string _c_id=Guid.NewGuid().ToString();
		private string _c_flow_id;
		private string _c_step_id;
		private decimal? _n_type;
		private decimal? _n_sort;
		private decimal? _n_status=1;
		private string _c_approve_id;
		private string _d_aging_dt;
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
		/// 流程ID
		/// </summary>
		public string C_FLOW_ID
		{
			set{ _c_flow_id=value;}
			get{return _c_flow_id;}
		}
		/// <summary>
		/// 步骤ID
		/// </summary>
		public string C_STEP_ID
		{
			set{ _c_step_id=value;}
			get{return _c_step_id;}
		}
		/// <summary>
		/// 类型：0顺序处理，1并行处理
		/// </summary>
		public decimal? N_TYPE
		{
			set{ _n_type=value;}
			get{return _n_type;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public decimal? N_SORT
		{
			set{ _n_sort=value;}
			get{return _n_sort;}
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
		/// 审批人
		/// </summary>
		public string C_APPROVE_ID
		{
			set{ _c_approve_id=value;}
			get{return _c_approve_id;}
		}
		/// <summary>
		/// 时效时间
		/// </summary>
		public string D_AGING_DT
		{
			set{ _d_aging_dt=value;}
			get{return _d_aging_dt;}
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
		/// 系统操作时间
		/// </summary>
		public DateTime? D_MOD_DT
		{
			set{ _d_mod_dt=value;}
			get{return _d_mod_dt;}
		}
		#endregion Model

	}
}

