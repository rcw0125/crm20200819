using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.MODEL
{
    /// <summary>
    /// 发运指标
    /// </summary>
    public class Mod_TMD_FYZB
    {
        public Mod_TMD_FYZB()
        { }

        public string C_TYPE { set; get; }

        /// <summary>
        /// 排序
        /// </summary>

        public int N_SORT { set; get; }


        /// <summary>
        /// ID
        /// </summary>
        public string C_ID { set; get; }
        /// <summary>
        /// 部门
        /// </summary>
        public string C_DEPT { set; get; }
        /// <summary>
        /// 发运总指标
        /// </summary>
        public decimal? N_WGT { set; get; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? D_DAY { set; get; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string C_EMPID { set; get; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? D_MOD_DT { set; get; }

        /// <summary>
        /// 各区域总库存
        /// </summary>
        public decimal? N_ZKWGT { set; get; }
        /// <summary>
        /// 各区域监控库存
        /// </summary>
        public decimal? N_JKWGT { set; get; }

        /// <summary>
        /// 各区域超期库存
        /// </summary>
        public decimal? N_CQWGT { set; get; }

        /// <summary>
        /// 各区域待判库存
        /// </summary>
        public decimal? N_DPWGT { set; get; }

        /// <summary>
        /// 各区域库存占比
        /// </summary>
        public decimal? N_KCZB { set; get; }

        /// <summary>
        /// 各区域监控占比
        /// </summary>
        public decimal? N_JKZB { set; get; }

        /// <summary>
        /// 各区域超期占比
        /// </summary>
        public decimal? N_CQZB { set; get; }

        /// <summary>
        /// 发运监控指标
        /// </summary>
        public decimal? N_FYJKZB { set; get; }

        /// <summary>
        /// 发运超期指标
        /// </summary>
        public decimal? N_FYCQZB { set; get; }

        /// <summary>
        /// 汽运发运量
        /// </summary>
        public decimal? N_QYFY { set; get; }

        /// <summary>
        /// 汽运监控发运量
        /// </summary>
        public decimal? N_QYJKFY { set; get; }

        /// <summary>
        /// 火运发运量
        /// </summary>
        public decimal? N_HYFY { set; get; }

        /// <summary>
        /// 火运监控发运量
        /// </summary>
        public decimal? N_HYJKFY { set; get; }

        /// <summary>
        /// 是否控制发运
        /// </summary>
        public string C_FLAG { set; get; }

        /// <summary>
        /// 超期库存发运
        /// </summary>
        public decimal? N_CQFY { set; get; }

    }
}
