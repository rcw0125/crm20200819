using System;
namespace NF.MODEL
{
	/// <summary>
	/// 客服
	/// </summary>
	[Serializable]
	public partial class Mod_TMC_CHAT_EMP
    {
		public Mod_TMC_CHAT_EMP()
		{}
		#region Model
		private string _c_id=Guid.NewGuid().ToString ();
		private string _c_user_id;
		private string _c_remark;
		private decimal? _n_status=1;
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
		/// 负责人
		/// </summary>
		public string C_USER_ID
		{
			set{ _c_user_id=value;}
			get{return _c_user_id;}
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

