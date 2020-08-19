using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.MODEL.Dto
{
    public class WWInventoryItem
    {
        /// <summary>
        /// 批号
        /// </summary>
        public string BatchNo { get; set; }

        /// <summary>
        /// 钢种
        /// </summary>
        public string Gz { get; set; }

        /// <summary>
        /// 执行标准
        /// </summary>
        public string Zxbz { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string Spec { get; set; }

        /// <summary>
        /// 转库数量
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 转库重量
        /// </summary>
        public decimal Amt { get; set; }

        /// <summary>
        /// 库存仓库编码
        /// </summary>
        public string InventoryCode { get; set; }

        public string BZYQ { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        public string MtrlCode { get; set; }
        /// <summary>
        /// 质量等级
        /// </summary>
        public string ZLDJ { get; set; }

        /// <summary>
        /// 入库状态
        /// </summary>
        public string MoveType { get; set; }
    }
}
