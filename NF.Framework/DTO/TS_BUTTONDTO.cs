using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    public class TS_BUTTONDTO : BASEDTO
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string C_BUTTONCODE { get; set; }

        /// <summary>
        /// 菜单ID
        /// </summary>  
        public string C_MENU_ID { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        [Required(ErrorMessage = "菜单不能为空")]
        public string C_MENU_NAME { get; set; }

        /// <summary>
        /// 按钮名称
        /// </summary>
        [Required(ErrorMessage = "按钮不能为空")]
        public string C_NAME { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? N_ISVISIBLE { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Required(ErrorMessage = "描述不能为空")]
        public string C_DESC { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [Required(ErrorMessage = "Code不能为空")]
        public string C_CODE { get; set; }

        /// <summary>
        /// 状态0停用1启用
        /// </summary>
        public decimal? N_STATUS { get; set; }

        /// <summary>
        /// 索引
        /// </summary>
        public decimal? N_INDEX { get; set; }

        /// <summary>
        /// 按钮列表
        /// </summary>
        public List<TS_BUTTONDTO> Buttons { get; set; }

    }
}
