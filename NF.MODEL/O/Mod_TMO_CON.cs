using System;
namespace NF.MODEL
{
    /// <summary>
    /// 合同
    /// </summary>
    [Serializable]
    public partial class Mod_TMO_CON
    {
        public Mod_TMO_CON()
        { }
        #region Model
        private string _c_con_no;
        private string _c_con_name;
        private string _c_contypeid;
        private string _c_customerid;
        private string _c_custname;
        private string _c_coperatorid;
        private DateTime? _d_dmakedate;
        private string _c_currencytypeid;
        private DateTime? _d_consing_dt;
        private DateTime? _d_coneffe_dt;
        private DateTime? _d_coninvalid_dt;
        private string _c_transmodeid;
        private string _c_area;
        private decimal? _n_status = -1;
        private string _n_flag;
        private string _c_salecorpid;
        private string _c_biztype;
        private string _c_deptid;
        private string _c_employeeid;
        private string _c_editemployeeid;
        private DateTime? _d_editdate;
        private string _c_approveid;
        private DateTime? _d_approvedate;
        private string _c_flowid;
        private string _c_xgid = "1001";
        private string _c_emp_id;
        private string _c_emp_name;
        private DateTime? _d_mod_dt;
        private decimal? _n_cust_lev;
        private string _c_creceiptcustomerid;
        private string _c_address;
        private string _c_creceiptareaid;
        private string _c_creceiptcorpid;
        private string _c_station;
        private string _c_reamrk;
        private DateTime? _d_changedate;
        private DateTime? _d_need_dt;
        private string _c_nc_state;
        private string _c_changeempid;
        private decimal? _n_changenum;
        private string _c_receiptcode;



        #region 自定义
        private string _c_contype;
        private string _c_currencytype;
        private string _c_transmode;
        private string _c_creceiptcustomer;
        private string _c_creceiptcorp;
        private string _c_employee;
        private string _c_biztypename;
        private string _classname;
        private string _c_salecorp;
        private string _c_dept;


        /// <summary>
        /// 业务类型
        /// </summary>
        public string C_BIZTYPENAME
        {
            set { _c_biztypename = value; }
            get { return _c_biztypename; }
        }
        /// <summary>
        /// 合同分类
        /// </summary>
        public string CLASSNAME
        {
            set { _classname = value; }
            get { return _classname; }
        }
        /// <summary>
        /// 销售组织
        /// </summary>
        public string C_SALECORP
        {
            set { _c_salecorp = value; }
            get { return _c_salecorp; }
        }
        /// <summary>
        /// 部门
        /// </summary>
        public string C_DEPT
        {
            set { _c_dept = value; }
            get { return _c_dept; }
        }


        /// <summary>
        /// 业务员名称
        /// </summary>
        public string C_EMPLOYEE
        {
            set { _c_employee = value; }
            get { return _c_employee; }
        }

        /// <summary>
        /// 合同类型名称
        /// </summary>
        public string C_CONTYPE
        {
            set { _c_contype = value; }
            get { return _c_contype; }
        }
        /// <summary>
        /// 货币名称
        /// </summary>
        public string C_CURRENCYTYPE
        {
            set { _c_currencytype = value; }
            get { return _c_currencytype; }
        }
        /// <summary>
        /// 发运方式
        /// </summary>
        public string C_TRANSMODE
        {
            set { _c_transmode = value; }
            get { return _c_transmode; }
        }

        /// <summary>
        /// 收货单位
        /// </summary>
        public string C_CRECEIPTCUSTOMER
        {
            set { _c_creceiptcustomer = value; }
            get { return _c_creceiptcustomer; }
        }
        /// <summary>
        /// 开票单位
        /// </summary>
        public string C_CRECEIPTCORP
        {
            set { _c_creceiptcorp = value; }
            get { return _c_creceiptcorp; }
        }

        #endregion

        /// <summary>
        /// 新合同号
        /// </summary>
        public string C_CON_NEW { set; get; }

        /// <summary>
        /// 合同序号
        /// </summary>
        public string C_CON_XH { set; get; }

        /// <summary>
        /// 客户编码
        /// </summary>
        public string C_CUST_NO { set; get; }

        /// <summary>
        /// 原合同号
        /// </summary>
        public string C_CON_NO_OLD { set; get; }

        /// <summary>
        /// 合同号(主键)
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
        /// 合同类型ID
        /// </summary>
        public string C_CONTYPEID
        {
            set { _c_contypeid = value; }
            get { return _c_contypeid; }
        }
        /// <summary>
        /// 客户ID
        /// </summary>
        public string C_CUSTOMERID
        {
            set { _c_customerid = value; }
            get { return _c_customerid; }
        }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string C_CUSTNAME
        {
            set { _c_custname = value; }
            get { return _c_custname; }
        }
        /// <summary>
        /// 制单人ID
        /// </summary>
        public string C_COPERATORID
        {
            set { _c_coperatorid = value; }
            get { return _c_coperatorid; }
        }
        /// <summary>
        /// 制单日期
        /// </summary>
        public DateTime? D_DMAKEDATE
        {
            set { _d_dmakedate = value; }
            get { return _d_dmakedate; }
        }
        /// <summary>
        /// 货币类型
        /// </summary>
        public string C_CURRENCYTYPEID
        {
            set { _c_currencytypeid = value; }
            get { return _c_currencytypeid; }
        }
        /// <summary>
        /// 合同签署日期
        /// </summary>
        public DateTime? D_CONSING_DT
        {
            set { _d_consing_dt = value; }
            get { return _d_consing_dt; }
        }
        /// <summary>
        /// 计划生效日期
        /// </summary>
        public DateTime? D_CONEFFE_DT
        {
            set { _d_coneffe_dt = value; }
            get { return _d_coneffe_dt; }
        }
        /// <summary>
        /// 计划失效日期
        /// </summary>
        public DateTime? D_CONINVALID_DT
        {
            set { _d_coninvalid_dt = value; }
            get { return _d_coninvalid_dt; }
        }
        /// <summary>
        /// 发运方式
        /// </summary>
        public string C_TRANSMODEID
        {
            set { _c_transmodeid = value; }
            get { return _c_transmodeid; }
        }
        /// <summary>
        /// 合同区域
        /// </summary>
        public string C_AREA
        {
            set { _c_area = value; }
            get { return _c_area; }
        }
        /// <summary>
        /// 合同状态：-1未提交，0待审，1审核中，2生效，3变更,4审核通过
        /// </summary>
        public decimal? N_STATUS
        {
            set { _n_status = value; }
            get { return _n_status; }
        }
        /// <summary>
        /// 合同标识：0日常合同  1买断合同，2特殊价格合同,3意向合同
        /// </summary>
        public string N_FLAG
        {
            set { _n_flag = value; }
            get { return _n_flag; }
        }
        /// <summary>
        /// 销售组织
        /// </summary>
        public string C_SALECORPID
        {
            set { _c_salecorpid = value; }
            get { return _c_salecorpid; }
        }
        /// <summary>
        /// 业务类型
        /// </summary>
        public string C_BIZTYPE
        {
            set { _c_biztype = value; }
            get { return _c_biztype; }
        }
        /// <summary>
        /// 部门
        /// </summary>
        public string C_DEPTID
        {
            set { _c_deptid = value; }
            get { return _c_deptid; }
        }
        /// <summary>
        /// 业务员
        /// </summary>
        public string C_EMPLOYEEID
        {
            set { _c_employeeid = value; }
            get { return _c_employeeid; }
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
        /// 审批人
        /// </summary>
        public string C_APPROVEID
        {
            set { _c_approveid = value; }
            get { return _c_approveid; }
        }
        /// <summary>
        /// 审批日期
        /// </summary>
        public DateTime? D_APPROVEDATE
        {
            set { _d_approvedate = value; }
            get { return _d_approvedate; }
        }
        /// <summary>
        /// 审批流ID
        /// </summary>
        public string C_FLOWID
        {
            set { _c_flowid = value; }
            get { return _c_flowid; }
        }
        /// <summary>
        /// 型钢公司ID
        /// </summary>
        public string C_XGID
        {
            set { _c_xgid = value; }
            get { return _c_xgid; }
        }
        /// <summary>
        /// 操作人ID
        /// </summary>
        public string C_EMP_ID
        {
            set { _c_emp_id = value; }
            get { return _c_emp_id; }
        }
        /// <summary>
        /// 操作人姓名
        /// </summary>
        public string C_EMP_NAME
        {
            set { _c_emp_name = value; }
            get { return _c_emp_name; }
        }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? D_MOD_DT
        {
            set { _d_mod_dt = value; }
            get { return _d_mod_dt; }
        }
        /// <summary>
        /// 客户等级
        /// </summary>
        public decimal? N_CUST_LEV
        {
            set { _n_cust_lev = value; }
            get { return _n_cust_lev; }
        }
        /// <summary>
        /// 收货单位
        /// </summary>
        public string C_CRECEIPTCUSTOMERID
        {
            set { _c_creceiptcustomerid = value; }
            get { return _c_creceiptcustomerid; }
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
        /// 收货地区
        /// </summary>
        public string C_CRECEIPTAREAID
        {
            set { _c_creceiptareaid = value; }
            get { return _c_creceiptareaid; }
        }
        /// <summary>
        /// 开票单位
        /// </summary>
        public string C_CRECEIPTCORPID
        {
            set { _c_creceiptcorpid = value; }
            get { return _c_creceiptcorpid; }
        }
        /// <summary>
        /// 到站
        /// </summary>
        public string C_STATION
        {
            set { _c_station = value; }
            get { return _c_station; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string C_REAMRK
        {
            set { _c_reamrk = value; }
            get { return _c_reamrk; }
        }
        /// <summary>
        /// 合同变更日期
        /// </summary>
        public DateTime? D_CHANGEDATE
        {
            set { _d_changedate = value; }
            get { return _d_changedate; }
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
        /// 是否已导入NC
        /// </summary>
        public string C_NC_STATE
        {
            set { _c_nc_state = value; }
            get { return _c_nc_state; }
        }

        /// <summary>
        /// 变更人ID
        /// </summary>
        public string C_CHANGEEMPID
        {
            set { _c_changeempid = value; }
            get { return _c_changeempid; }
        }
        /// <summary>
        /// 变更次数
        /// </summary>
        public decimal? N_CHANGENUM
        {
            set { _n_changenum = value; }
            get { return _n_changenum; }
        }

        /// <summary>
        /// 单据号
        /// </summary>
        public string C_RECEIPTCODE
        {
            set { _c_receiptcode = value; }
            get { return _c_receiptcode; }
        }

        #endregion Model
    }
}

