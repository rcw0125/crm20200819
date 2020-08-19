using System;
namespace NF.MODEL
{
	/// <summary>
	/// 工位表
	/// </summary>
	[Serializable]
	public partial class Mod_TB_STA
	{
		public Mod_TB_STA()
		{}
        #region Model
        private string _c_id = System.Guid.NewGuid().ToString();
        private decimal _n_status = 1M;
        private string _c_emp_id;
        private DateTime _d_mod_dt = System.DateTime.Now;
        private string _c_remark;
        private DateTime? _d_start_date;
        private DateTime? _d_end_date;
        private decimal? _n_sort;
        private string _c_pro_id;
        private string _c_sta_code;
        private string _c_sta_desc;
        private string _c_sta_erpcode;
        private string _c_sta_mescode;
        private string _c_erp_pk;
        private string _c_ssbmid;
        private decimal? _n_flag;
        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID
        {
            set { _c_id = value; }
            get { return _c_id; }
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
        /// 排序
        /// </summary>
        public decimal? N_SORT
        {
            set { _n_sort = value; }
            get { return _n_sort; }
        }
        /// <summary>
        /// 工序表主键
        /// </summary>
        public string C_PRO_ID
        {
            set { _c_pro_id = value; }
            get { return _c_pro_id; }
        }
        /// <summary>
        /// 工位代码
        /// </summary>
        public string C_STA_CODE
        {
            set { _c_sta_code = value; }
            get { return _c_sta_code; }
        }
        /// <summary>
        /// 工位描述
        /// </summary>
        public string C_STA_DESC
        {
            set { _c_sta_desc = value; }
            get { return _c_sta_desc; }
        }
        /// <summary>
        /// 工位ERP代码
        /// </summary>
        public string C_STA_ERPCODE
        {
            set { _c_sta_erpcode = value; }
            get { return _c_sta_erpcode; }
        }
        /// <summary>
        /// 工位MES代码
        /// </summary>
        public string C_STA_MESCODE
        {
            set { _c_sta_mescode = value; }
            get { return _c_sta_mescode; }
        }
        /// <summary>
        /// 工作中心ID
        /// </summary>
        public string C_ERP_PK
        {
            set { _c_erp_pk = value; }
            get { return _c_erp_pk; }
        }
        /// <summary>
        /// 生产部门ID
        /// </summary>
        public string C_SSBMID
        {
            set { _c_ssbmid = value; }
            get { return _c_ssbmid; }
        }
        /// <summary>
        /// 标识
        /// </summary>
        public decimal? N_FLAG
        {
            set { _n_flag = value; }
            get { return _n_flag; }
        }
        #endregion Model

    }
}

