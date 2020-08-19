using System;
namespace NF.MODEL
{
	/// <summary>
	/// 客户来访台账
	/// </summary>
	[Serializable]
	public partial class Mod_TMC_CUST_BOOK
	{
		public Mod_TMC_CUST_BOOK()
		{}
		#region Model
		private string _c_id= Guid.NewGuid().ToString ();
		private DateTime? _d_zf_dt;
		private string _c_cust_name;
		private string _c_area;
		private string _c_cust_manage;
		private string _c_cust_emp;
		private string _c_cust_emp_tel;
		private string _c_meeting_cust;
		private string _c_meeting_xg;
		private string _c_main_content;
		private string _c_need_s_q;
		private string _c_leave_q;
		private string _c_stl_grd;
		private string _c_pro_use;
		private string _c_site;
		private string _c_remark;
		private decimal? _n_type;
		/// <summary>
		/// 主键
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 走访日期
		/// </summary>
		public DateTime? D_ZF_DT
		{
			set{ _d_zf_dt=value;}
			get{return _d_zf_dt;}
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
		/// 区域
		/// </summary>
		public string C_AREA
		{
			set{ _c_area=value;}
			get{return _c_area;}
		}
		/// <summary>
		/// 客户经理
		/// </summary>
		public string C_CUST_MANAGE
		{
			set{ _c_cust_manage=value;}
			get{return _c_cust_manage;}
		}
		/// <summary>
		/// 客户人员
		/// </summary>
		public string C_CUST_EMP
		{
			set{ _c_cust_emp=value;}
			get{return _c_cust_emp;}
		}
		/// <summary>
		/// 客户人员电话
		/// </summary>
		public string C_CUST_EMP_TEL
		{
			set{ _c_cust_emp_tel=value;}
			get{return _c_cust_emp_tel;}
		}
		/// <summary>
		/// 参会客户名单
		/// </summary>
		public string C_MEETING_CUST
		{
			set{ _c_meeting_cust=value;}
			get{return _c_meeting_cust;}
		}
		/// <summary>
		/// 参会邢钢名单
		/// </summary>
		public string C_MEETING_XG
		{
			set{ _c_meeting_xg=value;}
			get{return _c_meeting_xg;}
		}
		/// <summary>
		/// 主要交流内容
		/// </summary>
		public string C_MAIN_CONTENT
		{
			set{ _c_main_content=value;}
			get{return _c_main_content;}
		}
		/// <summary>
		/// 需解决问题
		/// </summary>
		public string C_NEED_S_Q
		{
			set{ _c_need_s_q=value;}
			get{return _c_need_s_q;}
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
		/// 钢种
		/// </summary>
		public string C_STL_GRD
		{
			set{ _c_stl_grd=value;}
			get{return _c_stl_grd;}
		}
		/// <summary>
		/// 用途
		/// </summary>
		public string C_PRO_USE
		{
			set{ _c_pro_use=value;}
			get{return _c_pro_use;}
		}
		/// <summary>
		/// 交流地点
		/// </summary>
		public string C_SITE
		{
			set{ _c_site=value;}
			get{return _c_site;}
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
		/// 0：走访用户，1来访客户
		/// </summary>
		public decimal? N_TYPE
		{
			set{ _n_type=value;}
			get{return _n_type;}
		}

        public string C_EMPID { get; set; }
        #endregion Model

    }
}

