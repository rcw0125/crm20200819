using System;
namespace NF.MODEL
{
    /// <summary>
    /// 轧制主表
    /// </summary>
    [Serializable]
    public partial class Mod_TRC_ROLL_MAIN
    {
        public Mod_TRC_ROLL_MAIN()
        { }
        #region Model
        private string _c_id = "sys_guid";
        private string _c_sta_id;
        private string _c_plant;
        private string _c_stove;
        private string _c_batch_no;
        private string _c_plan_id;
        private decimal? _n_qua_total;
        private decimal? _n_wgt_total;
        private string _c_stl_grd_slab;
        private string _c_spec_slab;
        private string _c_emp_id;
        private string _c_shift;
        private string _c_group;
        private DateTime _d_mod_dt = Convert.ToDateTime(DateTime.Now);
        private decimal? _n_qua_remove;
        private decimal? _n_wgt_remove;
        private decimal? _n_qua_retrun;
        private decimal? _n_wgt_retrun;
        private decimal? _n_qua_join;
        private decimal? _n_wgt_join;
        private decimal? _n_qua_exit;
        private decimal? _n_wgt_exit;
        private decimal? _n_qua_cphalf;
        private decimal? _n_wgt_half;
        private decimal? _n_qua_cpwhole;
        private decimal? _n_wgt_cpwhole;
        private decimal? _c_roll_state;
        private string _c_fur_type;
        private decimal? _n_qua_elim;
        private decimal? _n_wgt_elim;
        private string _c_mat_slab_code;
        private string _c_mat_slab_name;
        private string _c_remark;
        private decimal _n_status = 1;
        private string _c_std_code;
        private string _c_stl_grd;
        private string _c_spec;
        private string _c_slab_num;
        private DateTime? _d_produce_date_b;
        private string _c_produce_emp_id;
        private string _c_produce_shift;
        private string _c_produce_group;
        private DateTime? _d_produce_date_e;
        private decimal? _n_qua_total_virtual;
        private decimal? _n_wgt_total_virtual;

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
        /// 组批支数
        /// </summary>
        public decimal? N_QUA_TOTAL
        {
            set { _n_qua_total = value; }
            get { return _n_qua_total; }
        }
        /// <summary>
        /// 组批重量
        /// </summary>
        public decimal? N_WGT_TOTAL
        {
            set { _n_wgt_total = value; }
            get { return _n_wgt_total; }
        }
        /// <summary>
        /// 组批坯料钢种
        /// </summary>
        public string C_STL_GRD_SLAB
        {
            set { _c_stl_grd_slab = value; }
            get { return _c_stl_grd_slab; }
        }
        /// <summary>
        /// 组批坯料规格
        /// </summary>
        public string C_SPEC_SLAB
        {
            set { _c_spec_slab = value; }
            get { return _c_spec_slab; }
        }
        /// <summary>
        /// 组批工号
        /// </summary>
        public string C_EMP_ID
        {
            set { _c_emp_id = value; }
            get { return _c_emp_id; }
        }
        /// <summary>
        /// 组批班次
        /// </summary>
        public string C_SHIFT
        {
            set { _c_shift = value; }
            get { return _c_shift; }
        }
        /// <summary>
        /// 组批班组
        /// </summary>
        public string C_GROUP
        {
            set { _c_group = value; }
            get { return _c_group; }
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
        /// 退库支数
        /// </summary>
        public decimal? N_QUA_REMOVE
        {
            set { _n_qua_remove = value; }
            get { return _n_qua_remove; }
        }
        /// <summary>
        /// 退库重量
        /// </summary>
        public decimal? N_WGT_REMOVE
        {
            set { _n_wgt_remove = value; }
            get { return _n_wgt_remove; }
        }
        /// <summary>
        /// 回炉支数
        /// </summary>
        public decimal? N_QUA_RETRUN
        {
            set { _n_qua_retrun = value; }
            get { return _n_qua_retrun; }
        }
        /// <summary>
        /// 回炉重量
        /// </summary>
        public decimal? N_WGT_RETRUN
        {
            set { _n_wgt_retrun = value; }
            get { return _n_wgt_retrun; }
        }
        /// <summary>
        /// 入炉支数
        /// </summary>
        public decimal? N_QUA_JOIN
        {
            set { _n_qua_join = value; }
            get { return _n_qua_join; }
        }
        /// <summary>
        /// 入炉重量
        /// </summary>
        public decimal? N_WGT_JOIN
        {
            set { _n_wgt_join = value; }
            get { return _n_wgt_join; }
        }
        /// <summary>
        /// 出炉支数
        /// </summary>
        public decimal? N_QUA_EXIT
        {
            set { _n_qua_exit = value; }
            get { return _n_qua_exit; }
        }
        /// <summary>
        /// 出炉重量
        /// </summary>
        public decimal? N_WGT_EXIT
        {
            set { _n_wgt_exit = value; }
            get { return _n_wgt_exit; }
        }
        /// <summary>
        /// 半废支数
        /// </summary>
        public decimal? N_QUA_CPHALF
        {
            set { _n_qua_cphalf = value; }
            get { return _n_qua_cphalf; }
        }
        /// <summary>
        /// 半废重量
        /// </summary>
        public decimal? N_WGT_HALF
        {
            set { _n_wgt_half = value; }
            get { return _n_wgt_half; }
        }
        /// <summary>
        /// 碎断支数
        /// </summary>
        public decimal? N_QUA_CPWHOLE
        {
            set { _n_qua_cpwhole = value; }
            get { return _n_qua_cpwhole; }
        }
        /// <summary>
        /// 碎断重量
        /// </summary>
        public decimal? N_WGT_CPWHOLE
        {
            set { _n_wgt_cpwhole = value; }
            get { return _n_wgt_cpwhole; }
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
        /// 剔除支数
        /// </summary>
        public decimal? N_QUA_ELIM
        {
            set { _n_qua_elim = value; }
            get { return _n_qua_elim; }
        }
        /// <summary>
        /// 剔除重量
        /// </summary>
        public decimal? N_WGT_ELIM
        {
            set { _n_wgt_elim = value; }
            get { return _n_wgt_elim; }
        }
        /// <summary>
        /// 钢坯物料编码
        /// </summary>
        public string C_MAT_SLAB_CODE
        {
            set { _c_mat_slab_code = value; }
            get { return _c_mat_slab_code; }
        }
        /// <summary>
        /// 钢坯物料
        /// </summary>
        public string C_MAT_SLAB_NAME
        {
            set { _c_mat_slab_name = value; }
            get { return _c_mat_slab_name; }
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
        /// 状态0停用1启用
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
        /// 钢坯序号
        /// </summary>
        public string C_SLAB_NUM
        {
            set { _c_slab_num = value; }
            get { return _c_slab_num; }
        }

        /// <summary>
        /// 组批支数
        /// </summary>
        public decimal? N_QUA_TOTAL_VRITUAL
        {
            set { _n_qua_total_virtual = value; }
            get { return _n_qua_total_virtual; }
        }
        /// <summary>
        /// 组批重量
        /// </summary>
        public decimal? N_WGT_TOTAL_VRITUAL
        {
            set { _n_wgt_total_virtual = value; }
            get { return _n_wgt_total_virtual; }
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
        /// 生产结束时间
        /// </summary>
        public DateTime? D_PRODUCE_DATE_E
        {
            set { _d_produce_date_e = value; }
            get { return _d_produce_date_e; }
        }
        /// <summary>
        /// 组批支数
        /// </summary>
        public decimal? N_QUA_TOTAL_VIRTUAL
        {
            set { _n_qua_total_virtual = value; }
            get { return _n_qua_total_virtual; }
        }
        /// <summary>
        /// 组批重量
        /// </summary>
        public decimal? N_WGT_TOTAL_VIRTUAL
        {
            set { _n_wgt_total_virtual = value; }
            get { return _n_wgt_total_virtual; }
        }

        #endregion Model

    }
}

