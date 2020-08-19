using System;
namespace NF.MODEL
{
	/// <summary>
	/// 下一处理人表
	/// </summary>
	[Serializable]
	public partial class Mod_TMB_FILE_NEXT_EMP
    {
		public Mod_TMB_FILE_NEXT_EMP()
		{}
		#region Model
		private string _c_id;
		private string _c_file_id;
		private string _c_flow_id;
		private string _c_next_emp_id;
		private string _c_remark;
		private string _c_step_id;
		/// <summary>
		/// 主键
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 文件ID
		/// </summary>
		public string C_FILE_ID
		{
			set{ _c_file_id=value;}
			get{return _c_file_id;}
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
		/// 下一处理人ID
		/// </summary>
		public string C_NEXT_EMP_ID
		{
			set{ _c_next_emp_id=value;}
			get{return _c_next_emp_id;}
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
		/// 步骤ID
		/// </summary>
		public string C_STEP_ID
		{
			set{ _c_step_id=value;}
			get{return _c_step_id;}
		}
		#endregion Model

	}
}

