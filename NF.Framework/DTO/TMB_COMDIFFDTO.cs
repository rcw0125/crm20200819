using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    public class TMB_COMDIFFDTO : BASEDTO
    {
        /// <summary>
        /// 主键
        /// </summary>
        [ScaffoldColumn(false)]
        [Display(Name = "主键")]
        public string C_ID { get; set; }

        /// <summary>
        /// 最小值
        /// </summary>
        [Range(typeof(int), "0", "1000000", ErrorMessage = "数值在{1}和{2}之间")]
        [Display(Name = "最小值")]
        public int? D_MIN { get; set; }

        /// <summary>
        /// 最大值
        /// </summary>
        [Range(typeof(int), "0", "1000000", ErrorMessage = "数值在{1}和{2}之间")]
        [Display(Name = "最大值")]
        public int? D_MAX { get; set; }

        /// <summary>
        /// 误差范围
        /// </summary>
        [Display(Name = "误差范围")]
        [Required(ErrorMessage = "误差范围不能为空。")]
        //[Range(typeof(int), "0", "1000", ErrorMessage = "误差范围在{1}和{2}之间")]
        public string C_RANGE { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public int N_STATUS { get; set; }

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

        /// <summary>
        /// 集合
        /// </summary>
        public List<TMB_COMDIFFDTO> ComDiffs { get; set; }
    }
}
