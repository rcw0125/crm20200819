using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    public class TMB_STEPINFODTO : BASEDTO
    {
        /// <summary>
        /// 编号
        /// </summary>
        [ScaffoldColumn(false)]
        [Display(Name = "编号")]
        public string C_ID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "姓名不能为空。")]
        public string C_NAME { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Display(Name = "描述")]
        [Required(ErrorMessage = "描述不能为空。")]
        public string C_DESC { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string C_REMARK { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Display(Name = "排序")]
        public int? N_SORT { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public int? N_STATUS { get; set; }

        /// <summary>
        /// 审批人ID
        /// </summary>
        [Display(Name = "审批人ID")]
        public string C_APPROVE_ID { get; set; }

        /// <summary>
        /// 审批人名称
        /// </summary>
        [Display(Name = "审批人名称")]
        public string C_APPROVE_Name { get; set; }

        /// <summary>
        /// 是否选中
        /// </summary>
        [Display(Name = "是否选中")]
        public bool IsCheck { get; set; }

        /// <summary>
        /// 处理方式
        /// </summary>
        [Display(Name = "处理方式")]
        public int? N_Type { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public int? N_SETP_TYPE { get; set; }

        public List<TMB_STEPINFODTO> SetpInfos { get; set; }
    }
}
