using System;
namespace NF.MODEL
{
	/// <summary>
	/// 发运日计划
	/// </summary>
	[Serializable]
	public partial class Mod_TMP_DAYPLAN
    {
		public Mod_TMP_DAYPLAN()
		{}
		#region Model
		private string _c_id=Guid.NewGuid().ToString ();
		private string _c_plcode;
		private string _c_pkbillb;
		private string _c_pkbillh;
		private string _c_conno;
		private string _c_orderno;
		private string _c_pkinv;
		private string _c_pkassistmeasure;
		private decimal? _n_assistnum;
		private decimal? _n_num;
		private decimal? _n_unitprice;
		private decimal? _n_money;
		private DateTime? _d_plandate;
		private DateTime? _d_ordsndate;
		private DateTime? _d_requiredate;
		private DateTime? _d_snddate;
		private string _c_pkcust;
		private string _c_pksendtype;
		private string _c_pksalecorp="1001";
		private string _c_pksaleorg;
		private string _c_pksendstoreorg="1001NC10000000000669";
		private string _c_pkoperator;
		private string _c_pkoprdepart;
		private string _c_pkplanperson;
		private string _c_pkapprperson;
		private DateTime? _d_apprdate;
		private string _c_pkarrivearea;
		private string _c_destaddress;
		private string _c_receiptcorpid;
		private string _c_biztype;
		private string _c_remark;
		private string _c_pksendarea;
		private string _c_pkdelivorg="1001NC10000000006EHS";
		private string _c_unitid;
		private string _c_vfree1;
		private string _c_vfree2;
		private string _c_vfree3;
		private string _c_vfree4;
        private string _c_salecode;
        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 计划单据号
		/// </summary>
		public string C_PLCODE
		{
			set{ _c_plcode=value;}
			get{return _c_plcode;}
		}
		/// <summary>
		/// 来源销售订单子表ID
		/// </summary>
		public string C_PKBILLB
		{
			set{ _c_pkbillb=value;}
			get{return _c_pkbillb;}
		}
		/// <summary>
		/// 来源销售订单主表ID
		/// </summary>
		public string C_PKBILLH
		{
			set{ _c_pkbillh=value;}
			get{return _c_pkbillh;}
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
		/// 订单号
		/// </summary>
		public string C_ORDERNO
		{
			set{ _c_orderno=value;}
			get{return _c_orderno;}
		}
		/// <summary>
		/// 存货主键
		/// </summary>
		public string C_PKINV
		{
			set{ _c_pkinv=value;}
			get{return _c_pkinv;}
		}
		/// <summary>
		/// 辅计量单位ID
		/// </summary>
		public string C_PKASSISTMEASURE
		{
			set{ _c_pkassistmeasure=value;}
			get{return _c_pkassistmeasure;}
		}
		/// <summary>
		/// 辅数量
		/// </summary>
		public decimal? N_ASSISTNUM
		{
			set{ _n_assistnum=value;}
			get{return _n_assistnum;}
		}
		/// <summary>
		/// 主数量
		/// </summary>
		public decimal? N_NUM
		{
			set{ _n_num=value;}
			get{return _n_num;}
		}
		/// <summary>
		/// 单价
		/// </summary>
		public decimal? N_UNITPRICE
		{
			set{ _n_unitprice=value;}
			get{return _n_unitprice;}
		}
		/// <summary>
		/// 订单金额
		/// </summary>
		public decimal? N_MONEY
		{
			set{ _n_money=value;}
			get{return _n_money;}
		}
		/// <summary>
		/// 日计划日期
		/// </summary>
		public DateTime? D_PLANDATE
		{
			set{ _d_plandate=value;}
			get{return _d_plandate;}
		}
		/// <summary>
		/// 定单要求发货日期
		/// </summary>
		public DateTime? D_ORDSNDATE
		{
			set{ _d_ordsndate=value;}
			get{return _d_ordsndate;}
		}
		/// <summary>
		/// 定单要求到货日期
		/// </summary>
		public DateTime? D_REQUIREDATE
		{
			set{ _d_requiredate=value;}
			get{return _d_requiredate;}
		}
		/// <summary>
		/// 实际发货日期
		/// </summary>
		public DateTime? D_SNDDATE
		{
			set{ _d_snddate=value;}
			get{return _d_snddate;}
		}
		/// <summary>
		/// 客户ID
		/// </summary>
		public string C_PKCUST
		{
			set{ _c_pkcust=value;}
			get{return _c_pkcust;}
		}
		/// <summary>
		/// 发运方式ID
		/// </summary>
		public string C_PKSENDTYPE
		{
			set{ _c_pksendtype=value;}
			get{return _c_pksendtype;}
		}
		/// <summary>
		/// 销售公司ID
		/// </summary>
		public string C_PKSALECORP
		{
			set{ _c_pksalecorp=value;}
			get{return _c_pksalecorp;}
		}
		/// <summary>
		/// 销售组织ID
		/// </summary>
		public string C_PKSALEORG
		{
			set{ _c_pksaleorg=value;}
			get{return _c_pksaleorg;}
		}
		/// <summary>
		/// 发货库存组织ID
		/// </summary>
		public string C_PKSENDSTOREORG
		{
			set{ _c_pksendstoreorg=value;}
			get{return _c_pksendstoreorg;}
		}
		/// <summary>
		/// 业务员ID
		/// </summary>
		public string C_PKOPERATOR
		{
			set{ _c_pkoperator=value;}
			get{return _c_pkoperator;}
		}
		/// <summary>
		/// 业务部门ID
		/// </summary>
		public string C_PKOPRDEPART
		{
			set{ _c_pkoprdepart=value;}
			get{return _c_pkoprdepart;}
		}
		/// <summary>
		/// 计划人ID
		/// </summary>
		public string C_PKPLANPERSON
		{
			set{ _c_pkplanperson=value;}
			get{return _c_pkplanperson;}
		}
		/// <summary>
		/// 审批人ID
		/// </summary>
		public string C_PKAPPRPERSON
		{
			set{ _c_pkapprperson=value;}
			get{return _c_pkapprperson;}
		}
		/// <summary>
		/// 审批日期
		/// </summary>
		public DateTime? D_APPRDATE
		{
			set{ _d_apprdate=value;}
			get{return _d_apprdate;}
		}
		/// <summary>
		/// 到货地区ID
		/// </summary>
		public string C_PKARRIVEAREA
		{
			set{ _c_pkarrivearea=value;}
			get{return _c_pkarrivearea;}
		}
		/// <summary>
		/// 到货地址
		/// </summary>
		public string C_DESTADDRESS
		{
			set{ _c_destaddress=value;}
			get{return _c_destaddress;}
		}
		/// <summary>
		/// 收货单位ID
		/// </summary>
		public string C_RECEIPTCORPID
		{
			set{ _c_receiptcorpid=value;}
			get{return _c_receiptcorpid;}
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
		/// 备注
		/// </summary>
		public string C_REMARK
		{
			set{ _c_remark=value;}
			get{return _c_remark;}
		}
		/// <summary>
		/// 发货地区ID
		/// </summary>
		public string C_PKSENDAREA
		{
			set{ _c_pksendarea=value;}
			get{return _c_pksendarea;}
		}
		/// <summary>
		/// 发运组织固定
		/// </summary>
		public string C_PKDELIVORG
		{
			set{ _c_pkdelivorg=value;}
			get{return _c_pkdelivorg;}
		}
		/// <summary>
		/// 计量单位ID
		/// </summary>
		public string C_UNITID
		{
			set{ _c_unitid=value;}
			get{return _c_unitid;}
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
		public string C_VFREE4
		{
			set{ _c_vfree4=value;}
			get{return _c_vfree4;}
		}
        /// <summary>
        /// 销售单据号
        /// </summary>
        public string C_SALECODE
        {
            set { _c_salecode = value; }
            get { return _c_salecode; }
        }

        #endregion Model

    }
}

