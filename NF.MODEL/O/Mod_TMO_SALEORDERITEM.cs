using System;
namespace NF.MODEL
{
	/// <summary>
	/// 销售订单子表
	/// </summary>
	[Serializable]
	public partial class Mod_TMO_SALEORDERITEM
    {
		public Mod_TMO_SALEORDERITEM()
		{}
		#region Model
		private string _c_id= Guid.NewGuid().ToString ();
		private string _c_billid;
		private string _c_initialize_id;
		private string _c_orderno;
		private string _c_conno;
		private string _c_invbasdocid;
		private string _c_inventoryid;
		private string _c_unitid;
		private string _c_funitid;
		private decimal? _n_number;
		private DateTime? _d_consigndate;
		private DateTime? _d_deliverdate;
		private string _c_pk_corp="1001";
		private string _c_advisecalbodyid="1001NC10000000000669";
		private string _c_currencytypeid;
		private decimal? _n_taxrate;
		private decimal? _n_originalcurprice;
		private decimal? _n_originalcurtaxprice;
		private decimal? _n_originalcurtaxmny;
		private decimal? _n_originalcurmny;
		private string _c_receiptareaid;
		private string _c_receiveaddress;
		private string _c_receiptcorpid;
		private decimal? _n_originalcursummny;
		private string _c_vfree1;
		private string _c_vfree2;
		private string _c_vfree3;
		private string _c_vdef1;
		private string _c_remark;
		private decimal? _n_status=1;
		private string _c_initorderid;
		/// <summary>
		/// 主键
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 来源销售主表ID
		/// </summary>
		public string C_BILLID
		{
			set{ _c_billid=value;}
			get{return _c_billid;}
		}
		/// <summary>
		/// 来源方案表主键
		/// </summary>
		public string C_INITIALIZE_ID
		{
			set{ _c_initialize_id=value;}
			get{return _c_initialize_id;}
		}
		/// <summary>
		/// 订单号
		/// </summary>
		public string C_ORDERNO
		{
			set{ _c_orderno=value;}
			get{return _c_orderno;}
		}
		/// <summary>
		/// 合同号
		/// </summary>
		public string C_CONNO
		{
			set{ _c_conno=value;}
			get{return _c_conno;}
		}
		/// <summary>
		/// 存货档案主键
		/// </summary>
		public string C_INVBASDOCID
		{
			set{ _c_invbasdocid=value;}
			get{return _c_invbasdocid;}
		}
		/// <summary>
		/// 存货管理档案主键
		/// </summary>
		public string C_INVENTORYID
		{
			set{ _c_inventoryid=value;}
			get{return _c_inventoryid;}
		}
		/// <summary>
		/// 主计量单位
		/// </summary>
		public string C_UNITID
		{
			set{ _c_unitid=value;}
			get{return _c_unitid;}
		}
		/// <summary>
		/// 辅单位
		/// </summary>
		public string C_FUNITID
		{
			set{ _c_funitid=value;}
			get{return _c_funitid;}
		}
		/// <summary>
		/// 数量
		/// </summary>
		public decimal? N_NUMBER
		{
			set{ _n_number=value;}
			get{return _n_number;}
		}
		/// <summary>
		/// 发货日期
		/// </summary>
		public DateTime? D_CONSIGNDATE
		{
			set{ _d_consigndate=value;}
			get{return _d_consigndate;}
		}
		/// <summary>
		/// 交货日期
		/// </summary>
		public DateTime? D_DELIVERDATE
		{
			set{ _d_deliverdate=value;}
			get{return _d_deliverdate;}
		}
		/// <summary>
		/// 发货公司
		/// </summary>
		public string C_PK_CORP
		{
			set{ _c_pk_corp=value;}
			get{return _c_pk_corp;}
		}
		/// <summary>
		/// 发货库存组织
		/// </summary>
		public string C_ADVISECALBODYID
		{
			set{ _c_advisecalbodyid=value;}
			get{return _c_advisecalbodyid;}
		}
		/// <summary>
		/// 货币
		/// </summary>
		public string C_CURRENCYTYPEID
		{
			set{ _c_currencytypeid=value;}
			get{return _c_currencytypeid;}
		}
		/// <summary>
		/// 税率
		/// </summary>
		public decimal? N_TAXRATE
		{
			set{ _n_taxrate=value;}
			get{return _n_taxrate;}
		}
		/// <summary>
		/// 原币无税单价
		/// </summary>
		public decimal? N_ORIGINALCURPRICE
		{
			set{ _n_originalcurprice=value;}
			get{return _n_originalcurprice;}
		}
		/// <summary>
		/// 原币含税单价
		/// </summary>
		public decimal? N_ORIGINALCURTAXPRICE
		{
			set{ _n_originalcurtaxprice=value;}
			get{return _n_originalcurtaxprice;}
		}
		/// <summary>
		/// 原币税额
		/// </summary>
		public decimal? N_ORIGINALCURTAXMNY
		{
			set{ _n_originalcurtaxmny=value;}
			get{return _n_originalcurtaxmny;}
		}
		/// <summary>
		/// 原币无税金额
		/// </summary>
		public decimal? N_ORIGINALCURMNY
		{
			set{ _n_originalcurmny=value;}
			get{return _n_originalcurmny;}
		}
		/// <summary>
		/// 收货地区
		/// </summary>
		public string C_RECEIPTAREAID
		{
			set{ _c_receiptareaid=value;}
			get{return _c_receiptareaid;}
		}
		/// <summary>
		/// 收货地址
		/// </summary>
		public string C_RECEIVEADDRESS
		{
			set{ _c_receiveaddress=value;}
			get{return _c_receiveaddress;}
		}
		/// <summary>
		/// 收货单位
		/// </summary>
		public string C_RECEIPTCORPID
		{
			set{ _c_receiptcorpid=value;}
			get{return _c_receiptcorpid;}
		}
		/// <summary>
		/// 原币价税合计
		/// </summary>
		public decimal? N_ORIGINALCURSUMMNY
		{
			set{ _n_originalcursummny=value;}
			get{return _n_originalcursummny;}
		}
		/// <summary>
		/// 自由项1
		/// </summary>
		public string C_VFREE1
		{
			set{ _c_vfree1=value;}
			get{return _c_vfree1;}
		}
		/// <summary>
		/// 自由项2
		/// </summary>
		public string C_VFREE2
		{
			set{ _c_vfree2=value;}
			get{return _c_vfree2;}
		}
		/// <summary>
		/// 包装要求
		/// </summary>
		public string C_VFREE3
		{
			set{ _c_vfree3=value;}
			get{return _c_vfree3;}
		}
		/// <summary>
		/// 质量等级
		/// </summary>
		public string C_VDEF1
		{
			set{ _c_vdef1=value;}
			get{return _c_vdef1;}
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
		/// 状态:0停用，1启用
		/// </summary>
		public decimal? N_STATUS
		{
			set{ _n_status=value;}
			get{return _n_status;}
		}
		/// <summary>
		/// 来源方案子表主键
		/// </summary>
		public string C_INITORDERID
		{
			set{ _c_initorderid=value;}
			get{return _c_initorderid;}
		}
		#endregion Model

	}
}

