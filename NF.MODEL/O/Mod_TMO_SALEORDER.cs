using System;
namespace NF.MODEL
{
	/// <summary>
	/// 销售订单
	/// </summary>
	[Serializable]
	public partial class Mod_TMO_SALEORDER
	{
		public Mod_TMO_SALEORDER()
		{}
		#region Model
		private string _c_id=Guid.NewGuid().ToString ();
		private string _c_code;
		private string _c_conno;
		private string _c_initialize_id;
		private string _c_pk_corp="1001";
		private string _c_biztype;
		private DateTime? _d_billdate;
		private string _c_customerid;
		private string _c_deptid;
		private string _c_employeeid;
		private string _c_operatorid;
		private string _c_coperatorid;
		private string _c_salecorpid;
		private string _c_calbodyid="1001NC10000000000669";
		private string _c_receiptcustomerid;
		private string _c_receiveaddress;
		private string _c_receiptcorpid;
		private string _c_transmodeid;
		private DateTime? _d_makedate;
		private string _c_approveid;
		private DateTime? _d_approvedate;
		private string _c_remark;
		private decimal? _n_status=1;
		/// <summary>
		/// 主键
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 单据号
		/// </summary>
		public string C_CODE
		{
			set{ _c_code=value;}
			get{return _c_code;}
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
		/// 方案表主键
		/// </summary>
		public string C_INITIALIZE_ID
		{
			set{ _c_initialize_id=value;}
			get{return _c_initialize_id;}
		}
		/// <summary>
		/// 公司ID
		/// </summary>
		public string C_PK_CORP
		{
			set{ _c_pk_corp=value;}
			get{return _c_pk_corp;}
		}
		/// <summary>
		/// 业务类型ID
		/// </summary>
		public string C_BIZTYPE
		{
			set{ _c_biztype=value;}
			get{return _c_biztype;}
		}
		/// <summary>
		/// 单据日期
		/// </summary>
		public DateTime? D_BILLDATE
		{
			set{ _d_billdate=value;}
			get{return _d_billdate;}
		}
		/// <summary>
		/// 客户ID-NC客商管理档案主键
		/// </summary>
		public string C_CUSTOMERID
		{
			set{ _c_customerid=value;}
			get{return _c_customerid;}
		}
		/// <summary>
		/// 部门ID
		/// </summary>
		public string C_DEPTID
		{
			set{ _c_deptid=value;}
			get{return _c_deptid;}
		}
		/// <summary>
		/// 业务员ID
		/// </summary>
		public string C_EMPLOYEEID
		{
			set{ _c_employeeid=value;}
			get{return _c_employeeid;}
		}
		/// <summary>
		/// 制单人ID
		/// </summary>
		public string C_OPERATORID
		{
			set{ _c_operatorid=value;}
			get{return _c_operatorid;}
		}
		/// <summary>
		/// 制单人ID
		/// </summary>
		public string C_COPERATORID
		{
			set{ _c_coperatorid=value;}
			get{return _c_coperatorid;}
		}
		/// <summary>
		/// 销售组织ID
		/// </summary>
		public string C_SALECORPID
		{
			set{ _c_salecorpid=value;}
			get{return _c_salecorpid;}
		}
		/// <summary>
		/// 库存组织
		/// </summary>
		public string C_CALBODYID
		{
			set{ _c_calbodyid=value;}
			get{return _c_calbodyid;}
		}
		/// <summary>
		/// 收货单位
		/// </summary>
		public string C_RECEIPTCUSTOMERID
		{
			set{ _c_receiptcustomerid=value;}
			get{return _c_receiptcustomerid;}
		}
		/// <summary>
		/// 收货地址-来源客户档案地区分类-pk_areacl
		/// </summary>
		public string C_RECEIVEADDRESS
		{
			set{ _c_receiveaddress=value;}
			get{return _c_receiveaddress;}
		}
		/// <summary>
		/// 开票单位ID-来源与客户档案信息
		/// </summary>
		public string C_RECEIPTCORPID
		{
			set{ _c_receiptcorpid=value;}
			get{return _c_receiptcorpid;}
		}
		/// <summary>
		/// 发运方式ID
		/// </summary>
		public string C_TRANSMODEID
		{
			set{ _c_transmodeid=value;}
			get{return _c_transmodeid;}
		}
		/// <summary>
		/// 制单日期
		/// </summary>
		public DateTime? D_MAKEDATE
		{
			set{ _d_makedate=value;}
			get{return _d_makedate;}
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
		/// 审批日期
		/// </summary>
		public DateTime? D_APPROVEDATE
		{
			set{ _d_approvedate=value;}
			get{return _d_approvedate;}
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
		#endregion Model

	}
}

