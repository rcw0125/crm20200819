using System;
namespace NF.MODEL
{
	/// <summary>
	/// 税率档案
	/// </summary>
	[Serializable]
	public partial class Mod_TMB_TAXITEMS
    {
		public Mod_TMB_TAXITEMS()
		{}
		#region Model
		private string _c_id;
		private string _c_taxcode;
		private string _c_taxname;
		private decimal? _n_taxratio;
		private DateTime? _d_ts= Convert.ToDateTime(DateTime.Now);
		private string _c_source="同步NC";
		/// <summary>
		/// 主键
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 编码
		/// </summary>
		public string C_TAXCODE
		{
			set{ _c_taxcode=value;}
			get{return _c_taxcode;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string C_TAXNAME
		{
			set{ _c_taxname=value;}
			get{return _c_taxname;}
		}
		/// <summary>
		/// 税率
		/// </summary>
		public decimal? N_TAXRATIO
		{
			set{ _n_taxratio=value;}
			get{return _n_taxratio;}
		}
		/// <summary>
		/// 同步时间
		/// </summary>
		public DateTime? D_TS
		{
			set{ _d_ts=value;}
			get{return _d_ts;}
		}
		/// <summary>
		/// 来源
		/// </summary>
		public string C_SOURCE
		{
			set{ _c_source=value;}
			get{return _c_source;}
		}
		#endregion Model

	}
}

