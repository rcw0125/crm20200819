using System;
namespace NF.MODEL
{
    /// <summary>
	/// 排班表
	/// </summary>
	[Serializable]
    public partial class Mod_TB_BCBZ
    {
        public Mod_TB_BCBZ()
        { }
        #region Model
        private string _c_id = "sys_guid";
        private DateTime? _d_start;
        private DateTime? _d_end;
        private string _c_bc;
        private string _c_bz;
        private string _c_emp_id;
        private string _c_pro_id;
        private DateTime _d_mod_dt = Convert.ToDateTime(DateTime.Now);
        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? D_START
        {
            set { _d_start = value; }
            get { return _d_start; }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? D_END
        {
            set { _d_end = value; }
            get { return _d_end; }
        }
        /// <summary>
        /// 班次
        /// </summary>
        public string C_BC
        {
            set { _c_bc = value; }
            get { return _c_bc; }
        }
        /// <summary>
        /// 班组
        /// </summary>
        public string C_BZ
        {
            set { _c_bz = value; }
            get { return _c_bz; }
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
        /// 工序
        /// </summary>
        public string C_PRO_ID
        {
            set { _c_pro_id = value; }
            get { return _c_pro_id; }
        }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime D_MOD_DT
        {
            set { _d_mod_dt = value; }
            get { return _d_mod_dt; }
        }
        #endregion Model

    }
}
