using System;
namespace NF.MODEL
{
	/// <summary>
	/// 问题-处理部门
	/// </summary>
	[Serializable]
	public partial class Mod_TMC_QUESTION_DEPT
    {
		public Mod_TMC_QUESTION_DEPT()
		{}
        #region Model
        private string _c_id = Guid.NewGuid().ToString();
		private string _c_question_id;
		private string _c_dept_id;
		private string _c_remark;
		private string _c_emp_id;
		private string _c_emp_name;
		private DateTime? _d_mod_dt= Convert.ToDateTime(DateTime.Now);
		/// <summary>
		/// C_ID
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 问题ID
		/// </summary>
		public string C_QUESTION_ID
		{
			set{ _c_question_id=value;}
			get{return _c_question_id;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string C_DEPT_ID
		{
			set{ _c_dept_id=value;}
			get{return _c_dept_id;}
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

