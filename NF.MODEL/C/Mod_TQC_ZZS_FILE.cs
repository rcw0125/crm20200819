using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.MODEL
{
    public class Mod_TQC_ZZS_FILE
    {

        /// <summary>
        /// 批号
        /// </summary>
        public string C_BATCH_NO { set; get; }
        /// <summary>
        /// 炉号
        /// </summary>
        public string C_STOVE { set; get; }
        /// <summary>
        /// 规格
        /// </summary>
        public string C_SPEC { set; get; }
        /// <summary>
        /// 钢种
        /// </summary>
        public string C_STL_GRD { set; get; }
        /// <summary>
        /// 执行标准
        /// </summary>
        public string C_STD_CODE { set; get; }


        /// <summary>
        /// PDF名称
        /// </summary>
        public string C_PDF_NAME { set; get; }
        /// <summary>
        /// PDF路径
        /// </summary>
        public string C_PDF_PATCH { set; get; }

        /// <summary>
        /// 上传时间
        /// </summary>
        public string D_QZRQ { set; get; }
        /// <summary>
        /// 使用状态   1-可用；0-停用
        /// </summary>
        public string N_STATUS { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        public string C_REMARK { set; get; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string C_EMP_ID { set; get; }
    }
}
