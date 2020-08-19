using System;
namespace NF.MODEL
{
	/// <summary>
	/// 物料主数据表
	/// </summary>
	[Serializable]
	public partial class Mod_TB_MATRL_MAIN
    {
		public Mod_TB_MATRL_MAIN()
		{}
		#region Model
		private string _c_id= "sys_guid";
		private string _c_mat_code;
		private string _c_mat_name;
		private string _c_mat_group_code;
		private string _c_mat_group_name;
		private string _c_prod_kind;
		private string _c_prod_name;
		private string _c_stl_grd;
		private string _c_spec;
		private string _c_emp_id="同步NC";
        private DateTime _d_mod_dt = DateTime.Now;
		private decimal? _n_thk;
		private decimal? _n_wth;
        private decimal? _n_lth = 0;
		private decimal? _c_mat_type;
		private decimal _c_is_visible=1;
		private string _c_cls_type="N";
		private string _c_remark1;
		private string _c_remark2;
		private string _c_remark3;
		private string _c_nc_pk;
		private string _c_pk_invcl;
		private string _c_pk_invbasdoc;
		private string _c_pk_invmandoc;
		private string _c_pk_produce;
		private string _c_pk_measdoc;
		private string _c_pk_taxitems;
		private string _c_invshortname;
		/// <summary>
		/// 主键
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 物料编码
		/// </summary>
		public string C_MAT_CODE
		{
			set{ _c_mat_code=value;}
			get{return _c_mat_code;}
		}
		/// <summary>
		/// 物料描述
		/// </summary>
		public string C_MAT_NAME
		{
			set{ _c_mat_name=value;}
			get{return _c_mat_name;}
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
		/// 钢种
		/// </summary>
		public string C_STL_GRD
		{
			set{ _c_stl_grd=value;}
			get{return _c_stl_grd;}
		}
		/// <summary>
		/// 规格/（NC）
		/// </summary>
		public string C_SPEC
		{
			set{ _c_spec=value;}
			get{return _c_spec;}
		}
		/// <summary>
		/// 修改人员
		/// </summary>
		public string C_EMP_ID
		{
			set{ _c_emp_id=value;}
			get{return _c_emp_id;}
		}
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime D_MOD_DT
		{
			set{ _d_mod_dt=value;}
			get{return _d_mod_dt;}
		}
		/// <summary>
		/// 厚度（直径）
		/// </summary>
		public decimal? N_THK
		{
			set{ _n_thk=value;}
			get{return _n_thk;}
		}
		/// <summary>
		/// 宽度
		/// </summary>
		public decimal? N_WTH
		{
			set{ _n_wth=value;}
			get{return _n_wth;}
		}
		/// <summary>
		/// 长度
		/// </summary>
		public decimal? N_LTH
		{
			set{ _n_lth=value;}
			get{return _n_lth;}
		}
		/// <summary>
		/// 物料状态(1外购坯6钢坯8线材)
		/// </summary>
		public decimal? C_MAT_TYPE
		{
			set{ _c_mat_type=value;}
			get{return _c_mat_type;}
		}
		/// <summary>
		/// 是否显示 0 不显示 1 显示 默认 1
		/// </summary>
		public decimal C_IS_VISIBLE
		{
			set{ _c_is_visible=value;}
			get{return _c_is_visible;}
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
		/// NC主键
		/// </summary>
		public string C_NC_PK
		{
			set{ _c_nc_pk=value;}
			get{return _c_nc_pk;}
		}
		/// <summary>
		/// 存货分类主键
		/// </summary>
		public string C_PK_INVCL
		{
			set{ _c_pk_invcl=value;}
			get{return _c_pk_invcl;}
		}
		/// <summary>
		/// 存货档案主键
		/// </summary>
		public string C_PK_INVBASDOC
		{
			set{ _c_pk_invbasdoc=value;}
			get{return _c_pk_invbasdoc;}
		}
		/// <summary>
		/// 存货管理档案主键
		/// </summary>
		public string C_PK_INVMANDOC
		{
			set{ _c_pk_invmandoc=value;}
			get{return _c_pk_invmandoc;}
		}
		/// <summary>
		/// 存货管理档案生产页主键
		/// </summary>
		public string C_PK_PRODUCE
		{
			set{ _c_pk_produce=value;}
			get{return _c_pk_produce;}
		}
		/// <summary>
		/// 主计量单位
		/// </summary>
		public string C_PK_MEASDOC
		{
			set{ _c_pk_measdoc=value;}
			get{return _c_pk_measdoc;}
		}
		/// <summary>
		/// 税目税率主键
		/// </summary>
		public string C_PK_TAXITEMS
		{
			set{ _c_pk_taxitems=value;}
			get{return _c_pk_taxitems;}
		}
		/// <summary>
		/// 存货简称
		/// </summary>
		public string C_INVSHORTNAME
		{
			set{ _c_invshortname=value;}
			get{return _c_invshortname;}
		}
		#endregion Model

	}
}

