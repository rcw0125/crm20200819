using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.MODEL
{
    public class Mod_TMC_TRAIN
    {

        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID { set; get; }

        /// <summary>
        /// 提报人
        /// </summary>
        public string C_EMPNAME { set; get; }
        /// <summary>
        /// 提报时间
        /// </summary>
        public DateTime D_DATE { set; get; }

        /// <summary>
        /// 合同号
        /// </summary>
        public string C_CONNO { set; get; }
        /// <summary>
        /// 计划内，计划外
        /// </summary>
        public string C_FLAG { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        public string C_REMARK { set; get; }
        /// <summary>
        /// 到站
        /// </summary>
        public string C_STATION { set; get; }
        /// <summary>
        /// 到局
        /// </summary>
        public string C_STATION_J { set; get; }
        /// <summary>
        /// 车数
        /// </summary>
        public decimal N_TRAIN_NUM { set; get; }
        /// <summary>
        /// 订货单位
        /// </summary>
        public string C_CUSTNO { set; get; }
        /// <summary>
        /// 收货单位
        /// </summary>
        public string C_CUSTNAME { set; get; }

        /// <summary>
        /// 计划号
        /// </summary>
        public string C_PLANNO { set; get; }
        /// <summary>
        /// 区域
        /// </summary>
        public string C_AREA { set; get; }
        /// <summary>
        /// 线材、钢坯
        /// </summary>
        public string C_TYPE { set; get; }

        public DateTime D_MONTH { set; get; }



    }
}
