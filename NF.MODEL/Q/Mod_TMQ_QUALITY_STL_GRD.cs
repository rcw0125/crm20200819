using System;
namespace NF.MODEL
{
	/// <summary>
	/// 质量异议-钢种
	/// </summary>
	[Serializable]
	public partial class Mod_TMQ_QUALITY_STL_GRD
    {
		public Mod_TMQ_QUALITY_STL_GRD()
		{}
		#region Model
		private string _c_id=Guid.NewGuid().ToString ();
		private string _c_quality_id;
		private string _c_mat_type;
		private string _c_mat_type_n;
		private string _c_stl_grd;
		private string _c_spec;
		private string _c_batch_no;
		private string _c_std_code;
		private decimal? _n_ship_wgt;
		private decimal? _n_objec_wgt;
		private decimal? _n_wgt;
		private string _c_remark;
		private decimal? _n_status=-1;
		private decimal? _n_flag;
		private string _c_emp_id;
		private string _c_emp_name;
		private DateTime? _d_mod_dt= Convert.ToDateTime(DateTime.Now);
		/// <summary>
		/// 
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 质量异议主表ID
		/// </summary>
		public string C_QUALITY_ID
		{
			set{ _c_quality_id=value;}
			get{return _c_quality_id;}
		}
		/// <summary>
		/// 物料大类
		/// </summary>
		public string C_MAT_TYPE
		{
			set{ _c_mat_type=value;}
			get{return _c_mat_type;}
		}
		/// <summary>
		/// 物料次类
		/// </summary>
		public string C_MAT_TYPE_N
		{
			set{ _c_mat_type_n=value;}
			get{return _c_mat_type_n;}
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
		/// 规格
		/// </summary>
		public string C_SPEC
		{
			set{ _c_spec=value;}
			get{return _c_spec;}
		}
		/// <summary>
		/// 批号
		/// </summary>
		public string C_BATCH_NO
		{
			set{ _c_batch_no=value;}
			get{return _c_batch_no;}
		}
		/// <summary>
		/// 执行标准
		/// </summary>
		public string C_STD_CODE
		{
			set{ _c_std_code=value;}
			get{return _c_std_code;}
		}
		/// <summary>
		/// 发货数量
		/// </summary>
		public decimal? N_SHIP_WGT
		{
			set{ _n_ship_wgt=value;}
			get{return _n_ship_wgt;}
		}
		/// <summary>
		/// 异议数量
		/// </summary>
		public decimal? N_OBJEC_WGT
		{
			set{ _n_objec_wgt=value;}
			get{return _n_objec_wgt;}
		}
		/// <summary>
		/// 数量
		/// </summary>
		public decimal? N_WGT
		{
			set{ _n_wgt=value;}
			get{return _n_wgt;}
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
		#endregion Model

	}
}

