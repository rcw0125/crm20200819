using System;
namespace NF.MODEL
{
	/// <summary>
	/// 订单质量设计信息
	/// </summary>
	[Serializable]
	public partial class Mod_TQB_DESIGN_ORDER
	{
		public Mod_TQB_DESIGN_ORDER()
		{}
		#region Model
		private string _c_id;
		private string _c_order_id;
		private string _c_design_id;
		private string _c_delivery_state;
		private decimal _n_status=1;
		private string _c_remark;
		private string _c_emp_id;
		private DateTime _d_mod_dt= Convert.ToDateTime(DateTime.Now);
		private string _c_emp_id_bg;
		private DateTime? _d_mod_dt_bg;
		private string _c_emp_id_sh;
		private DateTime? _d_mod_dt_sh;
		/// <summary>
		/// 主键
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 合同明细表主键
		/// </summary>
		public string C_ORDER_ID
		{
			set{ _c_order_id=value;}
			get{return _c_order_id;}
		}
		/// <summary>
		/// 质量设计表主键
		/// </summary>
		public string C_DESIGN_ID
		{
			set{ _c_design_id=value;}
			get{return _c_design_id;}
		}
		/// <summary>
		/// 交货状态
		/// </summary>
		public string C_DELIVERY_STATE
		{
			set{ _c_delivery_state=value;}
			get{return _c_delivery_state;}
		}
		/// <summary>
		/// 使用状态   1-可用；0-停用；2-审核中
		/// </summary>
		public decimal N_STATUS
		{
			set{ _n_status=value;}
			get{return _n_status;}
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
		/// <summary>
		/// 变更人
		/// </summary>
		public string C_EMP_ID_BG
		{
			set{ _c_emp_id_bg=value;}
			get{return _c_emp_id_bg;}
		}
		/// <summary>
		/// 变更时间
		/// </summary>
		public DateTime? D_MOD_DT_BG
		{
			set{ _d_mod_dt_bg=value;}
			get{return _d_mod_dt_bg;}
		}
		/// <summary>
		/// 审核人
		/// </summary>
		public string C_EMP_ID_SH
		{
			set{ _c_emp_id_sh=value;}
			get{return _c_emp_id_sh;}
		}
		/// <summary>
		/// 审核时间
		/// </summary>
		public DateTime? D_MOD_DT_SH
		{
			set{ _d_mod_dt_sh=value;}
			get{return _d_mod_dt_sh;}
		}
		#endregion Model

	}
}

