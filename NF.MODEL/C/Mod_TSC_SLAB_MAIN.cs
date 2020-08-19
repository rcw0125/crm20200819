using System;
namespace NF.MODEL
{
	/// <summary>
	/// 坯料主表
	/// </summary>
	[Serializable]
	public partial class Mod_TSC_SLAB_MAIN
    {
		public Mod_TSC_SLAB_MAIN()
		{}
		#region Model
		private string _c_id= Guid.NewGuid().ToString ();
		private string _c_plan_id;
		private string _c_ord_no;
		private string _c_stove;
		private string _c_sta_id;
		private string _c_sta_code;
		private string _c_sta_desc;
		private string _c_stl_grd;
		private string _c_stl_grd_pre;
		private string _c_mat_code;
		private string _c_mat_name;
		private string _c_spec;
		private decimal _n_len;
		private decimal _n_qua=1;
		private decimal _n_wgt;
		private string _c_std_code;
		private string _c_slab_type="R";
		private DateTime? _d_ccm_date;
		private string _c_ccm_shift;
		private string _c_ccm_group;
		private string _c_ccm_emp_id;
		private string _c_move_type="N";
		private string _c_sc_state="N";
		private DateTime? _d_esc_date;
		private DateTime? _d_lsc_date;
		private string _c_qkp_state="N";
		private string _c_kp_id;
		private string _c_con_no;
		private string _c_cus_no;
		private string _c_cus_name;
		private DateTime? _d_wl_date;
		private string _c_wl_shift;
		private string _c_wl_group;
		private string _c_wl_emp_id;
		private DateTime? _d_we_date;
		private string _c_we_shift;
		private string _c_we_group;
		private string _c_we_emp_id;
		private string _c_stock_state="W";
		private string _c_mat_type="1";
		private string _c_qgp_state="N";
		private string _c_slabwh_code;
		private string _c_slabwh_area_code;
		private string _c_slabwh_loc_code;
		private string _c_slabwh_tier_code;
		private string _c_q_result="0";
		private DateTime? _d_q_date;
		private string _c_q_note;
		private decimal? _n_wgt_meter;
		private string _c_qf_name;
		private string _c_design_no;
		private string _c_zrbm;
		private string _c_is_depot="0";
		private string _c_isxm="N";
		private string _c_xmgx;
		private string _c_isfree="N";

        private decimal? _n_jz;
        private string _c_fydh;

        /// <summary>
        /// 净重
        /// </summary>
        public decimal? N_JZ
        {
            set { _n_jz = value; }
            get { return _n_jz; }
        }
        /// <summary>
        /// 发运单号
        /// </summary>
        public string C_FYDH
        {
            set { _c_fydh = value; }
            get { return _c_fydh; }
        }


        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 计划ID
		/// </summary>
		public string C_PLAN_ID
		{
			set{ _c_plan_id=value;}
			get{return _c_plan_id;}
		}
		/// <summary>
		/// 订单号
		/// </summary>
		public string C_ORD_NO
		{
			set{ _c_ord_no=value;}
			get{return _c_ord_no;}
		}
		/// <summary>
		/// 1炉号
		/// </summary>
		public string C_STOVE
		{
			set{ _c_stove=value;}
			get{return _c_stove;}
		}
		/// <summary>
		/// 1铸机号 
		/// </summary>
		public string C_STA_ID
		{
			set{ _c_sta_id=value;}
			get{return _c_sta_id;}
		}
		/// <summary>
		/// 铸机编码
		/// </summary>
		public string C_STA_CODE
		{
			set{ _c_sta_code=value;}
			get{return _c_sta_code;}
		}
		/// <summary>
		/// 铸机描述
		/// </summary>
		public string C_STA_DESC
		{
			set{ _c_sta_desc=value;}
			get{return _c_sta_desc;}
		}
		/// <summary>
		/// 1钢种
		/// </summary>
		public string C_STL_GRD
		{
			set{ _c_stl_grd=value;}
			get{return _c_stl_grd;}
		}
		/// <summary>
		/// 改判前钢种
		/// </summary>
		public string C_STL_GRD_PRE
		{
			set{ _c_stl_grd_pre=value;}
			get{return _c_stl_grd_pre;}
		}
		/// <summary>
		/// 1物料编码 
		/// </summary>
		public string C_MAT_CODE
		{
			set{ _c_mat_code=value;}
			get{return _c_mat_code;}
		}
		/// <summary>
		/// 1物料名称
		/// </summary>
		public string C_MAT_NAME
		{
			set{ _c_mat_name=value;}
			get{return _c_mat_name;}
		}
		/// <summary>
		/// 1规格 
		/// </summary>
		public string C_SPEC
		{
			set{ _c_spec=value;}
			get{return _c_spec;}
		}
		/// <summary>
		/// 1长度
		/// </summary>
		public decimal N_LEN
		{
			set{ _n_len=value;}
			get{return _n_len;}
		}
		/// <summary>
		/// 1支数
		/// </summary>
		public decimal N_QUA
		{
			set{ _n_qua=value;}
			get{return _n_qua;}
		}
		/// <summary>
		/// 1单重
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
		/// 自备坯R,销售坯S
		/// </summary>
		public string C_SLAB_TYPE
		{
			set{ _c_slab_type=value;}
			get{return _c_slab_type;}
		}
		/// <summary>
		/// 连铸收料时间
		/// </summary>
		public DateTime? D_CCM_DATE
		{
			set{ _d_ccm_date=value;}
			get{return _d_ccm_date;}
		}
		/// <summary>
		/// 连铸收料班次
		/// </summary>
		public string C_CCM_SHIFT
		{
			set{ _c_ccm_shift=value;}
			get{return _c_ccm_shift;}
		}
		/// <summary>
		/// 连铸收料班组
		/// </summary>
		public string C_CCM_GROUP
		{
			set{ _c_ccm_group=value;}
			get{return _c_ccm_group;}
		}
		/// <summary>
		/// 连铸收料员工号
		/// </summary>
		public string C_CCM_EMP_ID
		{
			set{ _c_ccm_emp_id=value;}
			get{return _c_ccm_emp_id;}
		}
		/// <summary>
		/// N炼钢接收待入库CN剔除坯待入库CE剔除坯入库MN修磨待入库ME修磨入库PN开坯待入库PE开坯入库STN销售退坯待入库STE销售退坯入库D调拨DE调拨入库NZ待轧NP待开坯NM待修磨S销售
		/// </summary>
		public string C_MOVE_TYPE
		{
			set{ _c_move_type=value;}
			get{return _c_move_type;}
		}
		/// <summary>
		/// 入出缓冷坑 N 未如坑 E在坑内，H已缓冷
		/// </summary>
		public string C_SC_STATE
		{
			set{ _c_sc_state=value;}
			get{return _c_sc_state;}
		}
		/// <summary>
		/// 入坑时间
		/// </summary>
		public DateTime? D_ESC_DATE
		{
			set{ _d_esc_date=value;}
			get{return _d_esc_date;}
		}
		/// <summary>
		/// 出坑时间
		/// </summary>
		public DateTime? D_LSC_DATE
		{
			set{ _d_lsc_date=value;}
			get{return _d_lsc_date;}
		}
		/// <summary>
		/// 是否开坯Y 
		/// </summary>
		public string C_QKP_STATE
		{
			set{ _c_qkp_state=value;}
			get{return _c_qkp_state;}
		}
		/// <summary>
		/// 开坯前坯料主键
		/// </summary>
		public string C_KP_ID
		{
			set{ _c_kp_id=value;}
			get{return _c_kp_id;}
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
		/// 客户代码
		/// </summary>
		public string C_CUS_NO
		{
			set{ _c_cus_no=value;}
			get{return _c_cus_no;}
		}
		/// <summary>
		/// 客户名称
		/// </summary>
		public string C_CUS_NAME
		{
			set{ _c_cus_name=value;}
			get{return _c_cus_name;}
		}
		/// <summary>
		/// 出库时间
		/// </summary>
		public DateTime? D_WL_DATE
		{
			set{ _d_wl_date=value;}
			get{return _d_wl_date;}
		}
		/// <summary>
		/// 出库班次
		/// </summary>
		public string C_WL_SHIFT
		{
			set{ _c_wl_shift=value;}
			get{return _c_wl_shift;}
		}
		/// <summary>
		/// 出库班组
		/// </summary>
		public string C_WL_GROUP
		{
			set{ _c_wl_group=value;}
			get{return _c_wl_group;}
		}
		/// <summary>
		/// 出库员工号
		/// </summary>
		public string C_WL_EMP_ID
		{
			set{ _c_wl_emp_id=value;}
			get{return _c_wl_emp_id;}
		}
		/// <summary>
		/// 1入库时间
		/// </summary>
		public DateTime? D_WE_DATE
		{
			set{ _d_we_date=value;}
			get{return _d_we_date;}
		}
		/// <summary>
		/// 入库班次
		/// </summary>
		public string C_WE_SHIFT
		{
			set{ _c_we_shift=value;}
			get{return _c_we_shift;}
		}
		/// <summary>
		/// 入库班组
		/// </summary>
		public string C_WE_GROUP
		{
			set{ _c_we_group=value;}
			get{return _c_we_group;}
		}
		/// <summary>
		/// 入库员工号
		/// </summary>
		public string C_WE_EMP_ID
		{
			set{ _c_we_emp_id=value;}
			get{return _c_we_emp_id;}
		}
		/// <summary>
		/// 1库存状态 W:待判/F：已判定
		/// </summary>
		public string C_STOCK_STATE
		{
			set{ _c_stock_state=value;}
			get{return _c_stock_state;}
		}
		/// <summary>
		/// 1判定等级:合格品/协议品/待判/不合格品
		/// </summary>
		public string C_MAT_TYPE
		{
			set{ _c_mat_type=value;}
			get{return _c_mat_type;}
		}
		/// <summary>
		/// 是否改判Y 
		/// </summary>
		public string C_QGP_STATE
		{
			set{ _c_qgp_state=value;}
			get{return _c_qgp_state;}
		}
		/// <summary>
		/// 钢坯仓库编码
		/// </summary>
		public string C_SLABWH_CODE
		{
			set{ _c_slabwh_code=value;}
			get{return _c_slabwh_code;}
		}
		/// <summary>
		/// 钢坯库区域编码
		/// </summary>
		public string C_SLABWH_AREA_CODE
		{
			set{ _c_slabwh_area_code=value;}
			get{return _c_slabwh_area_code;}
		}
		/// <summary>
		/// 库位编号
		/// </summary>
		public string C_SLABWH_LOC_CODE
		{
			set{ _c_slabwh_loc_code=value;}
			get{return _c_slabwh_loc_code;}
		}
		/// <summary>
		/// 层编码
		/// </summary>
		public string C_SLABWH_TIER_CODE
		{
			set{ _c_slabwh_tier_code=value;}
			get{return _c_slabwh_tier_code;}
		}
		/// <summary>
		/// 确认1  综合判定结果
		/// </summary>
		public string C_Q_RESULT
		{
			set{ _c_q_result=value;}
			get{return _c_q_result;}
		}
		/// <summary>
		/// 判定时间 ((综判）
		/// </summary>
		public DateTime? D_Q_DATE
		{
			set{ _d_q_date=value;}
			get{return _d_q_date;}
		}
		/// <summary>
		/// 判废原因(综判）
		/// </summary>
		public string C_Q_NOTE
		{
			set{ _c_q_note=value;}
			get{return _c_q_note;}
		}
		/// <summary>
		/// 米单重
		/// </summary>
		public decimal? N_WGT_METER
		{
			set{ _n_wgt_meter=value;}
			get{return _n_wgt_meter;}
		}
		/// <summary>
		/// 表面判定人
		/// </summary>
		public string C_QF_NAME
		{
			set{ _c_qf_name=value;}
			get{return _c_qf_name;}
		}
		/// <summary>
		/// 质量设计号
		/// </summary>
		public string C_DESIGN_NO
		{
			set{ _c_design_no=value;}
			get{return _c_design_no;}
		}
		/// <summary>
		/// 1责任部门
		/// </summary>
		public string C_ZRBM
		{
			set{ _c_zrbm=value;}
			get{return _c_zrbm;}
		}
		/// <summary>
		/// 1是否库检 0：是 1：否
		/// </summary>
		public string C_IS_DEPOT
		{
			set{ _c_is_depot=value;}
			get{return _c_is_depot;}
		}
		/// <summary>
		/// 是否修磨
		/// </summary>
		public string C_ISXM
		{
			set{ _c_isxm=value;}
			get{return _c_isxm;}
		}
		/// <summary>
		/// 修磨工序，修磨>扒皮
		/// </summary>
		public string C_XMGX
		{
			set{ _c_xmgx=value;}
			get{return _c_xmgx;}
		}
		/// <summary>
		/// 是否自由状态货
		/// </summary>
		public string C_ISFREE
		{
			set{ _c_isfree=value;}
			get{return _c_isfree;}
		}
		#endregion Model

	}
}

