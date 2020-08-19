using System;
namespace NF.MODEL
{
	/// <summary>
	/// 包装要求维护
	/// </summary>
	[Serializable]
	public partial class Mod_TQB_PACK
    {
		public Mod_TQB_PACK()
		{}
        #region Model
        private string _c_id = Guid.NewGuid().ToString();
		private string _c_pack_type_code;
		private string _c_pack_type_name;
		private string _c_pack_desc;
		private decimal _n_status=1;
		private string _c_remark;
		private string _c_emp_id;
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
		/// 包装类型代码
		/// </summary>
		public string C_PACK_TYPE_CODE
		{
			set{ _c_pack_type_code=value;}
			get{return _c_pack_type_code;}
		}
		/// <summary>
		/// 包装类型名称
		/// </summary>
		public string C_PACK_TYPE_NAME
		{
			set{ _c_pack_type_name=value;}
			get{return _c_pack_type_name;}
		}
		/// <summary>
		/// 包装方式说明
		/// </summary>
		public string C_PACK_DESC
		{
			set{ _c_pack_desc=value;}
			get{return _c_pack_desc;}
		}
		/// <summary>
		/// 使用状态   1-可用；0-停用
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
		#endregion Model

	}
}

