using System;
namespace NF.MODEL
{
	/// <summary>
	/// 资源申请数据列表
	/// </summary>
	[Serializable]
	public partial class Mod_TMC_ROLL_APPLY_ITEM
    {
		public Mod_TMC_ROLL_APPLY_ITEM()
		{}
		#region Model
		private string _c_id;
		private string _c_pkid;
		private string _c_needarea;
		private string _c_needcust;
		private string _c_zyarea;
		private string _c_zycust;
		private string _c_zycon;
		private string _c_spec;
		private string _c_stl_grd;
		private decimal _c_wgt;
		private string _c_qua;
		private string _c_remark;
		private string _c_vfree1;
		private string _c_vfree2;
		private string _c_vfree3;
		private string _c_vfree4;
		private string _c_vfree5;
		private DateTime? _d_mod;
		/// <summary>
		/// 主键
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 表头主键
		/// </summary>
		public string C_PKID
		{
			set{ _c_pkid=value;}
			get{return _c_pkid;}
		}
		/// <summary>
		/// 需求区域
		/// </summary>
		public string C_NEEDAREA
		{
			set{ _c_needarea=value;}
			get{return _c_needarea;}
		}
		/// <summary>
		/// 需求客户
		/// </summary>
		public string C_NEEDCUST
		{
			set{ _c_needcust=value;}
			get{return _c_needcust;}
		}
		/// <summary>
		/// 资源所属区域
		/// </summary>
		public string C_ZYAREA
		{
			set{ _c_zyarea=value;}
			get{return _c_zyarea;}
		}
		/// <summary>
		/// 资源所属客户
		/// </summary>
		public string C_ZYCUST
		{
			set{ _c_zycust=value;}
			get{return _c_zycust;}
		}
        /// <summary>
		/// 资源所属合同
		/// </summary>
		public string C_ZYCON
        {
            set { _c_zycon = value; }
            get { return _c_zycon; }
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
		/// 钢种
		/// </summary>
		public string C_STL_GRD
		{
			set{ _c_stl_grd=value;}
			get{return _c_stl_grd;}
		}
		/// <summary>
		/// 需求吨数
		/// </summary>
		public decimal C_WGT
		{
			set{ _c_wgt=value;}
			get{return _c_wgt;}
		}
		/// <summary>
		/// 需求合同
		/// </summary>
		public string C_QUA
		{
			set{ _c_qua=value;}
			get{return _c_qua;}
		}
		/// <summary>
		/// 说明
		/// </summary>
		public string C_REMARK
		{
			set{ _c_remark=value;}
			get{return _c_remark;}
		}
		/// <summary>
		/// 自由字段1
		/// </summary>
		public string C_VFREE1
		{
			set{ _c_vfree1=value;}
			get{return _c_vfree1;}
		}
		/// <summary>
		/// 自由字段2
		/// </summary>
		public string C_VFREE2
		{
			set{ _c_vfree2=value;}
			get{return _c_vfree2;}
		}
		/// <summary>
		/// 自由字段3
		/// </summary>
		public string C_VFREE3
		{
			set{ _c_vfree3=value;}
			get{return _c_vfree3;}
		}
		/// <summary>
		/// 自由字段4
		/// </summary>
		public string C_VFREE4
		{
			set{ _c_vfree4=value;}
			get{return _c_vfree4;}
		}
		/// <summary>
		/// 自由字段5
		/// </summary>
		public string C_VFREE5
		{
			set{ _c_vfree5=value;}
			get{return _c_vfree5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? D_MOD
		{
			set{ _d_mod=value;}
			get{return _d_mod;}
		}
		#endregion Model

	}
}

