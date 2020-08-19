using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    public class TSC_SLAB_MAINDTO : BASEDTO
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
        /// 计划ID
        /// </summary>
        public string C_PLAN_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 订单号
        /// </summary>
        public string C_ORD_NO
        {
            set;
            get;
        }
        /// <summary>
        /// 1炉号
        /// </summary>
        public string C_STOVE
        {
            set;
            get;
        }
        /// <summary>
        /// 1铸机号 
        /// </summary>
        public string C_STA_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 铸机编码
        /// </summary>
        public string C_STA_CODE
        {
            set;
            get;
        }
        /// <summary>
        /// 铸机描述
        /// </summary>
        public string C_STA_DESC
        {
            set;
            get;
        }
        /// <summary>
        /// 1钢种
        /// </summary>
        public string C_STL_GRD
        {
            set;
            get;
        }
        /// <summary>
        /// 改判前钢种
        /// </summary>
        public string C_STL_GRD_PRE
        {
            set;
            get;
        }
        /// <summary>
        /// 1物料编码 
        /// </summary>
        public string C_MAT_CODE
        {
            set;
            get;
        }
        /// <summary>
        /// 1物料名称
        /// </summary>
        public string C_MAT_NAME
        {
            set;
            get;
        }
        /// <summary>
        /// 1规格 
        /// </summary>
        public string C_SPEC
        {
            set;
            get;
        }
        /// <summary>
        /// 1长度
        /// </summary>
        public decimal N_LEN
        {
            set;
            get;
        }
        /// <summary>
        /// 1支数
        /// </summary>
        public decimal N_QUA
        {
            set;
            get;
        }
        /// <summary>
        /// 1单重
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
        /// 自备坯R,销售坯S
        /// </summary>
        public string C_SLAB_TYPE
        {
            set;
            get;
        }
        /// <summary>
        /// 连铸收料时间
        /// </summary>
        public DateTime? D_CCM_DATE
        {
            set;
            get;
        }
        /// <summary>
        /// 连铸收料班次
        /// </summary>
        public string C_CCM_SHIFT
        {
            set;
            get;
        }
        /// <summary>
        /// 连铸收料班组
        /// </summary>
        public string C_CCM_GROUP
        {
            set;
            get;
        }
        /// <summary>
        /// 连铸收料员工号
        /// </summary>
        public string C_CCM_EMP_ID
        {
            set;
            get;
        }
        /// <summary>
        /// N炼钢接收待入库CN剔除坯待入库CE剔除坯入库MN修磨待入库ME修磨入库PN开坯待入库PE开坯入库STN销售退坯待入库STE销售退坯入库D调拨DE调拨入库NZ待轧NP待开坯NM待修磨S销售
        /// </summary>
        public string C_MOVE_TYPE
        {
            set;
            get;
        }
        /// <summary>
        /// 入出缓冷坑 N 未如坑 E在坑内，H已缓冷
        /// </summary>
        public string C_SC_STATE
        {
            set;
            get;
        }
        /// <summary>
        /// 入坑时间
        /// </summary>
        public DateTime? D_ESC_DATE
        {
            set;
            get;
        }
        /// <summary>
        /// 出坑时间
        /// </summary>
        public DateTime? D_LSC_DATE
        {
            set;
            get;
        }
        /// <summary>
        /// 是否开坯Y 
        /// </summary>
        public string C_QKP_STATE
        {
            set;
            get;
        }
        /// <summary>
        /// 开坯前坯料主键
        /// </summary>
        public string C_KP_ID
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
        /// 客户代码
        /// </summary>
        public string C_CUS_NO
        {
            set;
            get;
        }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string C_CUS_NAME
        {
            set;
            get;
        }
        /// <summary>
        /// 出库时间
        /// </summary>
        public DateTime? D_WL_DATE
        {
            set;
            get;
        }
        /// <summary>
        /// 出库班次
        /// </summary>
        public string C_WL_SHIFT
        {
            set;
            get;
        }
        /// <summary>
        /// 出库班组
        /// </summary>
        public string C_WL_GROUP
        {
            set;
            get;
        }
        /// <summary>
        /// 出库员工号
        /// </summary>
        public string C_WL_EMP_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 1入库时间
        /// </summary>
        public DateTime? D_WE_DATE
        {
            set;
            get;
        }
        /// <summary>
        /// 入库班次
        /// </summary>
        public string C_WE_SHIFT
        {
            set;
            get;
        }
        /// <summary>
        /// 入库班组
        /// </summary>
        public string C_WE_GROUP
        {
            set;
            get;
        }
        /// <summary>
        /// 入库员工号
        /// </summary>
        public string C_WE_EMP_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 1库存状态 W:待判/F：已判定
        /// </summary>
        public string C_STOCK_STATE
        {
            set;
            get;
        }
        /// <summary>
        /// 1判定等级:合格品/协议品/待判/不合格品
        /// </summary>
        public string C_MAT_TYPE
        {
            set;
            get;
        }
        /// <summary>
        /// 是否改判Y 
        /// </summary>
        public string C_QGP_STATE
        {
            set;
            get;
        }
        /// <summary>
        /// 钢坯仓库编码
        /// </summary>
        public string C_SLABWH_CODE
        {
            set;
            get;
        }
        /// <summary>
        /// 钢坯库区域编码
        /// </summary>
        public string C_SLABWH_AREA_CODE
        {
            set;
            get;
        }
        /// <summary>
        /// 库位编号
        /// </summary>
        public string C_SLABWH_LOC_CODE
        {
            set;
            get;
        }
        /// <summary>
        /// 层编码
        /// </summary>
        public string C_SLABWH_TIER_CODE
        {
            set;
            get;
        }
        /// <summary>
        /// 确认1  综合判定结果
        /// </summary>
        public string C_Q_RESULT
        {
            set;
            get;
        }
        /// <summary>
        /// 判定时间 ((综判）
        /// </summary>
        public DateTime? D_Q_DATE
        {
            set;
            get;
        }
        /// <summary>
        /// 判废原因(综判）
        /// </summary>
        public string C_Q_NOTE
        {
            set;
            get;
        }
        /// <summary>
        /// 米单重
        /// </summary>
        public decimal? N_WGT_METER
        {
            set;
            get;
        }
        /// <summary>
        /// 表面判定人
        /// </summary>
        public string C_QF_NAME
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
        /// 1责任部门
        /// </summary>
        public string C_ZRBM
        {
            set;
            get;
        }
        /// <summary>
        /// 1是否库检 0：是 1：否
        /// </summary>
        public string C_IS_DEPOT
        {
            set;
            get;
        }
        /// <summary>
        /// 是否修磨
        /// </summary>
        public string C_ISXM
        {
            set;
            get;
        }
        /// <summary>
        /// 修磨工序，修磨>扒皮
        /// </summary>
        public string C_XMGX
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
        /// 成分等级
        /// </summary>
        public string C_JUDGE_LEV_CF { get; set; }

        /// <summary>
        /// 性能等级
        /// </summary>
        public string C_JUDGE_LEV_XN { get; set; }

        /// <summary>
        /// 综合判定等级
        /// </summary>
        public string C_JUDGE_LEV_ZH { get; set; }

        /// <summary>
        /// 人工判定等级
        /// </summary>
        public string C_JUDGE_LEV_ZH_PEOPLE { get; set; }

        /// <summary>
        /// 批号
        /// </summary>
        public string C_BATCH_NO { get; set; }

        /// <summary>
        /// 刚批号
        /// </summary>
        public string C_SLAB_NO { get; set; }

        public List<TSC_SLAB_MAINDTO> SlabMains { get; set; }


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
