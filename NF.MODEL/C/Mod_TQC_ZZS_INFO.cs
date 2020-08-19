using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.MODEL
{
    public class Mod_TQC_ZZS_INFO
    {
        /// <summary>
        /// 发运单号
        /// </summary>
        public string C_FYDH { set; get; }
        /// <summary>
        /// 批号
        /// </summary>
        public string C_BATCH_NO { set; get; }
        /// <summary>
        /// 炉号
        /// </summary>
        public string C_STOVE { set; get; }
        /// <summary>
        /// 规格
        /// </summary>
        public string C_SPEC { set; get; }
        /// <summary>
        /// 钢种
        /// </summary>
        public string C_STL_GRD { set; get; }
        /// <summary>
        /// 执行标准
        /// </summary>
        public string C_STD_CODE { set; get; }
        /// <summary>
        /// 出库时间
        /// </summary>
        public DateTime D_CKSJ { set; get; }
        /// <summary>
        /// 重量
        /// </summary>
        public decimal N_JZ { set; get; }
        /// <summary>
        /// 件数
        /// </summary>
        public decimal N_NUM { set; get; }
        /// <summary>
        /// 车号
        /// </summary>
        public string C_CH { set; get; }
        /// <summary>
        /// PDF名称
        /// </summary>
        public string C_PDF_NAME { set; get; }
        /// <summary>
        /// PDF路径
        /// </summary>
        public string C_PDF_PATCH { set; get; }
        /// <summary>
        /// 打印次数
        /// </summary>
        public decimal N_PRINT_NUM { set; get; }
        /// <summary>
        /// 证书号
        /// </summary>
        public string C_ZSH { set; get; }
        /// <summary>
        /// 签证人
        /// </summary>
        public string C_QZR { set; get; }
        /// <summary>
        /// 签证时间
        /// </summary>
        public string D_QZRQ { set; get; }
        /// <summary>
        /// 使用状态   1-可用；0-停用
        /// </summary>
        public string N_STATUS { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        public string C_REMARK { set; get; }
        /// <summary>
        /// 二维码
        /// </summary>
        public string C_IMG { set; get; }
        /// <summary>
        /// 客户编码
        /// </summary>
        public string C_CUST_NO { set; get; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string C_CUST_NAME { set; get; }
        /// <summary>
        /// 合同号
        /// </summary>
        public string C_CON_NO { set; get; }
        /// <summary>
        /// 收货单位名称
        /// </summary>
        public string C_SH_NAME { set; get; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string C_MAT_NAME { set; get; }
        /// <summary>
        /// 交货标准
        /// </summary>
        public string C_STD_JH { set; get; }
        /// <summary>
        /// 质量等级
        /// </summary>
        public string C_ZLDJ { set; get; }
        /// <summary>
        /// 交货状态
        /// </summary>
        public string C_JH_STATE { set; get; }
        /// <summary>
        /// 技术协议号
        /// </summary>
        public string C_JSXYH { set; get; }
        /// <summary>
        /// 许可证号
        /// </summary>
        public string C_XKZH { set; get; }

        /// <summary>
        /// 8线材，6钢坯
        /// </summary>
        public string C_BY1 { set; get; }
    }
}
