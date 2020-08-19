using System;
namespace NF.MODEL
{
    /// <summary>
    /// 外委组批主表
    /// </summary>
    [Serializable]
    public partial class Mod_TRC_ROLL_WW_MAIN
    {
        public Mod_TRC_ROLL_WW_MAIN()
        { }
        #region Model
        private string _c_id = "sys_guid";
        private string _c_sta_id;
        private string _c_plant;
        private string _c_ord_id;
        private string _c_batch_no;
        private decimal? _n_qua_total;
        private decimal? _n_wgt_total;
        private string _c_stl_grd_slab;
        private string _c_spec_slab;
        private string _c_emp_id;
        private string _c_shift;
        private string _c_group;
        private DateTime _d_mod_dt = DateTime.Now;
        private decimal? _n_qua_remove;
        private decimal? _n_wgt_remove;
        private string _c_mat_slab_code;
        private string _c_mat_slab_name;
        private string _c_remark;
        private decimal _n_status = 1m;
        private string _c_std_code;
        private DateTime? _d_produce_date_b;
        private string _c_produce_emp_id;
        private string _c_produce_shift;
        private string _c_produce_group;
        private DateTime? _d_produce_date_e;
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
        /// 合同ID
        /// </summary>
        public string C_ORD_ID
        {
            set { _c_ord_id = value; }
            get { return _c_ord_id; }
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
        /// 完工支数
        /// </summary>
        public decimal? N_QUA_REMOVE
        {
            set { _n_qua_remove = value; }
            get { return _n_qua_remove; }
        }
        /// <summary>
        /// 完工重量
        /// </summary>
        public decimal? N_WGT_REMOVE
        {
            set { _n_wgt_remove = value; }
            get { return _n_wgt_remove; }
        }
        /// <summary>
        /// 订单成品物料编码
        /// </summary>
        public string C_MAT_SLAB_CODE
        {
            set { _c_mat_slab_code = value; }
            get { return _c_mat_slab_code; }
        }
        /// <summary>
        /// 订单成品物料名称
        /// </summary>
        public string C_MAT_SLAB_NAME
        {
            set { _c_mat_slab_name = value; }
            get { return _c_mat_slab_name; }
        }
        /// <summary>
		/// 订单成品物料编码
		/// </summary>
		public string C_MAT_XC_CODE { get; set; }
        /// <summary>
        /// 订单成品物料名称
        /// </summary>
        public string C_MAT_XC_NAME { get; set; }

        /// <summary>
        /// 线材批号
        /// </summary>
        public string C_XC_BATCH_NO { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string C_REMARK
        {
            set { _c_remark = value; }
            get { return _c_remark; }
        }
        /// <summary>
        /// 状态0创建1完工
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
        /// 线材仓库编码
        /// </summary>
        public string C_XC_LINEWH_CODE { get; set; }

        /// <summary>
        /// 线材包装方式
        /// </summary>
        public string C_XC_BZYQ { get; set; }

        /// <summary>
        /// 质量等级
        /// </summary>
        public string C_CHECKSTATE_NAME { get; set; }

        /// <summary>
        /// 成品入库仓库编码
        /// </summary>
        public string C_LINEWH_CODE { get; set; }
        /// <summary>
        /// 成品入库仓库名称
        /// </summary>
        public string C_LINEWH_NAME { get; set; }

        #endregion Model

    }
}

