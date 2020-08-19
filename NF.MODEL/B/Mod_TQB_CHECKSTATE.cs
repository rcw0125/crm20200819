using System;
namespace NF.MODEL
{
	/// <summary>
	/// 质量判定等级
	/// </summary>
	[Serializable]
	public partial class Mod_TQB_CHECKSTATE
    {
		public Mod_TQB_CHECKSTATE()
		{}
		#region Model
		private string _c_id;
		private string _c_checkstate_code;
		private string _c_checkstate_name;
		private string _c_checkstate_type;
		private decimal _n_status=1;
		private string _c_remark;
		private string _c_emp_id;
		private DateTime _d_mod_dt= Convert.ToDateTime(DateTime.Now);
		/// <summary>
		/// 主键
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 判定等级代码
		/// </summary>
		public string C_CHECKSTATE_CODE
		{
			set{ _c_checkstate_code=value;}
			get{return _c_checkstate_code;}
		}
		/// <summary>
		/// 判定等级名称
		/// </summary>
		public string C_CHECKSTATE_NAME
		{
			set{ _c_checkstate_name=value;}
			get{return _c_checkstate_name;}
		}
		/// <summary>
		/// 类型
		/// </summary>
		public string C_CHECKSTATE_TYPE
		{
			set{ _c_checkstate_type=value;}
			get{return _c_checkstate_type;}
		}
		/// <summary>
		/// 使用状态   1-可用；0-停用
		/// </summary>
		public decimal N_STATUS
		{
			set{ _n_status=value;}
			get{return _n_status;}
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
		/// 维护人
		/// </summary>
		public string C_EMP_ID
		{
			set{ _c_emp_id=value;}
			get{return _c_emp_id;}
		}
		/// <summary>
		/// 维护时间
		/// </summary>
		public DateTime D_MOD_DT
		{
			set{ _d_mod_dt=value;}
			get{return _d_mod_dt;}
		}
		#endregion Model

	}
}

