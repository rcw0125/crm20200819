using System;
namespace NF.MODEL
{
	/// <summary>
	/// 角色表
	/// </summary>
	[Serializable]
	public partial class Mod_TS_ROLE
    {
		public Mod_TS_ROLE()
		{}
		#region Model
		private string _c_id=Guid.NewGuid().ToString ();
		private string _c_name;
		private string _c_code;
		private string _c_desc;
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
		/// 名称
		/// </summary>
		public string C_NAME
		{
			set{ _c_name=value;}
			get{return _c_name;}
		}
		/// <summary>
		/// C_CODE
		/// </summary>
		public string C_CODE
		{
			set{ _c_code=value;}
			get{return _c_code;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string C_DESC
		{
			set{ _c_desc=value;}
			get{return _c_desc;}
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

