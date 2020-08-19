using System;
namespace NF.MODEL
{
    /// <summary>
    /// 轧钢完工单表
    /// </summary>
    [Serializable]
    public partial class Mod_TRC_ROLL_WGD
    {
        public Mod_TRC_ROLL_WGD()
        { }
        #region Model
        private string _c_id = "sys_guid";
        private string _c_sta_id;
        private string _c_plant;
        private string _c_stove;
        private string _c_batch_no;
        private string _c_plan_id;
        private decimal? _n_qua_produce;
        private decimal? _n_wgt_produce;
        private DateTime _d_mod_dt = Convert.ToDateTime(DateTime.Now);
        private decimal? _c_roll_state;
        private string _c_fur_type;
        private string _c_remark;
        private decimal _n_status = 0;
        private string _c_std_code;
        private string _c_stl_grd;
        private string _c_spec;
        private DateTime? _d_produce_date;
        private string _c_produce_emp_id;
        private string _c_produce_shift;
        private string _c_produce_group;
        private string _c_sx;
        private string _c_pclx;
        private string _c_main_id;
        private string _c_scx_nc;
        private string _c_pack;
        private string _c_free_term;
        private string _c_free_term2;
        private string _c_area;
        private string _c_zpdjbz;
        private decimal _n_scrf = 0;
        private string _c_mrsx = "A";
        private DateTime? _d_produce_date_b;
        private DateTime? _d_produce_date_e;
        private string _c_mat_code;
        private string _c_mat_desc;
        private string _c_produce_shift_name;
        private string _c_produce_group_name;
        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 工位主键
        /// </summary>
        public string C_STA_ID
        {
            set { _c_sta_id = value; }
            get { return _c_sta_id; }
        }
        /// <summary>
        /// 工厂
        /// </summary>
        public string C_PLANT
        {
            set { _c_plant = value; }
            get { return _c_plant; }
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
        /// 计划号
        /// </summary>
        public string C_PLAN_ID
        {
            set { _c_plan_id = value; }
            get { return _c_plan_id; }
        }
        /// <summary>
        /// 完工支数
        /// </summary>
        public decimal? N_QUA_PRODUCE
        {
            set { _n_qua_produce = value; }
            get { return _n_qua_produce; }
        }
        /// <summary>
        /// 完工重量
        /// </summary>
        public decimal? N_WGT_PRODUCE
        {
            set { _n_wgt_produce = value; }
            get { return _n_wgt_produce; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime D_MOD_DT
        {
            set { _d_mod_dt = value; }
            get { return _d_mod_dt; }
        }
        /// <summary>
        /// 轧制状态
        /// </summary>
        public decimal? C_ROLL_STATE
        {
            set { _c_roll_state = value; }
            get { return _c_roll_state; }
        }
        /// <summary>
        /// 装炉方式
        /// </summary>
        public string C_FUR_TYPE
        {
            set { _c_fur_type = value; }
            get { return _c_fur_type; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string C_REMARK
        {
            set { _c_remark = value; }
            get { return _c_remark; }
        }
        /// <summary>
        /// 状态0轧钢确认1质控部确认
        /// </summary>
        public decimal N_STATUS
        {
            set { _n_status = value; }
            get { return _n_status; }
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
        /// 钢种
        /// </summary>
        public string C_STL_GRD
        {
            set { _c_stl_grd = value; }
            get { return _c_stl_grd; }
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
        /// 生产日期
        /// </summary>
        public DateTime? D_PRODUCE_DATE
        {
            set { _d_produce_date = value; }
            get { return _d_produce_date; }
        }
        /// <summary>
        /// 生产人员
        /// </summary>
        public string C_PRODUCE_EMP_ID
        {
            set { _c_produce_emp_id = value; }
            get { return _c_produce_emp_id; }
        }
        /// <summary>
        /// 生产班次
        /// </summary>
        public string C_PRODUCE_SHIFT
        {
            set { _c_produce_shift = value; }
            get { return _c_produce_shift; }
        }
        /// <summary>
        /// 生产班组
        /// </summary>
        public string C_PRODUCE_GROUP
        {
            set { _c_produce_group = value; }
            get { return _c_produce_group; }
        }
        /// <summary>
        /// 属性
        /// </summary>
        public string C_SX
        {
            set { _c_sx = value; }
            get { return _c_sx; }
        }
        /// <summary>
        /// 批次类型0普通材，1出口材
        /// </summary>
        public string C_PCLX
        {
            set { _c_pclx = value; }
            get { return _c_pclx; }
        }
        /// <summary>
        /// 组批主表主键（完工单号）
        /// </summary>
        public string C_MAIN_ID
        {
            set { _c_main_id = value; }
            get { return _c_main_id; }
        }
        /// <summary>
        /// NC工位主键
        /// </summary>
        public string C_SCX_NC
        {
            set { _c_scx_nc = value; }
            get { return _c_scx_nc; }
        }
        /// <summary>
        /// 包装要求
        /// </summary>
        public string C_PACK
        {
            set { _c_pack = value; }
            get { return _c_pack; }
        }
        /// <summary>
        /// 自由项
        /// </summary>
        public string C_FREE_TERM
        {
            set { _c_free_term = value; }
            get { return _c_free_term; }
        }
        /// <summary>
        /// 自由项2
        /// </summary>
        public string C_FREE_TERM2
        {
            set { _c_free_term2 = value; }
            get { return _c_free_term2; }
        }
        /// <summary>
        /// 区域
        /// </summary>
        public string C_AREA
        {
            set { _c_area = value; }
            get { return _c_area; }
        }
        /// <summary>
        /// 整批待检标识0待检1完成
        /// </summary>
        public string C_ZPDJBZ
        {
            set { _c_zpdjbz = value; }
            get { return _c_zpdjbz; }
        }
        /// <summary>
        /// 是否上传条码0未传1已传
        /// </summary>
        public decimal N_SCRF
        {
            set { _n_scrf = value; }
            get { return _n_scrf; }
        }
        /// <summary>
        ///批次属性
        /// </summary>
        public string C_MRSX
        {
            set { _c_mrsx = value; }
            get { return _c_mrsx; }
        }
        /// <summary>
        /// 生产开始时间
        /// </summary>
        public DateTime? D_PRODUCE_DATE_B
        {
            set { _d_produce_date_b = value; }
            get { return _d_produce_date_b; }
        }
        /// <summary>
        /// 生产结束时间
        /// </summary>
        public DateTime? D_PRODUCE_DATE_E
        {
            set { _d_produce_date_e = value; }
            get { return _d_produce_date_e; }
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
        /// 物料名称
        /// </summary>
        public string C_MAT_DESC
        {
            set { _c_mat_desc = value; }
            get { return _c_mat_desc; }
        }

        /// <summary>
        /// 生产班次
        /// </summary>
        public string C_PRODUCE_SHIFT_NAME
        {
            set { _c_produce_shift_name = value; }
            get { return _c_produce_shift_name; }
        }
        /// <summary>
        /// 生产班组
        /// </summary>
        public string C_PRODUCE_GROUP_NAME
        {
            set { _c_produce_group_name = value; }
            get { return _c_produce_group_name; }
        }

        #endregion Model

    }
}

