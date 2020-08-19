using System;
namespace NF.MODEL
{
	/// <summary>
	/// 公告
	/// </summary>
	[Serializable]
	public partial class Mod_TMB_NOTICE
    {
		public Mod_TMB_NOTICE()
		{}
        #region Model
        private string _c_id = Guid.NewGuid().ToString();
        private string _c_class;
        private string _c_title;
        private string _c_picurl;
        private string _c_link;
        private string _c_content;
        private string _c_file;
        private decimal? _n_sort = 0;
		private string _c_remark;
        private decimal? _n_status = 1;
		private string _c_emp_id;
        private string _c_emp_name;
        private DateTime? _d_mod_dt = Convert.ToDateTime(DateTime.Now);
        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 类别
        /// </summary>
        public string C_CLASS
        {
            set { _c_class = value; }
            get { return _c_class; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string C_TITLE
        {
            set { _c_title = value; }
            get { return _c_title; }
        }
        /// <summary>
        /// 图片
        /// </summary>
        public string C_PICURL
        {
            set { _c_picurl = value; }
            get { return _c_picurl; }
        }
        /// <summary>
        /// 链接
        /// </summary>
        public string C_LINK
        {
            set { _c_link = value; }
            get { return _c_link; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string C_CONTENT
        {
            set { _c_content = value; }
            get { return _c_content; }
        }
        /// <summary>
        /// 附件
        /// </summary>
        public string C_FILE
        {
            set { _c_file = value; }
            get { return _c_file; }
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
        public decimal? N_STATUS
        {
            set { _n_status = value; }
            get { return _n_status; }
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

    }
}

