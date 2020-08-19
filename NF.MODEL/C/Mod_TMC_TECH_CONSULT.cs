using System;
namespace NF.MODEL
{
    /// <summary>
    /// 技术咨询主表
    /// </summary>
    [Serializable]
    public partial class Mod_TMC_TECH_CONSULT
    {
        public Mod_TMC_TECH_CONSULT()
        { }
        #region Model
        private string _c_id = Guid.NewGuid().ToString();
        private string _c_quest_id;
        private string _c_cust_name;
        private string _c_cust_code;
        private string _c_stl_grd;
        private string _c_use_desc;
        private string _c_remark;
        private string _c_emp_id;
        private string _c_emp_name;
        private DateTime? _d_mod_dt = Convert.ToDateTime(DateTime.Now);
        private string _c_dept;
        private string _c_emp;
        private DateTime? _d_plan_dt;
        private DateTime? _d_finish_dt;
        private string _c_real_time;
        private string _c_result;
        private string _c_leave_q;
        private string _c_remark2;
        private decimal? _n_cust_eval;
        private decimal? _n_state = 0;
        private DateTime? _d_cust_eval_dt;
        private decimal? _n_xg_eval;
        private string _c_xg_eval_emp;
        private DateTime? _d_xg_eval_dt;


        private string _c_order_no;

        /// <summary>
        /// 订单号
        /// </summary>
        public string C_ORDER_NO
        {
            set { _c_order_no = value; }
            get { return _c_order_no; }
        }


        /// <summary>
        /// C_ID
        /// </summary>
        public string C_ID
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 问题类型ID
        /// </summary>
        public string C_QUEST_ID
        {
            set { _c_quest_id = value; }
            get { return _c_quest_id; }
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
        /// 客户编码
        /// </summary>
        public string C_CUST_CODE
        {
            set { _c_cust_code = value; }
            get { return _c_cust_code; }
        }
        /// <summary>
        /// 产品
        /// </summary>
        public string C_STL_GRD
        {
            set { _c_stl_grd = value; }
            get { return _c_stl_grd; }
        }
        /// <summary>
        /// 用途及工艺
        /// </summary>
        public string C_USE_DESC
        {
            set { _c_use_desc = value; }
            get { return _c_use_desc; }
        }
        /// <summary>
        /// 问题描述
        /// </summary>
        public string C_REMARK
        {
            set { _c_remark = value; }
            get { return _c_remark; }
        }
        /// <summary>
        /// 操作人编号
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
        /// 部门
        /// </summary>
        public string C_DEPT
        {
            set { _c_dept = value; }
            get { return _c_dept; }
        }
        /// <summary>
        /// 服务专员
        /// </summary>
        public string C_EMP
        {
            set { _c_emp = value; }
            get { return _c_emp; }
        }
        /// <summary>
        /// 计划时间
        /// </summary>
        public DateTime? D_PLAN_DT
        {
            set { _d_plan_dt = value; }
            get { return _d_plan_dt; }
        }
        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime? D_FINISH_DT
        {
            set { _d_finish_dt = value; }
            get { return _d_finish_dt; }
        }
        /// <summary>
        /// 实时动态
        /// </summary>
        public string C_REAL_TIME
        {
            set { _c_real_time = value; }
            get { return _c_real_time; }
        }
        /// <summary>
        /// 处理情况
        /// </summary>
        public string C_RESULT
        {
            set { _c_result = value; }
            get { return _c_result; }
        }
        /// <summary>
        /// 遗留问题
        /// </summary>
        public string C_LEAVE_Q
        {
            set { _c_leave_q = value; }
            get { return _c_leave_q; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string C_REMARK2
        {
            set { _c_remark2 = value; }
            get { return _c_remark2; }
        }
        /// <summary>
        /// 客户评分
        /// </summary>
        public decimal? N_CUST_EVAL
        {
            set { _n_cust_eval = value; }
            get { return _n_cust_eval; }
        }
        /// <summary>
        /// 默认0,1邢钢已处理，2客户已评分
        /// </summary>
        public decimal? N_STATE
        {
            set { _n_state = value; }
            get { return _n_state; }
        }
        /// <summary>
        /// 客户评分时间
        /// </summary>
        public DateTime? D_CUST_EVAL_DT
        {
            set { _d_cust_eval_dt = value; }
            get { return _d_cust_eval_dt; }
        }
        /// <summary>
        /// 邢钢评分
        /// </summary>
        public decimal? N_XG_EVAL
        {
            set { _n_xg_eval = value; }
            get { return _n_xg_eval; }
        }
        /// <summary>
        /// 邢钢评分人
        /// </summary>
        public string C_XG_EVAL_EMP
        {
            set { _c_xg_eval_emp = value; }
            get { return _c_xg_eval_emp; }
        }
        /// <summary>
        /// 邢钢评分时间
        /// </summary>
        public DateTime? D_XG_EVAL_DT
        {
            set { _d_xg_eval_dt = value; }
            get { return _d_xg_eval_dt; }
        }
        #endregion Model

    }
}

