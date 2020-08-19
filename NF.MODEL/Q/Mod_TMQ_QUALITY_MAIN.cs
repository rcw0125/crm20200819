using System;
namespace NF.MODEL
{
	/// <summary>
	/// 质量异议主表
	/// </summary>
	[Serializable]
	public partial class Mod_TMQ_QUALITY_MAIN
    {
		public Mod_TMQ_QUALITY_MAIN()
		{}
		#region Model
		private string _c_id= Guid.NewGuid().ToString ();
		private string _c_quest_id;
		private string _c_prod_kind_id;
		private string _c_shipvia;
		private DateTime? _d_ship_start_dt;
		private DateTime? _d_ship_end_dt;
		private decimal? _n_parent_remain_wgt;
		private decimal? _n_middle_remain_wgt;
		private string _c_area;
		private string _c_cust_name;
		private string _c_cust_type;
		private string _c_cust_no;
		private string _c_tel;
		private string _c_name;
		private string _c_stl_grd_class;
		private string _c_prod_use;
		private decimal? _n_object_count_wgt;
		private string _c_object_content;
		private string _c_tech_desc;
		private string _c_site_survey_content;
		private decimal? _n_parent_qua;
		private decimal? _n_quest_qua;
		private decimal? _n_middle_qua;
		private decimal? _n_else_qua;
		private string _c_site_survey_emp;
		private string _c_dept;
		private string _c_remark;
		private string _c_cust_making;
		private DateTime? _c_cust_making_dt;
		private string _c_xg_modify;
		private DateTime? _c_xg_modeify_dt;
		private string _c_approver;
		private DateTime? _d_approver_dt;
		private string _c_flow_id;
		private decimal? _n_status=-1;
		private decimal? _n_flag;
		private string _c_emp_id;
		private string _c_emp_name;
		private DateTime? _d_mod_dt= Convert.ToDateTime(DateTime.Now);
		private string _c_dept2;
		private string _c_dept3;
		private string _c_dept4;
		/// <summary>
		/// C_ID
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 质量问题ID
		/// </summary>
		public string C_QUEST_ID
		{
			set{ _c_quest_id=value;}
			get{return _c_quest_id;}
		}
		/// <summary>
		/// 品种ID
		/// </summary>
		public string C_PROD_KIND_ID
		{
			set{ _c_prod_kind_id=value;}
			get{return _c_prod_kind_id;}
		}
		/// <summary>
		/// 发运方式
		/// </summary>
		public string C_SHIPVIA
		{
			set{ _c_shipvia=value;}
			get{return _c_shipvia;}
		}
		/// <summary>
		/// 发货开始时间
		/// </summary>
		public DateTime? D_SHIP_START_DT
		{
			set{ _d_ship_start_dt=value;}
			get{return _d_ship_start_dt;}
		}
		/// <summary>
		/// 发货到货时间
		/// </summary>
		public DateTime? D_SHIP_END_DT
		{
			set{ _d_ship_end_dt=value;}
			get{return _d_ship_end_dt;}
		}
		/// <summary>
		/// 母材剩余量
		/// </summary>
		public decimal? N_PARENT_REMAIN_WGT
		{
			set{ _n_parent_remain_wgt=value;}
			get{return _n_parent_remain_wgt;}
		}
		/// <summary>
		/// 中间产品剩余量
		/// </summary>
		public decimal? N_MIDDLE_REMAIN_WGT
		{
			set{ _n_middle_remain_wgt=value;}
			get{return _n_middle_remain_wgt;}
		}
		/// <summary>
		/// 区域:如华南销售大区
		/// </summary>
		public string C_AREA
		{
			set{ _c_area=value;}
			get{return _c_area;}
		}
		/// <summary>
		/// 客户名称
		/// </summary>
		public string C_CUST_NAME
		{
			set{ _c_cust_name=value;}
			get{return _c_cust_name;}
		}
		/// <summary>
		/// 客户类型：经销/直销
		/// </summary>
		public string C_CUST_TYPE
		{
			set{ _c_cust_type=value;}
			get{return _c_cust_type;}
		}
		/// <summary>
		/// 客户编码
		/// </summary>
		public string C_CUST_NO
		{
			set{ _c_cust_no=value;}
			get{return _c_cust_no;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string C_TEL
		{
			set{ _c_tel=value;}
			get{return _c_tel;}
		}
		/// <summary>
		/// 联系人
		/// </summary>
		public string C_NAME
		{
			set{ _c_name=value;}
			get{return _c_name;}
		}
		/// <summary>
		/// 钢种分类
		/// </summary>
		public string C_STL_GRD_CLASS
		{
			set{ _c_stl_grd_class=value;}
			get{return _c_stl_grd_class;}
		}
		/// <summary>
		/// 产品用途
		/// </summary>
		public string C_PROD_USE
		{
			set{ _c_prod_use=value;}
			get{return _c_prod_use;}
		}
		/// <summary>
		/// 异议数量合计
		/// </summary>
		public decimal? N_OBJECT_COUNT_WGT
		{
			set{ _n_object_count_wgt=value;}
			get{return _n_object_count_wgt;}
		}
		/// <summary>
		/// 投诉异议内容/信息内容
		/// </summary>
		public string C_OBJECT_CONTENT
		{
			set{ _c_object_content=value;}
			get{return _c_object_content;}
		}
		/// <summary>
		/// 用户工艺流程/生产工艺
		/// </summary>
		public string C_TECH_DESC
		{
			set{ _c_tech_desc=value;}
			get{return _c_tech_desc;}
		}
		/// <summary>
		/// 现场调查情况
		/// </summary>
		public string C_SITE_SURVEY_CONTENT
		{
			set{ _c_site_survey_content=value;}
			get{return _c_site_survey_content;}
		}
		/// <summary>
		/// 母材支数(取样)/原始盘条样
		/// </summary>
		public decimal? N_PARENT_QUA
		{
			set{ _n_parent_qua=value;}
			get{return _n_parent_qua;}
		}
		/// <summary>
		/// 问题样支数(取样)/问题产品
		/// </summary>
		public decimal? N_QUEST_QUA
		{
			set{ _n_quest_qua=value;}
			get{return _n_quest_qua;}
		}
		/// <summary>
		/// 中间样支数(取样)/中间产品样
		/// </summary>
		public decimal? N_MIDDLE_QUA
		{
			set{ _n_middle_qua=value;}
			get{return _n_middle_qua;}
		}
		/// <summary>
		/// 其他支数(取样)
		/// </summary>
		public decimal? N_ELSE_QUA
		{
			set{ _n_else_qua=value;}
			get{return _n_else_qua;}
		}
		/// <summary>
		/// 现场调查人员
		/// </summary>
		public string C_SITE_SURVEY_EMP
		{
			set{ _c_site_survey_emp=value;}
			get{return _c_site_survey_emp;}
		}
		/// <summary>
		/// 本部门
		/// </summary>
		public string C_DEPT
		{
			set{ _c_dept=value;}
			get{return _c_dept;}
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
		/// 制单人
		/// </summary>
		public string C_CUST_MAKING
		{
			set{ _c_cust_making=value;}
			get{return _c_cust_making;}
		}
		/// <summary>
		/// 制单时间
		/// </summary>
		public DateTime? C_CUST_MAKING_DT
		{
			set{ _c_cust_making_dt=value;}
			get{return _c_cust_making_dt;}
		}
		/// <summary>
		/// 型钢最后修改人
		/// </summary>
		public string C_XG_MODIFY
		{
			set{ _c_xg_modify=value;}
			get{return _c_xg_modify;}
		}
		/// <summary>
		/// 型钢最后修改日期
		/// </summary>
		public DateTime? C_XG_MODEIFY_DT
		{
			set{ _c_xg_modeify_dt=value;}
			get{return _c_xg_modeify_dt;}
		}
		/// <summary>
		/// 审批人
		/// </summary>
		public string C_APPROVER
		{
			set{ _c_approver=value;}
			get{return _c_approver;}
		}
		/// <summary>
		/// 审批时间
		/// </summary>
		public DateTime? D_APPROVER_DT
		{
			set{ _d_approver_dt=value;}
			get{return _d_approver_dt;}
		}
		/// <summary>
		/// 审批流程ID
		/// </summary>
		public string C_FLOW_ID
		{
			set{ _c_flow_id=value;}
			get{return _c_flow_id;}
		}
		/// <summary>
		/// 状态：-1未提交,0待处理,1处理中,2已完成
		/// </summary>
		public decimal? N_STATUS
		{
			set{ _n_status=value;}
			get{return _n_status;}
		}
		/// <summary>
		/// 标识：0 质量异议，1客户信息反馈
		/// </summary>
		public decimal? N_FLAG
		{
			set{ _n_flag=value;}
			get{return _n_flag;}
		}
		/// <summary>
		/// 系统操作人编号
		/// </summary>
		public string C_EMP_ID
		{
			set{ _c_emp_id=value;}
			get{return _c_emp_id;}
		}
		/// <summary>
		/// 系统操作人姓名
		/// </summary>
		public string C_EMP_NAME
		{
			set{ _c_emp_name=value;}
			get{return _c_emp_name;}
		}
		/// <summary>
		/// 系系统操作时间
		/// </summary>
		public DateTime? D_MOD_DT
		{
			set{ _d_mod_dt=value;}
			get{return _d_mod_dt;}
		}
		/// <summary>
		/// 质控部
		/// </summary>
		public string C_DEPT2
		{
			set{ _c_dept2=value;}
			get{return _c_dept2;}
		}
		/// <summary>
		/// 技术中心
		/// </summary>
		public string C_DEPT3
		{
			set{ _c_dept3=value;}
			get{return _c_dept3;}
		}
		/// <summary>
		/// 其他部门
		/// </summary>
		public string C_DEPT4
		{
			set{ _c_dept4=value;}
			get{return _c_dept4;}
		}
		#endregion Model

	}
}

