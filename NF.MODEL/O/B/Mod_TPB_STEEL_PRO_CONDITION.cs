using System;
namespace NF.MODEL
{
	/// <summary>
	/// 钢种生成条件主表
	/// </summary>
	[Serializable]
	public partial class Mod_TPB_STEEL_PRO_CONDITION
    {
		public Mod_TPB_STEEL_PRO_CONDITION()
		{}
		#region Model
		private string _c_id;
		private string _c_stl_grd_type;
		private string _c_stl_grd_rank;
		private string _c_stl_grd;
		private string _c_std_code;
		private string _c_stl_scrap_type;
		private string _c_stl_scrap_flij;
		private string _c_goute;
		private string _c_tease_person;
		private string _c_adv_pro_require;
		private decimal _n_status=1 ;
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
		/// 钢种类别
		/// </summary>
		public string C_STL_GRD_TYPE
		{
			set{ _c_stl_grd_type=value;}
			get{return _c_stl_grd_type;}
		}
		/// <summary>
		/// 钢种级别
		/// </summary>
		public string C_STL_GRD_RANK
		{
			set{ _c_stl_grd_rank=value;}
			get{return _c_stl_grd_rank;}
		}
		/// <summary>
		/// 计划钢种
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
		/// 产生废钢分类
		/// </summary>
		public string C_STL_SCRAP_TYPE
		{
			set{ _c_stl_scrap_type=value;}
			get{return _c_stl_scrap_type;}
		}
		/// <summary>
		/// 废钢分类标识号
		/// </summary>
		public string C_STL_SCRAP_FLIJ
		{
			set{ _c_stl_scrap_flij=value;}
			get{return _c_stl_scrap_flij;}
		}
		/// <summary>
		/// 三次冷却工艺要求
		/// </summary>
		public string C_GOUTE
		{
			set{ _c_goute=value;}
			get{return _c_goute;}
		}
		/// <summary>
		/// 梳理人
		/// </summary>
		public string C_TEASE_PERSON
		{
			set{ _c_tease_person=value;}
			get{return _c_tease_person;}
		}
		/// <summary>
		/// 特、高级产品用钢坯生产和改判要求
		/// </summary>
		public string C_ADV_PRO_REQUIRE
		{
			set{ _c_adv_pro_require=value;}
			get{return _c_adv_pro_require;}
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
		/// 操作人员
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
		#endregion Model

	}
}

