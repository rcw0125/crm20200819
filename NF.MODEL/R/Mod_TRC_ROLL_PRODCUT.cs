using System;
namespace NF.MODEL.R
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
        private string _c_id = "sys_guid";
        private string _c_emp_id;
        private DateTime? _d_mod_dt = Convert.ToDateTime(null);
        private string _c_trc_roll_main_id;
        private string _c_stove;
        private string _c_batch_no;
        private string _c_tick_no;
        private string _c_stl_grd;
        private string _c_stl_grd_before;
        private decimal? _n_wgt;
        private string _c_std_code;
        private string _c_std_code_before;
        private string _c_move_type;
        private string _c_spec;
        private string _c_shift;
        private string _c_group;
        private string _c_sta_id;
        private string _c_judge_lev_bp;
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
        private string _c_is_depot;
        private string _c_plan_id;
        private string _c_order_no;
        private string _c_con_no;
        private string _c_cust_no;
        private string _c_cust_name;
        private string _c_isfree;
        private string _c_linewh_code;
        private string _c_linewh_area_code;
        private string _c_linewh_loc_code;
        private string _c_floor;
        private string _c_cust_area;
        private string _c_sale_area;
        private string _c_judge_lev_cf;
        private string _c_judge_lev_xn;
        private string _c_judge_lev_xn_re;
        private string _c_judge_lev_zh_people;
        private DateTime? _d_judge_date;
        private string _c_is_qr="N";
        private string _c_qr_user;
        private DateTime? _d_qr_date;
        private string _c_design_no;
        private string _c_judge_lev_zh;
        private string _c_is_tb="N";
        private string _c_scutcheon;
        private string _c_gp_type;
        private string _c_barcode;
        private string _c_rkdh;
        private string _c_fydh;
        private string _c_ckdh;
        private string _c_move_desc;
        private string _c_ckry;
        private DateTime? _d_ckrq;
        private string _c_rkry;
        private DateTime? _d_rkrq;
        private string _c_bzyq;
        private DateTime? _d_weight_dt;
        private DateTime? _d_produce_date;
        private string _c_zyx1;
        private string _c_zyx2;
        private string _c_zkd_no;
        private string _c_master_id;
        private string _c_gp_before_id;
        private string _c_gp_after_id;
        private string _c_reason_name;
        private string _c_is_pd="N";
        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 实绩操作人
        /// </summary>
        public string C_EMP_ID
        {
            set { _c_emp_id = value; }
            get { return _c_emp_id; }
        }
        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime? D_MOD_DT
        {
            set { _d_mod_dt = value; }
            get { return _d_mod_dt; }
        }
        /// <summary>
        /// 组批表主键（完工单号）
        /// </summary>
        public string C_TRC_ROLL_MAIN_ID
        {
            set { _c_trc_roll_main_id = value; }
            get { return _c_trc_roll_main_id; }
        }
        /// <summary>
        /// 炉号
        /// </summary>
        public string C_STOVE
        {
            set { _c_stove = value; }
            get { return _c_stove; }
        }
        /// <summary>
        /// 批号
        /// </summary>
        public string C_BATCH_NO
        {
            set { _c_batch_no = value; }
            get { return _c_batch_no; }
        }
        /// <summary>
        /// 钩号
        /// </summary>
        public string C_TICK_NO
        {
            set { _c_tick_no = value; }
            get { return _c_tick_no; }
        }
        /// <summary>
        /// 钢种
        /// </summary>
        public string C_STL_GRD
        {
            set { _c_stl_grd = value; }
            get { return _c_stl_grd; }
        }
        /// <summary>
        /// 改判前钢种
        /// </summary>
        public string C_STL_GRD_BEFORE
        {
            set { _c_stl_grd_before = value; }
            get { return _c_stl_grd_before; }
        }
        /// <summary>
        /// 打牌重量
        /// </summary>
        public decimal? N_WGT
        {
            set { _n_wgt = value; }
            get { return _n_wgt; }
        }
        /// <summary>
        /// 执行标准
        /// </summary>
        public string C_STD_CODE
        {
            set { _c_std_code = value; }
            get { return _c_std_code; }
        }
        /// <summary>
        /// 改判前标准
        /// </summary>
        public string C_STD_CODE_BEFORE
        {
            set { _c_std_code_before = value; }
            get { return _c_std_code_before; }
        }
        /// <summary>
        /// 库存状态'N'未综判'E'已入库'S'已销售,'O'已占用,Z转库
        /// </summary>
        public string C_MOVE_TYPE
        {
            set { _c_move_type = value; }
            get { return _c_move_type; }
        }
        /// <summary>
        /// 规格
        /// </summary>
        public string C_SPEC
        {
            set { _c_spec = value; }
            get { return _c_spec; }
        }
        /// <summary>
        /// 班次
        /// </summary>
        public string C_SHIFT
        {
            set { _c_shift = value; }
            get { return _c_shift; }
        }
        /// <summary>
        /// 班组
        /// </summary>
        public string C_GROUP
        {
            set { _c_group = value; }
            get { return _c_group; }
        }
        /// <summary>
        /// 生产工位（外键）
        /// </summary>
        public string C_STA_ID
        {
            set { _c_sta_id = value; }
            get { return _c_sta_id; }
        }
        /// <summary>
        /// 表判等级
        /// </summary>
        public string C_JUDGE_LEV_BP
        {
            set { _c_judge_lev_bp = value; }
            get { return _c_judge_lev_bp; }
        }
        /// <summary>
        /// 打牌班次
        /// </summary>
        public string C_DP_SHIFT
        {
            set { _c_dp_shift = value; }
            get { return _c_dp_shift; }
        }
        /// <summary>
        /// 打牌班组
        /// </summary>
        public string C_DP_GROUP
        {
            set { _c_dp_group = value; }
            get { return _c_dp_group; }
        }
        /// <summary>
        /// 打牌操作人
        /// </summary>
        public string C_DP_EMP_ID
        {
            set { _c_dp_emp_id = value; }
            get { return _c_dp_emp_id; }
        }
        /// <summary>
        /// 打牌时间
        /// </summary>
        public DateTime? D_DP_DT
        {
            set { _d_dp_dt = value; }
            get { return _d_dp_dt; }
        }
        /// <summary>
        /// 工厂ID
        /// </summary>
        public string C_PLANT_ID
        {
            set { _c_plant_id = value; }
            get { return _c_plant_id; }
        }
        /// <summary>
        /// 工厂描述
        /// </summary>
        public string C_PLANT_DESC
        {
            set { _c_plant_desc = value; }
            get { return _c_plant_desc; }
        }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string C_MAT_CODE
        {
            set { _c_mat_code = value; }
            get { return _c_mat_code; }
        }
        /// <summary>
        /// 改判前物料编码
        /// </summary>
        public string C_MAT_CODE_BEFORE
        {
            set { _c_mat_code_before = value; }
            get { return _c_mat_code_before; }
        }
        /// <summary>
        /// 物料描述
        /// </summary>
        public string C_MAT_DESC
        {
            set { _c_mat_desc = value; }
            get { return _c_mat_desc; }
        }
        /// <summary>
        /// 改判前物料描述
        /// </summary>
        public string C_MAT_DESC_BEFORE
        {
            set { _c_mat_desc_before = value; }
            get { return _c_mat_desc_before; }
        }
        /// <summary>
        /// 库检状态0:未处理，1:已申请，2:已库检
        /// </summary>
        public string C_IS_DEPOT
        {
            set { _c_is_depot = value; }
            get { return _c_is_depot; }
        }
        /// <summary>
        /// 计划号
        /// </summary>
        public string C_PLAN_ID
        {
            set { _c_plan_id = value; }
            get { return _c_plan_id; }
        }
        /// <summary>
        /// 订单号
        /// </summary>
        public string C_ORDER_NO
        {
            set { _c_order_no = value; }
            get { return _c_order_no; }
        }
        /// <summary>
        /// 合同号
        /// </summary>
        public string C_CON_NO
        {
            set { _c_con_no = value; }
            get { return _c_con_no; }
        }
        /// <summary>
        /// 客户编码
        /// </summary>
        public string C_CUST_NO
        {
            set { _c_cust_no = value; }
            get { return _c_cust_no; }
        }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string C_CUST_NAME
        {
            set { _c_cust_name = value; }
            get { return _c_cust_name; }
        }
        /// <summary>
        /// 是否自由状态货
        /// </summary>
        public string C_ISFREE
        {
            set { _c_isfree = value; }
            get { return _c_isfree; }
        }
        /// <summary>
        /// 线材仓库编码
        /// </summary>
        public string C_LINEWH_CODE
        {
            set { _c_linewh_code = value; }
            get { return _c_linewh_code; }
        }
        /// <summary>
        /// 线材区域编码
        /// </summary>
        public string C_LINEWH_AREA_CODE
        {
            set { _c_linewh_area_code = value; }
            get { return _c_linewh_area_code; }
        }
        /// <summary>
        /// 库位编号
        /// </summary>
        public string C_LINEWH_LOC_CODE
        {
            set { _c_linewh_loc_code = value; }
            get { return _c_linewh_loc_code; }
        }
        /// <summary>
        /// 层
        /// </summary>
        public string C_FLOOR
        {
            set { _c_floor = value; }
            get { return _c_floor; }
        }
        /// <summary>
        /// 客户区域
        /// </summary>
        public string C_CUST_AREA
        {
            set { _c_cust_area = value; }
            get { return _c_cust_area; }
        }
        /// <summary>
        /// 销售区域
        /// </summary>
        public string C_SALE_AREA
        {
            set { _c_sale_area = value; }
            get { return _c_sale_area; }
        }
        /// <summary>
        /// 成分等级
        /// </summary>
        public string C_JUDGE_LEV_CF
        {
            set { _c_judge_lev_cf = value; }
            get { return _c_judge_lev_cf; }
        }
        /// <summary>
        /// 性能初检等级
        /// </summary>
        public string C_JUDGE_LEV_XN
        {
            set { _c_judge_lev_xn = value; }
            get { return _c_judge_lev_xn; }
        }
        /// <summary>
        /// 性能复检等级
        /// </summary>
        public string C_JUDGE_LEV_XN_RE
        {
            set { _c_judge_lev_xn_re = value; }
            get { return _c_judge_lev_xn_re; }
        }
        /// <summary>
        /// 人工判定等级
        /// </summary>
        public string C_JUDGE_LEV_ZH_PEOPLE
        {
            set { _c_judge_lev_zh_people = value; }
            get { return _c_judge_lev_zh_people; }
        }
        /// <summary>
        /// 综合判定时间
        /// </summary>
        public DateTime? D_JUDGE_DATE
        {
            set { _d_judge_date = value; }
            get { return _d_judge_date; }
        }
        /// <summary>
        /// 是否确认
        /// </summary>
        public string C_IS_QR
        {
            set { _c_is_qr = value; }
            get { return _c_is_qr; }
        }
        /// <summary>
        /// 确认人
        /// </summary>
        public string C_QR_USER
        {
            set { _c_qr_user = value; }
            get { return _c_qr_user; }
        }
        /// <summary>
        /// 确认时间
        /// </summary>
        public DateTime? D_QR_DATE
        {
            set { _d_qr_date = value; }
            get { return _d_qr_date; }
        }
        /// <summary>
        /// 质量设计号
        /// </summary>
        public string C_DESIGN_NO
        {
            set { _c_design_no = value; }
            get { return _c_design_no; }
        }
        /// <summary>
        /// 综合判定结果(SX)
        /// </summary>
        public string C_JUDGE_LEV_ZH
        {
            set { _c_judge_lev_zh = value; }
            get { return _c_judge_lev_zh; }
        }
        /// <summary>
        /// 是否同步（综合判定）
        /// </summary>
        public string C_IS_TB
        {
            set { _c_is_tb = value; }
            get { return _c_is_tb; }
        }
        /// <summary>
        /// 标牌类型 白牌/黄牌/红牌
        /// </summary>
        public string C_SCUTCHEON
        {
            set { _c_scutcheon = value; }
            get { return _c_scutcheon; }
        }
        /// <summary>
        /// 改判类型
        /// </summary>
        public string C_GP_TYPE
        {
            set { _c_gp_type = value; }
            get { return _c_gp_type; }
        }
        /// <summary>
        /// 打牌序号
        /// </summary>
        public string C_BARCODE
        {
            set { _c_barcode = value; }
            get { return _c_barcode; }
        }
        /// <summary>
        /// 入库单号
        /// </summary>
        public string C_RKDH
        {
            set { _c_rkdh = value; }
            get { return _c_rkdh; }
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
        /// 出库单号
        /// </summary>
        public string C_CKDH
        {
            set { _c_ckdh = value; }
            get { return _c_ckdh; }
        }
        /// <summary>
        /// 移动描述
        /// </summary>
        public string C_MOVE_DESC
        {
            set { _c_move_desc = value; }
            get { return _c_move_desc; }
        }
        /// <summary>
        /// 出库人员
        /// </summary>
        public string C_CKRY
        {
            set { _c_ckry = value; }
            get { return _c_ckry; }
        }
        /// <summary>
        /// 出库日期
        /// </summary>
        public DateTime? D_CKRQ
        {
            set { _d_ckrq = value; }
            get { return _d_ckrq; }
        }
        /// <summary>
        /// 入库人员
        /// </summary>
        public string C_RKRY
        {
            set { _c_rkry = value; }
            get { return _c_rkry; }
        }
        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime? D_RKRQ
        {
            set { _d_rkrq = value; }
            get { return _d_rkrq; }
        }
        /// <summary>
        /// 包装要求
        /// </summary>
        public string C_BZYQ
        {
            set { _c_bzyq = value; }
            get { return _c_bzyq; }
        }
        /// <summary>
        /// 计量时间
        /// </summary>
        public DateTime? D_WEIGHT_DT
        {
            set { _d_weight_dt = value; }
            get { return _d_weight_dt; }
        }
        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime? D_PRODUCE_DATE
        {
            set { _d_produce_date = value; }
            get { return _d_produce_date; }
        }
        /// <summary>
        /// 自由项1
        /// </summary>
        public string C_ZYX1
        {
            set { _c_zyx1 = value; }
            get { return _c_zyx1; }
        }
        /// <summary>
        /// 自由项2
        /// </summary>
        public string C_ZYX2
        {
            set { _c_zyx2 = value; }
            get { return _c_zyx2; }
        }
        /// <summary>
        ///转库单号
        /// </summary>
        public string C_ZKD_NO
        {
            set { _c_zkd_no = value; }
            get { return _c_zkd_no; }
        }

        /// <summary>
        /// 实绩主键
        /// </summary>
        public string C_MASTER_ID
        {
            set { _c_master_id = value; }
            get { return _c_master_id; }
        }
        /// <summary>
        /// 改变前主键
        /// </summary>
        public string C_GP_BEFORE_ID
        {
            set { _c_gp_before_id = value; }
            get { return _c_gp_before_id; }
        }
        /// <summary>
        /// 改判后主键
        /// </summary>
        public string C_GP_AFTER_ID
        {
            set { _c_gp_after_id = value; }
            get { return _c_gp_after_id; }
        }
        /// <summary>
        /// 不合格原因名称
        /// </summary>
        public string C_REASON_NAME
        {
            set { _c_reason_name = value; }
            get { return _c_reason_name; }
        }

        /// <summary>
        /// 是否已自动判定
        /// </summary>
        public string C_IS_PD
        {
            set { _c_is_pd = value; }
            get { return _c_is_pd; }
        }
        #endregion Model

    }
}

