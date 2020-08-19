using System;
namespace NF.MODEL
{
	/// <summary>
	/// 接口日志
	/// </summary>
	[Serializable]
	public partial class Mod_TMB_INTERFACE_LOG
    {
		public Mod_TMB_INTERFACE_LOG()
		{}
		#region Model
		private string _c_id;
		private string _c_pkid;
		private decimal? _n_sendnum=0;
		private string _c_empid;
		private DateTime? _d_sendtime;
		private string _c_resultcode;
		private string _c_resultdesc;
		private string _c_content;
		private string _c_remark;
		private string _c_flag;
		/// <summary>
		/// 
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 表主键
		/// </summary>
		public string C_PKID
		{
			set{ _c_pkid=value;}
			get{return _c_pkid;}
		}
		/// <summary>
		/// 发送次数
		/// </summary>
		public decimal? N_SENDNUM
		{
			set{ _n_sendnum=value;}
			get{return _n_sendnum;}
		}
		/// <summary>
		/// 操作人ID
		/// </summary>
		public string C_EMPID
		{
			set{ _c_empid=value;}
			get{return _c_empid;}
		}
		/// <summary>
		/// 发送时间
		/// </summary>
		public DateTime? D_SENDTIME
		{
			set{ _d_sendtime=value;}
			get{return _d_sendtime;}
		}
		/// <summary>
		/// 返回结果代码
		/// </summary>
		public string C_RESULTCODE
		{
			set{ _c_resultcode=value;}
			get{return _c_resultcode;}
		}
		/// <summary>
		/// 返回结果描述
		/// </summary>
		public string C_RESULTDESC
		{
			set{ _c_resultdesc=value;}
			get{return _c_resultdesc;}
		}
		/// <summary>
		/// 返回内容
		/// </summary>
		public string C_CONTENT
		{
			set{ _c_content=value;}
			get{return _c_content;}
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
		/// 标识
		/// </summary>
		public string C_FLAG
		{
			set{ _c_flag=value;}
			get{return _c_flag;}
		}
		#endregion Model

	}
}

