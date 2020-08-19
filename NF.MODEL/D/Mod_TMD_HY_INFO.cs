using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.MODEL
{
    /// <summary>
    /// 火运车皮计划执行情况
    /// </summary>
    public class Mod_TMD_HY_INFO
    {
        public Mod_TMD_HY_INFO()
        { }

        public string C_ID { set; get; }

        /// <summary>
        /// 空车
        /// </summary>
        public decimal N_KC_NUM { set; get; }

        /// <summary>
        /// 重车
        /// </summary>
        public decimal N_ZC_NUM { set; get; }

        /// <summary>
        /// 到达预报
        /// </summary>
        public decimal N_YB_NUM { set; get; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string C_EMP_NAME { set; get; }

        /// <summary>
        /// N/Y  添加/更新
        /// </summary>
        public string C_TYPE { set; get; }
    }
}
