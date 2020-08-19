using System;

namespace NF.MODEL
{
    /// <summary>
    /// 标准匹配表
    /// </summary>
    [Serializable]
    public partial class Mod_TB_STD_CONFIG
    {
        public Mod_TB_STD_CONFIG()
        { }
        #region Model
        private string _c_id;
        private string _c_std_code;
        private string _c_std_id;
        private string _c_cust_tech_prot;
        private string _c_zyx1;
        private string _c_zyx2;
        private string _c_stl_grd;
        private string _c_steel_sign;
        private decimal _n_status = 1M;
        private string _c_emp_id;
        private DateTime _d_mod_dt;
        private string _c_remark;
        private DateTime? _d_start_date;
        private DateTime? _d_end_date;
        private string _c_cust_no;
        private string _c_cust_name;
        private string _c_zzs;

        /// <summary>
        /// 客户协议标记
        /// </summary>
        public string C_FLAG { set; get; }

        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID
        {
            set { _c_id = value; }
            get { return _c_id; }
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
        /// 执行标准主键
        /// </summary>
        public string C_STD_ID
        {
            set { _c_std_id = value; }
            get { return _c_std_id; }
        }
        /// <summary>
        /// 客户技术协议号
        /// </summary>
        public string C_CUST_TECH_PROT
        {
            set { _c_cust_tech_prot = value; }
            get { return _c_cust_tech_prot; }
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
        /// 钢种
        /// </summary>
        public string C_STL_GRD
        {
            set { _c_stl_grd = value; }
            get { return _c_stl_grd; }
        }
        /// <summary>
        /// 炼钢记号
        /// </summary>
        public string C_STEEL_SIGN
        {
            set { _c_steel_sign = value; }
            get { return _c_steel_sign; }
        }
        /// <summary>
        /// 使用状态   1-可用；0-停用
        /// </summary>
        public decimal N_STATUS
        {
            set { _n_status = value; }
            get { return _n_status; }
        }
        /// <summary>
        /// 操作人
        /// </summary>
        public string C_EMP_ID
        {
            set { _c_emp_id = value; }
            get { return _c_emp_id; }
        }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime D_MOD_DT
        {
            set { _d_mod_dt = value; }
            get { return _d_mod_dt; }
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
        /// 启用时间
        /// </summary>
        public DateTime? D_START_DATE
        {
            set { _d_start_date = value; }
            get { return _d_start_date; }
        }
        /// <summary>
        /// 停用时间
        /// </summary>
        public DateTime? D_END_DATE
        {
            set { _d_end_date = value; }
            get { return _d_end_date; }
        }
        /// <summary>
        /// 客商编号
        /// </summary>
        public string C_CUST_NO
        {
            set { _c_cust_no = value; }
            get { return _c_cust_no; }
        }
        /// <summary>
        /// 客商名称
        /// </summary>
        public string C_CUST_NAME
        {
            set { _c_cust_name = value; }
            get { return _c_cust_name; }
        }
        /// <summary>
        /// 质证书
        /// </summary>
        public string C_ZZS
        {
            set { _c_zzs = value; }
            get { return _c_zzs; }
        }
        #endregion Model

    }
}

