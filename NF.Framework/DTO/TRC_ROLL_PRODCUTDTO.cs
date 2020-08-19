using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    public class TRC_ROLL_PRODCUTDTO : BASEDTO
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 组批表主键
        /// </summary>
        public string C_TRC_ROLL_MAIN_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 炉号
        /// </summary>
        public string C_STOVE
        {
            set;
            get;
        }
        /// <summary>
        /// 批号
        /// </summary>
        public string C_BATCH_NO
        {
            set;
            get;
        }
        /// <summary>
        /// 钩号
        /// </summary>
        public string C_TICK_NO
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
        /// 改判前钢种
        /// </summary>
        public string C_STL_GRD_BEFORE
        {
            set;
            get;
        }
        /// <summary>
        /// 打牌重量
        /// </summary>
        public decimal N_WGT
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
        /// 改判前标准
        /// </summary>
        public string C_STD_CODE_BEFORE
        {
            set;
            get;
        }
        /// <summary>
        /// 库存状态  'N'未综判 'E'已入库 ,'S'已销售,'O'已占用,Z转库
        /// </summary>
        public string C_MOVE_TYPE
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
        /// 班次
        /// </summary>
        public string C_SHIFT
        {
            set;
            get;
        }
        /// <summary>
        /// 班组
        /// </summary>
        public string C_GROUP
        {
            set;
            get;
        }

        /// <summary>
        /// 生产工位（外键）
        /// </summary>
        public string C_STA_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 表判等级
        /// </summary>
        public string C_JUDGE_LEV_BP
        {
            set;
            get;
        }
        /// <summary>
        /// 成分等级
        /// </summary>
        public string C_JUDGE_LEV_CF
        {
            set;
            get;
        }
        /// <summary>
        /// 性能等级
        /// </summary>
        public string C_JUDGE_LEV_XN
        {
            set;
            get;
        }
        /// <summary>
        /// 综合判定等级
        /// </summary>
        public string C_JUDGE_LEV_ZH
        {
            set;
            get;
        }
        /// <summary>
        /// 打牌班次
        /// </summary>
        public string C_DP_SHIFT
        {
            set;
            get;
        }
        /// <summary>
        /// 打牌班组
        /// </summary>
        public string C_DP_GROUP
        {
            set;
            get;
        }
        /// <summary>
        /// 打牌操作人
        /// </summary>
        public string C_DP_EMP_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 打牌时间
        /// </summary>
        public DateTime? D_DP_DT
        {
            set;
            get;
        }
        /// <summary>
        /// 工厂ID
        /// </summary>
        public string C_PLANT_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 工厂描述
        /// </summary>
        public string C_PLANT_DESC
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
        /// 改判前物料编码
        /// </summary>
        public string C_MAT_CODE_BEFORE
        {
            set;
            get;
        }
        /// <summary>
        /// 物料描述
        /// </summary>
        public string C_MAT_DESC
        {
            set;
            get;
        }
        /// <summary>
        /// 改判前物料描述
        /// </summary>
        public string C_MAT_DESC_BEFORE
        {
            set;
            get;
        }
        /// <summary>
        /// 库检状态 N:未处理，Y:已库检
        /// </summary>
        public string C_IS_DEPOT
        {
            set;
            get;
        }
        /// <summary>
        /// 计划号
        /// </summary>
        public string C_PLAN_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 订单号
        /// </summary>
        public string C_ORDER_NO
        {
            set;
            get;
        }
        /// <summary>
        /// 合同号
        /// </summary>
        public string C_CON_NO
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
        /// 是否自由状态货
        /// </summary>
        public string C_ISFREE
        {
            set;
            get;
        }
        /// <summary>
        /// 线材仓库编码
        /// </summary>
        public string C_LINEWH_CODE
        {
            set;
            get;
        }
        /// <summary>
        /// 线材区域编码
        /// </summary>
        public string C_LINEWH_AREA_CODE
        {
            set;
            get;
        }
        /// <summary>
        /// 库位编号
        /// </summary>
        public string C_LINEWH_LOC_CODE
        {
            set;
            get;
        }
        /// <summary>
        /// 层
        /// </summary>
        public string C_FLOOR
        {
            set;
            get;
        }
        /// <summary>
        /// 客户区域
        /// </summary>
        public string C_CUST_AREA
        {
            set;
            get;
        }
        /// <summary>
        /// 销售区域
        /// </summary>
        public string C_SALE_AREA
        {
            set;
            get;
        }

        public List<TRC_ROLL_PRODCUTDTO> RollProducts { get; set; }

        /// <summary>
        /// 出库量
        /// </summary>
        public decimal WareOutWgt { get; set; }

        /// <summary>
        /// 总量
        /// </summary>
        public decimal Wgt { get; set; }

        /// <summary>
        /// 工差最大量
        /// </summary>
        public decimal MaxWgt { get; set; }

        /// <summary>
        /// 工差最小量
        /// </summary>
        public decimal MinWgt { get; set; }


    }
}
