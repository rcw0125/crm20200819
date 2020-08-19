using System;
namespace NF.MODEL
{
	/// <summary>
	/// 邢钢公司基本信息
	/// </summary>
	[Serializable]
	public partial class Mod_TMB_XG
    {
		public Mod_TMB_XG()
		{}
		#region Model
		private string _c_id=Guid.NewGuid().ToString ();
		private string _c_name;
		private string _c_fr;
		private string _c_wt;
		private string _c_jb;
		private string _c_tel;
		private string _c_fax;
		private string _c_bank_name;
		private string _c_bank_no;
		private string _c_remark;
		private string _c_extend1;
		private string _c_extend2;
		private string _c_extend3;
		private string _c_extend4;
		/// <summary>
		/// 主键
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 公司名称
		/// </summary>
		public string C_NAME
		{
			set{ _c_name=value;}
			get{return _c_name;}
		}
		/// <summary>
		/// 法人代表
		/// </summary>
		public string C_FR
		{
			set{ _c_fr=value;}
			get{return _c_fr;}
		}
		/// <summary>
		/// 委托代理人
		/// </summary>
		public string C_WT
		{
			set{ _c_wt=value;}
			get{return _c_wt;}
		}
		/// <summary>
		/// 经办人
		/// </summary>
		public string C_JB
		{
			set{ _c_jb=value;}
			get{return _c_jb;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string C_TEL
		{
			set{ _c_tel=value;}
			get{return _c_tel;}
		}
		/// <summary>
		/// 传真
		/// </summary>
		public string C_FAX
		{
			set{ _c_fax=value;}
			get{return _c_fax;}
		}
		/// <summary>
		/// 工行银行
		/// </summary>
		public string C_BANK_NAME
		{
			set{ _c_bank_name=value;}
			get{return _c_bank_name;}
		}
		/// <summary>
		/// 账号
		/// </summary>
		public string C_BANK_NO
		{
			set{ _c_bank_no=value;}
			get{return _c_bank_no;}
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
		/// 
		/// </summary>
		public string C_EXTEND1
		{
			set{ _c_extend1=value;}
			get{return _c_extend1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string C_EXTEND2
		{
			set{ _c_extend2=value;}
			get{return _c_extend2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string C_EXTEND3
		{
			set{ _c_extend3=value;}
			get{return _c_extend3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string C_EXTEND4
		{
			set{ _c_extend4=value;}
			get{return _c_extend4;}
		}
		#endregion Model

	}
}

