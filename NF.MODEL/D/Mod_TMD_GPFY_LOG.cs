using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.MODEL.D
{
    /// <summary>
    /// 钢坯发运日志
    /// </summary>
    [Serializable]
    public partial class Mod_TMD_GPFY_LOG
    {
        public Mod_TMD_GPFY_LOG()
        { }
        #region Model
        private string _c_id;
        private string _c_fydh;
        private string _c_type;
        private string _c_emp_id;
        private DateTime _d_mod_dt;
        private decimal? _n_num;
        private decimal? _n_wgt;
        private string _c_send_stock;
        private string _c_batch_no;
        private string _c_stove;
        private string _c_stl_grd;
        private string _c_std_code;
        private string _c_spec;
        private string _c_zldj;
        private string _c_bzyq;
        private string _c_lic_pla_no;
        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 发运单号
        /// </summary>
        public string C_FYDH
        {
            set { _c_fydh = value; }
            get { return _c_fydh; }
        }
        /// <summary>
        /// 类型
        /// </summary>
        public string C_TYPE
        {
            set { _c_type = value; }
            get { return _c_type; }
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
        /// 数量
        /// </summary>
        public decimal? N_NUM
        {
            set { _n_num = value; }
            get { return _n_num; }
        }
        /// <summary>
        /// 净重
        /// </summary>
        public decimal? N_WGT
        {
            set { _n_wgt = value; }
            get { return _n_wgt; }
        }
        /// <summary>
        /// 发货仓库
        /// </summary>
        public string C_SEND_STOCK
        {
            set { _c_send_stock = value; }
            get { return _c_send_stock; }
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
        /// 炉号
        /// </summary>
        public string C_STOVE
        {
            set { _c_stove = value; }
            get { return _c_stove; }
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
        /// 执行标准
        /// </summary>
        public string C_STD_CODE
        {
            set { _c_std_code = value; }
            get { return _c_std_code; }
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
        /// 质量等级
        /// </summary>
        public string C_ZLDJ
        {
            set { _c_zldj = value; }
            get { return _c_zldj; }
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
        /// 车牌号
        /// </summary>
        public string C_LIC_PLA_NO
        {
            set { _c_lic_pla_no = value; }
            get { return _c_lic_pla_no; }
        }
        #endregion Model

    }
}
