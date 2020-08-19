using NF.EF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NF.Framework.DTO
{
    /// <summary>
    /// 数据字典
    /// </summary>
    public class TS_DICDTO : BASEDTO
    {
        /// <summary>
        /// 主键
        /// </summary>
        [ScaffoldColumn(false)]
        [Display(Name = "主键")]
        public string C_ID { get; set; }

        /// <summary>
        /// 类别编码
        /// </summary>    
        [Display(Name = "类别编码")]
        [Required(ErrorMessage = "类别编码不能为空。")]
        public string C_TYPECODE { get; set; }

        /// <summary>
        /// 类别名称
        /// </summary>
        [Display(Name = "类别名称")]
        [Required(ErrorMessage = "类别名称不能为空。")]
        public string C_TYPENAME { get; set; }

        /// <summary>
        /// 详细编码
        /// </summary>
        [Display(Name = "详细编码")]
        [Required(ErrorMessage = "详细编码不能为空。")]
        public string C_DETAILCODE { get; set; }

        /// <summary>
        /// 详细名称
        /// </summary>
        [Display(Name = "详细名称")]
        [Required(ErrorMessage = "详细名称不能为空。")]
        public string C_DETAILNAME { get; set; }

        /// <summary>
        /// 索引
        /// </summary>
        [Display(Name = "索引")]
        [RegularExpression(@"^\-?[0-9]+$",
            ErrorMessage = "格式不正确。")]
        [Required(ErrorMessage = "索引不能为空。")]
        public int C_INDEX { get; set; }

        /// <summary>
        /// 是否GPS
        /// </summary>
        [Display(Name = "是否GPS")]
        public int N_ISGPS { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public int N_STATUS { get; set; }

        /// <summary>
        /// 数据字典列表
        /// </summary>
        [Display(Name = "数据字典列表")]
        public List<TS_DICDTO> Dics { get; set; }

        public List<SelectListItem> DD_STATUAS { get; set; }

    }
}
