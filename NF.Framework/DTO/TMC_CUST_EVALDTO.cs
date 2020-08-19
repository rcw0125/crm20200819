using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NF.Framework.DTO
{
    public class TMC_CUST_EVALDTO : BASEDTO
    {
        public string C_ID { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        public string C_AREA { get; set; }

        /// <summary>
        /// 客户
        /// </summary>
        public string C_CUST { get; set; }

        /// <summary>
        /// 客户类型
        /// </summary>
        public int N_CUST_TYPE { get; set; }

        /// <summary>
        /// 主要采购产品名称/产品名称
        /// </summary>
        [Required(ErrorMessage ="不能为空")]
        public string C_PROD { get; set; }

        /// <summary>
        /// 主要采购产品名称/产品名称
        /// </summary>
        public string C_PROD_NAME { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string C_TEL { get; set; }

        /// <summary>
        /// 其他意见和要求
        /// </summary>
        public string C_REMARK { get; set; }

        public List<TMC_EVAL_ITEMDTO> EvalItems { get; set; }

        public List<TMC_CUST_EVAL_SUBDTO> EvalSubs { get; set; }

        public List<SelectListItem> StdMains { get; set; }

        public List<TMC_CUST_EVALDTO> CustEvals { get; set; }


        /// <summary>
        /// 开始时间
        /// </summary>
        [Display(Name = "开始时间")]
        public DateTime Start { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [Display(Name = "结束时间")]
        public DateTime End { get; set; }

    }
}
