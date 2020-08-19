using System;
namespace NF.MODEL
{
	/// <summary>
	/// 客户评分主表
	/// </summary>
	[Serializable]
	public partial class Mod_TMC_CUSTGMARK_MAIN
    {
		public Mod_TMC_CUSTGMARK_MAIN()
		{}
        #region Model
        private string _c_id;
        private string _c_title;
        private string _c_xgid;
        private string _c_stlgrd;
        private DateTime? _d_time;
        private string _c_custno;
        private string _c_custname;
        private string _c_empid;
        private string _c_empname;
        private decimal? _n_status = 0;
		private string _c_remark;


        private string _c_order_no;

        /// <summary>
        /// 订单号
        /// </summary>
        public string C_ORDER_NO
        {
            set { _c_order_no = value; }
            get { return _c_order_no; }
        }

        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID
        {
            set { _c_id = value; }
            get { return _c_id; }
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
        /// 供应商名称
        /// </summary>
        public string C_XGID
        {
            set { _c_xgid = value; }
            get { return _c_xgid; }
        }
        /// <summary>
        /// 供应材料
        /// </summary>
        public string C_STLGRD
        {
            set { _c_stlgrd = value; }
            get { return _c_stlgrd; }
        }
        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime? D_TIME
        {
            set { _d_time = value; }
            get { return _d_time; }
        }
        /// <summary>
        /// 客户编码
        /// </summary>
        public string C_CUSTNO
        {
            set { _c_custno = value; }
            get { return _c_custno; }
        }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string C_CUSTNAME
        {
            set { _c_custname = value; }
            get { return _c_custname; }
        }
        /// <summary>
        /// 操作人ID
        /// </summary>
        public string C_EMPID
        {
            set { _c_empid = value; }
            get { return _c_empid; }
        }
        /// <summary>
        /// 操作人姓名
        /// </summary>
        public string C_EMPNAME
        {
            set { _c_empname = value; }
            get { return _c_empname; }
        }
        /// <summary>
        /// 状态：0未提交，1已提交
        /// </summary>
        public decimal? N_STATUS
        {
            set { _n_status = value; }
            get { return _n_status; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string C_REMARK
        {
            set { _c_remark = value; }
            get { return _c_remark; }
        }
        #endregion Model

    }
}

