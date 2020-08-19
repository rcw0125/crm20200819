using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace NF.Framework.DTO
{
    public class TS_MENUDTO : BASEDTO
    {
        public TS_MENUDTO() { Menus = new List<TS_MENUDTO>(); }

        /// <summary>
        /// 编号
        /// </summary>
        [Display(Name = "编号")]
        [ScaffoldColumn(false)]
        public string C_ID { get; set; }

        /// <summary>
        /// 父级编号
        /// </summary>
        [Display(Name = "父级编号")]
        public string C_PARENT_ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Display(Name = "名称")]
        public string C_NAME { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Display(Name = "描述")]
        public string C_DESC { get; set; }

        /// <summary>
        /// URL
        /// </summary>
        [Display(Name = "URL")]
        public string C_URL { get; set; }

        /// <summary>
        /// N级菜单路径
        /// </summary>
        [Display(Name = "N级菜单路径")]
        public string N_SOURCEPATH { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public int N_STATUS { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        [Display(Name = "等级")]
        public int N_MENULEVEL { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Display(Name = "排序")]
        public int N_SORT { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [Display(Name = "图标")]
        public string C_ICON { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public int N_TYPE { get; set; }

        public List<TS_MENUDTO> Menus { get; set; }

        public List<SelectListItem> Levels { get; set; }

        public List<SelectListItem> MenuItems { get; set; }
    }
}
