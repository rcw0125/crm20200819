using System;
namespace NF.MODEL
{
    /// <summary>
    /// 合同明细
    /// </summary>
    [Serializable]
    public partial class Mod_TMO_CONDETAILS
    {
        public Mod_TMO_CONDETAILS()
        { }

        #region Model
        private string _c_no;
        private string _c_con_no;
        private string _c_con_name;
        private string _c_area;
        private string _c_xgid = "1001";
        private string _c_invbasdocid;
        private string _c_inventoryid;
        private string _c_prod_name;
        private string _c_prod_kind;
        private string _c_mat_code;
        private string _c_mat_name;
        private string _c_spec;
        private string _c_stl_grd;
        private string _c_pro_use;
        private string _c_packunitid;
        private string _c_unitid;
        private string _c_cust_sq;
        private DateTime? _d_need_dt;
        private DateTime? _d_delivery_dt;
        private DateTime? _d_dt;
        private string _c_tech_prot;
        private string _c_free_term;
        private string _c_free_term2;
        private string _c_pack;
        private decimal? _n_wgt;
        private string _c_creceiptareaid;
        private string _c_address;
        private string _c_receiptcorpid;
        private string _c_atstation;
        private string _c_currencytypeid;
        private string _c_std_code;
        private string _c_design_no;
        private string _c_stdid;
        private string _c_designid;
        private decimal? _n_slab_match_wgt;
        private decimal? _n_line_match_wgt;
        private decimal? _n_status = -1;
        private decimal? _n_flag = 0;
        private decimal? _n_type;
        private decimal? _n_exec_status = 0;
        private decimal? _n_user_lev;
        private string _c_editemployeeid;
        private DateTime? _d_editdate;
        private string _c_remark;
        private string _c_emp_id;
        private string _c_emp_name;
        private DateTime? _d_mod_dt;
        private string _c_cust_no;
        private string _c_cust_name;
        private string _c_sale_channel;
        private string _c_lev;
        private string _c_order_lev;
        private decimal? _n_cost;
        private decimal? _n_taxrate;
        private decimal? _n_originalcurprice;
        private decimal? _n_originalcurtaxprice;
        private decimal? _n_originalcurnetprice;
        private decimal? _n_originalcurtaxnetprice;
        private decimal? _n_originalcurtaxmny;
        private decimal? _n_originalcurmny;
        private decimal? _n_originalcursummny;
        private decimal? _n_price;
        private decimal? _n_taxprice;
        private decimal? _n_netprice;
        private decimal? _n_taxnetprice;
        private decimal? _n_taxmny;
        private decimal? _n_mny;
        private decimal? _n_summny;
        private string _c_nc_state;
        private decimal? _n_fnum;
        private decimal? _n_hsl;
        private string _c_vdef1;
        private string _c_vdef_name;
        private string _c_mat_group_code;
        private string _sczt;
        private string _ylxwgt;

        /// <summary>
        /// 已履行量
        /// </summary>
        public string YLXWGT
        {
            set { _ylxwgt = value; }
            get { return _ylxwgt; }
        }


        /// <summary>
        /// 上产状态
        /// </summary>
        public string SCZT
        {
            set { _sczt = value; }
            get { return _sczt; }
        }

        public string C_MAT_GROUP_CODE
        {
            set { _c_mat_group_code = value; }
            get { return _c_mat_group_code; }
        }

        /// <summary>
        /// 质量等级ID
        /// </summary>
        public string C_VDEF_NAME
        {
            set { _c_vdef_name = value; }
            get { return _c_vdef_name; }
        }

        /// <summary>
        /// 质量等级ID
        /// </summary>
        public string C_VDEF1
        {
            set { _c_vdef1 = value; }
            get { return _c_vdef1; }
        }

        /// <summary>
        /// 订单号(主键)
        /// </summary>
        public string C_NO
        {
            set { _c_no = value; }
            get { return _c_no; }
        }
        /// <summary>
        /// 合同号(外键)
        /// </summary>
        public string C_CON_NO
        {
            set { _c_con_no = value; }
            get { return _c_con_no; }
        }
        /// <summary>
        /// 合同名称
        /// </summary>
        public string C_CON_NAME
        {
            set { _c_con_name = value; }
            get { return _c_con_name; }
        }
        /// <summary>
        /// 区域
        /// </summary>
        public string C_AREA
        {
            set { _c_area = value; }
            get { return _c_area; }
        }
        /// <summary>
        /// 公司ID
        /// </summary>
        public string C_XGID
        {
            set { _c_xgid = value; }
            get { return _c_xgid; }
        }
        /// <summary>
        /// 存货档案主键
        /// </summary>
        public string C_INVBASDOCID
        {
            set { _c_invbasdocid = value; }
            get { return _c_invbasdocid; }
        }
        /// <summary>
        /// 存货管理档案主键
        /// </summary>
        public string C_INVENTORYID
        {
            set { _c_inventoryid = value; }
            get { return _c_inventoryid; }
        }
        /// <summary>
        /// 类别
        /// </summary>
        public string C_PROD_NAME
        {
            set { _c_prod_name = value; }
            get { return _c_prod_name; }
        }
        /// <summary>
        /// 品种
        /// </summary>
        public string C_PROD_KIND
        {
            set { _c_prod_kind = value; }
            get { return _c_prod_kind; }
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
        /// 产品用途
        /// </summary>
        public string C_PRO_USE
        {
            set { _c_pro_use = value; }
            get { return _c_pro_use; }
        }
        /// <summary>
        /// 辅单位
        /// </summary>
        public string C_PACKUNITID
        {
            set { _c_packunitid = value; }
            get { return _c_packunitid; }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string C_UNITID
        {
            set { _c_unitid = value; }
            get { return _c_unitid; }
        }
        /// <summary>
        /// 客户特殊要求
        /// </summary>
        public string C_CUST_SQ
        {
            set { _c_cust_sq = value; }
            get { return _c_cust_sq; }
        }
        /// <summary>
        /// 需求日期
        /// </summary>
        public DateTime? D_NEED_DT
        {
            set { _d_need_dt = value; }
            get { return _d_need_dt; }
        }
        /// <summary>
        /// 计划交货日期
        /// </summary>
        public DateTime? D_DELIVERY_DT
        {
            set { _d_delivery_dt = value; }
            get { return _d_delivery_dt; }
        }
        /// <summary>
        /// 订单日期
        /// </summary>
        public DateTime? D_DT
        {
            set { _d_dt = value; }
            get { return _d_dt; }
        }
        /// <summary>
        /// 客户协议号
        /// </summary>
        public string C_TECH_PROT
        {
            set { _c_tech_prot = value; }
            get { return _c_tech_prot; }
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
        /// 数量
        /// </summary>
        public decimal? N_WGT
        {
            set { _n_wgt = value; }
            get { return _n_wgt; }
        }
        /// <summary>
        /// 收货地区
        /// </summary>
        public string C_CRECEIPTAREAID
        {
            set { _c_creceiptareaid = value; }
            get { return _c_creceiptareaid; }
        }
        /// <summary>
        /// 收货地址
        /// </summary>
        public string C_ADDRESS
        {
            set { _c_address = value; }
            get { return _c_address; }
        }
        /// <summary>
        /// 收货单位
        /// </summary>
        public string C_RECEIPTCORPID
        {
            set { _c_receiptcorpid = value; }
            get { return _c_receiptcorpid; }
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
        /// 币种
        /// </summary>
        public string C_CURRENCYTYPEID
        {
            set { _c_currencytypeid = value; }
            get { return _c_currencytypeid; }
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
        /// 质量设计号
        /// </summary>
        public string C_DESIGN_NO
        {
            set { _c_design_no = value; }
            get { return _c_design_no; }
        }
        /// <summary>
        /// 执行标准ID
        /// </summary>
        public string C_STDID
        {
            set { _c_stdid = value; }
            get { return _c_stdid; }
        }
        /// <summary>
        /// 质量设计ID
        /// </summary>
        public string C_DESIGNID
        {
            set { _c_designid = value; }
            get { return _c_designid; }
        }
        /// <summary>
        /// 钢坯库存匹配量
        /// </summary>
        public decimal? N_SLAB_MATCH_WGT
        {
            set { _n_slab_match_wgt = value; }
            get { return _n_slab_match_wgt; }
        }
        /// <summary>
        /// 线材库存匹配量
        /// </summary>
        public decimal? N_LINE_MATCH_WGT
        {
            set { _n_line_match_wgt = value; }
            get { return _n_line_match_wgt; }
        }
        /// <summary>
        /// 合同状态：-1未提交，0待审，1审核中，2生效，3变更
        /// </summary>
        public decimal? N_STATUS
        {
            set { _n_status = value; }
            get { return _n_status; }
        }
        /// <summary>
        /// 0未导入NC,1已导入NC
        /// </summary>
        public decimal? N_FLAG
        {
            set { _n_flag = value; }
            get { return _n_flag; }
        }
        /// <summary>
        /// 订单类型: 6 钢坯，8线材
        /// </summary>
        public decimal? N_TYPE
        {
            set { _n_type = value; }
            get { return _n_type; }
        }
        /// <summary>
        /// 执行状态:0未排产，1已排产
        /// </summary>
        public decimal? N_EXEC_STATUS
        {
            set { _n_exec_status = value; }
            get { return _n_exec_status; }
        }
        /// <summary>
        /// 客户等级
        /// </summary>
        public decimal? N_USER_LEV
        {
            set { _n_user_lev = value; }
            get { return _n_user_lev; }
        }
        /// <summary>
        /// 修改人
        /// </summary>
        public string C_EDITEMPLOYEEID
        {
            set { _c_editemployeeid = value; }
            get { return _c_editemployeeid; }
        }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? D_EDITDATE
        {
            set { _d_editdate = value; }
            get { return _d_editdate; }
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
        /// 客户编码
        /// </summary>
        public string C_CUST_NO
        {
            set { _c_cust_no = value; }
            get { return _c_cust_no; }
        }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string C_CUST_NAME
        {
            set { _c_cust_name = value; }
            get { return _c_cust_name; }
        }
        /// <summary>
        /// 分销类别（2直销/1经销）
        /// </summary>
        public string C_SALE_CHANNEL
        {
            set { _c_sale_channel = value; }
            get { return _c_sale_channel; }
        }
        /// <summary>
        /// 维护等级：普通/买断/重点钢种/重点钢种买断
        /// </summary>
        public string C_LEV
        {
            set { _c_lev = value; }
            get { return _c_lev; }
        }
        /// <summary>
        /// 订单等级
        /// </summary>
        public string C_ORDER_LEV
        {
            set { _c_order_lev = value; }
            get { return _c_order_lev; }
        }
        /// <summary>
        /// 成本
        /// </summary>
        public decimal? N_COST
        {
            set { _n_cost = value; }
            get { return _n_cost; }
        }
        /// <summary>
        /// 税率
        /// </summary>
        public decimal? N_TAXRATE
        {
            set { _n_taxrate = value; }
            get { return _n_taxrate; }
        }
        /// <summary>
        /// 原币无税单价
        /// </summary>
        public decimal? N_ORIGINALCURPRICE
        {
            set { _n_originalcurprice = value; }
            get { return _n_originalcurprice; }
        }
        /// <summary>
        /// 原币含税单价
        /// </summary>
        public decimal? N_ORIGINALCURTAXPRICE
        {
            set { _n_originalcurtaxprice = value; }
            get { return _n_originalcurtaxprice; }
        }
        /// <summary>
        /// 原币无税净价
        /// </summary>
        public decimal? N_ORIGINALCURNETPRICE
        {
            set { _n_originalcurnetprice = value; }
            get { return _n_originalcurnetprice; }
        }
        /// <summary>
        /// 原币含税净价
        /// </summary>
        public decimal? N_ORIGINALCURTAXNETPRICE
        {
            set { _n_originalcurtaxnetprice = value; }
            get { return _n_originalcurtaxnetprice; }
        }
        /// <summary>
        /// 原币税额
        /// </summary>
        public decimal? N_ORIGINALCURTAXMNY
        {
            set { _n_originalcurtaxmny = value; }
            get { return _n_originalcurtaxmny; }
        }
        /// <summary>
        /// 原币无税金额
        /// </summary>
        public decimal? N_ORIGINALCURMNY
        {
            set { _n_originalcurmny = value; }
            get { return _n_originalcurmny; }
        }
        /// <summary>
        /// 原币价税合计
        /// </summary>
        public decimal? N_ORIGINALCURSUMMNY
        {
            set { _n_originalcursummny = value; }
            get { return _n_originalcursummny; }
        }
        /// <summary>
        /// 本币无税单价
        /// </summary>
        public decimal? N_PRICE
        {
            set { _n_price = value; }
            get { return _n_price; }
        }
        /// <summary>
        /// 本币含税单价
        /// </summary>
        public decimal? N_TAXPRICE
        {
            set { _n_taxprice = value; }
            get { return _n_taxprice; }
        }
        /// <summary>
        /// 本币无税净价
        /// </summary>
        public decimal? N_NETPRICE
        {
            set { _n_netprice = value; }
            get { return _n_netprice; }
        }
        /// <summary>
        /// 本币含税净价
        /// </summary>
        public decimal? N_TAXNETPRICE
        {
            set { _n_taxnetprice = value; }
            get { return _n_taxnetprice; }
        }
        /// <summary>
        /// 本币税额
        /// </summary>
        public decimal? N_TAXMNY
        {
            set { _n_taxmny = value; }
            get { return _n_taxmny; }
        }
        /// <summary>
        /// 本币无税金额
        /// </summary>
        public decimal? N_MNY
        {
            set { _n_mny = value; }
            get { return _n_mny; }
        }
        /// <summary>
        /// 本币价税合计
        /// </summary>
        public decimal? N_SUMMNY
        {
            set { _n_summny = value; }
            get { return _n_summny; }
        }
        /// <summary>
        /// 是否已导入NC
        /// </summary>
        public string C_NC_STATE
        {
            set { _c_nc_state = value; }
            get { return _c_nc_state; }
        }
        /// <summary>
        /// 辅数量
        /// </summary>
        public decimal? N_FNUM
        {
            set { _n_fnum = value; }
            get { return _n_fnum; }
        }
        /// <summary>
        /// 换算率
        /// </summary>
        public decimal? N_HSL
        {
            set { _n_hsl = value; }
            get { return _n_hsl; }
        }
        #endregion Model

    }
}

