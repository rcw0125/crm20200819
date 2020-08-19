using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.MODEL
{
    public class Mod_TMC_TRAIN_MAIN
    {

        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID { set; get; }
        /// <summary>
        /// /提报人主键
        /// </summary>
        public String C_EMPID { set; get; }

        /// <summary>
        /// 提报人
        /// </summary>
        public string C_EMPNAME { set; get; }
        /// <summary>
        /// 计划号
        /// </summary>
        public string C_PLANNO { set; get; }
        /// <summary>
        /// 到站
        /// </summary>
        public string C_STATION { set; get; }
        /// <summary>
        /// 专用线
        /// </summary>
        public string C_LINE { set; get; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime D_EDIT_DT { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        public string C_REMARK { set; get; }
        public string C_SHIPVIA { set; get; }
        /// <summary>
        /// Y审核通过/N未审核(泰翔)
        /// </summary>
        public string C_ISCHECK { set; get; }
        /// <summary>
        /// 车数
        /// </summary>
        public decimal N_TRAIN_NUM { set; get; }
        public DateTime D_DT { set; get; }
        public DateTime D_CHECKTIME { set; get; }
        public string C_CHECKEMP { set; get; }
    }
}
