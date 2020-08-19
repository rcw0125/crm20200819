using System;
namespace NF.MODEL
{
	/// <summary>
	/// 流程处理明细表
	/// </summary>
	[Serializable]
	public partial class Mod_TMB_FLOWPROC
    {
		public Mod_TMB_FLOWPROC()
		{}
		#region Model
		private string _c_id;
		private string _c_file_id;
		private string _c_step_id;
		private string _c_step_emp_id;
		private string _c_stepnote;
		private DateTime? _d_step_dt;
		private string _c_next_emp_id;
		private decimal? _n_procresult;
		private string _c_remark;
		/// <summary>
		/// 主键
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 文件事务ID
		/// </summary>
		public string C_FILE_ID
		{
			set{ _c_file_id=value;}
			get{return _c_file_id;}
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
		/// 步骤处理人员ID
		/// </summary>
		public string C_STEP_EMP_ID
		{
			set{ _c_step_emp_id=value;}
			get{return _c_step_emp_id;}
		}
		/// <summary>
		/// 步骤处理内容
		/// </summary>
		public string C_STEPNOTE
		{
			set{ _c_stepnote=value;}
			get{return _c_stepnote;}
		}
		/// <summary>
		/// 步骤处理时间
		/// </summary>
		public DateTime? D_STEP_DT
		{
			set{ _d_step_dt=value;}
			get{return _d_step_dt;}
		}
		/// <summary>
		/// 下一处理人
		/// </summary>
		public string C_NEXT_EMP_ID
		{
			set{ _c_next_emp_id=value;}
			get{return _c_next_emp_id;}
		}
		/// <summary>
		/// 处理结果
		/// </summary>
		public decimal? N_PROCRESULT
		{
			set{ _n_procresult=value;}
			get{return _n_procresult;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string C_REMARK
		{
			set{ _c_remark=value;}
			get{return _c_remark;}
		}
		#endregion Model

	}
}

