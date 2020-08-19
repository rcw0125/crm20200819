using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.MODEL
{
    public class Mod_ApproveCon
    {
        /// <summary>
        /// 当前审批人
        /// </summary>
        public string C_EMP_ID { get; set; }
        /// <summary>
        /// 上一步骤ID
        /// </summary>
        public string UPSTEPID { get; set; }
        /// <summary>
        /// 下一步骤ID
        /// </summary>
        public string NEXTSTEPID { get; set; }

        /// <summary>
        /// 当前步骤ID
        /// </summary>
        public string STEPID { get; set; }

        /// <summary>
        /// 文件状态
        /// </summary>
        public string FILE_STATUS { get; set; }

        /// <summary>
        /// 文件ID
        /// </summary>
        public string FILEID { get; set; }

        /// <summary>
        /// 合同状态
        /// </summary>
        public string CON_STATUS { get; set; }

        /// <summary>
        /// 合同号
        /// </summary>
        public string CON_NO { get; set; }

        /// <summary>
        /// 质量异议检验结果
        /// </summary>
        public string JYRESULT { set; get; }

        /// <summary>
        /// 质量异议赔付金额
        /// </summary>
        public decimal PFMONEY { set; get; }

        /// <summary>
        /// 质量异议赔付日期
        /// </summary>
        public DateTime PFDATE { set; get; }
    }
}
