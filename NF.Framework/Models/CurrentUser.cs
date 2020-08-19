using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NF.EF.Model;
using NF.Framework.DTO;

namespace NF.Framework
{
    public class CurrentUser
    {
        /// <summary>
        /// ID
        /// </summary>
        [Display(Name = "ID")]
        public string Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        [Display(Name = "登录名")]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Display(Name = "密码")]
        public string Password { get; set; }

        /// <summary>
        /// 客户档案ID
        /// </summary>
        [Display(Name = "客户档案ID")]
        public string CustId { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        [Display(Name = "登录时间")]
        public DateTime LoginTime { get; set; }

        /// <summary>
        /// tokenID
        /// </summary>
        public string C_TOKEN_ID { get; set; }

        /// <summary>
        /// 客户档案
        /// </summary>
        [Display(Name = "客户档案")]
        public TS_CUSTFILEDTO CustFile { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public List<TS_DEPTDTO> Depts { get; set; }


        /// <summary>
        /// 用户菜单权限
        /// </summary>
        public List<TS_FUNCTIONDTO> MenuFuncs { get; set; }

        /// <summary>
        /// 用户按钮权限
        /// </summary>
        public List<TS_FUNCTIONDTO> ButtonFuncs { get; set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        public List<TS_ROLEDTO> Roles { get; set; }


        /// <summary>
        /// 客户类型
        /// </summary>
        public string Type { get; set; }


        /// <summary>
        /// 手机
        /// </summary>
        [Display(Name = "手机")]
        [RegularExpression(@"^1\d{10}$",
            ErrorMessage = "格式不正确。")]
        public string C_MOBILE { get; set; }
    }

    /// <summary>
    /// 用户
    /// </summary>
    public class AppCurrentUser
    {
        /// <summary>
        /// ID
        /// </summary>
        [Display(Name = "ID")]
        public string Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        [Display(Name = "登录名")]
        public string Account { get; set; }


        /// <summary>
        /// 客户档案ID
        /// </summary>
        [Display(Name = "客户档案ID")]
        public string CustId { get; set; }

        /// <summary>
        /// 客户档案ID
        /// </summary>
        [Display(Name = "客户档案No")]
        public string CustNo { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        [Display(Name = "客户名称")]
        public string CustName { get; set; }

        /// <summary>
        /// 客户电话
        /// </summary>
        [Display(Name = "客户电话")]
        public string CustTel { get; set; }

        /// <summary>
        /// 客户地址
        /// </summary>
        [Display(Name = "客户电话")]
        public string CustAddress { get; set; }

        /// <summary>
        /// 客户档案主键
        /// </summary>
        public string C_NC_M_ID { get; set; }


        /// <summary>
        /// 客户类型（1客户 2销售）
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 旧密码
        /// </summary>
        public string OldPw { get; set; }

        /// <summary>
        /// 新密码
        /// </summary>
        public string NewPw { get; set; }

    }

    /// <summary>
    /// 用户使用报告
    /// </summary>
    public class AppTmcCustReport
    {
        public string C_ID { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string C_CUST_NAME { get; set; }

        /// <summary>
        /// 公司编码
        /// </summary>
        public string C_CUST_NO { get; set; }

        /// <summary>
        /// 产品型号
        /// </summary>
        public string C_STL_GRD { get; set; }

        /// <summary>
        /// 产品规格
        /// </summary>
        public string C_SPEC { get; set; }

        /// <summary>
        /// 产品用途
        /// </summary>
        public string C_PROD_USE { get; set; }

        /// <summary>
        /// 产品使用情况
        /// </summary>
        public string C_PROD_CONTENT { get; set; }
    }

    /// <summary>
    /// 问卷满意度调查 主
    /// </summary>
    public class AppTmcCustEval
    {
        public string C_ID { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        public string C_AREA { get; set; }

        /// <summary>
        /// 客户
        /// </summary>
        public string C_CUST { get; set; }

        /// <summary>
        /// 直销/经销
        /// </summary>
        public int? N_CUST_TYPE { get; set; }

        /// <summary>
        /// 钢种大类
        /// </summary>
        public string C_PROD { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string C_TEL { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string C_REMARK { get; set; }

        public string C_EMP_ID { get; set; }
        public string C_EMP_NAME { get; set; }
        public DateTime D_MOD_DT { get; set; }
        public List<AppTmcCustEvalSub> Subs { get; set; }
    }

    /// <summary>
    /// 问卷满意度调查 子
    /// </summary>
    public class AppTmcCustEvalSub
    {
        public string C_ID { get; set; }

        /// <summary>
        /// 主表ID
        /// </summary>
        public string C_CUST_EVAL_ID { get; set; }

        /// <summary>
        /// 评价项目ID
        /// </summary>
        public string C_ITEM_ID { get; set; }

        /// <summary>
        /// 邢钢
        /// </summary>
        public int? N_XG_SCORE { get; set; }

        /// <summary>
        /// 台湾中钢
        /// </summary>
        public int? N_TWZG_SCORE { get; set; }

        /// <summary>
        /// 宝钢
        /// </summary>
        public int? N_BG_SCORE { get; set; }

        /// <summary>
        /// 武钢
        /// </summary>
        public int? N_WG_SCORE { get; set; }

        /// <summary>
        /// 兴澄特钢
        /// </summary>
        public int? N_XCTG_SCORE { get; set; }

        /// <summary>
        /// 沙钢
        /// </summary>
        public int? N_SG_SCORE { get; set; }

        /// <summary>
        /// 永钢
        /// </summary>
        public int? N_YG_SCORE { get; set; }

        /// <summary>
        /// 湘钢
        /// </summary>
        public int? N_XIANGG_SCORE { get; set; }

        /// <summary>
        /// 中天
        /// </summary>
        public int? N_ZT_SCORE { get; set; }

        public int? N_ITEM1 { get; set; }
        public int? N_ITEM2 { get; set; }
        public int? N_ITEM3 { get; set; }
        public int? N_ITEM4 { get; set; }
    }

    /// <summary>
    /// 评价项目
    /// </summary>
    public class AppEvalItem
    {
        public string C_ID { get; set; }
        public string C_NAME { get; set; }
    }

    /// <summary>
    /// 质量异议返馈
    /// </summary>
    public class AppQuality
    {
        /// <summary>
        /// C_ID
        /// </summary>
        public string C_ID
        {
            set;
            get;
        }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string C_CUST_NAME
        {
            set;
            get;
        }

        /// <summary>
        /// 客户类型：经销/直销
        /// </summary>
        public string C_CUST_TYPE
        {
            set;
            get;
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime Start
        {
            set;
            get;
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime End
        {
            set;
            get;
        }

        /// <summary>
        /// 质量问题ID
        /// </summary>
        public string C_QUEST_ID
        {
            set;
            get;
        }

        /// <summary>
        /// 钢种ID
        /// </summary>
        public string C_PROD_KIND_ID
        {
            set;
            get;
        }

        /// <summary>
        /// 发运方式
        /// </summary>
        public string C_SHIPVIA
        {
            set;
            get;
        }

        /// <summary>
        /// 发货开始时间
        /// </summary>
        [Required(ErrorMessage = "发货开始时间不能为空。")]
        public DateTime? D_SHIP_START_DT
        {
            set;
            get;
        }
        /// <summary>
        /// 发货到货时间
        /// </summary>
        [Required(ErrorMessage = "发货到货时间不能为空。")]
        public DateTime? D_SHIP_END_DT
        {
            set;
            get;
        }

        /// <summary>
        /// 母材剩余量
        /// </summary>
        [Required(ErrorMessage = "母材剩余量不能为空。")]
        public decimal? N_PARENT_REMAIN_WGT
        {
            set;
            get;
        }
        /// <summary>
        /// 中间产品剩余量
        /// </summary>
        [Required(ErrorMessage = "中间产品剩余量不能为空。")]
        public decimal? N_MIDDLE_REMAIN_WGT
        {
            set;
            get;
        }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string C_TEL
        {
            set;
            get;
        }

        /// <summary>
        /// 联系人
        /// </summary>
        public string C_NAME
        {
            set;
            get;
        }

        /// <summary>
        /// 钢种分类
        /// </summary>
        public string C_STL_GRD_CLASS
        {
            set;
            get;
        }

        /// <summary>
        /// 产品用途
        /// </summary>
        public string C_PROD_USE
        {
            set;
            get;
        }

        /// <summary>
        /// 8线材 6钢坯
        /// </summary>
        public string N_ORDERTYPE { get; set; }

        /// <summary>
        /// 投诉异议内容/信息内容
        /// </summary>
        public string C_OBJECT_CONTENT { get; set; }

        /// <summary>
        /// 用户工艺流程/生产工艺
        /// </summary>
        public string C_TECH_DESC { get; set; }

        /// <summary>
        /// 状态：-1未提交,0待处理,1处理中,2已完成
        /// </summary>
        public decimal? N_STATUS
        {
            set;
            get;
        }

        /// <summary>
        /// 标识：0 质量异议，1客户信息反馈
        /// </summary>
        public decimal? N_FLAG
        {
            set;
            get;
        }

        /// <summary>
        /// 母材支数(取样)/原始盘条样
        /// </summary>
        public int? N_PARENT_QUA
        {
            set;
            get;
        }

        /// <summary>
        /// 问题样支数(取样)/问题产品
        /// </summary>
        public decimal? N_QUEST_QUA
        {
            set;
            get;
        }

        /// <summary>
        /// 中间样支数(取样)/中间产品样
        /// </summary>
        public decimal? N_MIDDLE_QUA
        {
            set;
            get;
        }

        /// <summary>
        /// 明细
        /// </summary>
        public List<AppQuality_STL_GRD> Details
        { get; set; }

    }

    public class AppUser
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Tel { get; set; }
        public string EMail { get; set; }
        public string Money { get; set; }
    }

    public class AppCompany
    {
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
    }

    public class AppQuality_STL_GRD
    {
        /// <summary>
        /// 批号
        /// </summary>
        public string BatchNO
        {
            set;
            get;
        }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal? N_WGT { get; set; }

        /// <summary>
        /// 异议数量
        /// </summary>
        public decimal? N_OBJEC_WGT
        {
            set;
            get;
        }

        /// <summary>
        /// 发货数量
        /// </summary>
        public decimal? N_SHIP_WGT { get; set; }

        public decimal? N_ORDERTYPE { get; set; }

    }
}
