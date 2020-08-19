using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    public class TMC_CUST_EVAL_SUBDTO : BASEDTO
    {
        public string C_ID { get; set; }

        /// <summary>
        /// 顾客调查主表
        /// </summary>
        public string C_CUST_EVAL_ID { get; set; }


        /// <summary>
        /// 评价项目
        /// </summary>
        public string C_ITEM_ID { get; set; }

        /// <summary>
        /// 评价项目名称
        /// </summary>
        public string C_ITEM_NAME { get; set; }

        /// <summary>
        /// 邢钢
        /// </summary>
        public int N_XG_SCORE { get; set; }

        /// <summary>
        /// 台湾中钢
        /// </summary>
        public int N_TWZG_SCORE { get; set; }

        /// <summary>
        /// 宝钢
        /// </summary>
        public int N_BG_SCORE { get; set; }

        /// <summary>
        /// 武钢
        /// </summary>
        public int N_WG_SCORE { get; set; }

        /// <summary>
        /// 兴澄特钢
        /// </summary>
        public int N_XCTG_SCORE { get; set; }

        /// <summary>
        /// 沙钢
        /// </summary>
        public int N_SG_SCORE { get; set; }

        /// <summary>
        /// 永钢
        /// </summary>
        public int N_YG_SCORE { get; set; }

        /// <summary>
        /// 湘钢
        /// </summary>
        public int N_XIANGG_SCORE { get; set; }

        /// <summary>
        /// 中天
        /// </summary>
        public int N_ZT_SCORE { get; set; }

        /// <summary>
        /// 自由项1
        /// </summary>
        public int N_ITEM1 { get; set; }

        /// <summary>
        /// 自由项2
        /// </summary>
        public int N_ITEM2 { get; set; }

        /// <summary>
        /// 自由项3
        /// </summary>
        public int N_ITEM3 { get; set; }

        /// <summary>
        /// 自由项4
        /// </summary>
        public int N_ITEM4 { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public string Desc { get; set; }

    }
}
