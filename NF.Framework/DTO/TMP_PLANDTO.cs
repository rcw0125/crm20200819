using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    public class TMP_PLANDTO : BASEDTO
    {
        /// <summary>
        /// 
        /// </summary>
        public string C_ID { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        [Display(Name = "订单号")]
        public string C_NO { get; set; }

        /// <summary>
        /// 合同号
        /// </summary>
        [Display(Name = "合同号")]
        public string C_CON_NO { get; set; }

        /// <summary>
        /// 计划发货时间
        /// </summary>
        [Display(Name = "计划发货时间")]
        public DateTime? D_PLANSEND_DT { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        [Display(Name = "物料编码")]
        public string C_MAT_CODE { get; set; }

        /// <summary>
        /// 物料名称
        /// </summary>
        [Display(Name = "物料名称")]
        public string C_MAT_NAME { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        [Display(Name = "规格")]
        public string C_SPEC { get; set; }

        /// <summary>
        /// 钢种
        /// </summary>
        [Display(Name = "钢种")]
        public string C_STL_GRD { get; set; }

        /// <summary>
        /// 质量等级
        /// </summary>
        [Display(Name = "质量等级")]
        public string C_QUALIRY_LEV { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [Display(Name = "数量")]
        public decimal? N_WGT { get; set; }

        /// <summary>
        /// 已发运数量
        /// </summary>
        [Display(Name = "已发运数量")]
        public decimal? N_SENDNUM_WGT { get; set; }

        /// <summary>
        /// 到站
        /// </summary>
        [Display(Name = "到站")]
        public string C_ATSTATION { get; set; }

        /// <summary>
        /// 到货地区
        /// </summary>
        [Display(Name = "到货地区")]
        public string C_AREA { get; set; }

        /// <summary>
        /// 到货地址
        /// </summary>
        [Display(Name = "到货地址")]
        public string C_ADDR { get; set; }

        /// <summary>
        /// 发运方式
        /// </summary>
        [Display(Name = "发运方式")]
        public string C_SHIPVIA { get; set; }

        /// <summary>
        ///  发运方式名称
        /// </summary>
        public string C_SHIPVIA_NAME { get; set; }

        /// <summary>
        /// 收货单位
        /// </summary>
        [Display(Name = "收货单位")]
        public string C_CGC { get; set; }

        /// <summary>
        /// 订货客户
        /// </summary>
        [Display(Name = "订货客户")]
        public string C_ORGO_CUST { get; set; }

        /// <summary>
        /// 发货库存组织
        /// </summary>
        [Display(Name = "发货库存组织")]
        public string C_SEND_STOCK_DEPT { get; set; }

        /// <summary>
        /// 计划状态
        /// </summary>
        [Display(Name = "计划状态")]
        public int? N_STATUS { get; set; }

        /// <summary>
        ///  计划状态名称
        /// </summary>
        public string C_STATUS_NAME { get; set; }

        /// <summary>
        /// 订单要求到货日期
        /// </summary>
        [Display(Name = "订单要求到货日期")]
        public DateTime? D_ORRE_AOG_DT { get; set; }

        /// <summary>
        /// 发货仓库
        /// </summary>
        [Display(Name = "发货仓库")]
        public string C_SEND_STOCK { get; set; }

        /// <summary>
        /// 到货库存组织
        /// </summary>
        [Display(Name = "到货库存组织")]
        public string C_AOG_STOCK_DEPT { get; set; }

        /// <summary>
        /// 到货仓库
        /// </summary>
        [Display(Name = "到货仓库")]
        public string C_AOG_STOCK { get; set; }

        /// <summary>
        /// 发货单位
        /// </summary>
        [Display(Name = "发货单位")]
        public string C_SEND_COM { get; set; }

        /// <summary>
        /// 销售公司
        /// </summary>
        [Display(Name = "销售公司")]
        public string C_SALE_COM { get; set; }

        /// <summary>
        /// 到货公司
        /// </summary>
        [Display(Name = "到货公司")]
        public string C_AOG_COM { get; set; }

        /// <summary>
        /// 发货地区
        /// </summary>
        [Display(Name = "发货地区")]
        public string C_SEND_AREA { get; set; }

        /// <summary>
        /// 发货地址
        /// </summary>
        [Display(Name = "发货地址")]
        public string C_SEND_ADDR { get; set; }

        /// <summary>
        /// 发货地点
        /// </summary>
        [Display(Name = "发货地点")]
        public string C_SEND_SITE { get; set; }

        /// <summary>
        /// 到货地点
        /// </summary>
        [Display(Name = "到货地点")]
        public string C_AOG_SITE { get; set; }

        /// <summary>
        /// 已出库数量
        /// </summary>
        [Display(Name = "已出库数量")]
        public decimal? N_OUT_STOCK_WGT { get; set; }

        /// <summary>
        /// 已签收数量
        /// </summary>
        [Display(Name = "已签收数量")]
        public decimal? N_SIGN_WGT { get; set; }

        /// <summary>
        /// 退回数量
        /// </summary>
        [Display(Name = "退回数量")]
        public decimal? N_BACK_WGT { get; set; }

        /// <summary>
        /// 途损主数量
        /// </summary>
        [Display(Name = "途损主数量")]
        public decimal? N_DAMAGE_WGT { get; set; }

        /// <summary>
        /// 制定计划日期
        /// </summary>
        [Display(Name = "制定计划日期")]
        public DateTime? D_FOR_PLAN_DT { get; set; }

        /// <summary>
        /// 制定计划人
        /// </summary>
        [Display(Name = "制定计划人")]
        public string C_FOR_PALN_ID { get; set; }

        /// <summary>
        /// 制定计划人名称
        /// </summary>
        [Display(Name = "制定计划人名称")]
        public string C_FOR_PALN_NAME { get; set; }

        /// <summary>
        /// 审批日期
        /// </summary>
        [Display(Name = "审批日期")]
        public DateTime? D_APPROVE_DT { get; set; }

        /// <summary>
        /// 审批人
        /// </summary>
        [Display(Name = "审批人")]
        public string C_APPROVE_ID { get; set; }


        /// <summary>
        /// 订单类型
        /// </summary>
        [Display(Name = "订单类型")]
        public string C_ORDER_TYPE { get; set; }

        /// <summary>
        /// 来源订单是否退
        /// </summary>
        [Display(Name = "来源订单是否退")]
        public int? N_SORO_BACK { get; set; }

        /// <summary>
        /// 来源订单是否退
        /// </summary>
        [Display(Name = "来源订单是否退")]
        public bool SORO_BACK { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string C_REMARK { get; set; }

        /// <summary>
        /// 业务部门
        /// </summary>
        [Display(Name = "业务部门")]
        public string C_BUSINESS_DEPT { get; set; }

        /// <summary>
        /// 业务部门名称
        /// </summary>
        [Display(Name = "业务部门名称")]
        public string C_BUSINESS_DEPT_NAME { get; set; }

        /// <summary>
        /// 业务类型
        /// </summary>
        [Display(Name = "业务类型")]
        public string C_BUSINESS_TYPE { get; set; }

        /// <summary>
        /// 业务员
        /// </summary>
        [Display(Name = "业务员")]
        public string C_SALESMAN { get; set; }

        /// <summary>
        /// 业务员名称
        /// </summary>
        [Display(Name = "业务员名称")]
        public string C_SALESMAN_NAME { get; set; }

        public List<TMP_PLANDTO> Plans { get; set; }
    }
}
