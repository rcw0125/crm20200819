using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    public class TMQ_QUALITY_MAIN_LOGDTO : BASEDTO
    {
        /// <summary>
		/// C_ID
		/// </summary>
		public string C_ID
        {
            set ;
            get;
        }
        /// <summary>
        /// 质量异议主表ID
        /// </summary>
        public string C_QUALITY_ID
        {
            set ;
            get;
        }
        /// <summary>
        /// 质量问题ID
        /// </summary>
        public string C_QUEST_ID
        {
            set ;
            get;
        }
        /// <summary>
        /// 品种ID
        /// </summary>
        public string C_PROD_KIND_ID
        {
            set ;
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
        public DateTime? D_SHIP_START_DT
        {
            set ;
            get;
        }
        /// <summary>
        /// 发货到货时间
        /// </summary>
        public DateTime? D_SHIP_END_DT
        {
            set ;
            get;
        }
        /// <summary>
        /// 母材剩余量
        /// </summary>
        public decimal? N_PARENT_REMAIN_WGT
        {
            set;
            get;
        }
        /// <summary>
        /// 中间产品剩余量
        /// </summary>
        public decimal? N_MIDDLE_REMAIN_WGT
        {
            set ;
            get;
        }
        /// <summary>
        /// 区域:如华南销售大区
        /// </summary>
        public string C_AREA
        {
            set ;
            get;
        }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string C_CUST_NAME
        {
            set ;
            get;
        }
        /// <summary>
        /// 客户类型：经销/直销
        /// </summary>
        public string C_CUST_TYPE
        {
            set ;
            get;
        }
        /// <summary>
        /// 客户编码
        /// </summary>
        public string C_CUST_NO
        {
            set ;
            get;
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string C_TEL
        {
            set ;
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
            set ;
            get;
        }
        /// <summary>
        /// 产品用途
        /// </summary>
        public string C_PROD_USE
        {
            set ;
            get;
        }
        /// <summary>
        /// 异议数量合计
        /// </summary>
        public decimal? N_OBJECT_COUNT_WGT
        {
            set ;
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
            set ;
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
        public decimal? N_PARENT_QUA
        {
            set ;
            get;
        }
        /// <summary>
        /// 问题样支数(取样)/问题产品
        /// </summary>
        public decimal? N_QUEST_QUA
        {
            set ;
            get;
        }
        /// <summary>
        /// 中间样支数(取样)/中间产品样
        /// </summary>
        public decimal? N_MIDDLE_QUA
        {
            set ;
            get;
        }
        /// <summary>
        /// 其他支数(取样)
        /// </summary>
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
            set ;
            get;
        }
        /// <summary>
        /// 部门
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
            set ;
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
            set ;
            get;
        }
        /// <summary>
        /// 型钢最后修改日期
        /// </summary>
        public DateTime? C_XG_MODEIFY_DT
        {
            set ;
            get;
        }
        /// <summary>
        /// 审批人
        /// </summary>
        public string C_APPROVER
        {
            set ;
            get;
        }
        /// <summary>
        /// 审批时间
        /// </summary>
        public DateTime? D_APPROVER_DT
        {
            set ;
            get;
        }
        /// <summary>
        /// 审批流程ID
        /// </summary>
        public string C_FLOW_ID
        {
            set ;
            get;
        }
        /// <summary>
        /// 状态：-1未提交,0待处理,1处理中,2已完成
        /// </summary>
        public decimal? N_STATUS
        {
            set ;
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
        
    }
}
