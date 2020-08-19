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
    public class Mod_TMD_HY_PLAN
    {
        public Mod_TMD_HY_PLAN()
        { }

        public string C_ID { set; get; }

        /// <summary>
        /// 名称
        /// </summary>
        public string C_TITLE { set; get; }

        /// <summary>
        /// 计划数
        /// </summary>
        public decimal N_PLAN_NUM { set; get; }

        /// <summary>
        /// 已完成
        /// </summary>
        public decimal N_END_NUM { set; get; }

        /// <summary>
        /// 正装
        /// </summary>
        public decimal N_ZT_NUM { set; get; }
        /// <summary>
        /// 待装
        /// </summary>
        public decimal N_START_NUM { set; get; }

        /// <summary>
        /// 备注
        /// </summary>
        public string C_REMARK { set; get; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string C_EMP_NAME { set; get; }

        /// <summary>
        /// N/Y  添加/更新
        /// </summary>
        public string C_TYPE { set; get; }
        public DateTime D_DT { set; get; }
    }
}
