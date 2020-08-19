using System;
namespace NF.MODEL
{
	/// <summary>
	/// 订单挂单表
	/// </summary>
	[Serializable]
	public partial class Mod_TMO_ORDER_MATCH
    {
		public Mod_TMO_ORDER_MATCH()
		{}
		#region Model
		private string _c_id= "sys_guid";
		private string _c_order_no;
		private string _c_match_id;
		private string _c_old_order_no;
		private decimal? _c_type;
		private DateTime? _d_dt= Convert.ToDateTime(System.DateTime.Now);
		/// <summary>
		/// C_ID
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 订单号
		/// </summary>
		public string C_ORDER_NO
		{
			set{ _c_order_no=value;}
			get{return _c_order_no;}
		}
		/// <summary>
		/// 匹配表ID
		/// </summary>
		public string C_MATCH_ID
		{
			set{ _c_match_id=value;}
			get{return _c_match_id;}
		}
		/// <summary>
		/// 原订单号
		/// </summary>
		public string C_OLD_ORDER_NO
		{
			set{ _c_old_order_no=value;}
			get{return _c_old_order_no;}
		}
		/// <summary>
		/// 品种类型:8线材，6钢坯
		/// </summary>
		public decimal? C_TYPE
		{
			set{ _c_type=value;}
			get{return _c_type;}
		}
		/// <summary>
		/// 提交时间
		/// </summary>
		public DateTime? D_DT
		{
			set{ _d_dt=value;}
			get{return _d_dt;}
		}
		#endregion Model

	}
}

