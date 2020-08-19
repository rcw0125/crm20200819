using System;
namespace NF.MODEL
{
	/// <summary>
	/// 发运日计划
	/// </summary>
	[Serializable]
	public partial class Mod_TMP_PLAN
    {
		public Mod_TMP_PLAN()
		{}
        #region Model
        private string _c_id = Guid.NewGuid().ToString();
        private string _c_no;
        private string _c_con_no;
        private DateTime? _d_plansend_dt;
        private string _c_mat_code;
        private string _c_mat_name;
        private string _c_spec;
        private string _c_stl_grd;
        private string _c_qualiry_lev;
        private decimal? _n_wgt;
        private decimal? _n_sendnum_wgt;
        private string _c_atstation;
        private string _c_area;
        private string _c_addr;
        private string _c_shipvia;
        private string _c_cgc;
        private string _c_orgo_cust;
        private string _c_send_stock_dept;
        private decimal? _n_status = null;
		private DateTime? _d_orre_aog_dt;
        private string _c_send_stock;
        private string _c_aog_stock_dept;
        private string _c_aog_stock;
        private string _c_send_com;
        private string _c_sale_com;
        private string _c_aog_com;
        private string _c_send_area;
        private string _c_send_addr;
        private string _c_send_site;
        private string _c_aog_site;
        private decimal? _n_out_stock_wgt;
        private decimal? _n_sign_wgt;
        private decimal? _n_back_wgt;
        private decimal? _n_damage_wgt;
        private DateTime? _d_for_plan_dt;
        private string _c_for_paln_id;
        private DateTime? _d_approve_dt;
        private string _c_approve_id;
        private string _c_order_type;
        private decimal? _n_soro_back;
        private string _c_remark;
        private string _c_business_dept;
        private string _c_business_type;
        private string _c_salesman;
        private string _c_emp_id;
        private string _c_emp_name;
        private DateTime? _d_mod_dt = Convert.ToDateTime(DateTime.Now);
        private decimal? _n_unitprice;
        private decimal? _n_money;
        private string _c_free1;
        private string _c_free2;
        private string _c_free3;
        /// <summary>
        /// 日计划单据号
        /// </summary>
        public string C_ID
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 订单号
        /// </summary>
        public string C_NO
        {
            set { _c_no = value; }
            get { return _c_no; }
        }
        /// <summary>
        /// 合同号
        /// </summary>
        public string C_CON_NO
        {
            set { _c_con_no = value; }
            get { return _c_con_no; }
        }
        /// <summary>
        /// 计划发货时间
        /// </summary>
        public DateTime? D_PLANSEND_DT
        {
            set { _d_plansend_dt = value; }
            get { return _d_plansend_dt; }
        }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string C_MAT_CODE
        {
            set { _c_mat_code = value; }
            get { return _c_mat_code; }
        }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string C_MAT_NAME
        {
            set { _c_mat_name = value; }
            get { return _c_mat_name; }
        }
        /// <summary>
        /// 规格
        /// </summary>
        public string C_SPEC
        {
            set { _c_spec = value; }
            get { return _c_spec; }
        }
        /// <summary>
        /// 钢种
        /// </summary>
        public string C_STL_GRD
        {
            set { _c_stl_grd = value; }
            get { return _c_stl_grd; }
        }
        /// <summary>
        /// 质量等级
        /// </summary>
        public string C_QUALIRY_LEV
        {
            set { _c_qualiry_lev = value; }
            get { return _c_qualiry_lev; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal? N_WGT
        {
            set { _n_wgt = value; }
            get { return _n_wgt; }
        }
        /// <summary>
        /// 已发运数量
        /// </summary>
        public decimal? N_SENDNUM_WGT
        {
            set { _n_sendnum_wgt = value; }
            get { return _n_sendnum_wgt; }
        }
        /// <summary>
        /// 到站
        /// </summary>
        public string C_ATSTATION
        {
            set { _c_atstation = value; }
            get { return _c_atstation; }
        }
        /// <summary>
        /// 到货地区
        /// </summary>
        public string C_AREA
        {
            set { _c_area = value; }
            get { return _c_area; }
        }
        /// <summary>
        /// 到货地址
        /// </summary>
        public string C_ADDR
        {
            set { _c_addr = value; }
            get { return _c_addr; }
        }
        /// <summary>
        /// 发运方式
        /// </summary>
        public string C_SHIPVIA
        {
            set { _c_shipvia = value; }
            get { return _c_shipvia; }
        }
        /// <summary>
        /// 收货单位
        /// </summary>
        public string C_CGC
        {
            set { _c_cgc = value; }
            get { return _c_cgc; }
        }
        /// <summary>
        /// 订货客户
        /// </summary>
        public string C_ORGO_CUST
        {
            set { _c_orgo_cust = value; }
            get { return _c_orgo_cust; }
        }
        /// <summary>
        /// 发货库存组织
        /// </summary>
        public string C_SEND_STOCK_DEPT
        {
            set { _c_send_stock_dept = value; }
            get { return _c_send_stock_dept; }
        }
        /// <summary>
        /// 计划状态 ：2自由状态，1不可用
        /// </summary>
        public decimal? N_STATUS
        {
            set { _n_status = value; }
            get { return _n_status; }
        }
        /// <summary>
        /// 订单要求到货日期
        /// </summary>
        public DateTime? D_ORRE_AOG_DT
        {
            set { _d_orre_aog_dt = value; }
            get { return _d_orre_aog_dt; }
        }
        /// <summary>
        /// 发货仓库
        /// </summary>
        public string C_SEND_STOCK
        {
            set { _c_send_stock = value; }
            get { return _c_send_stock; }
        }
        /// <summary>
        /// 到货库存组织
        /// </summary>
        public string C_AOG_STOCK_DEPT
        {
            set { _c_aog_stock_dept = value; }
            get { return _c_aog_stock_dept; }
        }
        /// <summary>
        /// 到货仓库
        /// </summary>
        public string C_AOG_STOCK
        {
            set { _c_aog_stock = value; }
            get { return _c_aog_stock; }
        }
        /// <summary>
        /// 发货单位
        /// </summary>
        public string C_SEND_COM
        {
            set { _c_send_com = value; }
            get { return _c_send_com; }
        }
        /// <summary>
        /// 销售公司
        /// </summary>
        public string C_SALE_COM
        {
            set { _c_sale_com = value; }
            get { return _c_sale_com; }
        }
        /// <summary>
        /// 到货公司
        /// </summary>
        public string C_AOG_COM
        {
            set { _c_aog_com = value; }
            get { return _c_aog_com; }
        }
        /// <summary>
        /// 发货地区
        /// </summary>
        public string C_SEND_AREA
        {
            set { _c_send_area = value; }
            get { return _c_send_area; }
        }
        /// <summary>
        /// 发货地址
        /// </summary>
        public string C_SEND_ADDR
        {
            set { _c_send_addr = value; }
            get { return _c_send_addr; }
        }
        /// <summary>
        /// 发货地点
        /// </summary>
        public string C_SEND_SITE
        {
            set { _c_send_site = value; }
            get { return _c_send_site; }
        }
        /// <summary>
        /// 到货地点
        /// </summary>
        public string C_AOG_SITE
        {
            set { _c_aog_site = value; }
            get { return _c_aog_site; }
        }
        /// <summary>
        /// 已出库数量
        /// </summary>
        public decimal? N_OUT_STOCK_WGT
        {
            set { _n_out_stock_wgt = value; }
            get { return _n_out_stock_wgt; }
        }
        /// <summary>
        /// 已签收数量
        /// </summary>
        public decimal? N_SIGN_WGT
        {
            set { _n_sign_wgt = value; }
            get { return _n_sign_wgt; }
        }
        /// <summary>
        /// 退回数量
        /// </summary>
        public decimal? N_BACK_WGT
        {
            set { _n_back_wgt = value; }
            get { return _n_back_wgt; }
        }
        /// <summary>
        /// 途损主数量
        /// </summary>
        public decimal? N_DAMAGE_WGT
        {
            set { _n_damage_wgt = value; }
            get { return _n_damage_wgt; }
        }
        /// <summary>
        /// 制定计划日期
        /// </summary>
        public DateTime? D_FOR_PLAN_DT
        {
            set { _d_for_plan_dt = value; }
            get { return _d_for_plan_dt; }
        }
        /// <summary>
        /// 制定计划人
        /// </summary>
        public string C_FOR_PALN_ID
        {
            set { _c_for_paln_id = value; }
            get { return _c_for_paln_id; }
        }
        /// <summary>
        /// 审批日期
        /// </summary>
        public DateTime? D_APPROVE_DT
        {
            set { _d_approve_dt = value; }
            get { return _d_approve_dt; }
        }
        /// <summary>
        /// 审批人
        /// </summary>
        public string C_APPROVE_ID
        {
            set { _c_approve_id = value; }
            get { return _c_approve_id; }
        }
        /// <summary>
        /// 订单类型
        /// </summary>
        public string C_ORDER_TYPE
        {
            set { _c_order_type = value; }
            get { return _c_order_type; }
        }
        /// <summary>
        /// 来源订单是否退
        /// </summary>
        public decimal? N_SORO_BACK
        {
            set { _n_soro_back = value; }
            get { return _n_soro_back; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string C_REMARK
        {
            set { _c_remark = value; }
            get { return _c_remark; }
        }
        /// <summary>
        /// 业务部门
        /// </summary>
        public string C_BUSINESS_DEPT
        {
            set { _c_business_dept = value; }
            get { return _c_business_dept; }
        }
        /// <summary>
        /// 业务类型
        /// </summary>
        public string C_BUSINESS_TYPE
        {
            set { _c_business_type = value; }
            get { return _c_business_type; }
        }
        /// <summary>
        /// 业务员
        /// </summary>
        public string C_SALESMAN
        {
            set { _c_salesman = value; }
            get { return _c_salesman; }
        }
        /// <summary>
        /// 系统操作人编号
        /// </summary>
        public string C_EMP_ID
        {
            set { _c_emp_id = value; }
            get { return _c_emp_id; }
        }
        /// <summary>
        /// 系统操作人姓名
        /// </summary>
        public string C_EMP_NAME
        {
            set { _c_emp_name = value; }
            get { return _c_emp_name; }
        }
        /// <summary>
        /// 系系统操作时间
        /// </summary>
        public DateTime? D_MOD_DT
        {
            set { _d_mod_dt = value; }
            get { return _d_mod_dt; }
        }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal? N_UNITPRICE
        {
            set { _n_unitprice = value; }
            get { return _n_unitprice; }
        }
        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal? N_MONEY
        {
            set { _n_money = value; }
            get { return _n_money; }
        }
        /// <summary>
        /// 自由项1
        /// </summary>
        public string C_FREE1
        {
            set { _c_free1 = value; }
            get { return _c_free1; }
        }
        /// <summary>
        /// 自由项1
        /// </summary>
        public string C_FREE2
        {
            set { _c_free2 = value; }
            get { return _c_free2; }
        }
        /// <summary>
        /// 包装要求
        /// </summary>
        public string C_FREE3
        {
            set { _c_free3 = value; }
            get { return _c_free3; }
        }
        #endregion Model

    }
}

