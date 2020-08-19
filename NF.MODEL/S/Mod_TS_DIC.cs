using System;
namespace NF.MODEL
{
    /// <summary>
    /// 数据字典
    /// </summary>
    [Serializable]
    public partial class Mod_TS_DIC
    {
        public Mod_TS_DIC()
        { }
        #region Model
        private string _c_id = "sys_guid";
        private string _c_typecode;
        private string _c_typename;
        private string _c_detailcode;
        private string _c_detailname;
        private decimal? _c_index;
        private decimal? _n_status = 1;
        private decimal? _n_isgps = 0;
        private string _c_emp_id;
        private string _c_emp_name;
        private DateTime? _d_mod_dt = Convert.ToDateTime(DateTime.Now);
        /// <summary>
        /// 编号
        /// </summary>
        public string C_ID
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 类别编码
        /// </summary>
        public string C_TYPECODE
        {
            set { _c_typecode = value; }
            get { return _c_typecode; }
        }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string C_TYPENAME
        {
            set { _c_typename = value; }
            get { return _c_typename; }
        }
        /// <summary>
        /// 详细编码
        /// </summary>
        public string C_DETAILCODE
        {
            set { _c_detailcode = value; }
            get { return _c_detailcode; }
        }
        /// <summary>
        /// 详细名称
        /// </summary>
        public string C_DETAILNAME
        {
            set { _c_detailname = value; }
            get { return _c_detailname; }
        }
        /// <summary>
        /// 索引
        /// </summary>
        public decimal? C_INDEX
        {
            set { _c_index = value; }
            get { return _c_index; }
        }
        /// <summary>
        /// 状态0停用1启用
        /// </summary>
        public decimal? N_STATUS
        {
            set { _n_status = value; }
            get { return _n_status; }
        }
        /// <summary>
        /// 是否GPS
        /// </summary>
        public decimal? N_ISGPS
        {
            set { _n_isgps = value; }
            get { return _n_isgps; }
        }
        /// <summary>
        /// 系统操作人编号
        /// </summary>
        public string C_EMP_ID
        {
            set { _c_emp_id = value; }
            get { return _c_emp_id; }
        }
        /// <summary>
        /// 系统操作人姓名
        /// </summary>
        public string C_EMP_NAME
        {
            set { _c_emp_name = value; }
            get { return _c_emp_name; }
        }
        /// <summary>
        /// 系系统操作时间
        /// </summary>
        public DateTime? D_MOD_DT
        {
            set { _d_mod_dt = value; }
            get { return _d_mod_dt; }
        }

        #endregion Model

        /// <summary>
        /// 区域客户控制发运
        /// </summary>
        public string C_EXTEND2 { set; get; }


    }
}

