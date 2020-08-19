using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NF.Framework.DTO
{
    public class TMO_CONDETAILSDTO : BASEDTO
    {
        /// <summary>
        /// 订单号(主键)
        /// </summary>
        public string C_ID
        {
            set;
            get;
        }

        public string C_ORDER_NO
        {
            get; set;
        }

        /// <summary>
        /// 合同号(外键)
        /// </summary>
        public string C_CON_NO
        {
            set;
            get;
        }
        /// <summary>
        /// 合同名称
        /// </summary>
        public string C_CON_NAME
        {
            set;
            get;
        }
        /// <summary>
        /// 区域
        /// </summary>
        public string C_AREA
        {
            set;
            get;
        }
        /// <summary>
        /// 公司ID
        /// </summary>
        public string C_XGID
        {
            set;
            get;
        }
        /// <summary>
        /// 存货档案主键
        /// </summary>
        public string C_INVBASDOCID
        {
            set;
            get;
        }
        /// <summary>
        /// 存货管理档案主键
        /// </summary>
        public string C_INVENTORYID
        {
            set;
            get;
        }
        /// <summary>
        /// 类别
        /// </summary>
        public string C_PROD_NAME
        {
            set;
            get;
        }
        /// <summary>
        /// 品种
        /// </summary>
        public string C_PROD_KIND
        {
            set;
            get;
        }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string C_MAT_CODE
        {
            set;
            get;
        }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string C_MAT_NAME
        {
            set;
            get;
        }
        /// <summary>
        /// 规格
        /// </summary>
        public string C_SPEC
        {
            set;
            get;
        }
        /// <summary>
        /// 钢种
        /// </summary>
        public string C_STL_GRD
        {
            set;
            get;
        }
        /// <summary>
        /// 产品用途
        /// </summary>
        public string C_PRO_USE
        {
            set;
            get;
        }
        /// <summary>
        /// 辅单位
        /// </summary>
        public string C_FUNITID
        {
            set;
            get;
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string C_UNITID
        {
            set;
            get;
        }
        /// <summary>
        /// 客户特殊要求
        /// </summary>
        public string C_CUST_SQ
        {
            set;
            get;
        }
        /// <summary>
        /// 需求日期
        /// </summary>
        public DateTime? D_NEED_DT
        {
            set;
            get;
        }
        /// <summary>
        /// 计划交货日期
        /// </summary>
        public DateTime? D_DELIVERY_DT
        {
            set;
            get;
        }
        /// <summary>
        /// 订单日期
        /// </summary>
        public DateTime? D_DT
        {
            set;
            get;
        }
        /// <summary>
        /// 客户协议号
        /// </summary>
        public string C_TECH_PROT
        {
            set;
            get;
        }
        /// <summary>
        /// 自由项
        /// </summary>
        public string C_FREE1
        {
            set;
            get;
        }
        /// <summary>
        /// 自由项2
        /// </summary>
        public string C_FREE2
        {
            set;
            get;
        }
        /// <summary>
        /// 包装要求
        /// </summary>
        public string C_PACK
        {
            set;
            get;
        }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal? N_WGT
        {
            set;
            get;
        }
        /// <summary>
        /// 收货地区
        /// </summary>
        public string C_CRECEIPTAREAID
        {
            set;
            get;
        }
        /// <summary>
        /// 收货地址
        /// </summary>
        public string C_RECEIVEADDRESS
        {
            set;
            get;
        }
        /// <summary>
        /// 收货单位
        /// </summary>
        public string C_RECEIPTAREAID
        {
            set;
            get;
        }

        /// <summary>
        /// 币种
        /// </summary>
        public string C_CURRENCYTYPEID
        {
            set;
            get;
        }
        /// <summary>
        /// 执行标准
        /// </summary>
        public string C_STD_CODE
        {
            set;
            get;
        }
        /// <summary>
        /// 质量设计号
        /// </summary>
        public string C_DESIGN_NO
        {
            set;
            get;
        }
        /// <summary>
        /// 执行标准ID
        /// </summary>
        public string C_STDID
        {
            set;
            get;
        }
        /// <summary>
        /// 质量设计ID
        /// </summary>
        public string C_DESIGNID
        {
            set;
            get;
        }
        /// <summary>
        /// 钢坯库存匹配量
        /// </summary>
        public decimal? N_SLAB_MATCH_WGT
        {
            set;
            get;
        }
        /// <summary>
        /// 线材库存匹配量
        /// </summary>
        public decimal? N_LINE_MATCH_WGT
        {
            set;
            get;
        }
        /// <summary>
        /// 合同状态：-1未提交，0待审，1审核中，2生效，3变更
        /// </summary>
        public decimal? N_STATUS
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_FLAG
        {
            set;
            get;
        }
        /// <summary>
        /// 订单类型: 6 钢坯，8线材
        /// </summary>
        public decimal? N_TYPE
        {
            set;
            get;
        }
        /// <summary>
        /// 执行状态:0未排产，1已排产
        /// </summary>
        public decimal? N_EXEC_STATUS
        {
            set;
            get;
        }
        /// <summary>
        /// 客户等级
        /// </summary>
        public decimal? N_USER_LEV
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
        /// 客户编码
        /// </summary>
        public string C_CUST_NO
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
        /// 分销类别（2直销/1经销）
        /// </summary>
        public string C_SALE_CHANNEL
        {
            set;
            get;
        }
        /// <summary>
        /// 维护等级：普通/买断/重点钢种/重点钢种买断
        /// </summary>
        public string C_LEV
        {
            set;
            get;
        }
        /// <summary>
        /// 订单等级
        /// </summary>
        public string C_ORDER_LEV
        {
            set;
            get;
        }
        /// <summary>
        /// 成本
        /// </summary>
        public decimal? N_COST
        {
            set;
            get;
        }
        /// <summary>
        /// 税率
        /// </summary>
        public decimal? N_TAXRATE
        {
            set;
            get;
        }
        /// <summary>
        /// 原币无税单价
        /// </summary>
        public decimal? N_ORIGINALCURPRICE
        {
            set;
            get;
        }
        /// <summary>
        /// 原币含税单价
        /// </summary>
        public decimal? N_ORIGINALCURTAXPRICE
        {
            set;
            get;
        }

        /// <summary>
        /// 原币税额
        /// </summary>
        public decimal? N_ORIGINALCURTAXMNY
        {
            set;
            get;
        }
        /// <summary>
        /// 原币无税金额
        /// </summary>
        public decimal? N_ORIGINALCURMNY
        {
            set;
            get;
        }
        /// <summary>
        /// 原币价税合计
        /// </summary>
        public decimal? N_ORIGINALCURSUMMNY
        {
            set;
            get;
        }

        /// <summary>
        /// 辅数量
        /// </summary>
        public decimal? N_FNUM
        {
            set;
            get;
        }
        /// <summary>
        /// 换算率
        /// </summary>
        public decimal? N_HSL
        {
            set;
            get;
        }
        /// <summary>
        /// 质量等级ID
        /// </summary>
        public string C_VDEF1
        {
            set;
            get;
        }

        /// <summary>
        /// 发运单订单列表
        /// </summary>
        public List<TMO_CONDETAILSDTO> ConDetails { get; set; }

        /// <summary>
        /// 发运单
        /// </summary>
        public TMD_DISPATCHDTO Dispatch { get; set; }

        /// <summary>
        /// 发运总量
        /// </summary>
        public decimal? DispatchSumWgt { get; set; }

        /// <summary>
        /// 发运总件数
        /// </summary>
        public decimal? DispatchSumQua { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [Display(Name = "开始时间")]
        public DateTime Start { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [Display(Name = "结束时间")]
        public DateTime End { get; set; }

        /// <summary>
        /// 区域信息
        /// </summary>
        public List<SelectListItem> AreaMaxs { get; set; }

        /// <summary>
        /// 区域信息
        /// </summary>
        public List<SelectListItem> Area { get; set; }

        /// <summary>
        /// 选中订单的订单号
        /// </summary>
        public string PitchConDeitailNo { get; set; }

        /// <summary>
        /// 撤销的发运单明细
        /// </summary>
        public string CancelDispatchOrderID { get; set; }

        /// <summary>
        /// 撤销的发运单数量
        /// </summary>
        public int CancelDispatchQua { get; set; }

        /// <summary>
        /// 撤销的发运单炉号
        /// </summary>
        public string CancelDispatchStove { get; set; }

        /// <summary>
        /// 撤销的发运单批号
        /// </summary>
        public string CancelDispatchBatchNo { get; set; }

        /// <summary>
        /// 补单订单号
        /// </summary>
        public string SupplementNo { get; set; }

        /// <summary>
        /// 补单数量
        /// </summary>
        public int SupplementQua { get; set; }

        /// <summary>
        /// 补单炉号
        /// </summary>
        public string SupplementStove { get; set; }

        /// <summary>
        /// 补单批号
        /// </summary>
        public string SupplementBatchNo { get; set; }

        /// <summary>
        /// 是否刷新页面
        /// </summary>
        public string IsRefresh { get; set; }

        /// <summary>
        /// 确定订单类型
        /// </summary>
        public decimal? ConfirmOrderType { get; set; }

        /// <summary>
        /// 页面面板记录
        /// </summary>
        public int TabIndex1 { get; set; }

        /// <summary>
        /// 页面面板记录
        /// </summary>
        public int TabIndex2 { get; set; }

        /// <summary>
        /// 件数
        /// </summary>
        public decimal? N_QUA { get; set; }

        /// <summary>
        /// 是否jsp
        /// </summary>
        public int IsGps { get; set; }

        /// <summary>
        /// 断面
        /// </summary>
        public string C_SLAB_SIZE { get; set; }

        /// <summary>
        /// 长度
        /// </summary>
        public int N_SLAB_LENGTH { get; set; }

    }
}
