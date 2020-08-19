using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.MODEL
{
    public class Mod_TMC_TRAIN_ITEM
    {

        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID { set; get; }
        /// <summary>
        /// 计划主键
        /// </summary>
        public string C_PKID { set; get; }
        /// <summary>
        /// 提报人
        /// </summary>
        public string C_EMPNAME { set; get; }
        /// <summary>
        /// 提报时间
        /// </summary>
        public DateTime D_DATE { set; get; }
        /// <summary>
        /// 区域
        /// </summary>
        public string C_AREA { set; get; }
        /// <summary>
        /// 合同号
        /// </summary>
        public string C_CONNO { set; get; }
        /// <summary>
        /// 订单单位
        /// </summary>
        public string C_DH_COMPANY { set; get; }
        /// <summary>
        /// 收货单位
        /// </summary>
        public string C_SH_COMPANY { set; get; }
        /// <summary>
        /// 到站
        /// </summary>
        public string C_STATION { set; get; }
        /// <summary>
        /// 车皮数
        /// </summary>
        public decimal N_TRAIN_NUM { set; get; }
        /// <summary>
        /// 客户编码
        /// </summary>
        public string C_CUSTNO { set; get; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string C_CUSTNAME { set; get; }
        /// <summary>
        /// 开户行
        /// </summary>
        public string C_KH_BANK { set; get; }
        /// <summary>
        /// 税号
        /// </summary>
        public string C_TAXNO { set; get; }
        /// <summary>
        /// 地址
        /// </summary>
        public string C_ADDRESS { set; get; }
        /// <summary>
        /// 电话
        /// </summary>
        public string C_TEL { set; get; }
        /// <summary>
        /// 专用线
        /// </summary>
        public string C_LINE { set; get; }
        /// <summary>
        /// 计划号
        /// </summary>
        public string C_PLANNO { set; get; }
        /// <summary>
        /// 规格
        /// </summary>
        public string C_SPEC { set; get; }
        /// <summary>
        /// 钢种
        /// </summary>
        public string C_STL_GRD { set; get; }
        /// <summary>
        /// 重量
        /// </summary>
        public decimal N_WGT { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        public string C_REMARK { set; get; }
        /// <summary>
        /// 0报备计划，1每日发运计划
        /// </summary>
        public string C_FLAG { set; get; }
        /// <summary>
        /// 账号
        /// </summary>
        public string C_ACCOUNT { set; get; }
        /// <summary>
        /// 单据号
        /// </summary>
        public string C_BILLCODE { set; get; }
        public DateTime D_MONTH { set; get; }

    }
}
