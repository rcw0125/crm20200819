using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    public class TMD_DISPATCHDETAILSDTO : BASEDTO
    {
        /// <summary>
        /// 发运单详情单据号
        /// </summary>
        [ScaffoldColumn(false)]
        [Display(Name = "编号")]
        public string C_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 发运单单据号
        /// </summary>
        public string C_DISPATCH_ID
        {
            set;
            get;
        }

        /// <summary>
        /// 炉号
        /// </summary>
        public string C_STOVE { get; set; }

        /// <summary>
        /// 批号
        /// </summary>
        public string C_BATCH_NO { get; set; }


        /// <summary>
        /// 勾号
        /// </summary>
        public string C_TICK_NO { get; set; }

        /// <summary>
        /// 钢坯号
        /// </summary>
        public string C_SLAB_NO { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        public string C_MAT_CODE
        {
            set;
            get;
        }

        /// <summary>
        /// 日计划单据号
        /// </summary>
        public string C_PLAN_ID
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
        /// 发货仓库
        /// </summary>
        public string C_SEND_STOCK
        {
            set;
            get;
        }
        /// <summary>
        /// 质量等级
        /// </summary>
        public string C_QUALIRY_LEV
        {
            set;
            get;
        }
        /// <summary>
        /// 自由项
        /// </summary>
        public string C_FREE_TERM
        {
            set;
            get;
        }
        /// <summary>
        /// 其他要求
        /// </summary>
        public string C_ELSENEED
        {
            set;
            get;
        }
        /// <summary>
        /// 辅数量
        /// </summary>
        public decimal? N_COM_AMOUNT_WGT
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
        /// 换算率
        /// </summary>
        public string C_EQUATION_FACTOR
        {
            set;
            get;
        }
        /// <summary>
        /// 已出库数量
        /// </summary>
        public decimal? N_OUT_STOCK_WGT
        {
            set;
            get;
        }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string C_UNITIS
        {
            set;
            get;
        }
        /// <summary>
        /// 发货地点
        /// </summary>
        public string C_SEND_SITE
        {
            set;
            get;
        }
        /// <summary>
        /// 到货地点
        /// </summary>
        public string C_AOG_SITE
        {
            set;
            get;
        }
        /// <summary>
        /// 订货客户
        /// </summary>
        public string C_ORGO_CUST
        {
            set;
            get;
        }
        /// <summary>
        /// 收货单位
        /// </summary>
        public string C_CGC
        {
            set;
            get;
        }
        /// <summary>
        /// 是否已出库关闭
        /// </summary>
        public decimal? N_IS_SEND_CLOSE
        {
            set;
            get;
        }
        /// <summary>
        /// 订单类型
        /// </summary>
        public string C_ORDER_TYPE
        {
            set;
            get;
        }
        /// <summary>
        /// 发货地区
        /// </summary>
        public string C_SEND_AREA
        {
            set;
            get;
        }
        /// <summary>
        /// 到货地区
        /// </summary>
        public string C_AREA
        {
            set;
            get;
        }
        /// <summary>
        /// 副计量单位
        /// </summary>
        public string C_AU_UNITIS
        {
            set;
            get;
        }
        /// <summary>
        /// 客户基本档案主键
        /// </summary>
        public string C_CUSTFILE_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 客户ID
        /// </summary>
        public string C_CUST_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 行备注
        /// </summary>
        public string C_REMARK
        {
            set;
            get;
        }
        /// <summary>
        /// 计算毛重日期
        /// </summary>
        public decimal? D_CAL_FAKE_WGT_DT
        {
            set;
            get;
        }
        /// <summary>
        /// 计算毛重
        /// </summary>
        public decimal? N_CAL_FAKE_WGT
        {
            set;
            get;
        }
        /// <summary>
        /// 计算皮重
        /// </summary>
        public decimal? N_CAL_PACK_WGT
        {
            set;
            get;
        }
        /// <summary>
        /// 计算净重
        /// </summary>
        public decimal? N_CAL_TRUE_WGT
        {
            set;
            get;
        }
        /// <summary>
        /// 计算毛量时间
        /// </summary>
        public decimal? N_CAL_FAKE_WGT_DT
        {
            set;
            get;
        }
        /// <summary>
        /// 计算皮重时间
        /// </summary>
        public decimal? N_CAL_PACK_WGT_DT
        {
            set;
            get;
        }

        /// <summary>
        /// 实绩数量
        /// </summary>
        public decimal? N_ACTUAL_WGT { get; set; }

        /// <summary>
        /// 件数
        /// </summary>
        public int? N_QUA { get; set; }

        /// <summary>
        /// 合同号
        /// </summary>
        public string C_CON_NO { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string C_NO { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public string C_PRODUCT_ID { get; set; }

        /// <summary>
        /// 综合判定结果(SX)
        /// </summary>
        public string C_JUDGE_LEV_ZH { get; set; }

        /// <summary>
        /// 执行标准
        /// </summary>
        public string C_STD_CODE { get; set; }

        /// <summary>
        ///是否选中
        /// </summary>
        public bool Check { get; set; }

        /// <summary>
        /// 修改时确认新增标记
        /// </summary>
        public int Flag { get; set; }

        /// <summary>
        /// 自由项
        /// </summary>
        public string C_FREE_TERM2 { get; set; }

        /// <summary>
        /// 包装
        /// </summary>
        public string C_PACK { get; set; }

    }
}
