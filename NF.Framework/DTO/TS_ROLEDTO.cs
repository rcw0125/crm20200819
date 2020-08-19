using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    public class TS_ROLEDTO : BASEDTO
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [Required(ErrorMessage = "角色名称不能为空。")]
        public string C_NAME { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [Required(ErrorMessage = "编码不能为空。")]
        public string C_CODE { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string C_DESC { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int? N_STATUS { get; set; }

        public List<TS_ROLEDTO> Roles { get; set; }

        public string UserID { get; set; }

        public string RoleID { get; set; }

    }
}
