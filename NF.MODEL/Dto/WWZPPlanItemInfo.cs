using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.MODEL
{
    /// <summary>
    /// 组批信息
    /// </summary>
    public class WWZPPlanItemInfo
    {
        /// <summary>
        /// 组批支数
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 组批重量
        /// </summary>
        public decimal ZpAmt { get; set; }

        /// <summary>
        /// 班次
        /// </summary>
        public string BC { get; set; }
        /// <summary>
        /// 班组
        /// </summary>
        public string BZ { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 库存线材批次号
        /// </summary>
        public string CBatchNo { get; set; }

        /// <summary>
        /// 合同ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 组批的批号
        /// </summary>
        public string BachNo { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        public string MtrlCode { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        public string InventoryCode { get; set; }

        /// <summary>
        /// 质量等级
        /// </summary>
        public string ZLDJ { get; set; }

        /// <summary>
        /// 包装要求
        /// </summary>
        public string BZYQ { get; set; }

    }

    public class NCInventoryDto
    {
        /// <summary>
        /// 根据自由项1，2获取执行标准
        /// </summary>
        /// <param name="zyx1"></param>
        /// <param name="zyx2"></param>
        /// <returns></returns>
        public static string GetZXBZ(string zyx1, string zyx2)
        {
            string bz = (zyx1.Split('~')[1].Contains("协议") ?
                    zyx2.Split('~')[1] : zyx1.Split('~')[1]).Replace(" ", "").Replace('（', '(').Replace('）', ')');//执行标准//
            return bz;
        }


        /// <summary>
        /// 批号
        /// </summary>
        public string BatchNo { get; set; }

        /// <summary>
        /// 钢种
        /// </summary>
        public string StlGrd { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string Spec { get; set; }

        /// <summary>
        /// 执行标准
        /// </summary>
        public string StdCode
        {
            get
            {
                return GetZXBZ(zyx1, zyx2);
            }
        }

        /// <summary>
        /// NC总支数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// NC总重量
        /// </summary>
        public decimal Wgt { get; set; }

        /// <summary>
        /// PCI总支数
        /// </summary>
        public int PciCount { get; set; }

        /// <summary>
        /// PCI总重量
        /// </summary>
        public decimal PciSum { get; set; }

        /// <summary>
        /// 四舍五入重量
        /// </summary>
        public decimal PciWgt
        {
            get { return Math.Round(PciSum, 4); }
        }

        /// <summary>
        /// 物料编码
        /// </summary>
        public string MtrlCode { get; set; }

        /// <summary>
        /// 物料描述
        /// </summary>
        public string MtrlName { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        public string InventoryCode { get; set; }

        /// <summary>
        /// 包装要求
        /// </summary>
        public string BZYQ { get; set; }

        /// <summary>
        /// 质量等级
        /// </summary>
        public string ZLDJ { get; set; }

        public string zyx1 { get; set; }
        public string zyx2 { get; set; }

        /// <summary>
        /// 炉号
        /// </summary>
        public string LuHao { get; set; }

        /// <summary>
        /// 销售区域
        /// </summary>
        public string SaleArea { get; set; }
    }

    public class ZKDInfoDto : Mod_TRC_ROLL_ZKD
    {
        public string UserName { get; set; }
    }

    public class WWPlanInfo : Mod_TRC_ROLL_WW_MAIN
    {
        /// <summary>
        /// NCA1单据，大于0代表NC存在单据
        /// </summary>
        public int A1Count { get; set; }
        public int A2Count { get; set; }
        public int A3Count { get; set; }
        public int A4Count { get; set; }
        public int A46Count { get; set; }

        /// <summary>
        /// 制单人
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 完工操作人
        /// </summary>
        public string ProductUser { get; set; }

        public bool IsNcCancel
        {
            get { return A1Count == 0 && A2Count == 0 && A3Count == 0 && A4Count == 0 && A46Count == 0; }
        }
    }

    public class PCIInventoryItem : Mod_TRC_ROLL_PRODCUT
    {
        public int NCCount { get; set; }

        public decimal NCWgt { get; set; }
    }
}
