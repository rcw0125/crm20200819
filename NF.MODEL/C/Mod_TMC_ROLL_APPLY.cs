using System;
namespace NF.MODEL
{
	/// <summary>
	/// 资源申请记录
	/// </summary>
	[Serializable]
	public partial class Mod_TMC_ROLL_APPLY
    {
		public Mod_TMC_ROLL_APPLY()
		{}
		#region Model
		private string _c_id;
		private string _c_title;
		private string _c_content;
		private string _c_empid;
		private string _c_empname;
		private DateTime? _d_mod;
		private string _c_status;
		private string _c_approveid;
		private DateTime? _d_approvedate;
		/// <summary>
		/// 主键
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 标题
		/// </summary>
		public string C_TITLE
		{
			set{ _c_title=value;}
			get{return _c_title;}
		}
		/// <summary>
		/// 内容
		/// </summary>
		public string C_CONTENT
		{
			set{ _c_content=value;}
			get{return _c_content;}
		}
		/// <summary>
		/// 申请人ID
		/// </summary>
		public string C_EMPID
		{
			set{ _c_empid=value;}
			get{return _c_empid;}
		}
		/// <summary>
		/// 申请姓名
		/// </summary>
		public string C_EMPNAME
		{
			set{ _c_empname=value;}
			get{return _c_empname;}
		}
		/// <summary>
		/// 申请时间
		/// </summary>
		public DateTime? D_MOD
		{
			set{ _d_mod=value;}
			get{return _d_mod;}
		}
		/// <summary>
		/// 状态：0审核中，1批准，2驳回
		/// </summary>
		public string C_STATUS
		{
			set{ _c_status=value;}
			get{return _c_status;}
		}
		/// <summary>
		/// 审批人
		/// </summary>
		public string C_APPROVEID
		{
			set{ _c_approveid=value;}
			get{return _c_approveid;}
		}
		/// <summary>
		/// 审批时间
		/// </summary>
		public DateTime? D_APPROVEDATE
		{
			set{ _d_approvedate=value;}
			get{return _d_approvedate;}
		}
		#endregion Model

	}
}

