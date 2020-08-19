using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NF.EF.Model;

namespace NF.Framework.DTO
{
    public class TS_FUNCTIONDTO : BASEDTO
    {
        /// <summary>
        /// ID
        /// </summary>
        public string C_ID { get; set; }

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool Choice { get; set; }

        /// <summary>
        /// 权限编码
        /// </summary>
        [Required(ErrorMessage = "编码不能为空。")]
        public string C_CODE { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        [Required(ErrorMessage = "名称不能为空。")]
        public string C_NAME { get; set; }

        /// <summary>
        /// 控制器编码
        /// </summary>
        public string C_CONTROLLERCODE { get; set; }

        /// <summary>
        ///动作编码
        /// </summary>
        public string C_ACTIONCODE { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public int? C_TYPE { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string C_DESC { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int? N_STATUS { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public string RoleID { get; set; }

        /// <summary>
        /// 权限ID
        /// </summary>
        public string FunID { get; set; }

        /// <summary>
        /// 权限关联菜单ID
        /// </summary>
        public string MenuID { get; set; }

        /// <summary>
        /// 权限关联按钮ID
        /// </summary>
        public string ButtonID { get; set; }

        public List<TS_FUNCTIONDTO> Functions { get; set; }

        public List<TS_FUNCTIONDTO> MenuFuncs { get; set; }

        public List<TS_FUNCTIONDTO> ButtonFuncs { get; set; }

        public List<TS_FUNCTIONDTO> MenuSecondFuncs { get; set; }

        public List<TS_FUNCTIONDTO> ButtonSecondFuncs { get; set; }

    }
}
