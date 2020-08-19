using System;
namespace NF.MODEL
{
	/// <summary>
	/// 物料分类表
	/// </summary>
	[Serializable]
	public partial class Mod_TB_MATRL_GROUP
	{
		public Mod_TB_MATRL_GROUP()
		{}
		#region Model
		private string _c_id;
		private string _c_mat_group_code;
		private string _c_mat_group_name;
		private string _c_prod_kind;
		private string _c_prod_name;
		private string _c_emp_id;
		private DateTime _d_mod_dt;
		private string _c_mat_type;
		private string _c_cls_type;
		private string _c_remark1;
		private string _c_remark2;
		private string _c_remark3;
		private decimal? _n_lev;
		/// <summary>
		/// 主键
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 物料组编码
		/// </summary>
		public string C_MAT_GROUP_CODE
		{
			set{ _c_mat_group_code=value;}
			get{return _c_mat_group_code;}
		}
		/// <summary>
		/// 物料组描述
		/// </summary>
		public string C_MAT_GROUP_NAME
		{
			set{ _c_mat_group_name=value;}
			get{return _c_mat_group_name;}
		}
		/// <summary>
		/// 品种
		/// </summary>
		public string C_PROD_KIND
		{
			set{ _c_prod_kind=value;}
			get{return _c_prod_kind;}
		}
		/// <summary>
		/// 品名
		/// </summary>
		public string C_PROD_NAME
		{
			set{ _c_prod_name=value;}
			get{return _c_prod_name;}
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
		/// 物料状态(1外购坯6钢坯8线材)
		/// </summary>
		public string C_MAT_TYPE
		{
			set{ _c_mat_type=value;}
			get{return _c_mat_type;}
		}
		/// <summary>
		/// 停用标识
		/// </summary>
		public string C_CLS_TYPE
		{
			set{ _c_cls_type=value;}
			get{return _c_cls_type;}
		}
		/// <summary>
		/// 备注1
		/// </summary>
		public string C_REMARK1
		{
			set{ _c_remark1=value;}
			get{return _c_remark1;}
		}
		/// <summary>
		/// 备注2
		/// </summary>
		public string C_REMARK2
		{
			set{ _c_remark2=value;}
			get{return _c_remark2;}
		}
		/// <summary>
		/// 备注3
		/// </summary>
		public string C_REMARK3
		{
			set{ _c_remark3=value;}
			get{return _c_remark3;}
		}
		/// <summary>
		/// 深度
		/// </summary>
		public decimal? N_LEV
		{
			set{ _n_lev=value;}
			get{return _n_lev;}
		}
		#endregion Model

	}
}

