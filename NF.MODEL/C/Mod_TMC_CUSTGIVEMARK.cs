using System;
namespace NF.MODEL
{
	/// <summary>
	/// 客户评分
	/// </summary>
	[Serializable]
	public partial class Mod_TMC_CUSTGIVEMARK
    {
		public Mod_TMC_CUSTGIVEMARK()
		{}
        #region Model
        private string _c_id;
        private string _c_pkhid;
        private string _c_pkid;
        private decimal? _n_score;
        private DateTime? _d_time;
        private string _c_remark;
        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 来源主表ID
        /// </summary>
        public string C_PKHID
        {
            set { _c_pkhid = value; }
            get { return _c_pkhid; }
        }
        /// <summary>
        /// 项目ID
        /// </summary>
        public string C_PKID
        {
            set { _c_pkid = value; }
            get { return _c_pkid; }
        }
        /// <summary>
        /// 评分
        /// </summary>
        public decimal? N_SCORE
        {
            set { _n_score = value; }
            get { return _n_score; }
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

