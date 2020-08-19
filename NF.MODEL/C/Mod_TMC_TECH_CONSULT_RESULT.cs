using System;
namespace NF.MODEL
{
	/// <summary>
	/// 技术咨询处理结果表
	/// </summary>
	[Serializable]
	public partial class Mod_TMC_TECH_CONSULT_RESULT
    {
		public Mod_TMC_TECH_CONSULT_RESULT()
		{}
        #region Model
        private string _c_id = Guid.NewGuid().ToString();
		private string _c_tech_consult_id;
		private string _c_dept;
		private string _c_emp_id;
		private DateTime? _d_plan_dt;
		private DateTime? _d_finish_dt;
		private string _c_real_time;
		private string _c_result;
		private string _c_leave_q;
		private string _c_remark;
		private decimal? _n_cust_eval;
		private DateTime? _d_cust_eval_dt;
		private decimal? _n_xg_eval;
		private string _c_xg_eval_emp;
		private DateTime? _d_xg_eval_dt;
		/// <summary>
		/// C_ID
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 技术咨询ID
		/// </summary>
		public string C_TECH_CONSULT_ID
		{
			set{ _c_tech_consult_id=value;}
			get{return _c_tech_consult_id;}
		}
		/// <summary>
		/// 部门
		/// </summary>
		public string C_DEPT
		{
			set{ _c_dept=value;}
			get{return _c_dept;}
		}
		/// <summary>
		/// 人员
		/// </summary>
		public string C_EMP_ID
		{
			set{ _c_emp_id=value;}
			get{return _c_emp_id;}
		}
		/// <summary>
		/// 计划时间
		/// </summary>
		public DateTime? D_PLAN_DT
		{
			set{ _d_plan_dt=value;}
			get{return _d_plan_dt;}
		}
		/// <summary>
		/// 完成时间
		/// </summary>
		public DateTime? D_FINISH_DT
		{
			set{ _d_finish_dt=value;}
			get{return _d_finish_dt;}
		}
		/// <summary>
		/// 实时动态
		/// </summary>
		public string C_REAL_TIME
		{
			set{ _c_real_time=value;}
			get{return _c_real_time;}
		}
		/// <summary>
		/// 处理情况
		/// </summary>
		public string C_RESULT
		{
			set{ _c_result=value;}
			get{return _c_result;}
		}
		/// <summary>
		/// 遗留问题
		/// </summary>
		public string C_LEAVE_Q
		{
			set{ _c_leave_q=value;}
			get{return _c_leave_q;}
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
		/// 客户评价
		/// </summary>
		public decimal? N_CUST_EVAL
		{
			set{ _n_cust_eval=value;}
			get{return _n_cust_eval;}
		}
		/// <summary>
		/// 客户评价时间
		/// </summary>
		public DateTime? D_CUST_EVAL_DT
		{
			set{ _d_cust_eval_dt=value;}
			get{return _d_cust_eval_dt;}
		}
		/// <summary>
		/// 邢钢评价
		/// </summary>
		public decimal? N_XG_EVAL
		{
			set{ _n_xg_eval=value;}
			get{return _n_xg_eval;}
		}
		/// <summary>
		/// 邢钢评价人
		/// </summary>
		public string C_XG_EVAL_EMP
		{
			set{ _c_xg_eval_emp=value;}
			get{return _c_xg_eval_emp;}
		}
		/// <summary>
		/// 邢钢评价时间
		/// </summary>
		public DateTime? D_XG_EVAL_DT
		{
			set{ _d_xg_eval_dt=value;}
			get{return _d_xg_eval_dt;}
		}
		#endregion Model

	}
}

