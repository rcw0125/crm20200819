using System;
namespace NF.MODEL
{
	/// <summary>
	/// 轧钢实绩
	/// </summary>
	[Serializable]
	public partial class Mod_TRC_ROLL_PRODCUT
    {
		public Mod_TRC_ROLL_PRODCUT()
		{}
		#region Model
		private string _c_id=Guid.NewGuid().ToString ();
		private string _c_trc_roll_main_id;
		private string _c_stove;
		private string _c_batch_no;
		private string _c_tick_no;
		private string _c_stl_grd;
		private string _c_stl_grd_before;
		private decimal _n_wgt=0;
		private string _c_std_code;
		private string _c_std_code_before;
		private string _c_move_type="N";
		private string _c_spec;
		private string _c_shift;
		private string _c_group;
		private string _c_emp_id;
		private DateTime _d_mod_dt= Convert.ToDateTime(DateTime.Now);
		private string _c_sta_id;
		private string _c_judge_lev_bp;
		private string _c_judge_lev_cf;
		private string _c_judge_lev_xn;
		private string _c_judge_lev_zh;
		private string _c_dp_shift;
		private string _c_dp_group;
		private string _c_dp_emp_id;
		private DateTime? _d_dp_dt;
		private string _c_plant_id;
		private string _c_plant_desc;
		private string _c_mat_code;
		private string _c_mat_code_before;
		private string _c_mat_desc;
		private string _c_mat_desc_before;
		private string _c_is_depot="N";
		private string _c_plan_id;
		private string _c_order_no;
		private string _c_con_no;
		private string _c_cust_no;
		private string _c_cust_name;
		private string _c_isfree="N";
		private string _c_linewh_code;
		private string _c_linewh_area_code;
		private string _c_linewh_loc_code;
		private string _c_floor;
		private string _c_cust_area;
		private string _c_sale_area;
		/// <summary>
		/// 主键
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 组批表主键
		/// </summary>
		public string C_TRC_ROLL_MAIN_ID
		{
			set{ _c_trc_roll_main_id=value;}
			get{return _c_trc_roll_main_id;}
		}
		/// <summary>
		/// 炉号
		/// </summary>
		public string C_STOVE
		{
			set{ _c_stove=value;}
			get{return _c_stove;}
		}
		/// <summary>
		/// 批号
		/// </summary>
		public string C_BATCH_NO
		{
			set{ _c_batch_no=value;}
			get{return _c_batch_no;}
		}
		/// <summary>
		/// 钩号
		/// </summary>
		public string C_TICK_NO
		{
			set{ _c_tick_no=value;}
			get{return _c_tick_no;}
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
		/// 改判前钢种
		/// </summary>
		public string C_STL_GRD_BEFORE
		{
			set{ _c_stl_grd_before=value;}
			get{return _c_stl_grd_before;}
		}
		/// <summary>
		/// 打牌重量
		/// </summary>
		public decimal N_WGT
		{
			set{ _n_wgt=value;}
			get{return _n_wgt;}
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
		/// 改判前标准
		/// </summary>
		public string C_STD_CODE_BEFORE
		{
			set{ _c_std_code_before=value;}
			get{return _c_std_code_before;}
		}
		/// <summary>
		/// 库存状态  'N'未综判 'E'已入库 ,'S'已销售,'O'已占用,Z转库
		/// </summary>
		public string C_MOVE_TYPE
		{
			set{ _c_move_type=value;}
			get{return _c_move_type;}
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
		/// 班次
		/// </summary>
		public string C_SHIFT
		{
			set{ _c_shift=value;}
			get{return _c_shift;}
		}
		/// <summary>
		/// 班组
		/// </summary>
		public string C_GROUP
		{
			set{ _c_group=value;}
			get{return _c_group;}
		}
		/// <summary>
		/// 实绩操作人
		/// </summary>
		public string C_EMP_ID
		{
			set{ _c_emp_id=value;}
			get{return _c_emp_id;}
		}
		/// <summary>
		/// 系统操作时间
		/// </summary>
		public DateTime D_MOD_DT
		{
			set{ _d_mod_dt=value;}
			get{return _d_mod_dt;}
		}
		/// <summary>
		/// 生产工位（外键）
		/// </summary>
		public string C_STA_ID
		{
			set{ _c_sta_id=value;}
			get{return _c_sta_id;}
		}
		/// <summary>
		/// 表判等级
		/// </summary>
		public string C_JUDGE_LEV_BP
		{
			set{ _c_judge_lev_bp=value;}
			get{return _c_judge_lev_bp;}
		}
		/// <summary>
		/// 成分等级
		/// </summary>
		public string C_JUDGE_LEV_CF
		{
			set{ _c_judge_lev_cf=value;}
			get{return _c_judge_lev_cf;}
		}
		/// <summary>
		/// 性能等级
		/// </summary>
		public string C_JUDGE_LEV_XN
		{
			set{ _c_judge_lev_xn=value;}
			get{return _c_judge_lev_xn;}
		}
		/// <summary>
		/// 综合判定等级
		/// </summary>
		public string C_JUDGE_LEV_ZH
		{
			set{ _c_judge_lev_zh=value;}
			get{return _c_judge_lev_zh;}
		}
		/// <summary>
		/// 打牌班次
		/// </summary>
		public string C_DP_SHIFT
		{
			set{ _c_dp_shift=value;}
			get{return _c_dp_shift;}
		}
		/// <summary>
		/// 打牌班组
		/// </summary>
		public string C_DP_GROUP
		{
			set{ _c_dp_group=value;}
			get{return _c_dp_group;}
		}
		/// <summary>
		/// 打牌操作人
		/// </summary>
		public string C_DP_EMP_ID
		{
			set{ _c_dp_emp_id=value;}
			get{return _c_dp_emp_id;}
		}
		/// <summary>
		/// 打牌时间
		/// </summary>
		public DateTime? D_DP_DT
		{
			set{ _d_dp_dt=value;}
			get{return _d_dp_dt;}
		}
		/// <summary>
		/// 工厂ID
		/// </summary>
		public string C_PLANT_ID
		{
			set{ _c_plant_id=value;}
			get{return _c_plant_id;}
		}
		/// <summary>
		/// 工厂描述
		/// </summary>
		public string C_PLANT_DESC
		{
			set{ _c_plant_desc=value;}
			get{return _c_plant_desc;}
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
		/// 改判前物料编码
		/// </summary>
		public string C_MAT_CODE_BEFORE
		{
			set{ _c_mat_code_before=value;}
			get{return _c_mat_code_before;}
		}
		/// <summary>
		/// 物料描述
		/// </summary>
		public string C_MAT_DESC
		{
			set{ _c_mat_desc=value;}
			get{return _c_mat_desc;}
		}
		/// <summary>
		/// 改判前物料描述
		/// </summary>
		public string C_MAT_DESC_BEFORE
		{
			set{ _c_mat_desc_before=value;}
			get{return _c_mat_desc_before;}
		}
		/// <summary>
		/// 库检状态 N:未处理，Y:已库检
		/// </summary>
		public string C_IS_DEPOT
		{
			set{ _c_is_depot=value;}
			get{return _c_is_depot;}
		}
		/// <summary>
		/// 计划号
		/// </summary>
		public string C_PLAN_ID
		{
			set{ _c_plan_id=value;}
			get{return _c_plan_id;}
		}
		/// <summary>
		/// 订单号
		/// </summary>
		public string C_ORDER_NO
		{
			set{ _c_order_no=value;}
			get{return _c_order_no;}
		}
		/// <summary>
		/// 合同号
		/// </summary>
		public string C_CON_NO
		{
			set{ _c_con_no=value;}
			get{return _c_con_no;}
		}
		/// <summary>
		/// 客户编码
		/// </summary>
		public string C_CUST_NO
		{
			set{ _c_cust_no=value;}
			get{return _c_cust_no;}
		}
		/// <summary>
		/// 客户名称
		/// </summary>
		public string C_CUST_NAME
		{
			set{ _c_cust_name=value;}
			get{return _c_cust_name;}
		}
		/// <summary>
		/// 是否自由状态货
		/// </summary>
		public string C_ISFREE
		{
			set{ _c_isfree=value;}
			get{return _c_isfree;}
		}
		/// <summary>
		/// 线材仓库编码
		/// </summary>
		public string C_LINEWH_CODE
		{
			set{ _c_linewh_code=value;}
			get{return _c_linewh_code;}
		}
		/// <summary>
		/// 线材区域编码
		/// </summary>
		public string C_LINEWH_AREA_CODE
		{
			set{ _c_linewh_area_code=value;}
			get{return _c_linewh_area_code;}
		}
		/// <summary>
		/// 库位编号
		/// </summary>
		public string C_LINEWH_LOC_CODE
		{
			set{ _c_linewh_loc_code=value;}
			get{return _c_linewh_loc_code;}
		}
		/// <summary>
		/// 层
		/// </summary>
		public string C_FLOOR
		{
			set{ _c_floor=value;}
			get{return _c_floor;}
		}
		/// <summary>
		/// 客户区域
		/// </summary>
		public string C_CUST_AREA
		{
			set{ _c_cust_area=value;}
			get{return _c_cust_area;}
		}
		/// <summary>
		/// 销售区域
		/// </summary>
		public string C_SALE_AREA
		{
			set{ _c_sale_area=value;}
			get{return _c_sale_area;}
		}

        public string C_BZYQ { get; set; }
        public string C_WWBATCH_NO { get; set; }
        public string C_ZYX1 { get; set; }
        public string C_ZYX2 { get; set; }
        #endregion Model

    }
}

