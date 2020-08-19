using System;
namespace NF.MODEL
{
    /// <summary>
    /// 发运单详情
    /// </summary>
    [Serializable]
    public partial class Mod_TMD_DISPATCHDETAILS
    {
        public Mod_TMD_DISPATCHDETAILS()
        { }
        #region Model
        private string _c_id;
        private string _c_dispatch_id;
        private string _c_stove;
        private string _c_batch_no;
        private string _c_tick_no;
        private string _c_slab_no;
        private string _c_mat_code;
        private string _c_mat_name;
        private string _c_spec;
        private string _c_stl_grd;
        private string _c_send_stock;
        private string _c_qualiry_lev;
        private string _c_free_term;
        private string _c_elseneed;
        private decimal? _n_com_amount_wgt;
        private decimal? _n_wgt;
        private string _c_equation_factor;
        private decimal? _n_out_stock_wgt;
        private string _c_unitis;
        private string _c_send_site;
        private string _c_aog_site;
        private string _c_orgo_cust;
        private string _c_cgc;
        private decimal? _n_is_send_close;
        private string _c_order_type;
        private string _c_send_area;
        private string _c_area;
        private string _c_au_unitis;
        private string _c_custfile_id;
        private string _c_cust_id;
        private string _c_remark;
        private string _c_mzdate;
        private decimal? _n_mwgt;
        private decimal? _n_pwgt;
        private decimal? _n_jwgt;
        private string _n_mztime;
        private string _n_pztime;
        private string _c_emp_id;
        private string _c_emp_name;
        private DateTime _d_mod_dt;
        private string _c_con_no;
        private string _c_plan_id;
        private string _c_plan_code;
        private string _c_pk_ncid;
        private string _c_no;
        private string _c_std_code;
        private string _c_judge_lev_zh;
        private string _c_product_id;
        private string _c_free_term2;
        private string _c_pack;
        private string _c_pzdate;
        private string _c_orderpk;
        private string _c_custno;
        private decimal? _n_fyzs;
        private decimal? _n_fywgt;
        private string _c_send_stock_pk;
        private string _c_send_stock_code;


        /// <summary>
        /// 到货地点费用
        /// </summary>
        public decimal N_PRICE { set; get; }

        /// <summary>
        /// Y/N 修改/添加
        /// </summary>
        public string FLAG { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 发运单单据号
        /// </summary>
        public string C_DISPATCH_ID
        {
            set { _c_dispatch_id = value; }
            get { return _c_dispatch_id; }
        }
        /// <summary>
        /// 炉号
        /// </summary>
        public string C_STOVE
        {
            set { _c_stove = value; }
            get { return _c_stove; }
        }
        /// <summary>
        /// 批号
        /// </summary>
        public string C_BATCH_NO
        {
            set { _c_batch_no = value; }
            get { return _c_batch_no; }
        }
        /// <summary>
        /// 勾号
        /// </summary>
        public string C_TICK_NO
        {
            set { _c_tick_no = value; }
            get { return _c_tick_no; }
        }
        /// <summary>
        /// 钢坯号
        /// </summary>
        public string C_SLAB_NO
        {
            set { _c_slab_no = value; }
            get { return _c_slab_no; }
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
        /// 发货仓库
        /// </summary>
        public string C_SEND_STOCK
        {
            set { _c_send_stock = value; }
            get { return _c_send_stock; }
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
        /// 自由项
        /// </summary>
        public string C_FREE_TERM
        {
            set { _c_free_term = value; }
            get { return _c_free_term; }
        }
        /// <summary>
        /// 其他要求
        /// </summary>
        public string C_ELSENEED
        {
            set { _c_elseneed = value; }
            get { return _c_elseneed; }
        }
        /// <summary>
        /// 辅数量
        /// </summary>
        public decimal? N_COM_AMOUNT_WGT
        {
            set { _n_com_amount_wgt = value; }
            get { return _n_com_amount_wgt; }
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
        /// 换算率
        /// </summary>
        public string C_EQUATION_FACTOR
        {
            set { _c_equation_factor = value; }
            get { return _c_equation_factor; }
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
        /// 计量单位
        /// </summary>
        public string C_UNITIS
        {
            set { _c_unitis = value; }
            get { return _c_unitis; }
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
        /// 订货客户
        /// </summary>
        public string C_ORGO_CUST
        {
            set { _c_orgo_cust = value; }
            get { return _c_orgo_cust; }
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
        /// 是否已出库关闭
        /// </summary>
        public decimal? N_IS_SEND_CLOSE
        {
            set { _n_is_send_close = value; }
            get { return _n_is_send_close; }
        }
        /// <summary>
        /// 订单类型 8线材 6钢坯 831废乱材  841焦化产品 851渣
        /// </summary>
        public string C_ORDER_TYPE
        {
            set { _c_order_type = value; }
            get { return _c_order_type; }
        }
        /// <summary>
        /// 到货地区
        /// </summary>
        public string C_SEND_AREA
        {
            set { _c_send_area = value; }
            get { return _c_send_area; }
        }
        /// <summary>
        /// 到货地址
        /// </summary>
        public string C_AREA
        {
            set { _c_area = value; }
            get { return _c_area; }
        }
        /// <summary>
        /// 副计量单位
        /// </summary>
        public string C_AU_UNITIS
        {
            set { _c_au_unitis = value; }
            get { return _c_au_unitis; }
        }
        /// <summary>
        /// 客户基本档案主键
        /// </summary>
        public string C_CUSTFILE_ID
        {
            set { _c_custfile_id = value; }
            get { return _c_custfile_id; }
        }
        /// <summary>
        /// 客户ID
        /// </summary>
        public string C_CUST_ID
        {
            set { _c_cust_id = value; }
            get { return _c_cust_id; }
        }
        /// <summary>
        /// 行备注
        /// </summary>
        public string C_REMARK
        {
            set { _c_remark = value; }
            get { return _c_remark; }
        }
        /// <summary>
        /// 计算毛重日期
        /// </summary>
        public string C_MZDATE
        {
            set { _c_mzdate = value; }
            get { return _c_mzdate; }
        }
        /// <summary>
        /// 计算毛重
        /// </summary>
        public decimal? N_MWGT
        {
            set { _n_mwgt = value; }
            get { return _n_mwgt; }
        }
        /// <summary>
        /// 计算皮重
        /// </summary>
        public decimal? N_PWGT
        {
            set { _n_pwgt = value; }
            get { return _n_pwgt; }
        }
        /// <summary>
        /// 计算净重
        /// </summary>
        public decimal? N_JWGT
        {
            set { _n_jwgt = value; }
            get { return _n_jwgt; }
        }
        /// <summary>
        /// 计算毛重时间
        /// </summary>
        public string N_MZTIME
        {
            set { _n_mztime = value; }
            get { return _n_mztime; }
        }
        /// <summary>
        /// 计算皮量时间
        /// </summary>
        public string N_PZTIME
        {
            set { _n_pztime = value; }
            get { return _n_pztime; }
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
        public DateTime D_MOD_DT
        {
            set { _d_mod_dt = value; }
            get { return _d_mod_dt; }
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
        /// 发运日计划主键
        /// </summary>
        public string C_PLAN_ID
        {
            set { _c_plan_id = value; }
            get { return _c_plan_id; }
        }
        /// <summary>
        /// 发运日计划单据号
        /// </summary>
        public string C_PLAN_CODE
        {
            set { _c_plan_code = value; }
            get { return _c_plan_code; }
        }
        /// <summary>
        /// 合并主键
        /// </summary>
        public string C_PK_NCID
        {
            set { _c_pk_ncid = value; }
            get { return _c_pk_ncid; }
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
        /// 执行标准
        /// </summary>
        public string C_STD_CODE
        {
            set { _c_std_code = value; }
            get { return _c_std_code; }
        }
        /// <summary>
        /// 综合判定结果(SX)
        /// </summary>
        public string C_JUDGE_LEV_ZH
        {
            set { _c_judge_lev_zh = value; }
            get { return _c_judge_lev_zh; }
        }
        /// <summary>
        /// 产品ID
        /// </summary>
        public string C_PRODUCT_ID
        {
            set { _c_product_id = value; }
            get { return _c_product_id; }
        }
        /// <summary>
        /// 自由项2
        /// </summary>
        public string C_FREE_TERM2
        {
            set { _c_free_term2 = value; }
            get { return _c_free_term2; }
        }
        /// <summary>
        /// 包装要求
        /// </summary>
        public string C_PACK
        {
            set { _c_pack = value; }
            get { return _c_pack; }
        }
        /// <summary>
        /// 皮重日期
        /// </summary>
        public string C_PZDATE
        {
            set { _c_pzdate = value; }
            get { return _c_pzdate; }
        }
        /// <summary>
        /// 订单主键
        /// </summary>
        public string C_ORDERPK
        {
            set { _c_orderpk = value; }
            get { return _c_orderpk; }
        }
        /// <summary>
        /// 客户编码
        /// </summary>
        public string C_CUSTNO
        {
            set { _c_custno = value; }
            get { return _c_custno; }
        }
        /// <summary>
        /// 发运支数
        /// </summary>
        public decimal? N_FYZS
        {
            set { _n_fyzs = value; }
            get { return _n_fyzs; }
        }
        /// <summary>
        /// 发运量
        /// </summary>
        public decimal? N_FYWGT
        {
            set { _n_fywgt = value; }
            get { return _n_fywgt; }
        }
        /// <summary>
        /// 发运仓库主键
        /// </summary>
        public string C_SEND_STOCK_PK
        {
            set { _c_send_stock_pk = value; }
            get { return _c_send_stock_pk; }
        }
        /// <summary>
        /// 发运仓库编码
        /// </summary>
        public string C_SEND_STOCK_CODE
        {
            set { _c_send_stock_code = value; }
            get { return _c_send_stock_code; }
        }
        #endregion Model

    }
}

