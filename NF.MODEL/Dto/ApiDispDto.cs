using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.MODEL
{
    public class ApiDispDto
    {
        /// <summary>
        /// 发运表体主键
        /// </summary>
        public string pkid { get; set; }
        /// <summary>
        /// 发运单据号
        /// </summary>
        public string sendcode { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string matcode { get; set; }

        /// <summary>
        /// 毛重日期
        /// </summary>
        public string   mzdate{ get; set; }
        /// <summary>
        /// 毛重时间
        /// </summary>
        public string mztime { get; set; }
        /// <summary>
        /// 毛重
        /// </summary>
        public string  mwgt { get; set; }
        /// <summary>
        /// 皮重日期
        /// </summary>
        public string pzdate { get; set; }
        /// <summary>
        /// 皮重时间
        /// </summary>
        public string pztime { get; set; }
        /// <summary>
        /// 皮重
        /// </summary>
        public string pwgt { get; set; }
        /// <summary>
        /// 净重
        /// </summary>
        public string jwgt { get; set; }
        

    }
}
