
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

using NF.EF.Model;

namespace NF.Framework.DTO
{
    public class TMQ_QUALITY_MAINDTO : BASEDTO
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
        /// 质量问题ID
        /// </summary>
        public string C_QUEST_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 品种ID
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
        [Range(typeof(decimal), "0", "99999999", ErrorMessage = "余量在{1}和{2}之间")]
        public decimal? N_PARENT_REMAIN_WGT
        {
            set;
            get;
        }
        /// <summary>
        /// 中间产品剩余量
        /// </summary>
        [Required(ErrorMessage = "中间产品剩余量不能为空。")]
        [Range(typeof(decimal), "0", "99999999", ErrorMessage = "余量在{1}和{2}之间")]
        public decimal? N_MIDDLE_REMAIN_WGT
        {
            set;
            get;
        }
        /// <summary>
        /// 区域:如华南销售大区
        /// </summary>
        public string C_AREA
        {
            set;
            get;
        }

        /// <summary>
        /// 区域:如华南销售大区
        /// </summary>
        public string C_AREA_NAME
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
        /// 客户编码
        /// </summary>
        public string C_CUST_NO
        {
            set;
            get;
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        [Display(Name = "手机")]
        [RegularExpression(@"^1\d{10}$",
               ErrorMessage = "格式不正确。")]
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
        /// 异议数量合计
        /// </summary>
        public decimal? N_OBJECT_COUNT_WGT
        {
            set;
            get;
        }
        /// <summary>
        /// 投诉异议内容/信息内容
        /// </summary>
        public string C_OBJECT_CONTENT
        {
            set;
            get;
        }
        /// <summary>
        /// 用户工艺流程/生产工艺
        /// </summary>
        public string C_TECH_DESC
        {
            set;
            get;
        }
        /// <summary>
        /// 现场调查情况
        /// </summary>
        public string C_SITE_SURVEY_CONTENT
        {
            set;
            get;
        }
        /// <summary>
        /// 母材支数(取样)/原始盘条样
        /// </summary>
        [Range(typeof(decimal), "1", "99999999", ErrorMessage = "余量在{1}和{2}之间")]
        public int? N_PARENT_QUA
        {
            set;
            get;
        }
        /// <summary>
        /// 问题样支数(取样)/问题产品
        /// </summary>
        [Range(typeof(decimal), "1", "99999999", ErrorMessage = "余量在{1}和{2}之间")]
        public decimal? N_QUEST_QUA
        {
            set;
            get;
        }
        /// <summary>
        /// 中间样支数(取样)/中间产品样
        /// </summary>
        [Range(typeof(decimal), "1", "99999999", ErrorMessage = "余量在{1}和{2}之间")]
        public decimal? N_MIDDLE_QUA
        {
            set;
            get;
        }
        /// <summary>
        /// 其他支数(取样)
        /// </summary>
        [Range(typeof(decimal), "1", "99999999", ErrorMessage = "余量在{1}和{2}之间")]
        public decimal? N_ELSE_QUA
        {
            set;
            get;
        }
        /// <summary>
        /// 现场调查人员
        /// </summary>
        public string C_SITE_SURVEY_EMP
        {
            set;
            get;
        }
        /// <summary>
        /// 本部门
        /// </summary>
        public string C_DEPT
        {
            set;
            get;
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string C_REMARK
        {
            set;
            get;
        }
        /// <summary>
        /// 制单人
        /// </summary>
        public string C_CUST_MAKING
        {
            set;
            get;
        }
        /// <summary>
        /// 制单时间
        /// </summary>
        public DateTime? C_CUST_MAKING_DT
        {
            set;
            get;
        }
        /// <summary>
        /// 型钢最后修改人
        /// </summary>
        public string C_XG_MODIFY
        {
            set;
            get;
        }
        /// <summary>
        /// 型钢最后修改日期
        /// </summary>
        public DateTime? C_XG_MODEIFY_DT
        {
            set;
            get;
        }
        /// <summary>
        /// 审批人
        /// </summary>
        public string C_APPROVER
        {
            set;
            get;
        }
        /// <summary>
        /// 审批时间
        /// </summary>
        public DateTime? D_APPROVER_DT
        {
            set;
            get;
        }
        /// <summary>
        /// 审批流程ID
        /// </summary>
        public string C_FLOW_ID
        {
            set;
            get;
        }
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

        public List<TMQ_QUALITY_MAINDTO> Qualitys { get; set; }

        /// <summary>
        /// 质量异议明细
        /// </summary>
        public List<TMQ_QUALITY_STL_GRDDTO> QualityStlGrds { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        public List<TMQ_QUALITY_FILEDTO> QualityFiles { get; set; }


        /// <summary>
        /// 制单时间
        /// </summary>
        public DateTime Start
        {
            set;
            get;
        }


        /// <summary>
        /// 制单时间
        /// </summary>
        public DateTime End
        {
            set;
            get;
        }

        /// <summary>
        /// 质控部
        /// </summary>
        public string C_DEPT2 { get; set; }

        /// <summary>
        /// 技术中心
        /// </summary>
        public string C_DEPT3 { get; set; }

        /// <summary>
        /// 其他部门
        /// </summary>
        public string C_DEPT4 { get; set; }

        /// <summary>
        /// 钢种大类
        /// </summary>
        public List<SelectListItem> StdMains { get; set; }

        /// <summary>
        /// 附件路径
        /// </summary>
        public string FileName1 { get; set; }

        /// <summary>
        /// 批号（根据批号获取钢种，规格，执行标准）
        /// </summary>
        [Range(typeof(decimal), "1", "999999999", ErrorMessage = "批号在{1}和{2}之间")]
        public string BatchNO { get; set; }

        /// <summary>
        /// 炉号（根据批号获取钢种，规格，执行标准）
        /// </summary>
        [Range(typeof(decimal), "1", "999999999", ErrorMessage = "炉号在{1}和{2}之间")]
        public string Stove { get; set; }

        /// <summary>
        /// 线材信息
        /// </summary>
        public List<TRC_ROLL_PRODCUT> Rolls { get; set; }

        /// <summary>
        /// 钢坯信息
        /// </summary>
        public List<TSC_SLAB_MAIN> Slabs { get; set; }

        /// <summary>
        /// 根据钢坯和线材查询不同的表（6钢坯 8线材）
        /// </summary>
        public string OrderType { get; set; }

        public decimal? N_ORDERTYPE { get; set; }

        /// <summary>
        /// 区分是修改还是新增
        /// </summary>
        public string ExecType { get; set; }

        /// <summary>
        /// 是质量异议处理
        /// </summary>
        public string IsOperation { get; set; }

    }
}


