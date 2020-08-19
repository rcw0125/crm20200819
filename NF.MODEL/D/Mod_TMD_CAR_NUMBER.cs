using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.MODEL.D
{

    /// <summary>
    /// 车牌号启停用表
    /// </summary>
    [Serializable]
    public partial class Mod_TMD_CAR_NUMBER
    {
        public Mod_TMD_CAR_NUMBER()
        { }
        #region Model
        private string _c_id = "SYS_GUID";
        private string _c_number;
        private decimal _n_status = 1;
        private string _c_emp_id;
        private DateTime _d_mod_dt;

        public string C_TYPE { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string C_ID
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string C_NUMBER
        {
            set { _c_number = value; }
            get { return _c_number; }
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
        #endregion Model

    }
}
