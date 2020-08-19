using System;
namespace NF.MODEL
{
    /// <summary>
    /// 发运单
    /// </summary>
    [Serializable]
    public partial class Mod_TMD_DISPATCH
    {
        public Mod_TMD_DISPATCH()
        { }
        #region Model
        private string _c_id;
        private string _c_plan_id;
        private string _c_gps_no;
        private string _c_no;
        private string _c_con_no;
        private DateTime? _d_disp_dt;
        private string _c_shipvia;
        private string _c_comcar;
        private string _c_path;
        private string _c_path_desc;
        private string _c_send_dept;
        private string _c_business_dept;
        private string _c_business_id;
        private string _c_is_wiresale;
        private decimal? _n_is_export;
        private string _c_lic_pla_no;
        private string _c_atstation;
        private DateTime? _d_approve_dt;
        private DateTime? _d_create_dt;
        private string _c_approve_id;
        private string _c_create_id;
        private string _c_status;
        private string _c_emp_id;
        private string _c_emp_name;
        private DateTime _d_mod_dt;
        private string _c_guid;
        private string _c_is_wiresale_id;
        private string _c_remark;
        private string _c_remark2;
        private DateTime? _d_failure;
        private string _c_extend1;
        private string _c_extend2;
        private string _c_extend3;
        private string _c_extend4;
        private string _c_extend5;
        private string _c_custname;
        private decimal? _n_qua;
        private decimal? _n_wgt;

        /// <summary>
        /// 修改人
        /// </summary>
        public string C_XGEMP { set; get; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime D_XGTIME { set; get; }

        /// <summary>
        /// 发运支数
        /// </summary>
        public decimal? N_QUA
        {
            set { _n_qua = value; }
            get { return _n_qua; }
        }
        /// <summary>
        /// 发运量
        /// </summary>
        public decimal? N_WGT
        {
            set { _n_wgt = value; }
            get { return _n_wgt; }
        }

        /// <summary>
        /// 客户
        /// </summary>
        public string C_CUSTNAME
        {
            set { _c_custname = value; }
            get { return _c_custname; }
        }


        /// <summary>
        /// 单据号
        /// </summary>
        public string C_ID
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 日计划主键
        /// </summary>
        public string C_PLAN_ID
        {
            set { _c_plan_id = value; }
            get { return _c_plan_id; }
        }
        /// <summary>
        /// GPS设备号
        /// </summary>
        public string C_GPS_NO
        {
            set { _c_gps_no = value; }
            get { return _c_gps_no; }
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
        /// 备注
        /// </summary>
        public string C_CON_NO
        {
            set { _c_con_no = value; }
            get { return _c_con_no; }
        }
        /// <summary>
        /// 发运日期
        /// </summary>
        public DateTime? D_DISP_DT
        {
            set { _d_disp_dt = value; }
            get { return _d_disp_dt; }
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
        /// 承运商
        /// </summary>
        public string C_COMCAR
        {
            set { _c_comcar = value; }
            get { return _c_comcar; }
        }
        /// <summary>
        /// 路线
        /// </summary>
        public string C_PATH
        {
            set { _c_path = value; }
            get { return _c_path; }
        }
        /// <summary>
        /// 路线描述
        /// </summary>
        public string C_PATH_DESC
        {
            set { _c_path_desc = value; }
            get { return _c_path_desc; }
        }
        /// <summary>
        /// 发运组织
        /// </summary>
        public string C_SEND_DEPT
        {
            set { _c_send_dept = value; }
            get { return _c_send_dept; }
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
        /// 业务员
        /// </summary>
        public string C_BUSINESS_ID
        {
            set { _c_business_id = value; }
            get { return _c_business_id; }
        }
        /// <summary>
        /// 是否线材销售
        /// </summary>
        public string C_IS_WIRESALE
        {
            set { _c_is_wiresale = value; }
            get { return _c_is_wiresale; }
        }
        /// <summary>
        /// 是否包到价
        /// </summary>
        public decimal? N_IS_EXPORT
        {
            set { _n_is_export = value; }
            get { return _n_is_export; }
        }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string C_LIC_PLA_NO
        {
            set { _c_lic_pla_no = value; }
            get { return _c_lic_pla_no; }
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
        /// 发运单审批日期
        /// </summary>
        public DateTime? D_APPROVE_DT
        {
            set { _d_approve_dt = value; }
            get { return _d_approve_dt; }
        }
        /// <summary>
        /// 发运单制单日期
        /// </summary>
        public DateTime? D_CREATE_DT
        {
            set { _d_create_dt = value; }
            get { return _d_create_dt; }
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
        /// 制单人
        /// </summary>
        public string C_CREATE_ID
        {
            set { _c_create_id = value; }
            get { return _c_create_id; }
        }
        /// <summary>
        /// 发运单状态 0自由状态 1金额不足 2已导入NC 3已导入条码 4已导入物流 5失效 6删除,7 已做实绩，8线材实绩已导入NC，9钢坯实绩已导入NC，10审核
        /// </summary>
        public string C_STATUS
        {
            set { _c_status = value; }
            get { return _c_status; }
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
        /// 主键
        /// </summary>
        public string C_GUID
        {
            set { _c_guid = value; }
            get { return _c_guid; }
        }
        /// <summary>
        /// 是否线材销售
        /// </summary>
        public string C_IS_WIRESALE_ID
        {
            set { _c_is_wiresale_id = value; }
            get { return _c_is_wiresale_id; }
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
        /// 备注2
        /// </summary>
        public string C_REMARK2
        {
            set { _c_remark2 = value; }
            get { return _c_remark2; }
        }
        /// <summary>
        /// 失效时间
        /// </summary>
        public DateTime? D_FAILURE
        {
            set { _d_failure = value; }
            get { return _d_failure; }
        }
        /// <summary>
        /// 扩展字段-记录导入条码系统次数
        /// </summary>
        public string C_EXTEND1
        {
            set { _c_extend1 = value; }
            get { return _c_extend1; }
        }
        /// <summary>
        /// 虚拟车号
        /// </summary>
        public string C_EXTEND2
        {
            set { _c_extend2 = value; }
            get { return _c_extend2; }
        }
        /// <summary>
        /// 司机姓名/电话
        /// </summary>
        public string C_EXTEND3
        {
            set { _c_extend3 = value; }
            get { return _c_extend3; }
        }
        /// <summary>
        /// 客户姓名/电话
        /// </summary>
        public string C_EXTEND4
        {
            set { _c_extend4 = value; }
            get { return _c_extend4; }
        }
        /// <summary>
        /// 扩展字段-订单类型 8线材 6钢坯 831废乱材  841焦化产品 851渣
        /// </summary>
        public string C_EXTEND5
        {
            set { _c_extend5 = value; }
            get { return _c_extend5; }
        }
        #endregion Model

    }
}

