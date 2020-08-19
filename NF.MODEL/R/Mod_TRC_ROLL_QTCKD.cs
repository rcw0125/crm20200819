using System;
namespace NF.MODEL
{
    /// <summary>
    /// 其他出库单
    /// </summary>
    [Serializable]
    public partial class Mod_TRC_ROLL_QTCKD
    {
        public Mod_TRC_ROLL_QTCKD()
        { }
        #region Model
        private string _c_id = "sys_guid";
        private string _c_qtckd_no;
        private string _c_lic_pla_no;
        private string _c_address;
        private string _c_create_id;
        private DateTime? _d_create_dt;
        private string _c_change_id;
        private DateTime? _d_change_dt;
        private decimal? _n_status = 1;
		private string _c_type;
        private string _c_ncdj;
        private string _c_cys;
        private string _c_shdw;
        private DateTime? _d_fysj;
        private string _c_mbwh_id;
        private string _c_mbwh_name;
        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 其他出库库单号
        /// </summary>
        public string C_QTCKD_NO
        {
            set { _c_qtckd_no = value; }
            get { return _c_qtckd_no; }
        }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string C_LIC_PLA_NO
        {
            set { _c_lic_pla_no = value; }
            get { return _c_lic_pla_no; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string C_ADDRESS
        {
            set { _c_address = value; }
            get { return _c_address; }
        }
        /// <summary>
        /// 制单人
        /// </summary>
        public string C_CREATE_ID
        {
            set { _c_create_id = value; }
            get { return _c_create_id; }
        }
        /// <summary>
        /// 制单日期
        /// </summary>
        public DateTime? D_CREATE_DT
        {
            set { _d_create_dt = value; }
            get { return _d_create_dt; }
        }
        /// <summary>
        /// 改变人
        /// </summary>
        public string C_CHANGE_ID
        {
            set { _c_change_id = value; }
            get { return _c_change_id; }
        }
        /// <summary>
        /// 改变日期
        /// </summary>
        public DateTime? D_CHANGE_DT
        {
            set { _d_change_dt = value; }
            get { return _d_change_dt; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public decimal? N_STATUS
        {
            set { _n_status = value; }
            get { return _n_status; }
        }
        /// <summary>
        /// 出库类型
        /// </summary>
        public string C_TYPE
        {
            set { _c_type = value; }
            get { return _c_type; }
        }
        /// <summary>
        /// NC单号
        /// </summary>
        public string C_NCDJ
        {
            set { _c_ncdj = value; }
            get { return _c_ncdj; }
        }
        /// <summary>
        /// 承运商
        /// </summary>
        public string C_CYS
        {
            set { _c_cys = value; }
            get { return _c_cys; }
        }
        /// <summary>
        /// 送货单位
        /// </summary>
        public string C_SHDW
        {
            set { _c_shdw = value; }
            get { return _c_shdw; }
        }
        /// <summary>
        /// 发运时间
        /// </summary>
        public DateTime? D_FYSJ
        {
            set { _d_fysj = value; }
            get { return _d_fysj; }
        }
        /// <summary>
        /// 目标仓库ID
        /// </summary>
        public string C_MBWH_ID
        {
            set { _c_mbwh_id = value; }
            get { return _c_mbwh_id; }
        }
        /// <summary>
        /// 目标仓库名称
        /// </summary>
        public string C_MBWH_NAME
        {
            set { _c_mbwh_name = value; }
            get { return _c_mbwh_name; }
        }
        #endregion Model

    }
}
