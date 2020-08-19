using System;
namespace NF.MODEL
{
	/// <summary>
	/// 客户地址
	/// </summary>
	[Serializable]
	public partial class Mod_TS_CUSTADDR
    {
		public Mod_TS_CUSTADDR()
		{}
		#region Model
		private string _c_id;
		private string _c_cust_id;
		private string _c_cgc;
		private string _c_cgaddr;
		private string _c_cgarea;
		private string _c_cgman;
		private string _c_postcode;
		private string _c_cgmobile;
		private string _c_cgmobile2;
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
		/// 收货单位
		/// </summary>
		public string C_CGC
		{
			set{ _c_cgc=value;}
			get{return _c_cgc;}
		}
		/// <summary>
		/// 收货地址
		/// </summary>
		public string C_CGADDR
		{
			set{ _c_cgaddr=value;}
			get{return _c_cgaddr;}
		}
		/// <summary>
		/// 收货地区
		/// </summary>
		public string C_CGAREA
		{
			set{ _c_cgarea=value;}
			get{return _c_cgarea;}
		}
		/// <summary>
		/// 收货人
		/// </summary>
		public string C_CGMAN
		{
			set{ _c_cgman=value;}
			get{return _c_cgman;}
		}
		/// <summary>
		/// 邮政编码
		/// </summary>
		public string C_POSTCODE
		{
			set{ _c_postcode=value;}
			get{return _c_postcode;}
		}
		/// <summary>
		/// 收货电话
		/// </summary>
		public string C_CGMOBILE
		{
			set{ _c_cgmobile=value;}
			get{return _c_cgmobile;}
		}
		/// <summary>
		/// 收货电话2
		/// </summary>
		public string C_CGMOBILE2
		{
			set{ _c_cgmobile2=value;}
			get{return _c_cgmobile2;}
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

