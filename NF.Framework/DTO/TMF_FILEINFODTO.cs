using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NF.Framework.DTO
{
    public class TMF_FILEINFODTO : BASEDTO
    {
        /// <summary>
        /// ID
        /// </summary>
        public string C_ID { get; set; }

        /// <summary>
        /// 流程ID
        /// </summary>
        public string C_FLOW_ID { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string C_TITLE { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string C_CONTENT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string C_FILEURL { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int N_STATUS { get; set; }

        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime D_SB_DT { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string C_REMARK { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public int N_TYPE { get; set; }

        /// <summary>
        /// 任务ID
        /// </summary>
        public string C_TASK_ID { get; set; }

        /// <summary>
        /// 步骤
        /// </summary>
        public string C_STEP_ID { get; set; }

        /// <summary>
        /// 审批人
        /// </summary>
        public string C_NEXT_EMP_ID { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        public string hidEmpID { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        public string hidSetpID { get; set; }

        public List<SelectListItem> ListItem { get; set; }
    }
}
