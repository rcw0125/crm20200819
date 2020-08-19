using System;
namespace NF.MODEL
{
	/// <summary>
	/// 客户开票单位
	/// </summary>
	[Serializable]
	public partial class Mod_TS_CUSTOTCOMPANY
    {
		public Mod_TS_CUSTOTCOMPANY()
		{}
		#region Model
		private string _c_id;
		private string _c_cust_id;
		private string _c_otcompany;
		private string _c_openbank;
		private string _c_accountbank;
		private decimal? _n_isdefault;
		/// <summary>
		/// 主键
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 外键客户档案
		/// </summary>
		public string C_CUST_ID
		{
			set{ _c_cust_id=value;}
			get{return _c_cust_id;}
		}
		/// <summary>
		/// 开票单位
		/// </summary>
		public string C_OTCOMPANY
		{
			set{ _c_otcompany=value;}
			get{return _c_otcompany;}
		}
		/// <summary>
		/// 开户银行
		/// </summary>
		public string C_OPENBANK
		{
			set{ _c_openbank=value;}
			get{return _c_openbank;}
		}
		/// <summary>
		/// 账号
		/// </summary>
		public string C_ACCOUNTBANK
		{
			set{ _c_accountbank=value;}
			get{return _c_accountbank;}
		}
		/// <summary>
		/// 是否默认
		/// </summary>
		public decimal? N_ISDEFAULT
		{
			set{ _n_isdefault=value;}
			get{return _n_isdefault;}
		}
		#endregion Model

	}
}

