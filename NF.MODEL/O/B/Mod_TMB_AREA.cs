using System;
namespace NF.MODEL
{
	/// <summary>
	/// 地理区域
	/// </summary>
	[Serializable]
	public partial class Mod_TMB_AREA
    {
		public Mod_TMB_AREA()
		{}
		#region Model
		private string _c_id=Guid.NewGuid().ToString ();
		private string _c_code;
		private string _c_name;
		private string _n_parentid;
		private decimal? _n_sort;
		private decimal? _n_depth;
		private string _c_remark;
		private decimal? _n_status=1;
		private decimal? _n_isgps=0;
		private string _c_emp_id;
		private string _c_emp_name;
		private DateTime? _d_mod_dt= Convert.ToDateTime(DateTime.Now);
		/// <summary>
		/// 主键ID
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 区域编码
		/// </summary>
		public string C_CODE
		{
			set{ _c_code=value;}
			get{return _c_code;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string C_NAME
		{
			set{ _c_name=value;}
			get{return _c_name;}
		}
		/// <summary>
		/// 父ID
		/// </summary>
		public string N_PARENTID
		{
			set{ _n_parentid=value;}
			get{return _n_parentid;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public decimal? N_SORT
		{
			set{ _n_sort=value;}
			get{return _n_sort;}
		}
		/// <summary>
		/// 深度
		/// </summary>
		public decimal? N_DEPTH
		{
			set{ _n_depth=value;}
			get{return _n_depth;}
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
		/// 状态0停用1启用
		/// </summary>
		public decimal? N_STATUS
		{
			set{ _n_status=value;}
			get{return _n_status;}
		}
		/// <summary>
		/// 是否GPS
		/// </summary>
		public decimal? N_ISGPS
		{
			set{ _n_isgps=value;}
			get{return _n_isgps;}
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

