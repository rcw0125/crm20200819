using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.MODEL
{
    public class ApiOrderDto
    {
        public ApiOrderDto()
        { }
        /// <summary>
        /// 销售订单主键ID
        /// </summary>
        public string NC_ID { get; set; }

        /// <summary>
        /// 销售单据号
        /// </summary>
        public string SaleCode { get; set; }

        /// <summary>
        /// 合同号
        /// </summary>
        public string ConNO { get; set; }

        /// <summary>
        /// 单据日期
        /// </summary>
        public string D_NC_DATE { get; set; }
    }
}
