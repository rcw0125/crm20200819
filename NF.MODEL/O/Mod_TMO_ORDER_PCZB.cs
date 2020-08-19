using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.MODEL
{
    /// <summary>
    /// 订单排产指标
    /// </summary>
    [Serializable]
    public partial class Mod_TMO_ORDER_PCZB
    {
        /// <summary>
		/// 主键
		/// </summary>
		public string C_ID { set; get; }

        /// <summary>
        /// 区域
        /// </summary>
        public string C_AREA { set; get; }

        /// <summary>
        /// 月监控指标
        /// </summary>
        public decimal? N_MONTH_JK_ZB { set; get; }

        /// <summary>
        /// 月精品指标
        /// </summary>
        public decimal? N_MONTH_JP_ZB { set; get; }

        /// <summary>
        /// 月品种指标
        /// </summary>
        public decimal? N_MONTH_PZ_ZB { set; get; }

        /// <summary>
        /// 月普碳指标
        /// </summary>
        public decimal? N_MONTH_PT_ZB { set; get; }

        /// <summary>
        /// 旬监控指标
        /// </summary>
        public decimal? N_DAY_JK_ZB { set; get; }

        /// <summary>
        /// 旬精品指标
        /// </summary>
        public decimal? N_DAY_JP_ZB { set; get; }

        /// <summary>
        /// 旬品种指标
        /// </summary>
        public decimal? N_DAY_PZ_ZB { set; get; }

        /// <summary>
        /// 旬普碳指标
        /// </summary>
        public decimal? N_DAY_PT_ZB { set; get; }

        /// <summary>
        /// 正常合同实际需求总量
        /// </summary>
        public decimal? N_CON_WGT { set; get; }

        /// <summary>
        /// 计划排产日期
        /// </summary>
        public DateTime? D_PLAN_DT { set; get; }

        /// <summary>
        /// 1上旬 ，2中旬，3下旬
        /// </summary>
        public decimal? N_TYPE { set; get; }

        /// <summary>
        /// 制单人
        /// </summary>
        public string C_CREATE_ID { set; get; }

        /// <summary>
        /// 制单时间
        /// </summary>
        public DateTime? D_CREATE_DT { set; get; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        public string C_EMP_ID { set; get; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? D_EMP_DT { set; get; }

        /// <summary>
        /// N/Y 是否控制下发排产量
        /// </summary>
        public string C_FLAG { set; get; }

        /// <summary>
        /// 监控下发范围
        /// </summary>
        public decimal? N_PC_JK { set; get; }

        /// <summary>
        /// 精品下发范围
        /// </summary>
        public decimal? N_PC_JP { set; get; }

        /// <summary>
        /// 品种下发范围
        /// </summary>
        public decimal? N_PC_PZ { set; get; }

        /// <summary>
        /// 普碳下发范围
        /// </summary>
        public decimal? N_PC_PT { set; get; }

        /// <summary>
        /// N/Y INSERT /UPDATE
        /// </summary>
        public string C_TYPE2 { set; get; }

        /// <summary>
        /// 排序
        /// </summary>
        public int N_SORT { set; get; }
    }
}
