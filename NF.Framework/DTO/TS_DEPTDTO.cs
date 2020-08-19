using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    public class TS_DEPTDTO : BASEDTO
    {
        [ScaffoldColumn(false)]
        [Display(Name = "编号")]
        public string C_ID { get; set; }

        [Display(Name = "父级ID")]
        public string C_PARENT_ID { get; set; }

        [Display(Name = "部门编码")]
        public string C_CODE { get; set; }

        [Display(Name = "部门名称")]
        public string C_NAME { get; set; }

        [Display(Name = "部门描述")]
        public string C_DESC { get; set; }

        [Display(Name = "状态")]
        public int? N_STATUS { get; set; }

        [Display(Name = "深度")]
        public int? C_DEPTH { get; set; }

        public string N_DEPTATTR { get; set; }

        public List<TS_DEPTDTO> Depts { get; set; }

        public string JsonDept { get; set; }

    }
}
