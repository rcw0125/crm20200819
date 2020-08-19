using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    /// <summary>
    /// 区域计划量
    /// </summary>
    public class TMB_AREAPLANDTO : BASEDTO
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Display(Name = "主键")]
        [ScaffoldColumn(false)]
        public string C_ID { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        [Display(Name = "区域")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string C_AERA_ID { get; set; }

        /// <summary>
        /// 区域名称
        /// </summary>
        [Display(Name = "区域名称")]
        public string C_AREA_NAME { get; set; }

        /// <summary>
        /// 计划量
        /// </summary>
        [Display(Name = "计划量")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(20, ErrorMessage = "{0}数值超出")]
        public decimal N_NUM { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [Display(Name = "开始时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime D_START { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [Display(Name = "结束时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime D_END { get; set; }

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

        public IEnumerable<TMB_AREAPLANDTO> AREAPLAN { get; set; }

    }
}
