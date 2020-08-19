using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

using NF.EF.Model;

namespace NF.Framework.DTO
{
    public class TS_USERDTO : BASEDTO
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
        public string C_NAME { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        [Display(Name = "登录名")]
        [Required(ErrorMessage = "登录名不能为空。")]
        //[Remote("User", "Validate", HttpMethod = "post", ErrorMessage = "登录名已经存在")]
        public string C_ACCOUNT { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "密码不能为空")]
        public string C_PASSWORD { get; set; }


        /// <summary>
        /// 邮箱
        /// </summary>
        [Display(Name = "邮箱")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "邮箱必填")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9]+\.[A-Za-z]{2,4}", ErrorMessage = "{0}的格式不正确")]
        public string C_EMAIL { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [Display(Name = "手机")]
        [RegularExpression(@"^1\d{10}$",
            ErrorMessage = "格式不正确。")]
        public string C_MOBILE { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public int N_STATUS { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [Display(Name = "类型")]
        public int N_TYPE { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        [Display(Name = "最后登录时间")]
        public DateTime D_LASTLOGINTIME { get; set; }

        /// <summary>
        /// 手机2
        /// </summary>
        [Display(Name = "手机2")]
        public string C_MOBILE2 { get; set; }

        /// <summary>
        /// 固定电话
        /// </summary>
        [Display(Name = "固定电话")]
        public string C_PHONE { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        [Display(Name = "公司名称")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "公司名称必填")]
        public string C_SHORTNAME { get; set; }

        /// <summary>
        /// 1多选 0单选
        /// </summary>
        [Display(Name = "查询类型")]
        public int C_QueryType { get; set; }

        /// <summary>
        /// 流程页面审批人html标记id
        /// </summary>
        public string HtmlApproveId { get; set; }

        /// <summary>
        ///  流程页面审批人名称html标记id
        /// </summary>
        public string HtmlApproveName { get; set; }

        public List<TS_USERDTO> Users { get; set; }

        /// <summary>
        /// 客户档案ID
        /// </summary>
        [Display(Name = "客户档案ID")]
        public string C_CUST_ID { get; set; }

        public TS_CUSTFILE CustFile { get; set; }

        public TS_USER_DEPT UserDept { get; set; }

        public string DeptID { get; set; }

        public string DeptName { get; set; }

        public string C_TOKEN_ID { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public string RoleID { get; set; }

        /// <summary>
        /// 角色列表
        /// </summary>
        public List<SelectListItem> Roles { get; set; }

        /// <summary>
        /// 厂家名称
        /// </summary>
        public string C_CJNAME { get; set; }

        /// <summary>
        /// 厂家简介
        /// </summary>
        public string C_CJINTRO { get; set; }

        /// <summary>
        /// 使用钢种
        /// </summary>
        public string C_STL_GRD { get; set; }

        /// <summary>
        /// 法人代表
        /// </summary>
        public string C_LEGALREPRES { get; set; }

        /// <summary>
        /// 采购决策人员姓名
        /// </summary>
        public string C_CGJCR { get; set; }

        /// <summary>
        /// 采购决策人员姓名职务
        /// </summary>
        public string C_JOB { get; set; }


        /// <summary>
        /// 采购决策人员电话
        /// </summary>
        public string C_JCTEL { get; set; }

        /// <summary>
        /// 具体地址
        /// </summary>
        public string C_ADDRESS { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        public string C_AREA { get; set; }

        /// <summary>
        /// 客户经理
        /// </summary>
        public string C_MANAGER { get; set; }

        // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        //[Range(typeof(decimal), "20.0", "30.0", ErrorMessage = "金额在{1}和{2}之间")]
        //[Compare("Email", ErrorMessage = "邮箱要相同")]
        //  [StringLength(20, MinimumLength = 6, ErrorMessage = "用户名不能大于{2} 且要小于{1}")]
    }
}
