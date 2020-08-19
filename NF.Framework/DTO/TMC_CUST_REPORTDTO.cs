using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    public class TMC_CUST_REPORTDTO : BASEDTO
    {
        /// <summary>
        /// 
        /// </summary>
        public string C_ID { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        [Required(ErrorMessage = "公司名称不能为空。")]
        public string C_CUST_NAME { get; set; }

        /// <summary>
        /// 公司编码
        /// </summary>
        public string C_CUST_NO { get; set; }

        /// <summary>
        /// 产品型号
        /// </summary>
        [Required(ErrorMessage = "产品型号不能为空。")]
        public string C_STL_GRD { get; set; }

        /// <summary>
        /// 产品规格
        /// </summary>
        [Required(ErrorMessage = "产品规格不能为空。")]
        public string C_SPEC { get; set; }

        /// <summary>
        /// 产品用途
        /// </summary>
        [Required(ErrorMessage = "产品用途不能为空。")]
        public string C_PROD_USE { get; set; }

        /// <summary>
        /// 产品使用情况
        /// </summary>
        [Required(ErrorMessage = "产品使用情况不能为空。")]
        public string C_PROD_CONTENT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<TMC_CUST_REPORTDTO> CustReports { get; set; }

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
