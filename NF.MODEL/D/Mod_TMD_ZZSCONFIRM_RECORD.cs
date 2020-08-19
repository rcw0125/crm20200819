using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.MODEL.D
{
    public class Mod_TMD_ZZSCONFIRM_RECORD
    {
        private string _c_id;
        private string _c_ckd;
        private string _c_fyd;
        private string _c_batch;
        private DateTime? _d_mod_dt;
        private string _c_emp_name;
        private string _c_emp_id;
        private string _c_state;
        private decimal? _n_type;
        /// <summary>
		/// C_ID
		/// </summary>
		public string C_ID
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 出库单号
        /// </summary>
        public string C_CKD
        {
            set { _c_ckd = value; }
            get { return _c_ckd; }
        }
        /// <summary>
        /// 发运单号
        /// </summary>
        public string C_FYD
        {
            set { _c_fyd = value; }
            get { return _c_fyd; }
        }
        /// <summary>
        /// 批号
        /// </summary>
        public string C_BATCH
        {
            set { _c_batch = value; }
            get { return _c_batch; }
        }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? D_MOD_DT
        {
            set { _d_mod_dt = value; }
            get { return _d_mod_dt; }
        }
        /// <summary>
        /// 操作人
        /// </summary>
        public string C_EMP_NAME
        {
            set { _c_emp_name = value; }
            get { return _c_emp_name; }
        }
        /// <summary>
        /// 操作人ID
        /// </summary>
        public string C_EMP_ID
        {
            set { _c_emp_id = value; }
            get { return _c_emp_id; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public string C_STATE
        {
            set {_c_state = value; }
            get { return _c_state; }
        }

        public decimal? N_TYPE
        {
            set { _n_type = value; }
            get { return _n_type; }
        }
    }
}
