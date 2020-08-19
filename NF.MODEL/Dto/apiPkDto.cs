using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.MODEL
{
    /// <summary>
    /// 发运单明细NC表体主键
    /// </summary>
    public class apiPkDto
    {
        /// <summary>
        /// 计划单据号
        /// </summary>
        public string plancode { get; set; }
        /// <summary>
        /// 发运单号
        /// </summary>
        public string sendcode { get; set; }
        /// <summary>
        /// 炉号
        /// </summary>
        public string stove_no { get; set; }
        /// <summary>
        /// 批号
        /// </summary>
        public string batch_no { get; set; }
        /// <summary>
        /// 仓库
        /// </summary>
        public string stock { get; set; }

        /// <summary>
        /// 发运单明细表体NC主键
        /// </summary>
        public string pk_ncid { get; set; }
    }
}
