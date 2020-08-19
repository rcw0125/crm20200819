using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NF.Framework.DTO
{
    public class TMB_FLOWINFODTO : BASEDTO
    {
        /// <summary>
        /// 编号
        /// </summary>
        [ScaffoldColumn(false)]
        [Display(Name = "编号")]
        public string C_ID { get; set; }

        /// <summary>
        /// 流程名称
        /// </summary>
        [Display(Name = "流程名称")]
        [Required(ErrorMessage = "流程名称不能空")]
        public string C_NAME { get; set; }

        /// <summary>
        /// 流程处理说明
        /// </summary>
        [Display(Name = "流程处理说明")]
        [Required(ErrorMessage = "流程处理说明")]
        public string C_DESC { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Display(Name = "排序")]
        public int N_SORT { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string C_REMARK { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public int N_STATUS { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public int? N_TYPE { get; set; }

        public List<SelectListItem> items { get; set; }

        public List<TMB_FLOWINFODTO> FlowInfos { get; set; }

        public List<TMB_STEPINFODTO> StepInfos { get; set; }
    }
}
