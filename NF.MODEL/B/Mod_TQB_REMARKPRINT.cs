using System;
namespace NF.MODEL
{
	/// <summary>
	/// 质量设计主表信息
	/// </summary>
	[Serializable]
	public partial class Mod_TQB_REMARKPRINT
    {
		public Mod_TQB_REMARKPRINT()
		{}
		#region Model
		private string _c_id;
		private string _c_key;
		private string _c_value;
		private decimal _n_status=1;
		private string _c_emp_id;
        private decimal? _n_type ;
        private DateTime _d_mod_dt= Convert.ToDateTime(DateTime.Now);
		/// <summary>
		/// 主键
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 质量设计号
		/// </summary>
		public string C_KEY
        {
			set{ _c_key=value;}
			get{return _c_key; }
		}
		/// <summary>
		/// 执行标准主键
		/// </summary>
		public string C_VALUE
        {
			set{ _c_value=value;}
			get{return _c_value; }
		}
		/// <summary>
		/// 使用状态   1-可用；0-停用
		/// </summary>
		public decimal N_STATUS
		{
			set{ _n_status=value;}
			get{return _n_status;}
		}
	    public decimal? N_TYPE
        {
            set { _n_type = value; }
            get { return _n_type; }
        }
		/// <summary>
		/// 维护人
		/// </summary>
		public string C_EMP_ID
		{
			set{ _c_emp_id=value;}
			get{return _c_emp_id;}
		}
		/// <summary>
		/// 维护时间
		/// </summary>
		public DateTime D_MOD_DT
		{
			set{ _d_mod_dt=value;}
			get{return _d_mod_dt;}
		}
		#endregion Model

	}
}

