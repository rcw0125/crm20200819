using System;
namespace NF.MODEL
{
	/// <summary>
	/// 测量档案
	/// </summary>
	[Serializable]
	public partial class Mod_TMB_MEAS
    {
		public Mod_TMB_MEAS()
		{}
        #region Model
        private string _c_id = Guid.NewGuid().ToString();
		private string _c_type;
		private string _c_name;
		private decimal? _n_scalef_actor;
		private decimal? _c_status=1;
		private string _c_remark;
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
		/// 量纲
		/// </summary>
		public string C_TYPE
		{
			set{ _c_type=value;}
			get{return _c_type;}
		}
		/// <summary>
		/// 计量单位
		/// </summary>
		public string C_NAME
		{
			set{ _c_name=value;}
			get{return _c_name;}
		}
		/// <summary>
		/// 换算比例
		/// </summary>
		public decimal? N_SCALEF_ACTOR
		{
			set{ _n_scalef_actor=value;}
			get{return _n_scalef_actor;}
		}
		/// <summary>
		/// 状态：0停用  1启用
		/// </summary>
		public decimal? C_STATUS
		{
			set{ _c_status=value;}
			get{return _c_status;}
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
		/// 操作人ID
		/// </summary>
		public string C_EMP_ID
		{
			set{ _c_emp_id=value;}
			get{return _c_emp_id;}
		}
		/// <summary>
		/// 操作人
		/// </summary>
		public string C_EMP_NAME
		{
			set{ _c_emp_name=value;}
			get{return _c_emp_name;}
		}
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime? D_MOD_DT
		{
			set{ _d_mod_dt=value;}
			get{return _d_mod_dt;}
		}
		#endregion Model

	}
}

