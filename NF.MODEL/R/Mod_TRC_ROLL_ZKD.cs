using System;
namespace NF.MODEL
{
    /// <summary>
    /// 线材转库单
    /// </summary>
    [Serializable]
    public partial class Mod_TRC_ROLL_ZKD
    {
        public Mod_TRC_ROLL_ZKD()
        { }
        #region Model
        private string _c_id = "sys_guid";
        private string _c_zkd_no;
        private string _c_mat_code;
        private string _c_mat_desc;
        private string _c_linewh_code;
        private string _c_mblinewh_code;
        private string _c_stl_grd;
        private string _c_judge_lev_zh;
        private decimal? _n_num;
        private decimal? _n_wgt;
        private string _c_z_dw = "件【线材】";
        private string _c_f_dw = "吨";
        private string _c_batch_no;
        private string _c_spec;
        private string _c_stove;
        private string _c_zyx1;
        private string _c_zyx2;
        private string _c_bzyq;
        private string _c_zyx4;
        private decimal? _n_status = 1;
		private string _c_emp_id;
        private DateTime? _d_mod_dt = Convert.ToDateTime(DateTime.Now);
        private DateTime? _d_produce_date;
        private string _c_tb;
        private string _c_judge_lev_bp;
        private string _c_std_code;
        private string _c_linewh_id;
        private string _c_mblinewh_id;
        private string _c_create_code;
        private DateTime? _d_create_date;
        private decimal? _n_sjnum;
        private decimal? _n_sjwgt;
        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 转库单号
        /// </summary>
        public string C_ZKD_NO
        {
            set { _c_zkd_no = value; }
            get { return _c_zkd_no; }
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
        /// 物料描述
        /// </summary>
        public string C_MAT_DESC
        {
            set { _c_mat_desc = value; }
            get { return _c_mat_desc; }
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
        /// 目标仓库编码
        /// </summary>
        public string C_MBLINEWH_CODE
        {
            set { _c_mblinewh_code = value; }
            get { return _c_mblinewh_code; }
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
        /// 综合判定结果(SX)
        /// </summary>
        public string C_JUDGE_LEV_ZH
        {
            set { _c_judge_lev_zh = value; }
            get { return _c_judge_lev_zh; }
        }
        /// <summary>
        /// 计划数量
        /// </summary>
        public decimal? N_NUM
        {
            set { _n_num = value; }
            get { return _n_num; }
        }
        /// <summary>
        /// 计划重量
        /// </summary>
        public decimal? N_WGT
        {
            set { _n_wgt = value; }
            get { return _n_wgt; }
        }
        /// <summary>
        /// 主计量单位
        /// </summary>
        public string C_Z_DW
        {
            set { _c_z_dw = value; }
            get { return _c_z_dw; }
        }
        /// <summary>
        /// 辅计量单位
        /// </summary>
        public string C_F_DW
        {
            set { _c_f_dw = value; }
            get { return _c_f_dw; }
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
        /// 规格
        /// </summary>
        public string C_SPEC
        {
            set { _c_spec = value; }
            get { return _c_spec; }
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
        /// 包装要求
        /// </summary>
        public string C_BZYQ
        {
            set { _c_bzyq = value; }
            get { return _c_bzyq; }
        }
        /// <summary>
        /// 自由项4
        /// </summary>
        public string C_ZYX4
        {
            set { _c_zyx4 = value; }
            get { return _c_zyx4; }
        }
        /// <summary>
        /// 状态1未上传2成功
        /// </summary>
        public decimal? N_STATUS
        {
            set { _n_status = value; }
            get { return _n_status; }
        }
        /// <summary>
        /// 制单人
        /// </summary>
        public string C_EMP_ID
        {
            set { _c_emp_id = value; }
            get { return _c_emp_id; }
        }
        /// <summary>
        /// 操作日期
        /// </summary>
        public DateTime? D_MOD_DT
        {
            set { _d_mod_dt = value; }
            get { return _d_mod_dt; }
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
        /// 同步信息
        /// </summary>
        public string C_TB
        {
            set { _c_tb = value; }
            get { return _c_tb; }
        }
        /// <summary>
        /// 表判结果
        /// </summary>
        public string C_JUDGE_LEV_BP
        {
            set { _c_judge_lev_bp = value; }
            get { return _c_judge_lev_bp; }
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
        /// 线材仓库id
        /// </summary>
        public string C_LINEWH_ID
        {
            set { _c_linewh_id = value; }
            get { return _c_linewh_id; }
        }
        /// <summary>
        /// 目标仓库id
        /// </summary>
        public string C_MBLINEWH_ID
        {
            set { _c_mblinewh_id = value; }
            get { return _c_mblinewh_id; }
        }
        /// <summary>
        /// 制单人编码
        /// </summary>
        public string C_CREATE_CODE
        {
            set { _c_create_code = value; }
            get { return _c_create_code; }
        }
        /// <summary>
        /// 制单日期
        /// </summary>
        public DateTime? D_CREATE_DATE
        {
            set { _d_create_date = value; }
            get { return _d_create_date; }
        }
        /// <summary>
        /// 实绩数量
        /// </summary>
        public decimal? N_SJNUM
        {
            set { _n_sjnum = value; }
            get { return _n_sjnum; }
        }
        /// <summary>
        /// 实绩重量
        /// </summary>
        public decimal? N_SJWGT
        {
            set { _n_sjwgt = value; }
            get { return _n_sjwgt; }
        }
        #endregion Model

      
    }
}
