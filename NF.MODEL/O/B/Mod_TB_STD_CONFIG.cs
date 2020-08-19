using System;

namespace NF.MODEL
{
	/// <summary>
	/// 标准匹配表
	/// </summary>
	[Serializable]
	public partial class Mod_TB_STD_CONFIG
    {
		public Mod_TB_STD_CONFIG()
		{}
        #region Model
        private string _c_id = Guid.NewGuid().ToString ();
		private string _c_std_id;
		private string _c_cust_tech_prot;
		private string _c_zyx1;
		private string _c_zyx2;
		private string _c_stl_grd;
		private string _c_std_code;
		private string _c_steel_sign;
		private string _c_emp_id;
        private DateTime _d_mod_dt = DateTime.Now;
		private string _c_remark;
        private DateTime _d_start_date = DateTime.Now;
		private DateTime? _d_end_date;
		private decimal _n_status=1;
		/// <summary>
		/// 主键
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 执行标准主键
		/// </summary>
		public string C_STD_ID
		{
			set{ _c_std_id=value;}
			get{return _c_std_id;}
		}
		/// <summary>
		/// 客户技术协议号
		/// </summary>
		public string C_CUST_TECH_PROT
		{
			set{ _c_cust_tech_prot=value;}
			get{return _c_cust_tech_prot;}
		}
		/// <summary>
		/// 自由项1
		/// </summary>
		public string C_ZYX1
		{
			set{ _c_zyx1=value;}
			get{return _c_zyx1;}
		}
		/// <summary>
		/// 自由项2
		/// </summary>
		public string C_ZYX2
		{
			set{ _c_zyx2=value;}
			get{return _c_zyx2;}
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
		/// 执行标准
		/// </summary>
		public string C_STD_CODE
		{
			set{ _c_std_code=value;}
			get{return _c_std_code;}
		}
		/// <summary>
		/// 炼钢记号
		/// </summary>
		public string C_STEEL_SIGN
		{
			set{ _c_steel_sign=value;}
			get{return _c_steel_sign;}
		}
		/// <summary>
		/// 操作人
		/// </summary>
		public string C_EMP_ID
		{
			set{ _c_emp_id=value;}
			get{return _c_emp_id;}
		}
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime D_MOD_DT
		{
			set{ _d_mod_dt=value;}
			get{return _d_mod_dt;}
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
		/// 启用时间
		/// </summary>
		public DateTime D_START_DATE
		{
			set{ _d_start_date=value;}
			get{return _d_start_date;}
		}
		/// <summary>
		/// 停用时间
		/// </summary>
		public DateTime? D_END_DATE
		{
			set{ _d_end_date=value;}
			get{return _d_end_date;}
		}
		/// <summary>
		/// 状态0停用1启用
		/// </summary>
		public decimal N_STATUS
		{
			set{ _n_status=value;}
			get{return _n_status;}
		}
		#endregion Model

	}
}

